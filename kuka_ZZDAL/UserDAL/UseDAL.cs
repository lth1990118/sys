using Dapper;
using Kuka_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuka_ZZDAL.UserDAL
{
    public class UserDAL
    {
        private  string sqlstr = SQLStr.SqlStrCon;

        /// <summary>
        /// 获取人员列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public KukaPage<user> Get(int page, int limit, string name, string sex)
        {
            using (IDbConnection conn = new SqlConnection(sqlstr))
            {
                conn.Open();
                KukaPage<user> reModel = new KukaPage<user>();

                string query = "SELECT * FROM [user] b ";
                var b = conn.Query<user>(query);
                var reList = b.ToList();

                if (!string.IsNullOrEmpty(name))
                {
                    reList = reList.Where(a => a.name.Contains(name)).ToList();
                }
                if (!string.IsNullOrEmpty(sex))
                {
                    reList = reList.Where(a => a.sex.Contains(sex)).ToList();
                }
                reModel.count = reList.Count();
                reModel.code = "0";
                reModel.msg = "";
                reModel.data = reList.Skip((page - 1) * limit).Take(limit).ToList();
                return reModel;
            }

        }

        /// <summary>
        /// 通过ID获取人员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  user Get(int id)
        {
            using (IDbConnection conn = new SqlConnection(sqlstr))
            {
                conn.Open();
                string query = "SELECT * FROM [user] b  where b.ID=@ID";
                var b = conn.Query<user>(query,
                  new { ID = id }
                    );
                return b.FirstOrDefault();
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public  user Login(user u)
        {
            using (IDbConnection conn = new SqlConnection(sqlstr))
            {
                conn.Open();
                string query = "SELECT * FROM [user] b  where b.name=@name and b.password=@password";
                var b = conn.Query<user>(query,
                 u
                    );
                return b.FirstOrDefault();
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  int Delete(string id)
        {
            using (IDbConnection conn = new SqlConnection(sqlstr))
            {
                string[] arr = id.Split(',');
                conn.Open();
                string query = "delete FROM [user]  where ID in @ID";
                var b = conn.Execute(query,
                  new { ID = arr }
                    );
                return b;
            }
        }

       /// <summary>
       /// 添加
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
        public  int Add(user u)
        {
            using (IDbConnection conn = new SqlConnection(sqlstr))
            {
                conn.Open();
                string query = "insert into [user](name,age,address,phone,sex,city,createuser,createtime) values (@name,@age,@address,@phone,@sex,@city,@createuser,@createtime)";
                var b = conn.Execute(query, u);
                return b;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public  int Updata(user u)
        {
            using (IDbConnection conn = new SqlConnection(sqlstr))
            {
                conn.Open();
                string query = "update [user] set name=@name,age=@age,address=@address,phone=@phone,sex=@sex,city=@city,createuser=@createuser,createtime=@createtime  where ID=@id";
                var b = conn.Execute(query, u);
                return b;
            }
        }

       /// <summary>
       /// 添加人员角色
       /// </summary>
       /// <param name="userID"></param>
       /// <param name="idList"></param>
       /// <returns></returns>
        public  int AddUserRole(int userID, string idList)
        {
            using (IDbConnection conn = new SqlConnection(sqlstr))
            {
                string deleteSql = "delete from userrole where userid=@ID";
                var de = conn.Execute(deleteSql, new { ID = userID });

                var idArr = idList.Split(',');
                List<userrole> arr = new List<userrole>();
                foreach (var item in idArr)
                {
                    arr.Add(new userrole
                    {
                        userid = userID,
                        roleid = int.Parse(item)
                    });
                }
                string addSql = "insert into userrole(userid,roleid) values(@userid,@roleid)";
                var ad = conn.Execute(addSql, arr);
                return ad;

            }
        }
        /// <summary>
        /// 获取角色树
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetRoleTree(int id)
        {
            using (IDbConnection conn = new SqlConnection(sqlstr))
            {
                string sql = @"SELECT m.name title,m.id as value,(case when mr.id is null then 'false' else  'true' end) as checked,m.id id from role m
LEFT JOIN
  userrole mr --and mr.id = 1
on m.id = mr.roleid  and mr.userid = @ID";
                var obj = conn.Query<MenuTree>(sql, new { ID = id });

                return obj;
            }
        }
    }
}
