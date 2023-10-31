using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Text;
using System.Linq;
using log4net;

namespace MSPB.Common.Dao
{
    public class daoBase : IDisposable
    {
        #region 変数
        private string _connectionString = string.Empty;

        private OracleConnection _connection;

        private OracleTransaction _transaction;

        private int _commandTimeout = 0;
        public bool LogDbSelect { get; set; }

        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region プロパティ
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public OracleConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        public OracleTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        public int CommandTimeout
        {
            get { return _commandTimeout; }
            set { _commandTimeout = value; }
        }
        #endregion

        #region コンストラクタ
        public daoBase()
        {

        }

        public daoBase(string name)
        {
            try
            {
                ConnectionStringSettings settings;
                settings = ConfigurationManager.ConnectionStrings[name];

                ConnectionString = settings.ConnectionString;
                if (ConnectionString != string.Empty)
                {
                
                        Connection = new OracleConnection();
                        Connection.ConnectionString = ConnectionString;
                        Connection.Open();
                }
            }
            catch (Exception ex)
            {
                this.logger.Info("DB接続でエラーが発生しました。" + ex.Message);
                throw new Exception(ex.Message, ex);
            }

        }
        #endregion


        public void LogDataTable(DataTable dt)
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

        #region コネクション
        public void dbConnection(string name)
        {
            try
            {
                ConnectionStringSettings settings;
                settings = ConfigurationManager.ConnectionStrings[name];

                ConnectionString = settings.ConnectionString;
                if (ConnectionString != string.Empty)
                {
                    Connection = new OracleConnection();
                    Connection.ConnectionString = ConnectionString;
                    Connection.Open();
                }
            }
            catch(Exception ex)
            {
                this.logger.Info("DB接続でエラーが発生しました。" + ex.Message);
                throw new Exception(ex.Message, ex);
            }
            

        }
        #endregion

        #region トランザクション開始
        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }
        #endregion
        #region コミット
        public void Commit()
        {
            Transaction.Commit();
        }
        #endregion
        #region ロールバック
        public void Rollback()
        {
            Transaction.Rollback();
        }
        #endregion

        #region 検索処理
        public DataTable Fill(string sql, System.Collections.ArrayList parm = null)
        {
            DataTable tbl = new DataTable();
            OracleCommand cmd;

            cmd = Command(sql, parm);

            using(OracleDataAdapter adapter = new OracleDataAdapter(cmd))
            {
                adapter.Fill(tbl);
            }

            cmd.Dispose();

            return tbl;

        }
        #endregion

        #region 検索処理（件数取得）
        public int FillCount(string sql, System.Collections.ArrayList parm = null)
        {
            DataTable tbl = new DataTable();
            OracleCommand cmd;
            int count = 0;

            cmd = Command(sql, parm);

            using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
            {
                adapter.Fill(tbl);
            }
            if (tbl.Rows.Count > 0)
                count = int.Parse(tbl.Rows[0][0].ToString());

            cmd.Dispose();

            return count;

        }
        #endregion

        #region 更新処理
        public void Update(string sql, System.Collections.ArrayList parm = null)
        {
            DataTable tbl = new DataTable();
            OracleCommand cmd;

            cmd = Command(sql, parm);

            cmd.ExecuteNonQuery();

            cmd.Dispose();

        }
        public void ExecuteNonQuery(string sql)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = Connection;
            cmd.CommandText = sql;
            cmd.CommandTimeout = CommandTimeout;

            cmd.ExecuteNonQuery();

            cmd.Dispose();
        }

        #endregion

        #region コマンド作成
        private OracleCommand Command(string sql, System.Collections.ArrayList parm = null)
        {
            OracleCommand cmd = new OracleCommand("", Connection);

            //cmd.CommandText = sql.Replace("?", ":0");
            cmd.CommandText = sql;
            cmd.CommandTimeout = CommandTimeout;
            if (parm != null)
            {
                foreach(Object obj in parm)
                {
                    OracleParameter op = new OracleParameter();
                    op.Value = obj;
                    cmd.Parameters.Add(op);
                }
            }

            return cmd;
        }
        #endregion

        #region クローズ
        public void Close()
        {
            Connection.Close();
            Connection.Dispose();
        }
        #endregion
        #region "Dispose"
        // <summary>
        // Dispose
        // </summary>
        // <remarks></remarks>
        //public void Dispose() Implements IDisposable.Dispose
        public void Dispose()
        {
            Close();
        }
        #endregion

    }

}
