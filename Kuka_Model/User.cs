using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuka_Model
{
    public class user
    {
        public user()
        {
            wp = new List<user_wp>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string sex { get; set; }
        public string city { get; set; }
        public string createuser { get; set; }
        public string password { get; set; }
        public DateTime createtime { get; set; }
        public List<user_wp> wp { get; set; }

}

    public class user_wp
    {

        public int id { get; set; }
        public string name { get; set; }
        public int userid { get; set; }
        public string createuser { get; set; }
        public DateTime createtime { get; set; }
    }
}