using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuka_Model;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Kuka_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuka_ZZDAL.FactoryDAL
{
    public class FactoryDAL
    {
        public List<Factory> GetFactory()
        {
            string strSql = @"SELECT ID, Name FROM KUKA_Factory ";
            using (IDbConnection conn = new SqlConnection(SQLStr.sqlStrProductionConn))
            {
                conn.Open();
                var query = conn.Query<Factory>(strSql);
                return query.ToList();
            }
        }
    }
}
