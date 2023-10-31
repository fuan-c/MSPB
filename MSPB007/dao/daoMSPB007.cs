using dnp.nulcommon.dao;
using log4net;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MSPB.MSPB007.dao
{
    class daoMSPB007 : DaoBase
    {
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string UserId { get; set; }

        public bool LogDbSelect { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        public daoMSPB007(string userId, string name)
            : base(name)
        {
            UserId = userId;
        }
        private void LogDataTable(DataTable dt)
        {
            if (this.LogDbSelect)
            {
                StringBuilder sb = new StringBuilder();

                List<string> lstColumnTitles = new List<string>();
                foreach (DataColumn col in dt.Columns)
                {
                    lstColumnTitles.Add(col.ColumnName);
                }
                sb.AppendLine(string.Join("\t", lstColumnTitles));

                foreach (DataRow row in dt.Rows)
                {
                    sb.AppendLine(string.Join("\t", row.ItemArray.Select(item => Convert.IsDBNull(item) ? "<Null>" : item.ToString())));
                }
                this.logger.Debug(dt.TableName + Environment.NewLine + sb.ToString());
            }
        }

        /// <summary>
        /// 追跡番号取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TrackingNumberEnity> SelectT_TRACKING_NUMBER()
        {
            logger.Debug("〇SelectT_TRACKING_NUMBER");

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("  ID ");
            sql.Append("  , TRACKING_NO ");
            sql.Append("FROM ");
            sql.Append("  T_MS_YUU_TRACKING_NUMBER ");
            sql.Append("WHERE ");
            sql.Append("  USE_DATE IS NULL ");
            sql.Append("ORDER BY ");
            sql.Append(" ID DESC ");

            DataTable dt = new DataTable();
            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                this.logger.Debug(cmd.CommandText);
                foreach (OracleParameter prm in cmd.Parameters)
                {
                    this.logger.DebugFormat("{0}[{1}]", prm.ParameterName, prm.Value == null ? "<Null>" : prm.Value.ToString());
                }

                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            LogDataTable(dt);


            return dt.AsEnumerable().Select(row => new TrackingNumberEnity(row));
        }

        /// <summary>
        /// 追跡番号ID最大値取得
        /// </summary>
        /// <returns></returns>
        public int getTrackingNumberMaxID()
        {

            logger.Debug("〇SelectT_TRACKING_NUMBER");

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("  MAX(ID) AS ID ");
            sql.Append("FROM ");
            sql.Append("  T_MS_YUU_TRACKING_NUMBER ");

            DataTable dt = new DataTable();
            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                this.logger.Debug(cmd.CommandText);
                foreach (OracleParameter prm in cmd.Parameters)
                {
                    this.logger.DebugFormat("{0}[{1}]", prm.ParameterName, prm.Value == null ? "<Null>" : prm.Value.ToString());
                }

                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            LogDataTable(dt);

            return !string.IsNullOrEmpty(dt.Rows[0]["ID"].ToString()) ?
                int.Parse(dt.Rows[0]["ID"].ToString()) : 0;

        }

        /// <summary>
        /// 追跡番号範囲取得
        /// </summary>
        /// <param name="fromNo"></param>
        /// <param name="toNo"></param>
        /// <returns></returns>
        public IEnumerable<TrackingNumberEnity> SelectT_TRACKING_NUMBER(string fromNo, string toNo)
        {
            logger.Debug("〇SelectT_TRACKING_NUMBER");

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("  A.TRACKING_NO  ");
            sql.Append("FROM ");
            sql.Append("  (  ");
            sql.Append("    SELECT ");
            sql.Append("      SUBSTR(REPLACE (TRACKING_NO, 'a', ''), 1, 11) AS TRACKING_NO  ");
            sql.Append("    FROM ");
            sql.Append("  T_MS_YUU_TRACKING_NUMBER ");
            sql.Append("  ) A ");
            sql.Append("WHERE ");
            sql.Append("  A.TRACKING_NO >= :FROM_TRACKING_NO ");
            sql.Append("  AND A.TRACKING_NO <= :TO_TRACKING_NO ");

            DataTable dt = new DataTable();
            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":FROM_TRACKING_NO", fromNo);
                cmd.Parameters.Add(":TO_TRACKING_NO", toNo);
                this.logger.Debug(cmd.CommandText);
                foreach (OracleParameter prm in cmd.Parameters)
                {
                    this.logger.DebugFormat("{0}[{1}]", prm.ParameterName, prm.Value == null ? "<Null>" : prm.Value.ToString());
                }

                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            LogDataTable(dt);

            return dt.AsEnumerable().Select(row => new TrackingNumberEnity(row));

        }

        /// <summary>
        /// 追跡番号削除
        /// </summary>
        /// <param name="date"></param>
        public void DeleteT_TRACKING_NUMBER(string date)
        {

            logger.Debug("〇DeleteT_TRACKING_NUMBER");

            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE ");
            sql.Append("FROM ");
            sql.Append("  T_MS_YUU_TRACKING_NUMBER ");
            sql.Append("WHERE ");
            sql.Append("  USE_DATE < :USE_DATE ");

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":USE_DATE", date);
                this.logger.Debug(cmd.CommandText);
                foreach (OracleParameter prm in cmd.Parameters)
                {
                    this.logger.DebugFormat("{0}[{1}]", prm.ParameterName, prm.Value == null ? "<Null>" : prm.Value.ToString());
                }

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 処理履歴データの最大ID取得
        /// </summary>
        /// <returns></returns>
        public int getProcessHistoryMaxSeqNo()
        {
            logger.Debug("〇getProcessHistoryMaxSeqNo");

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("MAX(SEQ_NO) AS SEQ_NO ");
            sql.Append("FROM ");
            sql.Append("T_PROCESS_HISTORY");
            DataTable dt = new DataTable();

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {

                this.logger.Debug(cmd.CommandText);
                foreach (OracleParameter prm in cmd.Parameters)
                {
                    this.logger.DebugFormat("{0}[{1}]", prm.ParameterName, prm.Value == null ? "<Null>" : prm.Value.ToString());
                }

                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            LogDataTable(dt);

            return
                !string.IsNullOrEmpty(dt.Rows[0]["SEQ_NO"].ToString()) ?
                int.Parse(dt.Rows[0]["SEQ_NO"].ToString()) : 0;
        }
    }
}
