using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuka_Model
{
    public class MenuTree
    {
        public MenuTree()
        {
            data = new List<MenuTree>();
        }
        public int value { get; set; }
        public string title { get; set; }

        public bool @checked { get; set; }
        public bool ischeck { get; set; }

        public int parentid { get; set; }
        public List<MenuTree> data { get; set; }
    }
}