using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using KuKa_Quartz.Helper;
using Kuka_Model;

namespace KuKa_Quartz.Job
{
   public class ProcJob:IJob
    {
      

        public void Execute(IJobExecutionContext context)
        {
           var procname=  context.JobDetail.JobDataMap.Get("TaskParam");
            var taskid = context.JobDetail.JobDataMap.Get("taskid");
            var taskname = context.JobDetail.JobDataMap.Get("taskname");
            DateTime excutytime = DateTime.Now;
            try {

                DapperHelper.ExecuteProc(procname.ToString(), null);
                task_log log = new task_log();
                log.msg = "成功";
                log.stat = 1;
                log.taskid = (int)taskid;
                log.taskname = taskname.ToString();
                log.excutetime = excutytime;
                DapperHelper.AddLog(log);

            }
            catch(Exception ex)
            {
                task_log log = new task_log();
                log.msg = ex.Message;
                log.stat = 0;
                log.taskid = (int)taskid;
                log.taskname = taskname.ToString();
                log.excutetime = excutytime;
                DapperHelper.AddLog(log);
            }
            //LogHelper.AddLog("触发存储过程作业，函数名:"+ procname);
        }
    }
}
