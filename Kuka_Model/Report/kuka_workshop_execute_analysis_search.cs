using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuka_Model.Report
{
    public class kuka_workshop_execute_analysis_searchModel : PageBase
    {
        public string sales_order_no { get; set; }

        public string main_schedule_no { get; set; }

        public string plan_reply_begin_date { get; set; }

        public string plan_reply_end_date { get; set; }

        public string packing_begin_time { get; set; }

        public string packing_end_time { get; set; }

        public string storage_begin_date { get; set; }

        public string storage_end_date { get; set; }

        public string factory_name { get; set; }

        public string package_begin_date { get; set; }

        public string package_end_date { get; set; }

        public string scan_begin_date { get; set; }

        public string scan_end_date { get; set; }

        public string is_not_in_storage { get; set; }    
 
    }
}
