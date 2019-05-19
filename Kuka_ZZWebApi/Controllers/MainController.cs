using Kuka_Model;
using Kuka_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kuka_ZZBLL.MainBLL;

namespace Kuka_ZZWebApi.Controllers
{
    public class MainController : ApiController
    {
        MainBLL _bll = new MainBLL();


        /// <summary>
        /// 通过人员ID获取菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Menu> GetMenuByUserID(int id)
        {         
            return _bll.GetBYId(id);
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public KukaPage<Role> GetRoleList(int page,int limit,string name)
        {
            return _bll.GetRoleList(page, limit, name);
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public Role GetRoleByID(int ID)
        {
            return _bll.GetRoleByID(ID);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public int DeleteByID(string ID)
        {
            return _bll.DeleteByID(ID);
        }



        /// <summary>
        /// 获取菜单树结构
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetMenuTree(int ID)
        {
            return _bll.GetMenuTree(ID);
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="idList"></param>
        /// <returns></returns>
        [HttpGet]
        public int AddMenuRole(int roleID, string idList)
        {
            return _bll.AddMenuRole(roleID, idList);
        }
    }
}
