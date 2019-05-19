using Kuka_Model;
using kuka_ZZDAL.QuartzDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuka_ZZBLL.QuartzBLL
{
   public class QuartzBLL
    {
        public QuartzDAL dal = new QuartzDAL();
        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public KukaPage<task_proc> GetAllTask(int page, int limit, string name)
        {
            return dal.GetAllTask(page, limit, name);
        }

        /// <summary>
        /// 通过ID获取任务详情
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public task_proc GetTaskByID(int ID)
        {
            return dal.GetTaskByID(ID);
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(task_proc t)
        {
            return dal.Add(t);
        }

        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(task_proc t)
        {
            return dal.Update(t);
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int Delete(string idList)
        {
            return dal.Delete(idList);
        }


        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="state"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EditTaskSt(int state, int id)
        {
            return dal.EditTaskSt(state,id);
        }

        /// <summary>
        /// 获取任务运行日志
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public KukaPage<task_log> GetLog(int page, int limit, string name)
        {
            return dal.GetLog(page, limit, name);
        }

    }
}
