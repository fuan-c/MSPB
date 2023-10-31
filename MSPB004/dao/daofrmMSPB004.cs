using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using log4net;
using MSPB.Common.Dao;
using Oracle.ManagedDataAccess.Client;

namespace MSPB.MSPB004.dao
{
    class daofrmMSPB004 : daoBase
    {

        #region "変数"

        // ユーザーID
        string _userId = string.Empty;

        // log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        
        // コンストラクタ
        public daofrmMSPB004(string name)
        {
            dbConnection(name);
        }

        #region "SELECT"

        #region  梱包ラインテーブルより出荷日取得
        // 梱包ラインテーブルより出荷日取得
        public DataTable Select_ShippingDate_T_MS_PACKING_LINE()
        {
            _logger.Info("〇Select_ShippingDate_T_MS_PACKING_LINE");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" SHIPPING_DATE, ");
            sb.AppendLine(" COUNT(SHIPPING_DATE) ");
            sb.AppendLine(" FROM T_MS_PACKING_LINE ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  SHIPPING_COMPLEATE_DATE IS NULL ");
            sb.AppendLine("  AND RETURN_PLACE = '1' ");        // 返却先が「1:契約者返却」
            sb.AppendLine(" GROUP BY SHIPPING_DATE ");
            sb.AppendLine(" ORDER BY SHIPPING_DATE ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return tbl;
        }
        #endregion

        #region  梱包ラインテーブルより出荷日取得
        // 梱包ラインテーブルより出荷日取得
        public DataTable Select_TrgShippingData_T_MS_PACKING_LINE(string shippingDate)
        {
            _logger.Info("〇Select_TrgShippingData_T_MS_PACKING_LINE");

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine(" PL.ID ");
            sql.AppendLine(" ,PL.SHIPPING_DATE ");
            sql.AppendLine(" ,PL.RETURN_PLACE ");
            sql.AppendLine(" ,PL.PACKING_COUNT ");
            sql.AppendLine(" ,PL.PACKING_STATUS ");
            sql.AppendLine(" ,PL.SHIPPING_COMPLEATE_DATE ");
            sql.AppendLine(" ,ER.RESPONSE_TEXT ");
            sql.AppendLine("FROM T_MS_PACKING_LINE PL");
            sql.AppendLine("LEFT JOIN T_ESCALATION_RESPONSE ER");
            sql.AppendLine(" ON ER.RESPONSE_CODE = PL.RETURN_PLACE");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("  SHIPPING_COMPLEATE_DATE IS NULL ");
            sql.AppendLine("  AND RETURN_PLACE = '1' ");        // 返却先「1:契約者返却」
            sql.AppendLine("  AND SHIPPING_DATE = :SHIPPING_DATE ");
            sql.AppendLine(" ORDER BY ID ");

            DataTable dt = new DataTable();

            _logger.Info("sql[" + Environment.NewLine + sql + "]");

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":SHIPPING_DATE", shippingDate);

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

        #region  会社情報取得
        /// <summary>
        /// 会社情報取得
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public IEnumerable<CompanyEntity> Select_M_COMPANY(string companyCode)
        {
            _logger.Debug("〇Select_M_COMPANY");

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("  COMPANY_CODE ");
            sql.Append("  , COMPANY_RYAKU ");
            sql.Append("  , COMPANY_NAME_RYAKU ");
            sql.Append("  , FORMAL_NAME ");
            sql.Append("  , POSTAL_CODE ");
            sql.Append("  , ADDRESS ");
            sql.Append("  , YUPACK_CUSTOMER_NO ");
            sql.Append("  , RETURNPACK_CUSTOMER_NO ");
            sql.Append("  , YUPACKET_CUSTOMER_NO ");
            sql.Append("  , REGULAR_MAIL_COUSTOMER_NO ");
            sql.Append("FROM ");
            sql.Append("  M_COMPANY ");
            sql.Append("WHERE ");
            sql.Append("  COMPANY_CODE = :COMPANY_CODE ");

            DataTable dt = new DataTable();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":COMPANY_CODE", companyCode);

                foreach (OracleParameter prm in cmd.Parameters)
                {
                    this._logger.InfoFormat("{0}[{1}]", prm.ParameterName, prm.Value == null ? "<Null>" : prm.Value.ToString());
                }

                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt.AsEnumerable().Select(row => new CompanyEntity(row));
        }
        #endregion

        #region  MS発送QMSテーブルより指定された「出荷日」のデータ取得
        // MS発送QMSテーブルより指定された「出荷日」のデータ取得
        public DataTable Select_ShippingDate_T_MS_SHIPPING_QMS(string trgDate)
        {
            _logger.Info("〇Select_ShippingDate_T_MS_SHIPPING_QMS");

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine(" QMS.ID ");
            sql.AppendLine(" ,QMS.SHIPPING_DATE ");
            sql.AppendLine(" ,QMS.DELIVERY_SLIP_CONTROL_NO ");
            sql.AppendLine(" ,QMS.CONTACT_NO ");
            sql.AppendLine(" ,QMS.CONTROL_NO ");
            sql.AppendLine(" ,QMS.CONTRACT_NO ");
            sql.AppendLine(" ,ES.REGIST_DATE ");
            sql.AppendLine(" ,ES.SEND_DEST_POSTAL_CODE ");
            sql.AppendLine(" ,ES.SEND_DEST_ADDRESS ");
            sql.AppendLine(" ,ES.SEND_DEST_NAME ");
            sql.AppendLine(" ,ES.SEND_DEST_TEL_NO ");
            sql.AppendLine(" FROM T_MS_SHIPPING_QMS QMS ");
            sql.AppendLine(" INNER JOIN T_ESCALATION ES ");
            sql.AppendLine("    ON ES.CONTROL_NO = QMS.CONTROL_NO ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("    QMS.SHIPPING_DATE = :SHIPPING_DATE ");
            sql.AppendLine(" ORDER BY QMS.ID ");

            DataTable dt = new DataTable();

            _logger.Info("sql[" + Environment.NewLine + sql + "]");

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":SHIPPING_DATE", trgDate);

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

        #region 処理履歴テーブルのMAX ID取得
        // 処理履歴テーブルのMAX ID取得
        public int Select_MaxSeqNo_T_PROCESS_HISTORY()
        {
            _logger.Info("〇Select_MaxSeqNo_T_PROCESS_HISTORY");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" MAX(SEQ_NO) AS MAX_SEQ_NO");
            sb.AppendLine(" FROM T_PROCESS_HISTORY ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
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
            try
            {

                _logger.Info("処理履歴テーブルデータ登録 開始");
                _logger.Info("〇Insert_T_PROCESS_HISTORY");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                _logger.Info($"処理履歴テーブル 登録1行 SEQ_NO：[{entity.SEQ_NO}]、PROCESS_TEXT：[{entity.PROCESS_TEXT}]、OUTPUT_FILE_NAME：[{entity.OUTPUT_FILE_NAME}]、OUTPUT_COUNT：[{entity.OUTPUT_COUNT}]、UPDATE_USER：[{entity.UPDATE_USER}]");

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

                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

                return;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                _logger.Info("処理履歴テーブルデータ登録 終了");
            }
        }
        #endregion
        
        #endregion

        #region "UPDATE"
        
        #region 梱包ラインテーブル更新処理

        public void Update_ContractorRtn_T_MS_PACKING_LINE(string shippingCmpDate, string id)
        {
            try
            {   
                _logger.Info("〇Update_ContractorRtn_T_MS_PACKING_LINE");

                StringBuilder sql = new StringBuilder();

                _logger.Info($"梱包ラインテーブル 更新1行 SHIPPING_COMPLEATE_DATE：[{shippingCmpDate}]");

                sql.AppendLine(" UPDATE T_MS_PACKING_LINE ");
                sql.AppendLine("    SET ");                
                sql.AppendLine("    SHIPPING_COMPLEATE_DATE = :SHIPPING_COMPLEATE_DATE ");
                sql.AppendLine(" WHERE ");
                sql.AppendLine("   ID = :ID ");

                _logger.Info("sql[" + Environment.NewLine + sql + "]");

                DataTable dt = new DataTable();

                using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
                {                    
                    cmd.Parameters.Add(":SHIPPING_COMPLEATE_DATE", shippingCmpDate);
                    cmd.Parameters.Add(":ID", id);

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
        }
        #endregion

        #region 発送QMSテーブル更新処理

        public void Update_ContractorRtn_T_MS_SHIPPING_QMS(string shippingCmpDate, string shippingDate)
        {
            try
            {
                _logger.Info("〇Update_ContractorRtn_T_MS_SHIPPING_QMS");

                StringBuilder sql = new StringBuilder();

                _logger.Info($"発送QMSテーブル 更新1行 SHIPPING_COMPLEATE_DATE：[{shippingCmpDate}]");

                sql.AppendLine(" UPDATE T_MS_SHIPPING_QMS ");
                sql.AppendLine("    SET ");
                sql.AppendLine("    SHIPPING_COMPLEATE_DATE = :SHIPPING_COMPLEATE_DATE ");
                sql.AppendLine(" WHERE ");
                sql.AppendLine("   SHIPPING_DATE = :SHIPPING_DATE ");                

                _logger.Info("sql[" + Environment.NewLine + sql + "]");

                DataTable dt = new DataTable();

                using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
                {
                    cmd.Parameters.Add(":SHIPPING_COMPLEATE_DATE", shippingCmpDate);                    
                    cmd.Parameters.Add(":SHIPPING_DATE", shippingDate);                    

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
        }
        #endregion

        #region エスカレテーブルデータ更新
        public void Update_ContractorRtn_T_ESCALATION(string status, string trackingNo, string controlNo)
        {
            try
            {   
                _logger.Info("〇Update_ContractorRtn_T_ESCALATION");

                StringBuilder sql = new StringBuilder();

                _logger.Info($"エスカレテーブル 更新1行 STATUS：[{status}]、TRACKING_NO：[{trackingNo}]");

                sql.AppendLine(" UPDATE T_ESCALATION ");
                sql.AppendLine("    SET ");
                sql.AppendLine("    STATUS = :STATUS ");
                sql.AppendLine("    ,TRACKING_NO = :TRACKING_NO ");
                sql.AppendLine(" WHERE ");
                sql.AppendLine("   CONTROL_NO = :CONTROL_NO ");

                _logger.Info("sql[" + Environment.NewLine + sql + "]");

                DataTable dt = new DataTable();

                using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
                {
                    cmd.Parameters.Add(":STATUS", status);
                    cmd.Parameters.Add(":TRACKING_NO", trackingNo);
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
