using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Kuka_Model;
using KuKa_Quartz.Helper;

namespace KuKa_Quartz.Job
{
    public class MainJob : IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            //添加作业
            List<task_proc> taskList = new List<task_proc>();
            taskList = DapperHelper.GetAllTask();

            //新增的作业
            var addList = taskList.Where(a => a.state == (int)taskstate.add).ToList();
            foreach (var item in addList)
            {             
                QuartzManage.AddJob(item);
            }

            //修改的作业
            var editList = taskList.Where(a => a.state == (int)taskstate.edit).ToList();
            foreach (var item in editList)
            {
                QuartzManage.AddJob(item);
            }



            //停用的作业
            var deleteList = taskList.Where(a => a.state == (int)taskstate.delete).ToList();
            foreach (var item in deleteList)
            {
                QuartzManage.DeleteJob(item);
            }

           // LogHelper.AddLog("触发主作业");
        }
    }
}
