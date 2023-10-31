using log4net;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Configuration;

namespace dnp.nulcommon.dao
{
    /// <summary>
    /// テーブルエンティティインターフェース
    /// </summary>
    public interface IDbTableEntity
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// プライマリーキー
        /// </summary>
        IEnumerable<string> PrimaryKeys { get; }

        /// <summary>
        /// カラム
        /// </summary>
        IEnumerable<string> Columns { get; }

        /// <summary>
        /// エンティティ追加
        /// </summary>
        /// <param name="conn">OracleConnection</param>
        int InsertEntity(OracleConnection conn);

        /// <summary>
        /// エンティティ更新
        /// </summary>
        /// <param name="conn">OracleConnection</param>
        /// <param name="isUpdateNull">Null項目更新可否(falseの場合、nullは更新対象外)</param>
        int UpdateEntity(OracleConnection conn, bool isUpdateNull = false);

        /// <summary>
        /// エンティティ追加更新
        /// </summary>
        /// <param name="conn">OracleConnection</param>
        /// <param name="isUpdateNull">Null項目更新可否(falseの場合、nullは更新対象外)</param>
        int UpdateInsertEntity(OracleConnection conn, bool isUpdateNull = false);

        /// <summary>
        /// エンティティ削除
        /// </summary>
        /// <param name="conn">OracleConnection</param>
        int DeleteEntity(OracleConnection conn);
    }

    /// <summary>
    /// テーブルエンティティ基本クラス
    /// </summary>
    public abstract class DbTableEntity : DbEntity, IDbTableEntity
    {
        private ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region テーブル情報
        /// <summary>
        /// テーブル名
        /// </summary>
        public abstract string TableName { get; }

        /// <summary>
        /// プライマリキー
        /// </summary>
        public abstract IEnumerable<string> PrimaryKeys { get; }

        /// <summary>
        /// カラム
        /// </summary>
        public abstract IEnumerable<string> Columns { get; }
        #endregion

        /// <summary>
        /// Insert実行時追加設定カラム
        /// </summary>
        protected abstract IEnumerable<KeyValuePair<string, object>> AdditionalColumnsInsert { get; }

        /// <summary>
        /// Update実行時追加設定カラム
        /// </summary>
        protected abstract IEnumerable<KeyValuePair<string, object>> AdditionalColumnsUpdate { get; }

        #region コンストラクタ
        public DbTableEntity()
            : base()
        {
        }

        public DbTableEntity(DataRow row)
            : base(row)
        {
        }
        #endregion コンストラクタ

        public static string RUN_WORK_KIND = ConfigurationManager.AppSettings["WORK_KIND"]; // 実行作業種別 AD/MS

        /// <summary>
        /// エンティティ追加
        /// </summary>
        /// <param name="conn">OracleConnection</param>
        public int InsertEntity(OracleConnection conn)
        {

            List<KeyValuePair<string, object>> values = new List<KeyValuePair<string, object>>();

            IEnumerable<PropertyInfo> piAll = this.GetType().GetProperties();

            if (this.PrimaryKeys.Count(pk =>
                piAll.Count(prop => prop.Name == pk) < 1 ||//PKプロパティ未存在
                piAll.Where(prop => prop.Name == pk).Count(prop => prop.GetValue(this, null) == null) > 0//PKプロパティ値 NULL
                ) > 0)
            {
                //PK未設定の場合は更新しない
                return -1;
            }

            values.AddRange(this.Columns.Join(piAll, col => col.Replace("#", "NO"), pi => pi.Name, (col, pi) => new KeyValuePair<string, object>(col, new OracleParameter(pi.Name, pi.GetValue(this, null)))));
            values.AddRange(this.AdditionalColumnsInsert);

            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO ");
            if (this.TableName.IndexOf("T_TRACKING_NUMBER") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_YUU_TRACKING_NUMBER ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_YUU_TRACKING_NUMBER ");
                }
            }
            else if (this.TableName.IndexOf("T_RITAN_TRACKING_NUMBER") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_RITAN_TRACKING_NUMBER ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_RITAN_TRACKING_NUMBER ");
                }
            }
            else if (this.TableName.IndexOf("T_SHIPPING_QMS_TMP") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_SHIPPING_QMS_TMP ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_SHIPPING_QMS_TMP ");
                }
            }
            else if (this.TableName.IndexOf("T_SHIPPING_QMS") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_SHIPPING_QMS ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_SHIPPING_QMS ");
                }
            }
            else if (this.TableName.IndexOf("T_COLLECTION_QMS_TMP") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_COLLECTION_QMS_TMP ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_COLLECTION_QMS_TMP ");
                }
            }
            else if (this.TableName.IndexOf("T_COLLECTION_QMS") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_COLLECTION_QMS ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_COLLECTION_QMS ");
                }
            }
            else if (this.TableName.IndexOf("T_AD_SHIPPING_QMS_TMP") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_SHIPPING_QMS_TMP ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_SHIPPING_QMS_TMP ");
                }
            }
            else if (this.TableName.IndexOf("T_PACKING_LINE") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_PACKING_LINE ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_PACKING_LINE ");
                }
            }
            else
            {
                sql.Append(this.TableName);
            }
            sql.Append(" (");
            sql.Append(string.Join(",", values.Select(x => x.Key)));
            sql.Append(") VALUES (");
            sql.Append(string.Join(",", values.Select(x => x.Value is OracleParameter ? ":" + (x.Value as OracleParameter).ParameterName : x.Value.ToString())));
            sql.Append(")");

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), conn) { BindByName = true })
            {
                cmd.Parameters.AddRange(values.Where(x => x.Value is OracleParameter).Select(x => x.Value as OracleParameter).ToArray());
                log.Debug(cmd.CommandText);
                foreach (OracleParameter param in cmd.Parameters) log.DebugFormat("{0}[{1}]", param.ParameterName, param.Value == null ? "<NULL>" : param.Value);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// エンティティ更新
        /// </summary>
        /// <param name="conn">OracleConnection</param>
        /// <param name="isUpdateNull">Null項目更新可否(falseの場合、nullは更新対象外)</param>
        public int UpdateEntity(OracleConnection conn, bool isUpdateNull = false)
        {
            List<KeyValuePair<string, object>> setters = new List<KeyValuePair<string, object>>();
            List<string> criteria = new List<string>();
            List<OracleParameter> criteriaParams = new List<OracleParameter>();

            foreach (string pk in this.PrimaryKeys)
            {
                IEnumerable<PropertyInfo> eProp = this.GetType().GetProperties().Where(x => pk.Replace("#", "NO").Equals(x.Name));
                if (eProp.Count() <= 0 || eProp.First().GetValue(this, null) == null)
                {
                    //PK未設定の場合は更新しない
                    return -1;
                }
                criteria.Add(String.Format("{0}=:{1}", pk, eProp.First().Name));
                criteriaParams.Add(new OracleParameter(eProp.First().Name, eProp.First().GetValue(this, null)));
            }

            foreach (string col in this.Columns)
            {
                if (this.PrimaryKeys.Contains(col)) continue;

                foreach (PropertyInfo pi in this.GetType().GetProperties().Where(x => col.Replace("#", "NO").Equals(x.Name) && (isUpdateNull || x.GetValue(this, null) != null)))
                {
                    setters.Add(new KeyValuePair<string, object>(col, new OracleParameter(pi.Name, pi.GetValue(this, null))));
                }
            }
            if (setters.Count() <= 0) return -2;

            setters.AddRange(this.AdditionalColumnsUpdate);

            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE ");
            // 2021/11/08 修正 tokimori
            if (this.TableName.IndexOf("T_SHIPPING_QMS_TMP") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_SHIPPING_QMS_TMP ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_SHIPPING_QMS_TMP ");
                }
            }
            // 2021/11/08 修正 tokimori end
            else if (this.TableName.IndexOf("T_SHIPPING_QMS") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_SHIPPING_QMS ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_SHIPPING_QMS ");
                }
            }
            else if (this.TableName.IndexOf("T_TRACKING_REQUEST") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_TRACKING_REQUEST ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_RITAN_TRACKING_NUMBER ");
                }
            }
            // 2021/11/08 修正 tokimori
            else if (this.TableName.IndexOf("T_COLLECTION_QMS_TMP") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_COLLECTION_QMS_TMP ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_COLLECTION_QMS_TMP ");
                }
            }
            // 2021/11/08 修正 tokimori end
            else if (this.TableName.IndexOf("T_COLLECTION_QMS") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_COLLECTION_QMS ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_COLLECTION_QMS ");
                }
            }
            else if (this.TableName.IndexOf("T_ONBOARD_EQUIPMENT") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_ONBOARD_EQUIPMENT ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_ONBOARD_EQUIPMENT ");
                }
            }
            else if (this.TableName.IndexOf("T_CMT_SEND_DATA") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_SEND_DATA ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_SEND_DATA ");
                }
            }
            else if (this.TableName.IndexOf("T_PACKING_LINE") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_PACKING_LINE ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_PACKING_LINE ");
                }
            }
            else if (this.TableName.IndexOf("T_YUU_TRACKING_NUMBER") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_YUU_TRACKING_NUMBER ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_YUU_TRACKING_NUMBER ");
                }
            }
            else if (this.TableName.IndexOf("T_RITAN_TRACKING_NUMBER") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_RITAN_TRACKING_NUMBER ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_RITAN_TRACKING_NUMBER ");
                }
            }
            else if (this.TableName.IndexOf("T_SEND_DATA") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_SEND_DATA ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_SEND_DATA ");
                }
            }
            else if (this.TableName.IndexOf("T_COLLECTION_DATA") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_COLLECTION_DATA ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_COLLECTION_DATA ");
                }
            }
            else
            {
                sql.Append(this.TableName);
            }
            sql.Append(" SET ");
            sql.Append(string.Join(",", setters.Select(x => x.Key + "=" + (x.Value is OracleParameter ? ":" + (x.Value as OracleParameter).ParameterName : x.Value.ToString()))));
            sql.Append(criteria.Count() > 0 ? " WHERE " + string.Join(" AND ", criteria) : string.Empty);

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), conn) { BindByName = true })
            {
                cmd.Parameters.AddRange(setters.Where(x => x.Value is OracleParameter).Select(x => x.Value as OracleParameter).ToArray());
                cmd.Parameters.AddRange(criteriaParams.ToArray());
                log.Debug(cmd.CommandText);
                foreach (OracleParameter param in cmd.Parameters) log.DebugFormat("{0}[{1}]", param.ParameterName, param.Value == null ? "<NULL>" : param.Value);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// エンティティ追加更新
        /// </summary>
        /// <param name="conn">OracleConnection</param>
        /// <param name="isUpdateNull">Null項目更新可否(falseの場合、nullは更新対象外)</param>
        public int UpdateInsertEntity(OracleConnection conn, bool isUpdateNull = false)
        {
            List<KeyValuePair<string, object>> setters = new List<KeyValuePair<string, object>>();
            List<string> criteria = new List<string>();
            List<OracleParameter> criteriaParams = new List<OracleParameter>();

            foreach (string pk in this.PrimaryKeys)
            {
                IEnumerable<PropertyInfo> eProp = this.GetType().GetProperties().Where(x => pk.Replace("#", "NO").Equals(x.Name));
                if (eProp.Count() <= 0 || eProp.First().GetValue(this, null) == null)
                {
                    //PK未設定の場合は更新しない
                    return -1;
                }
                criteria.Add(String.Format("{0}=:{1}", pk, eProp.First().Name));
                criteriaParams.Add(new OracleParameter(eProp.First().Name, eProp.First().GetValue(this, null)));
            }

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("COUNT(*)");
            sql.Append(" FROM ");
            sql.Append(this.TableName);
            sql.Append(criteria.Count() > 0 ? " WHERE " + string.Join(" AND ", criteria) : string.Empty);

            decimal cnt = 0;
            using (OracleCommand cmd = new OracleCommand(sql.ToString(), conn) { BindByName = true })
            {
                cmd.Parameters.AddRange(criteriaParams.ToArray());
                log.Debug(cmd.CommandText);
                foreach (OracleParameter param in cmd.Parameters) log.DebugFormat("{0}[{1}]", param.ParameterName, param.Value == null ? "<NULL>" : param.Value);
                cnt = (decimal)cmd.ExecuteScalar();
            }

            if (cnt > 0)
            {
                return UpdateEntity(conn, isUpdateNull);
            }
            else
            {
                return InsertEntity(conn);
            }
        }
        
        /// <summary>
        /// エンティティ削除
        /// </summary>
        /// <param name="conn">OracleConnection</param>
        public int DeleteEntity(OracleConnection conn)
        {
            List<string> criteria = new List<string>();
            List<OracleParameter> criteriaParams = new List<OracleParameter>();

            foreach (string pk in this.PrimaryKeys)
            {
                IEnumerable<PropertyInfo> eProp = this.GetType().GetProperties().Where(x => pk.Replace("#", "NO").Equals(x.Name));
                if (eProp.Count() <= 0 || eProp.First().GetValue(this, null) == null)
                {
                    //PK未設定の場合は更新しない
                    return -1;
                }
                criteria.Add(String.Format("{0}=:{1}", pk, eProp.First().Name));
                criteriaParams.Add(new OracleParameter(eProp.First().Name, eProp.First().GetValue(this, null)));
            }

            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE");
            sql.Append(" FROM ");
            if (this.TableName.IndexOf("T_SHIPPING_QMS_TMP") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_SHIPPING_QMS_TMP ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_SHIPPING_QMS_TMP ");
                }
            }
            else if (this.TableName.IndexOf("T_TRACKING_REQUEST") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_TRACKING_REQUEST ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_RITAN_TRACKING_NUMBER ");
                }
            }
            else if (this.TableName.IndexOf("T_COLLECTION_QMS_TMP") >= 0)
            {
                if (RUN_WORK_KIND.ToString() == "AD")
                {
                    sql.Append("  T_AD_COLLECTION_QMS_TMP ");
                }
                else if (RUN_WORK_KIND.ToString() == "MS")
                {
                    sql.Append("  T_MS_COLLECTION_QMS_TMP ");
                }
            }
            else
            {
                sql.Append(this.TableName);
            }
            sql.Append(criteria.Count() > 0 ? " WHERE " + string.Join(" AND ", criteria) : string.Empty);

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), conn) { BindByName = true })
            {
                cmd.Parameters.AddRange(criteriaParams.ToArray());
                log.Debug(cmd.CommandText);
                foreach (OracleParameter param in cmd.Parameters) log.DebugFormat("{0}[{1}]", param.ParameterName, param.Value == null ? "<NULL>" : param.Value);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
