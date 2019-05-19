using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuka_Model
{
    public class Menu
    {
        public Menu(){
            Childs = new List<Menu>();
            }


        public int id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 跳转路由：../
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 是否父级菜单
        /// </summary>
        public bool IsParent { get; set; }

        public int parentid { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<Menu> Childs { get; set; }
    }
}