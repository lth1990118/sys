using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuka_Model
{
    public class task_proc
    {
        public int id { get; set; }
        public string procname { get; set; }
        public string parm { get; set; }
        public int state { get; set; }
        public string cronstr { get; set; }

        public int typeid { get; set; }
        public string dllname { get; set; }
        public string classname { get; set; }

        public string taskname { get; set; }

        public string remake { get; set; }
    }
}