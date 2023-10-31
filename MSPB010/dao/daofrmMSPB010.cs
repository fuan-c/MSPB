using log4net;
using MSPB.Common.Dao;
using System;
using System.Data;
using System.Text;

namespace MSPB.MSPB010.dao
{
    class daofrmMSPB010 : daoBase
    {
        #region "変数"

        // ユーザーID
        string _userId = string.Empty;

        // log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region コンストラクタ


        // コンストラクタ
        public daofrmMSPB010(string name, string userid)
        {
            dbConnection(name);
            _userId = userid;

        }
        #endregion

        #region "SELECT"

        #region  私物返却_ステータステーブルより取得
        // 私物返却_ステータステーブルより取得
        public DataTable Select_T_STATUS()
        {
            _logger.Info("〇Select_T_STATUS");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" STATUS_CODE ");
            sb.AppendLine(" ,STATUS_TEXT ");
            sb.AppendLine(" FROM T_STATUS ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return tbl;
        }
        #endregion

        #region  エスカレテーブルより取得(検索)
        // エスカレテーブルより取得
        public DataTable Select_T_ESCALATION(string registDate, string productType, string controlNo,
                                            string contractNo, string status, string personalBelongingsInfo, string reportDate,
                                            string storageReferenceDate, string storagePeriod, string responseDate, string returnPlace,
                                            string escalationResponse, string trackNo, string shippingDate)
        {
            _logger.Info("〇Select_T_ESCALATION");

            StringBuilder sql = new StringBuilder();
            string sb = String.Empty;
            DataTable tbl = new DataTable();
            bool bCondition = false;
            string status_Work = null;
            string escalation_Response = null;


            sql.AppendLine("SELECT ");
            sql.AppendLine(" REGIST_DATE ");
            sql.AppendLine(" ,PRODUCT_TYPE ");
            sql.AppendLine(" ,CONTROL_NO ");
            sql.AppendLine(" ,CONTRACT_NO ");
            sql.AppendLine(" ,STATUS ");
            sql.AppendLine(" ,STORAGE_PERIOD ");
            sql.AppendLine(" ,ESCALATION_RESPONSE ");
            sql.AppendLine(" ,RESPONSE_DATE ");
            sql.AppendLine(" ,TRACKING_NO ");
            sql.AppendLine(" ,SHIPPING_DATE ");
            sql.AppendLine(" FROM T_ESCALATION ");

            
            if (!String.IsNullOrEmpty(registDate))
            {
                sql.AppendLine("WHERE REGIST_DATE like '" + registDate + "%' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(productType))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("PRODUCT_TYPE = '" + productType + "' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(controlNo))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("CONTROL_NO like '" + controlNo + "%' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(contractNo))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("CONTRACT_NO like '%" + contractNo + "%' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(status))
            {
                switch (status)
                {
                    case "エスカレ":
                        status_Work = "0";
                        break;
                    case "エスカレ送付":
                        status_Work = "1";
                        break;
                    case "回答済":
                        status_Work = "2";
                        break;
                    case "承認":
                        status_Work = "3";
                        break;
                    case "承認保管期間経過":
                        status_Work = "4";
                        break;
                    case "返却処理":
                        status_Work = "5";
                        break;
                    case "返却済":
                        status_Work = "6";
                        break;
                    case "不着":
                        status_Work = "9";
                        break;
                    default:
                        break;
                }
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("STATUS = '" + status_Work + "' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(personalBelongingsInfo))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("PERSONAL_BELONGINGS_INFO like '%" + personalBelongingsInfo + "%' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(reportDate))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("REPORT_DATE like '" + reportDate + "%' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(storageReferenceDate))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("TO_CHAR(STORAGE_REFERENCE_DATE, 'yyyyMMdd') like '" + storageReferenceDate + "%' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(storagePeriod))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("TO_CHAR(STORAGE_PERIOD, 'yyyyMMdd') like '" + storagePeriod + "%' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(responseDate))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("RESPONSE_DATE like '" + responseDate + "%' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(returnPlace))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("RETURN_PLACE = '" + returnPlace + "' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(escalationResponse))
            {
                switch (escalationResponse)
                {
                    case "エスカレ":
                        escalation_Response = "0";
                        break;
                    case "契約者返却":
                        escalation_Response = "1";
                        break;
                    case "MS返却":
                        escalation_Response = "2";
                        break;
                    case "保管期間経過":
                        escalation_Response = "3";
                        break;
                    default:
                        break;
                }
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("ESCALATION_RESPONSE = '" + escalation_Response + "' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(trackNo))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("TRACKING_NO like '" + trackNo + "%' ");
                bCondition = true;
            }
            if (!String.IsNullOrEmpty(shippingDate))
            {
                if (bCondition)
                {
                    sql.AppendLine("AND ");
                }
                else
                {
                    sql.AppendLine("WHERE ");
                }
                sql.AppendLine("SHIPPING_DATE like '" + shippingDate + "%' ");
                bCondition = true;
            }
            sql.AppendLine("ORDER BY CONTROL_NO");

            sb = sql.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sb);

            _logger.Info("出荷依頼テーブル 取得終了");

            return tbl;
        }
        #endregion

        #region  エスカレ回答テーブルより取得(詳細)
        // エスカレ回答テーブルより取得
        public DataTable Select_T_ESCALATION(string ControlNo)
        {
            _logger.Info("〇Select_T_ESCALATION");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine("es.CONTROL_NO, ");
            sb.AppendLine("es.CONTRACT_NO, ");
            sb.AppendLine("es.CONTRACTOR_NAME, ");
            sb.AppendLine("es.SEND_DEST_POSTAL_CODE, ");
            sb.AppendLine("es.SEND_DEST_ADDRESS, ");
            sb.AppendLine("es.SEND_DEST_NAME, ");
            sb.AppendLine("es.SEND_DEST_TEL_NO, ");
            sb.AppendLine("es.PRODUCT_TYPE, ");
            sb.AppendLine("st.STATUS_TEXT, ");
            sb.AppendLine("es.STATUS, ");
            sb.AppendLine("es.REGIST_DATE, ");
            sb.AppendLine("es.REPORT_DATE, ");
            sb.AppendLine("es.STORAGE_REFERENCE_DATE, ");
            sb.AppendLine("teres.RESPONSE_TEXT AS RETURN_PLACE, ");
            sb.AppendLine("es.STORAGE_PERIOD, ");
            sb.AppendLine("es.RESPONSE_DATE, ");
            sb.AppendLine("es.PERSONAL_BELONGINGS_INFO, ");
            sb.AppendLine("es.SHIPPING_DATE, ");
            sb.AppendLine("es.TRACKING_NO, ");
            sb.AppendLine("eres.RESPONSE_TEXT, ");
            sb.AppendLine("es.REGIST_USER_NAME, ");
            sb.AppendLine("es.RESPONSE_USER_NAME, ");
            sb.AppendLine("es.APPROVER_NAME, ");
            sb.AppendLine("es.NON_ARRIVAL_DATE, ");
            sb.AppendLine("es.NON_ARRIVAL_REASON ");
            sb.AppendLine("FROM T_ESCALATION es  ");
            sb.AppendLine("LEFT JOIN T_STATUS st ON es.STATUS = st.STATUS_CODE ");
            sb.AppendLine("LEFT JOIN T_ESCALATION_RESPONSE eres ON es.ESCALATION_RESPONSE = eres.RESPONSE_CODE ");
            sb.AppendLine("LEFT JOIN T_ESCALATION_RESPONSE teres ON es.RETURN_PLACE = teres.RESPONSE_CODE ");
            sb.AppendLine("WHERE CONTROL_NO = '" + ControlNo + "'");


            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return tbl;
        }
        #endregion

        #region  エスカレ回答テーブルより取得(プルダウン)
        // エスカレ回答テーブルより取得
        public DataTable Select_T_ESCALATION_RESPONSE()
        {
            _logger.Info("〇Select_T_ESCALATION_RESPONSE");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" RESPONSE_CODE ");
            sb.AppendLine(" ,RESPONSE_TEXT ");
            sb.AppendLine(" FROM T_ESCALATION_RESPONSE ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return tbl;
        }
        #endregion

        
        #endregion

        #region "INSERT"

        #endregion

        #region "UPDATE"

        #region "エスカレテーブルデータ更新"
        public void Update_T_ESCALATION(string controlNo, string nonArrivalDate, string nonArrivalReason)
        {
            try
            {
                _logger.Info("エスカレテーブルデータ更新 開始");
                _logger.Info("〇update_T_ESCALATION");

                StringBuilder sb = new StringBuilder();
                string sql = String.Empty;
                DataTable tbl = new DataTable();


                sb.AppendLine(" UPDATE T_ESCALATION ");
                sb.AppendLine("    SET ");
                sb.AppendLine("    STATUS = '9'");
                sb.AppendLine("   ,NON_ARRIVAL_DATE = '" + nonArrivalDate + "'");
                sb.AppendLine("   ,NON_ARRIVAL_REASON = '" + nonArrivalReason + "'");
                sb.AppendLine(" WHERE ");
                sb.AppendLine("   CONTROL_NO = '"+ controlNo + "'");

                sql = sb.ToString();
                _logger.Info("sql[" + Environment.NewLine + sql + "]");
                tbl = base.Fill(sql);

                return;

            }
            catch (Exception ex)
            {
                throw new Exception("エスカレテーブルデータ更新処理：" + ex.Message, ex);
            }
            finally
            {
                _logger.Info("エスカレテーブルデータ更新 終了");
            }
        }
        #endregion

        #endregion

        #region "DELETE"

        #endregion
    }
}
