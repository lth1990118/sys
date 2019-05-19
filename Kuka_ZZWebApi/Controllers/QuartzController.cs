using Kuka_Model;
using Kuka_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kuka_ZZBLL.QuartzBLL;

namespace Kuka_ZZWebApi.Controllers
{
    public class QuartzController : ApiController
    {
        QuartzBLL _bll = new QuartzBLL();

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public KukaPage<task_proc> GetAllTask(int page, int limit, string name)
        {
            return _bll.GetAllTask(page, limit, name);
        }


        /// <summary>
        /// 获取任务详情
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public task_proc GetTaskByID(int ID)
        {
            return _bll.GetTaskByID(ID);
        }


        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int Add([FromBody]task_proc t)
        {
            return _bll.Add(t);
        }


        /// <summary>
        /// 修改任务
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update([FromBody]task_proc t)
        {
            return _bll.Update(t);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        [HttpGet]
        public int Delete(string idList)
        {
            return _bll.Delete(idList);
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="state"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public  int EditTaskSt(int state, int id)
        {
            return _bll.EditTaskSt(state,id);
        }


        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="state"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public KukaPage<task_log> GetLog(int page, int limit, string name)
        {
            return _bll.GetLog(page, limit, name);
        }

    }
}
