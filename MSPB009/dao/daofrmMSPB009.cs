using System;
using System.Text;
using System.Data;
using log4net;
using MSPB.Common.Dao;
using Oracle.ManagedDataAccess.Client;

namespace MSPB.MSPB009.dao
{
    class daofrmMSPB009 : daoBase
    {

        #region "変数"

        // ユーザーID
        string _userId = string.Empty;

        // log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        
        // コンストラクタ
        public daofrmMSPB009(string name, string userid)
        {
            dbConnection(name);
            _userId = userid;
        }

        #region "SELECT"

        #region  エスカレテーブルより未承認のデータ取得
        // エスカレテーブルより未承認のデータ取得
        public DataTable Select_NonApproved_T_ESCALATION(DateTime now)
        {
            _logger.Info("〇Select_NonApproved_T_ESCALATION");

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine(" REGIST_DATE ");
            sql.AppendLine(" ,PRODUCT_TYPE ");
            sql.AppendLine(" ,CONTROL_NO ");
            sql.AppendLine(" ,CONTRACT_NO ");
            sql.AppendLine(" ,STATUS ");
            sql.AppendLine(" ,ESCALATION_RESPONSE ");
            sql.AppendLine(" ,STORAGE_PERIOD ");
            sql.AppendLine(" FROM T_ESCALATION ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("  ( STATUS = '2' AND ");
            sql.AppendLine("    (ESCALATION_RESPONSE IN ('1','2')) ) ");
            sql.AppendLine("  OR ");
            sql.AppendLine("  ( STATUS IN ('0','1') AND ");
            sql.AppendLine("    STORAGE_PERIOD <= :TODAY ) ");
            sql.AppendLine(" ORDER BY ID DESC");    // ID 降順

            DataTable dt = new DataTable();

            _logger.Info("sql[" + Environment.NewLine + sql + "]");

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":TODAY", now.ToShortDateString());

                foreach (OracleParameter prm in cmd.Parameters)
                {
                    this._logger.InfoFormat("{0}[{1}]", prm.ParameterName, prm.Value == null ? "<Null>" : prm.Value.ToString());
                }

                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
        #endregion

        #region  エスカレテーブルより承認済件数取得
        // エスカレテーブルより承認済件数取得
        public DataTable Select_ApprovedCnt_T_ESCALATION()
        {
            _logger.Info("〇Select_ApprovedCnt_T_ESCALATION");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" CONTROL_NO ");
            sb.AppendLine(" FROM T_ESCALATION ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  STATUS IN ('3', '4') ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return tbl;
        }
        #endregion

        #region  エスカレ回答テーブルより取得
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
            sb.AppendLine("WHERE ");
            sb.AppendLine("  RESPONSE_CODE IN ('1', '2') ");
            sb.AppendLine("ORDER BY RESPONSE_CODE ");

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
        public void Update_T_ESCALATION(string approvalTarget, string status, string userName)
        {
            try
            {
                
                _logger.Info("エスカレテーブルデータ更新 開始");
                _logger.Info("〇update_T_ESCALATION");

                StringBuilder sql = new StringBuilder();

                _logger.Info($"エスカレデータ 更新1行 STATUS：[{status}]、APPROVER_NAME：[{userName}]");

                sql.AppendLine(" UPDATE T_ESCALATION ");
                sql.AppendLine("    SET ");
                sql.AppendLine("    STATUS = :STATUS ");
                sql.AppendLine("    ,APPROVER_NAME = :APPROVER_NAME ");
                // ＭＳ返却（超過）の場合、エスカレテーブル「エスカレ回答 = 3 : 保管期間経過」をセット
                if (status == "4")
                {
                    sql.AppendLine("    ,ESCALATION_RESPONSE = '3' ");
                }
                sql.AppendLine(" WHERE ");
                sql.AppendLine("   CONTROL_NO = :CONTROL_NO ");

                _logger.Info("sql[" + Environment.NewLine + sql + "]");

                DataTable dt = new DataTable();

                using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
                {
                    cmd.Parameters.Add(":STATUS", status);                    
                    cmd.Parameters.Add(":APPROVER_NAME", userName);                    
                    cmd.Parameters.Add(":CONTROL_NO", approvalTarget);

                    foreach (OracleParameter prm in cmd.Parameters)
                    {
                        this._logger.DebugFormat("{0}[{1}]", prm.ParameterName, prm.Value == null ? "<Null>" : prm.Value.ToString());
                    }

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                return;
                
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message, ex);
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
