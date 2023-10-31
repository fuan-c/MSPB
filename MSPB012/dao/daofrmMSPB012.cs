using System;
using System.Text;
using System.Data;
using log4net;

namespace MSPB.MSPB012.dao
{
    class daofrmMSPB012 : MSPB.Common.Dao.daoBase
    {

        #region "変数"
        //log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion

        //コンストラクタ
        public daofrmMSPB012(string name)
        {
            dbConnection(name);
        }

        #region "SELECT"

        #region ユーザ管理テーブルよりユーザ情報取得
        //ユーザ管理テーブルよりユーザ情報取得
        public DataTable Select_T_Employee()
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("ユーザ情報 取得開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine(" ID ");
            sb.AppendLine(" ,USER_ID ");
            sb.AppendLine(" ,USER_NAME ");
            sb.AppendLine(" ,USER_AUTHORITY ");
            sb.AppendLine(" ,USER_PASSWORD ");            
            sb.AppendLine("FROM ");
            sb.AppendLine("T_EMPLOYEE ");                       
            sb.AppendLine("ORDER BY ID ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("ユーザ情報 取得終了");

            return tbl;
        }
        #endregion

        #endregion

        #region "INSERT"

        #region "管理者テーブルデータ登録"
        public void Insert_T_EMPLOYEE(string list)
        {
            try
            {
                _logger.Info("管理者テーブルデータ登録 開始");
                _logger.Info("〇Insert_T_EMPLOYEE");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                string[] fields = list.ToString().Split(',');

                _logger.Info($"管理者テーブルデータ 登録1行 ID：[{fields[0]}]、USER_ID：[{fields[1]}]、USER_NAME：[{fields[2]}]、USER_AUTHORITY：[{fields[3]}]、USER_PASSWORD：[{fields[4]}]");

                sb.AppendLine(" INSERT INTO T_EMPLOYEE ( ");
                sb.AppendLine("   ID ");
                sb.AppendLine("   ,USER_ID ");
                sb.AppendLine("   ,USER_NAME ");
                sb.AppendLine("   ,USER_AUTHORITY ");
                sb.AppendLine("   ,USER_PASSWORD ");
                sb.AppendLine("  ) VALUES (");
                sb.AppendLine("  " + fields[0]);
                sb.AppendLine("  ,'" + fields[1] + "'");
                sb.AppendLine("  ,'" + fields[2] + "'");
                sb.AppendLine("  ,'" + fields[3] + "'");
                sb.AppendLine("  ,'" + fields[4] + "'");
                sb.AppendLine(")");

                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            catch(Exception ex)
            {
                throw new Exception("管理者テーブル登録処理：" + ex.Message, ex);
            }
            finally
            {
                _logger.Info("管理者テーブルデータ登録 終了");
            }
        }
        #endregion

        #endregion

        #region "DELETE"

        #region "管理者テーブルデータ削除"
        //管理者テーブルデータ削除
        public void Delete_T_EMPLOYEE()
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("管理者テーブルデータ削除 開始");
            _logger.Info("〇Delete_T_EMPLOYEE");
            try
            {
                sb.AppendLine(" DELETE FROM T_EMPLOYEE ");                

                sql = sb.ToString();
                _logger.Info("sql[" + Environment.NewLine + sql + "]");
                tbl = base.Fill(sql);

            }
            catch (Exception ex)
            {
                throw new Exception("管理者テーブル削除処理：" + ex.Message, ex);
            }
            finally
            {
                _logger.Info("管理者テーブルデータ削除 終了");
            }

        }
        #endregion
        
        #endregion

    }
}
