using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuka_Model
{
    public class task_log
    {
        public int id { get; set; }
        public int taskid { get; set; }
        public string taskname { get; set; }
        public int stat { get; set; }
        public string msg { get; set; }
        public DateTime excutetime { get; set; }
    }
}