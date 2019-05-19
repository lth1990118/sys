using Kuka_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace kuka_ZZDAL.MainDAL
{
   public class MainDAL
    {
        private static string sqlstr = SQLStr.SqlStrCon;

        /// <summary>
        /// 通过人员获取菜单树
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public  List<Menu> GetBYId(int ID)
        {
            string SQL = "SELECT DISTINCT * from (select mp.* from userrole u INNER  JOIN menurole r on u.roleid = r.roleid and u.userid = @ID INNER   JOIN menu mp on r.menuid = mp.id and mp.parentid = 0) a LEFT JOIN(select mp.* from userrole u INNER  JOIN menurole r on u.roleid = r.roleid and u.userid = @ID    INNER   JOIN menu mp on r.menuid = mp.id and mp.parentid <> 0) b on a.id = b.parentid";

            using (IDbConnection conn = new SqlConnection(sqlstr))
            {
                conn.Open();
                var lookUp = new Dictionary<int, Menu>();
                var b = conn.Query<Menu, Menu, Menu>(SQL, (menu, menuc) =>
                {
                    Menu m;


                    if (!lookUp.TryGetValue(menu.id, out m))
                    {
                        lookUp.Add(menu.id, m = menu);
                    }
                    if (menuc != null && menuc.parentid == m.id)
                    {
                        m.Childs.Add(menuc);
                    }
                    return m;
                },
                new { ID = ID }
                );
                return lookUp.Values.ToList();
            }
        }


        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public KukaPage<Role> GetRoleList(int page, int limit, string name)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                KukaPage<Role> returnList = new KukaPage<Role>();
                returnList.code = "0";
                returnList.msg = "";
                conn.Open();
                StringBuilder query = new StringBuilder();
                query.Append("SELECT * FROM [role] b where 1=1 ");
                StringBuilder queryC = new StringBuilder();
                queryC.Append("select count(*) from [role] b where 1=1 ");
                if (!string.IsNullOrEmpty(name))
                {
                    query.Append("and b.name like @name");
                    queryC.Append("and b.name like @name");
                }
                query.Append(" order by b.id OFFSET @skip ROWS FETCH NEXT @page ROWS ONLY");

                var b = conn.Query<Role>(query.ToString(), new
                {
                    skip = (page - 1) * limit,
                    page = limit,
                    name = '%' + name + '%'
                });
                returnList.data = b.ToList();
                var count = conn.Query<int>(queryC.ToString(), new
                {
                    name = '%' + name + '%'
                });
                returnList.count = count.FirstOrDefault();
                return returnList;
            }
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Role GetRoleByID(int ID)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                string sql = "select * from [role] where id=@ID";
                var model = conn.Query<Role>(sql,
                    new { ID = ID });
                return model.FirstOrDefault();
            }
        }


       /// <summary>
       /// 删除角色
       /// </summary>
       /// <param name="ID"></param>
       /// <returns></returns>
        public int DeleteByID(string ID)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                string[] arr = ID.Split(',');
                string sql = "delete  from [role] where id IN @ID";
                var model = conn.Execute(sql,
                    new { ID = arr });
                return model;
            }
        }

        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public object GetMenuTree(int ID)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                var lookUp = new Dictionary<int, MenuTree>();
                string sql = @"SELECT a.*,b.* from ( 
SELECT m.name title,m.id as value,(case when mr.id is null then 'false' else  'true' end) as checked,m.parentid,m.id id from menu m
LEFT JOIN
  menurole mr --and mr.id=1
on   m.id=mr.menuid  and mr.roleid=@ID
where  m.parentid=0) a
LEFT JOIN (
SELECT m.name title,m.id as value,(case when mr.id is null then 'false' else  'true' end) as checked,m.parentid from menu m
LEFT JOIN
  menurole mr --and mr.id=1
on   m.id=mr.menuid  and mr.roleid=@ID
where  m.parentid<>0) b on b.parentid=a.id
";
                var model = conn.Query<MenuTree, MenuTree, MenuTree>(sql, (menu, menuc) => {
                    MenuTree m;


                    if (!lookUp.TryGetValue(menu.value, out m))
                    {
                        lookUp.Add(menu.value, m = menu);
                    }
                    if (menuc != null && menuc.parentid == m.value)
                    {
                        m.data.Add(menuc);
                    }
                    return m;
                }, new { ID = ID });
                return lookUp.Values.ToList();
            }
        }


        /// <summary>
        /// 添加角色菜单
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int AddMenuRole(int roleID, string idList)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.SqlStrCon))
            {
                string deleteSql = "delete from menurole where roleid=@ID";
                var de = conn.Execute(deleteSql, new { ID = roleID });

                var idArr = idList.Split(',');
                List<menurole> arr = new List<menurole>();
                foreach (var item in idArr)
                {
                    arr.Add(new menurole
                    {
                        roleid = roleID,
                        menuid = int.Parse(item)
                    });
                }
                string addSql = "insert into menurole(roleid,menuid) values(@roleid,@menuid)";
                var ad = conn.Execute(addSql, arr);
                return ad;

            }
        }


    }
}
