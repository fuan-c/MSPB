using System;
using System.Text;
using System.Data;
using log4net;

namespace MSPB.MSPB006.dao
{
    class daofrmMSPB006 : MSPB.Common.Dao.daoBase
    {

        #region "変数"
        //log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion

        //コンストラクタ
        public daofrmMSPB006(string name)
        {
            dbConnection(name);
        }

        #region "SELECT"

        #region エスカレテーブルより「登録日」単位に集計データに取得        
        public DataTable Select_SearchDate_T_Escalation(string FromDate, string ToDate)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("エスカレテーブル 件数取得開始");

            sb.AppendLine("SELECT TE.REGIST_DATE, ");
            sb.AppendLine("  TE.STATUS, ");
            sb.AppendLine("  TE.ESCALATION_RESPONSE, ");
            sb.AppendLine("  COUNT(TE.REGIST_DATE) AS COUNT ");
            sb.AppendLine(" FROM T_ESCALATION TE ");
            sb.AppendLine(" INNER JOIN T_STATUS TS ");
            sb.AppendLine("  ON TS.STATUS_CODE = TE.STATUS ");
            sb.AppendLine(" INNER JOIN T_ESCALATION_RESPONSE TER ");
            sb.AppendLine("  ON TER.RESPONSE_CODE = TE.ESCALATION_RESPONSE ");
            if (!string.IsNullOrEmpty(FromDate) || !string.IsNullOrEmpty(ToDate))
            {
                sb.AppendLine("WHERE ");
            }
            if (!string.IsNullOrEmpty(FromDate))
            {
                sb.AppendLine("TE.REGIST_DATE >= '" + FromDate + "' ");
                if (!string.IsNullOrEmpty(ToDate))
                {
                    sb.AppendLine("AND ");
                }
            }
            if (!string.IsNullOrEmpty(ToDate))
            {
                sb.AppendLine("TE.REGIST_DATE <= '" + ToDate + "' ");
            }
            sb.AppendLine(" GROUP BY TE.REGIST_DATE, ");
            sb.AppendLine("  TE.STATUS, ");
            sb.AppendLine("  TE.ESCALATION_RESPONSE ");
            sb.AppendLine(" ORDER BY TE.REGIST_DATE, ");
            sb.AppendLine("  TE.STATUS, ");
            sb.AppendLine("  TE.ESCALATION_RESPONSE ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("エスカレテーブル 件数取得終了");

            return tbl;
        }
        #endregion

        #endregion

        #region "INSERT"

        #endregion

        #region "DELETE"

        #endregion


        #region "Property"
        public class TotalResult_T_ESCALATION
        {
            public string No { get; set; }
            public string RegistDate { get; set; }
            public string SumValue { get; set; }
            public string EscRegist { get; set; }
            public string EscSend { get; set; }
            public string Responsed { get; set; }
            public string Approval { get; set; }
            public string ApprovalTimeOver { get; set; }
            public string RetrunProcess { get; set; }
            public string Returned { get; set; }
            public string NoneArrived { get; set; }
            public string EscProcess { get; set; }
            public string ContractorRtn { get; set; }
            public string MSRtn { get; set; }
            public string MSRtnTimeOver { get; set; }
        }

        #endregion
    }
}
