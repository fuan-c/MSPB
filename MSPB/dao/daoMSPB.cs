using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using log4net;
using MSPB.Common.Dao;

namespace MSPB.MSPB.dao
{
    /// <summary>
    /// ログインdaoクラス
    /// </summary>
    class daoMSPB:daoBase   //:DaoBase
    {

        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);        

        private string UserId { get; set; }
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        public daoMSPB(string userId, string name)
            : base(name)
        {
            UserId = userId;
        }        

        /// <summary>
        /// 担当者データ取得
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public DataTable SelectEMPLOYEE(string loginId)
        {
            logger.Debug("〇SelectEMPLOYEE");

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("  USER_ID ");
            sql.Append("  ,USER_NAME ");
            sql.Append("  ,USER_AUTHORITY ");
            sql.Append("  ,USER_PASSWORD ");            
            sql.Append("FROM ");
            sql.Append("  T_EMPLOYEE ");
            sql.Append("WHERE ");
            sql.Append("  USER_ID = :USER_ID ");

            DataTable dt = new DataTable();

            using (OracleCommand cmd = new OracleCommand(sql.ToString(), this.Connection) { BindByName = true })
            {
                cmd.Parameters.Add(":USER_ID", loginId);
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

            return dt;
        }        
    }
}
