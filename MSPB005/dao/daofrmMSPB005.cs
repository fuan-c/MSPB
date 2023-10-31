using System;
using System.Text;
using System.Data;
using log4net;
using MSPB.Common.Dao;
using Oracle.ManagedDataAccess.Client;

namespace MSPB.MSPB005.dao
{
    class daofrmMSPB005 : daoBase
    {

        #region "変数"

        // ユーザーID
        string _userId = string.Empty;

        // log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        
        // コンストラクタ
        public daofrmMSPB005(string name)
        {
            dbConnection(name);
        }

        #region "SELECT"

        #region エスカレテーブルよりエスカレ件数取得
        // エスカレテーブルよりエスカレ件数取得
        public DataTable Select_T_ESCALATION()
        {
            _logger.Debug("〇Select_T_ESCALATION");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" ID, ");
            sb.AppendLine(" REGIST_DATE, ");
            sb.AppendLine(" PRODUCT_TYPE, ");
            sb.AppendLine(" CONTROL_NO, ");
            sb.AppendLine(" CONTRACT_NO ");
            sb.AppendLine(" FROM T_ESCALATION ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  STATUS = '0' ");       // ステータス「0:エスカレ」
            sb.AppendLine(" ORDER BY ID DESC");         // ID降順

            sql = sb.ToString();
            _logger.Debug("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return tbl;
        }
        #endregion

        #region エスカレテーブルより総件数取得
        // エスカレテーブルより総件数取得
        public DataTable Select_TotalOutputCount_T_ESCALATION(int addDate)
        {
            _logger.Debug("〇Select_TotalOutputCount_T_ESCALATION");

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine(" TE.ID, ");
            sql.AppendLine(" TE.REGIST_DATE, ");
            sql.AppendLine(" TE.PRODUCT_TYPE, ");
            sql.AppendLine(" TE.CONTROL_NO, ");
            sql.AppendLine(" TE.CONTRACT_NO, ");
            sql.AppendLine(" TE.PERSONAL_BELONGINGS_INFO, ");
            sql.AppendLine(" TE.MS_RETURN_FLAG, ");
            sql.AppendLine(" TE.SHIPPING_DATE, ");
            sql.AppendLine(" TRS.ESCALATION_LABEL ");
            sql.AppendLine(" FROM T_ESCALATION TE ");
            sql.AppendLine(" LEFT JOIN T_REPORT_STATUS TRS ");
            sql.AppendLine("  ON TRS.STATUS_CODE = TE.STATUS AND ");
            sql.AppendLine("     TRS.RESPONSE_CODE = TE.ESCALATION_RESPONSE ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("  TE.REGIST_DATE >= TO_CHAR(SYSDATE - :ADD_DATE, 'YYYYMMDD')");       // 加算日数：SYSDATE(yyyyMMdd) - 92日
            sql.AppendLine(" ORDER BY TE.ID DESC");

            DataTable dt = new DataTable();

            _logger.Debug("sql[" + Environment.NewLine + sql + "]");

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":ADD_DATE", addDate);

                foreach (OracleParameter prm in cmd.Parameters)
                {
                    this._logger.DebugFormat("{0}[{1}]", prm.ParameterName, prm.Value == null ? "<Null>" : prm.Value.ToString());
                }

                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
        #endregion

        #region 処理履歴テーブルのMAX ID取得
        // 処理履歴テーブルのMAX ID取得
        public int Select_MaxSeqNo_T_PROCESS_HISTORY()
        {
            _logger.Debug("〇Select_MaxSeqNo_T_PROCESS_HISTORY");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" MAX(SEQ_NO) AS MAX_SEQ_NO");
            sb.AppendLine(" FROM T_PROCESS_HISTORY ");

            sql = sb.ToString();
            _logger.Debug("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return string.IsNullOrEmpty(tbl.Rows[0]["MAX_SEQ_NO"].ToString()) ?
                   0 : int.Parse(tbl.Rows[0]["MAX_SEQ_NO"].ToString());
        }
        #endregion

        #endregion

        #region "INSERT"

        #region 処理履歴テーブルデータ登録
        public void Insert_T_PROCESS_HISTORY(ProcessHistoryEnity entity)
        {            
            _logger.Debug("〇Insert_T_PROCESS_HISTORY");

            StringBuilder sb = new StringBuilder();
            string sql = null;

            _logger.Debug($"処理履歴テーブル 登録1行 SEQ_NO：[{entity.SEQ_NO}]、PROCESS_TEXT：[{entity.PROCESS_TEXT}]、OUTPUT_FILE_NAME：[{entity.OUTPUT_FILE_NAME}]、OUTPUT_COUNT：[{entity.OUTPUT_COUNT}]、UPDATE_USER：[{entity.UPDATE_USER}]");

            sb.AppendLine(" INSERT INTO T_PROCESS_HISTORY( ");
            sb.AppendLine("    SEQ_NO ");
            sb.AppendLine("    , PROCESS_TEXT ");
            sb.AppendLine("    , OUTPUT_FILE_NAME ");
            sb.AppendLine("    , OUTPUT_COUNT ");
            sb.AppendLine("    , UPDATE_DATE ");
            sb.AppendLine("    , UPDATE_USER ");
            sb.AppendLine(" ) VALUES (  ");
            sb.AppendLine("    " + entity.SEQ_NO);
            sb.AppendLine("  ,'" + entity.PROCESS_TEXT + "'");
            sb.AppendLine("  ,'" + entity.OUTPUT_FILE_NAME + "'");
            sb.AppendLine("  ,'" + entity.OUTPUT_COUNT + "'");
            sb.AppendLine("  , SYSDATE");
            sb.AppendLine("  ,'" + entity.UPDATE_USER + "' )");

            _logger.Debug("sql[" + Environment.NewLine + sb.ToString() + "]");
            sql = sb.ToString();
            Update(sql);

            return;
        }
        #endregion

        #endregion

        #region "UPDATE"

        #region エスカレテーブルデータ更新
        public void Update_TrgEscSheet_T_ESCALATION(string status, string reportDate, string controlNo)
        {
               
            _logger.Debug("〇Update_ContractorRtn_T_ESCALATION");

            StringBuilder sql = new StringBuilder();

            _logger.Debug($"エスカレテーブル 更新1行 STATUS：[{status}]、REPORT_DATE：[{reportDate}]");

            sql.AppendLine(" UPDATE T_ESCALATION ");
            sql.AppendLine("    SET ");
            sql.AppendLine("    STATUS = :STATUS ");
            sql.AppendLine("    ,REPORT_DATE = :REPORT_DATE ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("   CONTROL_NO = :CONTROL_NO ");

            _logger.Debug("sql[" + Environment.NewLine + sql + "]");

            DataTable dt = new DataTable();

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":STATUS", status);
                cmd.Parameters.Add(":REPORT_DATE", reportDate);
                cmd.Parameters.Add(":CONTROL_NO", controlNo);

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
        #endregion

        #endregion

    }
}
