using System;
using System.Text;
using System.Data;
using log4net;
using MSPB.Common.Dao;
using Oracle.ManagedDataAccess.Client;

namespace MSPB.MSPB002.dao
{
    class daofrmMSPB002 : daoBase
    {

        #region "変数"

        // ユーザーID
        string _userId = string.Empty;

        // log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        
        // コンストラクタ
        public daofrmMSPB002(string name, string userid)
        {
            dbConnection(name);
            _userId = userid;

        }

        #region "SELECT"

        #region  回答_TEMPテーブルより取得
        // 回答_TEMPテーブルより取得
        public DataTable Select_T_RESPONSE_TMP(string controlNo)
        {
            _logger.Info("〇Select_T_RESPONSE_TMP");

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine(" REPORT_DATE ");
            sql.AppendLine(" ,PRODUCT_TYPE ");
            sql.AppendLine(" ,CONTROL_NO ");
            sql.AppendLine(" ,CONTRACT_NO ");
            sql.AppendLine(" ,ESCALATION_RESPONSE ");
            sql.AppendLine(" FROM T_RESPONSE_TMP ");
            sql.AppendLine("WHERE ");
            sql.AppendLine("  CONTROL_NO = :CONTROL_NO ");

            DataTable dt = new DataTable();

            _logger.Info("sql[" + Environment.NewLine + sql + "]");

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":CONTROL_NO", controlNo);

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

        public DataTable Select_T_RESPONSE_TMP()
        {
            _logger.Info("〇Select_T_RESPONSE_TMP");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" ID ");
            sb.AppendLine(" ,REPORT_DATE ");
            sb.AppendLine(" ,PRODUCT_TYPE ");
            sb.AppendLine(" ,CONTROL_NO ");
            sb.AppendLine(" ,CONTRACT_NO ");
            sb.AppendLine(" ,ESCALATION_RESPONSE ");
            sb.AppendLine(" FROM T_RESPONSE_TMP ");
            sb.AppendLine(" ORDER BY ID ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return tbl;
        }
        #endregion

        #region  エスカレテーブルより取得
        // エスカレテーブルより取得
        public DataTable Select_T_ESCALATION(string controlNo)
        {
            _logger.Info("〇Select_T_ESCALATION");

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine(" REGIST_DATE ");
            sql.AppendLine(" ,PRODUCT_TYPE ");
            sql.AppendLine(" ,CONTROL_NO ");
            sql.AppendLine(" ,CONTRACT_NO ");
            sql.AppendLine(" ,STATUS ");
            sql.AppendLine(" ,PERSONAL_BELONGINGS_INFO ");            
            sql.AppendLine(" ,MS_RETURN_FLAG ");
            sql.AppendLine(" FROM T_ESCALATION ");
            sql.AppendLine("WHERE ");
            sql.AppendLine("  CONTROL_NO = :CONTROL_NO ");

            DataTable dt = new DataTable();

            _logger.Info("sql[" + Environment.NewLine + sql + "]");

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":CONTROL_NO", controlNo);
                
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
        
        #region "回答_TEMPテーブルデータ登録"        
        public void Insert_T_RESPONSE_TMP(DataTable dt, int id, string response)
        {
            try
            {
                //トランザクション開始
                BeginTransaction();

                _logger.Info("回答_TEMPテーブルデータ登録 開始");
                _logger.Info("〇insert_T_RESPONSE_TMP");

                StringBuilder sb = new StringBuilder();
                string sql = null;
                
                _logger.Info($"回答_TEMPデータ 登録1行 ID：[{id}]、REGIST_DATE：[{dt.Rows[0]["REGIST_DATE"].ToString()}]、PRODUCT_TYPE：[{dt.Rows[0]["PRODUCT_TYPE"].ToString()}]、CONTROL_NO：[{dt.Rows[0]["CONTROL_NO"].ToString()}]、CONTRACT_NO：[{dt.Rows[0]["CONTRACT_NO"].ToString()}]、ESCALATION_RESPONSE：[{response}]");
                
                sb.AppendLine(" INSERT INTO T_RESPONSE_TMP ( ");
                sb.AppendLine("   ID ");
                sb.AppendLine("   ,REPORT_DATE ");
                sb.AppendLine("   ,PRODUCT_TYPE ");
                sb.AppendLine("   ,CONTROL_NO ");
                sb.AppendLine("   ,CONTRACT_NO ");
                sb.AppendLine("   ,ESCALATION_RESPONSE ");
                sb.AppendLine("  ) VALUES (");
                sb.AppendLine("  " + id);
                sb.AppendLine("  ,'" + dt.Rows[0]["REGIST_DATE"].ToString() + "'");
                sb.AppendLine("  ,'" + dt.Rows[0]["PRODUCT_TYPE"].ToString() + "'");
                sb.AppendLine("  ,'" + dt.Rows[0]["CONTROL_NO"].ToString() + "'");
                sb.AppendLine("  ,'" + dt.Rows[0]["CONTRACT_NO"].ToString() + "'");
                sb.AppendLine("  ,'" + response + "'");                
                sb.AppendLine(")");
                
                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);
                
                //コミット
                Commit();                
            }
            catch (Exception ex)
            {
                //ロールバック
                Rollback();
                throw new Exception("回答_TEMPテーブルデータ登録処理：" + ex.Message, ex);
            }
            finally
            {
                _logger.Info("回答_TEMPテーブルデータ登録 終了");
            }
        }
        #endregion

        #endregion

        #region "UPDATE"

        #region "エスカレテーブルデータ更新"
        public void Update_T_ESCALATION(string updateStatus, string registDate, string controlNo, string userName, string response)
        {
            try
            {
                _logger.Info("エスカレテーブルデータ更新 開始");
                _logger.Info("〇update_T_ESCALATION");

                StringBuilder sql = new StringBuilder();

                _logger.Info($"エスカレデータ 更新1行 STATUS：[{updateStatus}]、REGIST_DATE：[{registDate}]、RESPONSE_USER_NAME：[{userName}]、RETURN_PLACE：[{response}]、ESCALATION_RESPONSE：[{response}]");

                sql.AppendLine(" UPDATE T_ESCALATION ");
                sql.AppendLine("    SET ");
                sql.AppendLine("    STATUS = :STATUS ");
                sql.AppendLine("    ,RESPONSE_DATE = :RESPONSE_DATE ");
                sql.AppendLine("    ,RESPONSE_USER_NAME = :RESPONSE_USER_NAME ");
                sql.AppendLine("    ,RETURN_PLACE = :ESCALATION_RESPONSE ");
                sql.AppendLine("    ,ESCALATION_RESPONSE = :ESCALATION_RESPONSE ");
                sql.AppendLine(" WHERE ");
                sql.AppendLine("   CONTROL_NO = :CONTROL_NO ");

                _logger.Info("sql[" + Environment.NewLine + sql + "]");

                DataTable dt = new DataTable();

                using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
                {
                    cmd.Parameters.Add(":STATUS", updateStatus);
                    cmd.Parameters.Add(":RESPONSE_DATE", registDate);
                    cmd.Parameters.Add(":RESPONSE_USER_NAME", userName);
                    cmd.Parameters.Add(":ESCALATION_RESPONSE", response);
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
                //LogDataTable(dt);

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

        #region 回答_TEMPテーブルデータ削除
        public void Delete_T_RESPONSE_TMP()
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("回答_TEMPテーブルデータ削除 開始");
            _logger.Info("〇delete_T_RESPONSE_TMP");
            try
            {
                sb.AppendLine(" DELETE FROM T_RESPONSE_TMP ");

                sql = sb.ToString();
                _logger.Info("sql[" + Environment.NewLine + sql + "]");
                tbl = base.Fill(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("回答_TEMPテーブル削除処理：" + ex.Message, ex);
            }
            finally
            {
                _logger.Info("管回答_TEMPテーブルデータ削除 終了");
            }

        }
        #endregion

        #endregion
    }
}
