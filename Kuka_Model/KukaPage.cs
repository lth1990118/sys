using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuka_Model
{
    public class KukaPage<T>
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public string code { get; set; }
        
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> data { get; set; }
    }
}