using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuka_ZZDAL.UserDAL;
using Kuka_Model;

namespace Kuka_ZZBLL.UserBLL
{
   public class UserBLL
    {

        public UserDAL dal = new UserDAL();
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
            return dal.Get(page, limit, name, sex);
        }

        /// <summary>
        /// 通过ID获取人员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public user Get(int id)
        {
            return dal.Get(id);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public user Login(user u)
        {
            return dal.Login(u);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int Add(user u)
        {
            return dal.Add(u);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int Updata(user u)
        {
            return dal.Updata(u);
        }

        /// <summary>
        /// 添加人员角色
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int AddUserRole(int userID, string idList)
        {
            return dal.AddUserRole(userID, idList);
        }


        /// <summary>
        /// 获取角色树
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetRoleTree(int id)
        {
            return dal.GetRoleTree(id);
        }
    }
}
