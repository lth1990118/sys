using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kuka_ZZDAL
{
    public class SQLStr
    {
        public static string SqlStrCon= "Server=118.24.89.204;Database=fk_sql;User ID = sa; Password=fk.224118;Connection TimeOut = 20; Pooling=true;Max Pool Size = 512";

        public static string sqlStrProductionConn = @"Server=192.168.252.18; Database=production; User ID = fr_rpt; Password=U9rpt123; Connection TimeOut = 20; Pooling=true;Max Pool Size = 512";

        public static string sqlStrBaseDataConn = @"Server=192.168.252.18; Database=kuka_basedata; User ID = fr_rpt; Password=U9rpt123; Connection TimeOut = 20; Pooling=true;Max Pool Size = 512";
    }
}