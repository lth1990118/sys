using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Kuka_Model;

namespace KuKa_Quartz.Helper
{
    public class DapperHelper
    {

        /// <summary>
        /// 获取所有任务
        /// </summary>
        /// <returns></returns>
        public static List<task_proc> GetAllTask()
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                conn.Open();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from task_proc");
                var list = conn.Query<task_proc>(strSql.ToString());
                return list.ToList();
            }
        }

        /// <summary>
        /// 执行存储过程返回受影响行数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public static int ExecuteProc(string name, DynamicParameters parm = null)
        {

            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                try
                {
                    conn.Open();
                    var rowcouny = conn.Execute(name, parm, commandType: CommandType.StoredProcedure);
                    return rowcouny;

                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }


        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="state"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int EditTaskSt(int state,int id)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                conn.Open();
                string sql = "update task_proc set state=@state where id=@ID";
                var rowcouny = conn.Execute(sql,new {
                    state= state,
                    ID=id
                });
                return rowcouny;
            }
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="state"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int AddLog(task_log l)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                conn.Open();
                string sql = "insert into task_log(taskid, taskname, stat, msg, excutetime) values(@taskid,@taskname,@stat,@msg,@excutetime)";
                var rowcouny = conn.Execute(sql, l
                );
                return rowcouny;
            }
        }

    }
}
