using Kuka_Model;
using Kuka_ZZBLL.UserBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kuka_ZZWebApi.Controllers
{
    public class UserController : ApiController
    {

        public UserBLL bll = new UserBLL();

        [HttpGet]
        public KukaPage<user> Get(int page, int limit, string name, string sex)
        {
          return  bll.Get(page, limit, name, sex);
        }

        [HttpGet]
        public user GetById(int ID)
        {
            return bll.Get(ID);
        }

        [HttpGet]
        public int Delete(string deleteID)
        {
            return bll.Delete(deleteID);
        }

        [HttpPost]
        public int Add([FromBody]user u)
        {
            return bll.Add(u);
        }

        [HttpPost]
        public int Updata([FromBody]user u)
        {
            return bll.Updata(u);
        }
        
        [HttpPost]
        public user Login([FromBody]user u)
        {
            return bll.Login(u);
        }

        [HttpGet]
        public object GetRoleTree(int id)
        {
            return bll.GetRoleTree(id);
        }

        [HttpGet]
        public int AddUserRole(int userID, string idList)
        {
            return bll.AddUserRole(userID, idList);
        }
    }
}
