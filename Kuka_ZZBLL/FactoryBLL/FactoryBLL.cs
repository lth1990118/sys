using Kuka_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuka_ZZDAL.FactoryDAL;

namespace Kuka_ZZBLL.FactoryBLL
{        
    public class FactoryBLL
    {
        public FactoryDAL dal = new FactoryDAL();
        
        public List<Factory> GetFactory()
        {
            return dal.GetFactory();
        }
    }
}
