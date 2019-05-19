using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuka_Model.Report
{
    public class kuka_workshop_execute_analysi_resultModel
    {
        public string bar_code { get; set; }

        public string suite_bar_code { get; set; }

        public string cargo_no { get; set; }

        public string specifications_no { get; set; }

        public string model_no { get; set; }

        public string single_spec { get; set; }

        public decimal? num { get; set; }

        public decimal? standard_set { get; set; }

        public string sewing_working_procedure_plan_date { get; set; }

        public string sewing_working_procedure_scan_date { get; set; }

        public string sofa_working_procedure_plan_date { get; set; }

        public string sofa_working_procedure_scan_date { get; set; }

        public string sofa_working_procedure_work_shop { get; set; }

        public string pack_working_procedure_plan_date { get; set; }

        public string pack_working_procedure_scan_date { get; set; }

        public string actual_item_u9_storage_time { get; set; }

        public string plan_replay_time { get; set; }

        public string packing_time { get; set; }

        public string main_schedule_no { get; set; }

        public string sales_order_no { get; set; }

        public DateTime? create_date { get; set; }

        public string factory_name { get; set; }

        public string factory_id { get; set; }

        public string SnCode { get; set; }

    }
}
