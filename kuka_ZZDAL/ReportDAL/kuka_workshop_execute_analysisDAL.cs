using Kuka_Model;
using Kuka_Model.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace kuka_ZZDAL.ReportDAL
{
    public class kuka_workshop_execute_analysisDAL
    {
        public KukaPage<kuka_workshop_execute_analysi_resultModel> GetWorkshopExecuteAnalysis(kuka_workshop_execute_analysis_searchModel model)
        {
            using (IDbConnection conn = new SqlConnection(SQLStr.sqlStrBaseDataConn))
            {
                KukaPage<kuka_workshop_execute_analysi_resultModel> returnList = new KukaPage<kuka_workshop_execute_analysi_resultModel>();
                returnList.code = "0";
                returnList.msg = "";
                conn.Open();
                StringBuilder query1 = new StringBuilder();
                query1.Append("SELECT * FROM [kuka_workshop_execute_analysis] b WHERE 1 = 1 ");
                StringBuilder query2 = new StringBuilder();
                query2.Append("SELECT COUNT(*) FROM [kuka_workshop_execute_analysis] b WHERE 1 = 1 ");

                if (!string.IsNullOrEmpty(model.sales_order_no))
                {
                    query1.AppendFormat(" AND b.[sales_order_no] = '{0}' ", model.sales_order_no);
                    query2.AppendFormat(" AND b.[sales_order_no] = '{0}' ", model.sales_order_no);
                }
                if (!string.IsNullOrEmpty(model.main_schedule_no))
                {
                    query1.AppendFormat(" AND b.[main_schedule_no] = '{0}' ", model.main_schedule_no);
                    query2.AppendFormat(" AND b.[main_schedule_no] = '{0}' ", model.main_schedule_no);
                }
                if (!string.IsNullOrEmpty(model.factory_name))
                {
                    query1.AppendFormat(" AND b.[factory_id] IN ({0}) ", model.factory_name);
                    query2.AppendFormat(" AND b.[factory_id] IN ({0}) ", model.factory_name);
                }
                //计划回复交期
                #region - 计划回复交期 -
                if (!string.IsNullOrEmpty(model.plan_reply_begin_date) && !string.IsNullOrEmpty(model.plan_reply_end_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), plan_replay_time, 23) >= '{0}' AND CONVERT(VARCHAR(100), plan_replay_time, 23) <= '{1}' ", model.plan_reply_begin_date, model.plan_reply_end_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), plan_replay_time, 23) >= '{0}' AND CONVERT(VARCHAR(100), plan_replay_time, 23) <= '{1}' ", model.plan_reply_begin_date, model.plan_reply_end_date);
                }
                else if (!string.IsNullOrEmpty(model.plan_reply_begin_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), plan_replay_time, 23) >= '{0}' ", model.plan_reply_begin_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), plan_replay_time, 23) >= '{0}' ", model.plan_reply_begin_date);
                }
                else if (!string.IsNullOrEmpty(model.plan_reply_end_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), plan_replay_time, 23) <= '{0}' ", model.plan_reply_end_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), plan_replay_time, 23) <= '{0}' ", model.plan_reply_end_date);
                }
                #endregion

                //计划装箱日期
                #region - 计划装箱日期 -
                if (!string.IsNullOrEmpty(model.packing_begin_time) && !string.IsNullOrEmpty(model.packing_end_time))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), packing_time, 23) >= '{0}' AND CONVERT(VARCHAR(100), packing_time, 23) <= '{1}' ", model.packing_begin_time, model.packing_end_time);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), packing_time, 23) >= '{0}' AND CONVERT(VARCHAR(100), packing_time, 23) <= '{1}' ", model.packing_begin_time, model.packing_end_time);
                }
                else if (!string.IsNullOrEmpty(model.packing_begin_time))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), packing_time, 23) >= '{0}' ", model.packing_begin_time);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), packing_time, 23) >= '{0}' ", model.packing_begin_time);
                }
                else if (!string.IsNullOrEmpty(model.packing_end_time))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), packing_time, 23) <= '{0}' ", model.packing_end_time);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), packing_time, 23) <= '{0}' ", model.packing_end_time);
                }
                #endregion

                //U9入库时间
                #region - U9入库时间 -
                if (!string.IsNullOrEmpty(model.storage_begin_date) && !string.IsNullOrEmpty(model.storage_end_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), actual_item_u9_storage_time, 23) >= '{0}' AND CONVERT(VARCHAR(100), actual_item_u9_storage_time, 23) <= '{1}' ", model.storage_begin_date, model.storage_end_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), actual_item_u9_storage_time, 23) >= '{0}' AND CONVERT(VARCHAR(100), actual_item_u9_storage_time, 23) <= '{1}' ", model.storage_begin_date, model.storage_end_date);
                }
                else if (!string.IsNullOrEmpty(model.storage_begin_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), actual_item_u9_storage_time, 23) >= '{0}' ", model.storage_begin_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), actual_item_u9_storage_time, 23) >= '{0}' ", model.storage_begin_date);
                }
                else if (!string.IsNullOrEmpty(model.storage_end_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), actual_item_u9_storage_time, 23) <= '{0}' ", model.storage_end_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), actual_item_u9_storage_time, 23) <= '{0}' ", model.storage_end_date);
                }
                #endregion

                //打包完工时间
                #region - 打包完工时间 -
                if (!string.IsNullOrEmpty(model.package_begin_date) && !string.IsNullOrEmpty(model.package_end_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), pack_working_procedure_scan_date, 23) >= '{0}' AND CONVERT(VARCHAR(100), pack_working_procedure_scan_date, 23) <= '{1}' ", model.package_begin_date, model.package_end_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), pack_working_procedure_scan_date, 23) >= '{0}' AND CONVERT(VARCHAR(100), pack_working_procedure_scan_date, 23) <= '{1}' ", model.package_begin_date, model.package_end_date);
                }
                else if (!string.IsNullOrEmpty(model.package_begin_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), pack_working_procedure_scan_date, 23) >= '{0}' ", model.package_begin_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), pack_working_procedure_scan_date, 23) >= '{0}' ", model.package_begin_date);
                }
                else if (!string.IsNullOrEmpty(model.package_end_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), pack_working_procedure_scan_date, 23) <= '{0}' ", model.package_end_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), pack_working_procedure_scan_date, 23) <= '{0}' ", model.package_end_date);
                }
                #endregion

                //包制完成时间
                #region - 包制完成时间 -
                if (!string.IsNullOrEmpty(model.scan_begin_date) && !string.IsNullOrEmpty(model.scan_end_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), sofa_working_procedure_scan_date, 23) >= '{0}' AND CONVERT(VARCHAR(100), sofa_working_procedure_scan_date, 23) <= '{1}' ", model.scan_begin_date, model.scan_end_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), sofa_working_procedure_scan_date, 23) >= '{0}' AND CONVERT(VARCHAR(100), sofa_working_procedure_scan_date, 23) <= '{1}' ", model.scan_begin_date, model.scan_end_date);
                }
                else if (!string.IsNullOrEmpty(model.scan_begin_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), sofa_working_procedure_scan_date, 23) >= '{0}' ", model.scan_begin_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), sofa_working_procedure_scan_date, 23) >= '{0}' ", model.scan_begin_date);
                }
                else if (!string.IsNullOrEmpty(model.scan_end_date))
                {
                    query1.AppendFormat(" AND CONVERT(VARCHAR(100), sofa_working_procedure_scan_date, 23) <= '{1}' ", model.scan_end_date);
                    query2.AppendFormat(" AND CONVERT(VARCHAR(100), sofa_working_procedure_scan_date, 23) <= '{1}' ", model.scan_end_date);
                }
                #endregion

                //U9未入库
                if (!string.IsNullOrEmpty(model.is_not_in_storage))
                {
                    switch (model.is_not_in_storage)
                    {
                        case "是":
                            query1.AppendFormat(" AND actual_item_u9_storage_time IS NULL ");
                            query2.AppendFormat(" AND actual_item_u9_storage_time IS NULL ");
                            break;
                        case "否":
                            query1.AppendFormat(" AND actual_item_u9_storage_time IS NOT NULL ");
                            query2.AppendFormat(" AND actual_item_u9_storage_time IS NOT NULL ");
                            break;
                        default:
                            break;
                    }
                }

                query1.Append(" ORDER BY b.[sales_order_no] OFFSET @skip ROWS FETCH NEXT @page ROWS ONLY ");

                var b = conn.Query<kuka_workshop_execute_analysi_resultModel>(query1.ToString(), new
                {
                    skip = (model.page - 1) * model.limit,
                    page = model.limit
                });

                var count = conn.Query<int>(query2.ToString(), new
                {
                });


                returnList.data = b.ToList();
                returnList.count = count.FirstOrDefault();

                return returnList;
            }
        }
    }
}
