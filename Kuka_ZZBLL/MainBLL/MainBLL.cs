using Kuka_Model;
using kuka_ZZDAL.MainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuka_ZZBLL.MainBLL
{
  public class MainBLL
    {
        public MainDAL dal = new MainDAL();



        /// <summary>
        /// 通过人员获取菜单树
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<Menu> GetBYId(int ID)
        {
            return dal.GetBYId(ID);
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

            return dal.GetRoleList(page, limit, name);
        }

        /// <summary>
        /// 通过ID获取角色
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Role GetRoleByID(int ID)
        {
            return dal.GetRoleByID(ID);
        }


        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleteByID(string ID)
        {
            return dal.DeleteByID(ID);
        }


        /// <summary>
        /// 获取角色树
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public object GetMenuTree(int ID)
        {
            return dal.GetMenuTree(ID);
        }

        /// <summary>
        /// 添加角色菜单
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int AddMenuRole(int roleID, string idList)
        {
            return dal.AddMenuRole(roleID, idList);
        }
    }
}
