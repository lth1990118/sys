using Kuka_ZZBLL.FactoryBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kuka_Model.Report;
using Kuka_ZZBLL.ReportBLL;
using Kuka_Model;
using Newtonsoft.Json;

namespace Kuka_ZZWebApi.Controllers
{
    public class ReportController : Controller
    {
        FactoryBLL _bll = new FactoryBLL();
        kuka_workshop_execute_analysisBLL _reportBLL = new kuka_workshop_execute_analysisBLL();

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult kuka_sp_workshop_execute_analysis()
        {
            kuka_workshop_execute_analysisModel model = new kuka_workshop_execute_analysisModel();
            var list = _bll.GetFactory();
            model.FactoryList = list;
            return View(model);
        }

        [HttpGet]
        public object GetWorkshopExecuteAnalysis(int page,
            int limit,
            string sales_order_no,
            string main_schedule_no,
            string factory_name,
            string plan_reply_begin_date,
            string plan_reply_end_date,
            string packing_begin_time,
            string packing_end_time,
            string storage_begin_date,
            string storage_end_date,
            string package_begin_date,
            string package_end_date,
            string scan_begin_date,
            string scan_end_date,
            string is_not_in_storage
            )
        {
            kuka_workshop_execute_analysis_searchModel searchModel = new kuka_workshop_execute_analysis_searchModel();
            searchModel.page = page;
            searchModel.limit = limit;
            searchModel.sales_order_no = sales_order_no;
            searchModel.main_schedule_no = main_schedule_no;
            if (!string.IsNullOrEmpty(factory_name))
            {
                searchModel.factory_name = factory_name.TrimEnd(',');
            }
            searchModel.plan_reply_begin_date = plan_reply_begin_date;
            searchModel.plan_reply_end_date = plan_reply_end_date;
            searchModel.packing_begin_time = packing_begin_time;
            searchModel.packing_end_time = packing_end_time;
            searchModel.storage_begin_date = storage_begin_date;
            searchModel.storage_end_date = storage_end_date;
            searchModel.package_begin_date = package_begin_date;
            searchModel.package_end_date = package_end_date;
            searchModel.scan_begin_date = scan_begin_date;
            searchModel.scan_end_date = scan_end_date;
            if (!string.IsNullOrEmpty(is_not_in_storage))
            {
                searchModel.is_not_in_storage = is_not_in_storage.TrimEnd(',');
            }
            var obj = _reportBLL.GetWorkshopExecuteAnalysis(searchModel);
            var result = JsonConvert.SerializeObject(obj);
            return result;
        }
    }
}