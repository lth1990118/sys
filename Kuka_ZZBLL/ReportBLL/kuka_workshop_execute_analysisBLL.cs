using Kuka_Model;
using Kuka_Model.Report;
using kuka_ZZDAL.ReportDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuka_ZZBLL.ReportBLL
{
    public class kuka_workshop_execute_analysisBLL
    {
        public kuka_workshop_execute_analysisDAL dal = new kuka_workshop_execute_analysisDAL();
        public KukaPage<kuka_workshop_execute_analysi_resultModel> GetWorkshopExecuteAnalysis(kuka_workshop_execute_analysis_searchModel model)
        {
            return dal.GetWorkshopExecuteAnalysis(model);
        }
    }
}
