using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using log4net;
using MSPB.Common.Dao;
using MSPB.MSPB003.logic;
using Oracle.ManagedDataAccess.Client;

namespace MSPB.MSPB003.dao
{
    class daofrmMSPB003 : daoBase
    {

        #region "変数"
        // log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        
        // コンストラクタ
        public daofrmMSPB003(string name)
        {
            dbConnection(name);
        }

        #region "SELECT"

        #region  エスカレテーブルより未承認済件数取得
        // エスカレテーブルより未承認のデータ取得
        public DataTable Select_NonApprovedCnt_T_ESCALATION(DateTime now)
        {
            _logger.Info("〇Select_NonApprovedCnt_T_ESCALATION");

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine(" CONTROL_NO ");
            sql.AppendLine(" FROM T_ESCALATION ");
            sql.AppendLine(" WHERE ");
            //sql.AppendLine("  ( STATUS = '2' AND ");
            //sql.AppendLine("    (ESCALATION_RESPONSE IN ('1','2')) ) ");
            sql.AppendLine("  STATUS = '2' ");
            sql.AppendLine("  OR ");
            sql.AppendLine("  ( STATUS IN ('0','1') AND ");
            sql.AppendLine("    STORAGE_PERIOD <= :TODAY ) ");            

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

        #region  エスカレテーブルより承認済データ取得
        // エスカレテーブルより承認済件数取得
        public DataTable Select_Approved_T_ESCALATION()
        {
            _logger.Info("〇Select_Approved_T_ESCALATION");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" ID ");
            sb.AppendLine(" ,REGIST_DATE ");
            sb.AppendLine(" ,PRODUCT_TYPE ");
            sb.AppendLine(" ,CONTROL_NO ");
            sb.AppendLine(" ,CONTRACT_NO ");
            sb.AppendLine(" ,STATUS ");
            sb.AppendLine(" ,ESCALATION_RESPONSE ");
            sb.AppendLine(" ,STORAGE_PERIOD ");
            sb.AppendLine(" FROM T_ESCALATION ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  STATUS IN ('3', '4') ");
            
            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return tbl;
        }
        #endregion

        #region  MSゆう追跡番号テーブルより追跡番号残数取得
        // エスカレテーブルより承認済件数取得
        public DataTable Select_TrackingNoCnt_T_MS_YUU_TRACKING_NUMBER()
        {
            _logger.Info("〇Select_TrackingNoCnt_T_MS_YUU_TRACKING_NUMBER");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" TRACKING_NO ");
            sb.AppendLine(" FROM T_MS_YUU_TRACKING_NUMBER ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  USE_DATE IS NULL ");            

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return tbl;
        }
        #endregion

        #region  エスカレテーブルより未承認済件数取得
        // エスカレテーブルより未承認のデータ取得
        public DataTable Select_ShippingDateCheck_T_MS_PACKING_LINE(string date)
        {
            _logger.Info("〇Select_ShippingDateCheck_T_MS_PACKING_LINE");

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine(" SHIPPING_DATE ");
            sql.AppendLine(" FROM T_MS_PACKING_LINE ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("  SHIPPING_DATE = :SHIPPING_DATE");

            DataTable dt = new DataTable();

            _logger.Info("sql[" + Environment.NewLine + sql + "]");

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":SHIPPING_DATE", date);

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

        #region  使用可能な追跡番号取得
        public TrackingNumberEntity Select_Usable_T_MS_YUU_TRACKING_NUMBER()
        {

            _logger.Debug("〇Select_Usable_T_MS_YUU_TRACKING_NUMBER");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" ID ");
            sb.AppendLine(" ,TRACKING_NO ");
            sb.AppendLine(" FROM T_MS_YUU_TRACKING_NUMBER ");            
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  ID = ( ");            
            sb.AppendLine("         SELECT ");
            sb.AppendLine("          MIN(ID) ");
            sb.AppendLine("          FROM T_MS_YUU_TRACKING_NUMBER ");            
            sb.AppendLine("          WHERE ");
            sb.AppendLine("           USE_DATE IS NULL ");
            sb.AppendLine("        ) ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return tbl.AsEnumerable().Select(row => new TrackingNumberEntity(row)).FirstOrDefault();
        }
        #endregion

        #region 発送QMSテーブルのMAX ID取得
        // 発送QMSテーブルのMAX ID取得
        public int Select_MaxID_T_MS_SHIPPING_QMS()
        {
            _logger.Info("〇Select_MaxID_T_MS_SHIPPING_QMS");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" MAX(ID) AS MAX_ID");
            sb.AppendLine(" FROM T_MS_SHIPPING_QMS ");            

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return string.IsNullOrEmpty(tbl.Rows[0]["MAX_ID"].ToString()) ?
                   0 : int.Parse(tbl.Rows[0]["MAX_ID"].ToString());
        }
        #endregion

        #region 梱包ラインテーブルのMAX ID取得
        // 梱包ラインテーブルのMAX ID取得
        public int Select_MaxID_T_MS_PACKING_LINE()
        {
            _logger.Info("〇Select_MaxID_T_MS_PACKING_LINE");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" MAX(ID) AS MAX_ID");
            sb.AppendLine(" FROM T_MS_PACKING_LINE ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            return string.IsNullOrEmpty(tbl.Rows[0]["MAX_ID"].ToString()) ?
                   0 : int.Parse(tbl.Rows[0]["MAX_ID"].ToString());
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
            sql.AppendLine(" ,ES.ITEM_NAME ");
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

        #region 仕分け番号取得
        /// <summary>
        /// 仕分け番号取得
        /// </summary>
        /// <param name="postalcode"></param>
        /// <returns></returns>
        public DataTable Select_M_SORTING_CODE(string postalcode)
        {
            _logger.Debug("〇Select_M_SORTING_CODE");

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("  POSTAL_CODE ");
            sql.Append("  ,SORTING_NO ");
            sql.Append("FROM ");
            sql.Append("  M_SORTING_CODE ");
            sql.Append("WHERE ");
            sql.Append("  POSTAL_CODE = :POSTAL_CODE ");

            DataTable dt = new DataTable();

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":POSTAL_CODE", postalcode);
                _logger.Debug(cmd.CommandText);
                foreach (OracleParameter prm in cmd.Parameters)
                {
                    _logger.DebugFormat("{0}[{1}]", prm.ParameterName, prm.Value == null ? "<Null>" : prm.Value.ToString());
                }

                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            LogDataTable(dt);

            return dt;
        }
        #endregion

        #endregion

        #region "INSERT"

        #region 発送QMSテーブルデータ登録
        public void Insert_ContractorRtn_T_MS_SHIPPING_QMS(clsMsShippingQmsData qmsData)
        {
            try
            {

                _logger.Info("発送QMSテーブルデータ登録 開始");
                _logger.Info("〇Insert_ContractorRtn_T_MS_SHIPPING_QMS");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                _logger.Info($"発送QMSテーブル 登録1行 ID：[{qmsData.ID}]、SHIPPING_DATE：[{qmsData.SHIPPING_DATE}]、DELIVERY_SLIP_CONTROL_NO：[{qmsData.DELIVERY_SLIP_CONTROL_NO}]、CONTACT_NO：[{qmsData.CONTACT_NO}]、CONTROL_NO：[{qmsData.CONTROL_NO}]、CONTRACT_NO：[{qmsData.CONTRACT_NO}]、REGIST_DATE：[{qmsData.REGIST_DATE}]、REGIST_USER_NAME：[{qmsData.REGIST_USER_NAME}]");

                sb.AppendLine(" INSERT INTO T_MS_SHIPPING_QMS( ");
                sb.AppendLine("    ID ");
                sb.AppendLine("    , SHIPPING_DATE ");
                sb.AppendLine("    , DELIVERY_SLIP_CONTROL_NO ");
                sb.AppendLine("    , CONTACT_NO ");
                sb.AppendLine("    , CONTROL_NO ");
                sb.AppendLine("    , CONTRACT_NO ");
                sb.AppendLine("    , REGIST_DATE ");
                sb.AppendLine("    , REGIST_USER_NAME ");
                sb.AppendLine(" ) VALUES (  ");
                sb.AppendLine("    " + qmsData.ID);
                sb.AppendLine("  ,'" + qmsData.SHIPPING_DATE + "'");
                sb.AppendLine("  ,'" + qmsData.DELIVERY_SLIP_CONTROL_NO + "'");
                sb.AppendLine("  ,'" + qmsData.CONTACT_NO + "'");
                sb.AppendLine("  ,'" + qmsData.CONTROL_NO + "'");
                sb.AppendLine("  ,'" + qmsData.CONTRACT_NO + "'");
                sb.AppendLine("  ,SYSDATE");
                sb.AppendLine("  ,'" + qmsData.REGIST_USER_NAME + "' )");


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
                _logger.Info("発送QMSテーブルデータ登録 終了");
            }
        }
        #endregion

        #region 梱包ラインテーブルデータ登録
        public void Insert_ContractorRtn_T_MS_PACKING_LINE(PackingLineEntity entity)
        {
            try
            {

                _logger.Info("梱包ラインテーブルデータ登録 開始");
                _logger.Info("〇Insert_ContractorRtn_T_MS_PACKING_LINE");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                _logger.Info($"梱包ラインテーブル 登録1行 ID：[{entity.ID}]、SHIPPING_DATE：[{entity.SHIPPING_DATE}]、INSURANCE_CODE：[{entity.INSURANCE_CODE}]、RETURN_PLACE：[{entity.RETURN_PLACE}]、PACKING_COUNT：[{entity.PACKING_COUNT}]、REGIST_DATE：[{entity.REGIST_DATE}]、REGIST_USER_NAME：[{entity.REGIST_USER_NAME}]");

                sb.AppendLine(" INSERT INTO T_MS_PACKING_LINE( ");
                sb.AppendLine("    ID ");
                sb.AppendLine("    , SHIPPING_DATE ");
                sb.AppendLine("    , INSURANCE_CODE ");
                sb.AppendLine("    , RETURN_PLACE ");
                sb.AppendLine("    , PACKING_COUNT ");
                sb.AppendLine("    , REGIST_DATE ");                
                sb.AppendLine("    , REGIST_USER_NAME ");
                sb.AppendLine(" ) VALUES (  ");
                sb.AppendLine("    " + entity.ID);
                sb.AppendLine("  ,'" + entity.SHIPPING_DATE + "'");
                sb.AppendLine("  ,'" + entity.INSURANCE_CODE + "'");
                sb.AppendLine("  ,'" + entity.RETURN_PLACE + "'");
                sb.AppendLine("  ," + entity.PACKING_COUNT);
                sb.AppendLine("  ,'" + entity.REGIST_DATE + "'");                
                sb.AppendLine("  ,'" + entity.REGIST_USER_NAME + "' )");

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
                _logger.Info("梱包ラインテーブルデータ登録 終了");
            }
        }
        #endregion

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

        #region 使用済みの追跡番号更新
        public void Update_T_MS_YUU_TRACKING_NUMBER(string trgTrackingNo)
        {
            try
            {

                _logger.Info("MSゆう追跡番号テーブルデータ更新 開始");
                _logger.Info("〇Update_T_MS_YUU_TRACKING_NUMBER");

                StringBuilder sql = new StringBuilder();

                _logger.Info($"MSゆう追跡番号テーブル 更新1行 USE_DATE：[{DateTime.Now.ToString("yyyyMMdd")}]");

                sql.AppendLine(" UPDATE T_MS_YUU_TRACKING_NUMBER ");
                sql.AppendLine("    SET ");
                sql.AppendLine("    USE_DATE = :USE_DATE ");                
                sql.AppendLine(" WHERE ");
                sql.AppendLine("   TRACKING_NO = :TRACKING_NO ");

                _logger.Info("sql[" + Environment.NewLine + sql + "]");

                DataTable dt = new DataTable();

                using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
                {
                    cmd.Parameters.Add(":USE_DATE", DateTime.Now.ToString("yyyyMMdd"));
                    cmd.Parameters.Add(":TRACKING_NO", trgTrackingNo);                    

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
                _logger.Info("MSゆう追跡番号テーブルデータ更新 終了");
            }
        }
        #endregion

        #region エスカレテーブルデータ更新
        public void Update_ShippingSlip_T_ESCALATION(string shippingDate, string status, string trgData)
        {
            try
            {
                
                _logger.Info("エスカレテーブルデータ更新 開始");
                _logger.Info("〇Update_ShippingSlip_T_ESCALATION");

                StringBuilder sql = new StringBuilder();

                _logger.Info($"エスカレテーブル 更新1行 STATUS：[5]、SHIPPING_DATE：[{shippingDate}]");

                sql.AppendLine(" UPDATE T_ESCALATION ");
                sql.AppendLine("    SET ");
                sql.AppendLine("    STATUS = :STATUS ");
                sql.AppendLine("    ,SHIPPING_DATE = :SHIPPING_DATE ");                
                sql.AppendLine(" WHERE ");
                sql.AppendLine("   CONTROL_NO = :CONTROL_NO ");

                _logger.Info("sql[" + Environment.NewLine + sql + "]");

                DataTable dt = new DataTable();

                using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
                {
                    cmd.Parameters.Add(":STATUS", status);                    
                    cmd.Parameters.Add(":SHIPPING_DATE", shippingDate);                    
                    cmd.Parameters.Add(":CONTROL_NO", trgData);

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
