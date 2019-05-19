using KuKa_Quartz.Job;
using Kuka_Model;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KuKa_Quartz.Helper
{
  public  class QuartzManage
    {
        private static IScheduler scheduler = null;

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            if (scheduler == null)
            {
                ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
                scheduler = schedulerFactory.GetScheduler();
                IJobDetail job = JobBuilder.Create<MainJob>().WithIdentity("job1", "group1").Build();
                ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .WithCronSchedule("0/5 * * * * ?")
            .Build();
                scheduler.ScheduleJob(job, trigger);
                scheduler.Start();
            }
        }

        /// <summary>
        /// 添加作业
        /// </summary>
        public static void AddJob(task_proc task)
        {

            if (task.typeid == 2)
            {
                AddDllJob(task);
                return;
            }
            DeleteJob(task);//判断是否存在，存在删除(伪更新)
            try {
                IJobDetail job = new JobDetailImpl(task.id.ToString(), typeof(ProcJob));
                //添加任务执行参数
                job.JobDataMap.Add("TaskParam", task.procname);
                job.JobDataMap.Add("taskid", task.id);
                job.JobDataMap.Add("taskname", task.taskname);
                CronTriggerImpl trigger = new CronTriggerImpl();
                trigger.CronExpressionString = task.cronstr;
                trigger.Name = task.id.ToString();
                trigger.Description = task.procname;
                scheduler.ScheduleJob(job, trigger);
                DapperHelper.EditTaskSt(4, task.id);
            }
            catch(Exception ex)
            {
                DapperHelper.EditTaskSt(0, task.id);
                LogHelper.AddLog("任务:" + task.taskname + " 异常,异常原因:" + ex.Message);
            }
        }


        /// <summary>
        /// 添加插件作业
        /// </summary>
        public static void AddDllJob(task_proc task)
        {

            DeleteJob(task);//判断是否存在，存在删除(伪更新)
            try {
                IJobDetail job = new JobDetailImpl(task.id.ToString(), GetClassInfo(task.dllname, task.classname));
                //添加任务执行参数
                job.JobDataMap.Add("taskid", task.id);
                job.JobDataMap.Add("taskname", task.taskname);
                CronTriggerImpl trigger = new CronTriggerImpl();
                trigger.CronExpressionString = task.cronstr;
                trigger.Name = task.id.ToString();
                trigger.Description = task.procname;
                scheduler.ScheduleJob(job, trigger);
                DapperHelper.EditTaskSt(4, task.id);
            }
            catch (Exception ex)
            {
                LogHelper.AddLog("任务:" + task.taskname + " 异常,异常原因:" + ex.Message);
                DapperHelper.EditTaskSt(0, task.id);
            }
        }

        /// <summary>
        /// 删除作业
        /// </summary>
        /// <param name="task"></param>
        public static void DeleteJob(task_proc task)
        {
            try
            {
                JobKey jk = new JobKey(task.id.ToString());
                if (scheduler.CheckExists(jk))
                {
                    //任务已经存在则删除
                    scheduler.DeleteJob(jk);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 停止任务调度
        /// </summary>
        public static void StopSchedule()
        {
            try
            {
                //判断调度是否已经关闭
                if (!scheduler.IsShutdown)
                {
                    //等待任务运行完成
                    scheduler.Shutdown(true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// 获取类的属性、方法  
        /// </summary>  
        /// <param name="assemblyName">程序集</param>  
        /// <param name="className">类名</param>  
        private static Type GetClassInfo(string assemblyName, string className)
        {
            try
            {
                assemblyName = GetAbsolutePath(assemblyName + ".dll");
                Assembly assembly = null;
                assembly = Assembly.LoadFrom(assemblyName);
                Type type = assembly.GetType(className, true, true);
                return type;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取文件的绝对路径
        /// </summary>
        /// <param name="relativePath">相对路径地址</param>
        /// <returns>绝对路径地址</returns>
        public static string GetAbsolutePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                throw new ArgumentNullException("参数relativePath空异常！");
            }
            relativePath = relativePath.Replace("/", "\\");
            if (relativePath[0] == '\\')
            {
                relativePath = relativePath.Remove(0, 1);
            }
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

        }


    }
}
