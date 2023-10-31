using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace dnp.nulcommon.dao
{
    /// <summary>
    /// DAO基本クラスインターフェース
    /// </summary>
    public interface IDaoBase : IDisposable
    {
        /// <summary>
        /// 接続文字列
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// OracleConnection
        /// </summary>
        OracleConnection Connection { get; }

        /// <summary>
        /// OracleTransaction
        /// </summary>
        OracleTransaction Transaction { get; }

        /// <summary>
        /// トランザクション開始
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// コミット
        /// </summary>
        void Commit();

        /// <summary>
        /// ロールバック
        /// </summary>
        void RollBack();

        /// <summary>
        /// エンティティ連続追加
        /// </summary>
        /// <param name="entities">エンティティ</param>
        void InsertEntity(IEnumerable<DbTableEntity> entities);

        /// <summary>
        /// エンティティ連続更新
        /// </summary>
        /// <param name="entities">エンティティ</param>
        /// <param name="isUpdateNull">Null項目更新可否(falseの場合、nullは更新対象外)</param>
        int UpdateEntity(IEnumerable<DbTableEntity> entities, bool isUpdateNull = false);

        /// <summary>
        /// エンティティ連続追加更新
        /// </summary>
        /// <param name="entities">エンティティ</param>
        /// <param name="isUpdateNull">Null項目更新可否(falseの場合、nullは更新対象外)</param>
        void UpdateInsertEntity(IEnumerable<DbTableEntity> entities, bool isUpdateNull = false);

        /// <summary>
        /// エンティティ連続削除
        /// </summary>
        /// <param name="entities">エンティティ</param>
        int DeleteEntity(IEnumerable<DbTableEntity> entities);
    }

    /// <summary>
    /// DAO基本クラス
    /// </summary>
    public abstract class DaoBase : IDaoBase
    {
        private string _ConnectionString = string.Empty;
        /// <summary>
        /// 接続文字列
        /// </summary>
        public string ConnectionString
        {
            get { return this._ConnectionString; }
            private set { this._ConnectionString = value; }
        }

        private OracleConnection _Connection = null;
        /// <summary>
        /// OracleConnection
        /// </summary>
        public OracleConnection Connection
        {
            get { return this._Connection; }
            private set { this._Connection = value; }
        }

        private OracleTransaction _Transaction = null;
        /// <summary>
        /// OracleTransaction
        /// </summary>
        public OracleTransaction Transaction
        {
            get { return this._Transaction; }
            private set { this._Transaction = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="nameConnectionString"></param>
        public DaoBase(string nameConnectionString)
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings[nameConnectionString].ConnectionString;
            if (string.IsNullOrEmpty(this.ConnectionString)) throw new Exception(string.Format("接続文字列名[{0}]が設定されていません。", nameConnectionString));

            this.Connection = new OracleConnection() { ConnectionString = this.ConnectionString };
            this.Connection.Open();
        }

        /// <summary>
        /// トランザクション開始
        /// </summary>
        public void BeginTransaction()
        {
            if (this.Connection == null)
            {
                throw new Exception("コネクションがありません。");
            }
            else
            {
                this.Transaction = this.Connection.BeginTransaction();
            }
        }

        /// <summary>
        /// コミット
        /// </summary>
        public void Commit()
        {
            if (this.Transaction == null)
            {
                throw new Exception("トランザクションが開始されていません。");
            }
            else
            {
                this.Transaction.Commit();
            }
        }

        /// <summary>
        /// ロールバック
        /// </summary>
        public void RollBack()
        {
            if (this.Transaction == null)
            {
                throw new Exception("トランザクションが開始されていません。");
            }
            else
            {
                this.Transaction.Rollback();
            }
        }

        /// <summary>
        /// エンティティ連続追加
        /// </summary>
        /// <param name="entities">エンティティ</param>
        public void InsertEntity(IEnumerable<DbTableEntity> entities)
        {
            foreach (DbTableEntity dte in entities)
            {
                dte.InsertEntity(this.Connection);
            }
        }

        /// <summary>
        /// エンティティ連続更新
        /// </summary>
        /// <param name="entities">エンティティ</param>
        /// <param name="isUpdateNull">Null項目更新可否(falseの場合、nullは更新対象外)</param>
        public int UpdateEntity(IEnumerable<DbTableEntity> entities, bool isUpdateNull = false)
        {
            int cntUpdate = 0;

            foreach (DbTableEntity dte in entities)
            {
                int result = dte.UpdateEntity(this.Connection, isUpdateNull);
                if (result >= 0)
                {
                    cntUpdate += result;
                }
                else
                {
                    switch(result)
                    {
                        case -1:
                            throw new Exception("キー項目未設定データを更新しようとしています。");
                        case -2:
                            throw new Exception("更新内容が設定されていないデータを更新しようとしています。");
                    }
                }
            }
            return cntUpdate;
        }

        /// <summary>
        /// エンティティ連続追加更新
        /// </summary>
        /// <param name="entities">エンティティ</param>
        /// <param name="isUpdateNull">Null項目更新可否(falseの場合、nullは更新対象外)</param>
        public void UpdateInsertEntity(IEnumerable<DbTableEntity> entities, bool isUpdateNull = false)
        {
            foreach (DbTableEntity dte in entities)
            {
                dte.UpdateInsertEntity(this.Connection, isUpdateNull);
            }
        }

        /// <summary>
        /// エンティティ連続削除
        /// </summary>
        /// <param name="entities">エンティティ</param>
        public int DeleteEntity(IEnumerable<DbTableEntity> entities)
        {
            int cntUpdate = 0;

            foreach (DbTableEntity dte in entities)
            {
                int result = dte.DeleteEntity(this.Connection);
                if (result >= 0)
                {
                    cntUpdate += result;
                }
                else
                {
                    throw new Exception("キー項目未設定データを削除しようとしています。");
                }
            }

            return cntUpdate;
        }

        private bool disposedValue = false;
        protected void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (this.Transaction != null)
                    {
                        this.Transaction.Dispose();
                    }
                    if (this.Connection != null)
                    {
                        this.Connection.Dispose();
                    }
                }
            }
            this.disposedValue = true;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
