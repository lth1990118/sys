using Dapper;
using Kuka_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuka_ZZDAL.QuartzDAL
{
   public class QuartzDAL
    {
        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public KukaPage<task_proc> GetAllTask(int page, int limit, string name)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                KukaPage<task_proc> returnPage = new KukaPage<task_proc>();
                StringBuilder sql = new StringBuilder();
                sql.Append("select * from task_proc t where 1=1");
                if (!string.IsNullOrEmpty(name))
                {
                    sql.Append(" and t.taskname like @name");
                }

                sql.Append(" order by t.id desc OFFSET @skip ROWS FETCH NEXT @page ROWS ONLY");
                var model = conn.Query<task_proc>(sql.ToString(), new
                {
                    skip = (page - 1) * limit,
                    page = limit,
                    name = '%' + name + '%'
                });

                StringBuilder sqlCount = new StringBuilder();
                sqlCount.Append("select count(*) from task_proc t where 1=1");
                if (!string.IsNullOrEmpty(name))
                {
                    sql.Append(" and t.taskname like @name");
                }
                int count = conn.Query<int>(sqlCount.ToString(), new
                {
                    name = '%' + name + '%'
                }).FirstOrDefault();
                returnPage.code = "";
                returnPage.msg = "";
                returnPage.count = count;
                returnPage.data = model.ToList();
                return returnPage;

            }



        }

        /// <summary>
        /// 通过ID获取任务详情
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public task_proc GetTaskByID(int ID)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("select * from task_proc where id=@ID");
                var model = conn.Query<task_proc>(sql.ToString(), new
                {
                    ID = ID
                }).FirstOrDefault();
                return model;
            }
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(task_proc t)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("insert into task_proc(procname,parm,state,cronstr,typeid,dllname,classname,taskname,remake) values (@procname,@parm,@state,@cronstr,@typeid,@dllname,@classname,@taskname,@remake)");
                var model = conn.Query<int>(sql.ToString(), t
               ).FirstOrDefault();
                return model;
            }
        }

        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(task_proc t)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("update task_proc set procname=@procname,parm=@parm,state=3,cronstr=@cronstr,typeid=@typeid,dllname=@dllname,classname=@classname,taskname=@taskname,remake=@remake where id=@ID");
                var model = conn.Query<int>(sql.ToString(), t
               ).FirstOrDefault();
                return model;
            }
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int Delete(string idList)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                StringBuilder sql = new StringBuilder();
                string[] idArr = idList.Split(',');
                sql.Append("update task_proc set state=0 where id in @ID");
                var model = conn.Query<int>(sql.ToString(), new
                {
                    ID = idArr
                }
               ).FirstOrDefault();
                return model;
            }
        }


        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="state"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EditTaskSt(int state, int id)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                conn.Open();
                string sql = "update task_proc set state=@state where id=@ID";
                var rowcouny = conn.Execute(sql, new
                {
                    state = state,
                    ID = id
                });
                return rowcouny;
            }
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
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                KukaPage<task_log> returnPage = new KukaPage<task_log>();
                StringBuilder sql = new StringBuilder();
                sql.Append("select * from task_log t where 1=1");
                if (!string.IsNullOrEmpty(name))
                {
                    sql.Append(" and t.taskname like @name");
                }

                sql.Append(" order by t.id desc OFFSET @skip ROWS FETCH NEXT @page ROWS ONLY");
                var model = conn.Query<task_log>(sql.ToString(), new
                {
                    skip = (page - 1) * limit,
                    page = limit,
                    name = '%' + name + '%'
                });

                StringBuilder sqlCount = new StringBuilder();
                sqlCount.Append("select count(*) from task_log t where 1=1");
                if (!string.IsNullOrEmpty(name))
                {
                    sql.Append(" and t.taskname like @name");
                }
                int count = conn.Query<int>(sqlCount.ToString(), new
                {
                    name = '%' + name + '%'
                }).FirstOrDefault();
                returnPage.code = "";
                returnPage.msg = "";
                returnPage.count = count;
                returnPage.data = model.ToList();
                return returnPage;
            }
        }
    }
}
