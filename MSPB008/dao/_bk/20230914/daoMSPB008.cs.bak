using log4net;
using System;
using System.Data;
using System.Text;

namespace MSPB.MSPB008.dao
{
    class daoMSPB008 : Dao.daoBase
    {
        #region "変数"

        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        string _userId = string.Empty;

        #endregion

        //コンストラクタ
        public daoMSPB008(string name, string userid)
        {
            dbConnection(name);
            _userId = userid;

        }

        #region "SELECT"

        #region "処理履歴テーブルより最大SEQ_NOの取得"
        /// <summary>
        /// 処理履歴テーブルより最大SEQ_NOの取得
        /// </summary>
        /// <return>最大SEQ_NO</return>
        public int select_MAX_SEQ_NO_From_T_PROCESS_HISTORY()
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();
            int max_SEQ_NO = 0;

            logger.Info("最大SEQ_NO 取得開始");

            sb.AppendLine("SELECT MAX(SEQ_NO) ");
            sb.AppendLine("FROM T_PROCESS_HISTORY ");

            sql = sb.ToString();
            logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            if (tbl.Rows.Count > 0)
            {
                if (tbl.Rows[0].ItemArray[0] != DBNull.Value)
                {
                    max_SEQ_NO = Int32.Parse(tbl.Rows[0].ItemArray[0].ToString());
                }
                else
                {
                    max_SEQ_NO = 0;
                }
            }
            else
            {
                max_SEQ_NO = 0;
            }

            logger.Info("最大SEQ_NO [" + max_SEQ_NO + "]");
            logger.Info("最大SEQ_NO 取得終了");

            return max_SEQ_NO;

        }
        #endregion

        #endregion

        #region "INSERT"

        #region "処理履歴テーブル追加"
        /// <summary>
        /// 処理履歴テーブル追加
        /// </summary>
        /// <param name="next_no">SEQ_NO</param>
        /// <param name="PROCESS_TEXT">処理内容</param>
        /// <param name="INPUT_FILE_NAME">入力ファイル名コード</param>
        /// <param name="INPUT_COUNT">入力件数</param>
        /// <param name="REGISTER_COUNT">登録件数</param>
        /// <param name="UPDATE_USER">処理担当者名</param>
        /// <return>none</return>
        public void insert_T_PROCESS_HISTORY(int next_no, string PROCESS_TEXT, string INPUT_FILE_NAME, int INPUT_COUNT, int REGISTER_COUNT, string UPDATE_USER)
        {
            try
            {
                logger.Info("処理履歴テーブル追加 開始");
                logger.Info("SEQ_NO [" + next_no + "]");
                logger.Info("処理内容 [" + PROCESS_TEXT + "]");
                logger.Info("入力ファイル名 [" + INPUT_FILE_NAME + "]");
                logger.Info("入力件数 [" + INPUT_COUNT + "]");
                logger.Info("登録件数 [" + REGISTER_COUNT + "]");
                logger.Info("担当者名 [" + UPDATE_USER + "]");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                //入力ファイル関連登録
                sb.AppendLine(" INSERT INTO T_PROCESS_HISTORY ( ");
                sb.AppendLine("    SEQ_NO ");
                sb.AppendLine("   ,PROCESS_TEXT ");
                sb.AppendLine("   ,INPUT_FILE_NAME ");
                sb.AppendLine("   ,INPUT_COUNT ");
                sb.AppendLine("   ,OUTPUT_COUNT ");
                sb.AppendLine("   ,UPDATE_DATE ");
                sb.AppendLine("   ,UPDATE_USER ");
                sb.AppendLine("  ) VALUES (");
                sb.AppendLine("   '" + next_no + "'");
                sb.AppendLine("  ,'" + PROCESS_TEXT + "'");
                sb.AppendLine("  ,'" + INPUT_FILE_NAME + "'");
                sb.AppendLine("  ,'" + INPUT_COUNT + "'");
                sb.AppendLine("  ,'" + REGISTER_COUNT + "'");
                sb.AppendLine("  ,SYSDATE ");
                sb.AppendLine("  ,'" + UPDATE_USER + "')");

                logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            finally
            {
                logger.Info("処理履歴テーブル追加 終了");
            }
        }
        #endregion

        #region "仕分けコード追加"
        /// <summary>
        /// 仕分けコード追加
        /// <param name="list">登録用1行イメージ</param>
        /// <param name="staff_name">処理担当者名</param>
        /// </summary>
        /// <return>none</return>
        public void insert_M_SORTING_CODE(string list, string staff_name)
        {
            try
            {
                logger.Info("仕分けコード追加 開始");

                logger.Info("仕分けコード追加　登録1行イメージ [" + list + "]");

                StringBuilder sb = new StringBuilder();
                string sql = null;
                string[] fields = list.ToString().Split(',');

                sb.AppendLine("INSERT INTO M_SORTING_CODE ( ");
                if (!string.IsNullOrEmpty(fields[0])) sb.AppendLine("   INDUSTRY ");
                if (!string.IsNullOrEmpty(fields[1])) sb.AppendLine("  ,POSTAL_CODE ");
                if (!string.IsNullOrEmpty(fields[2])) sb.AppendLine("  ,SHIP_CODE ");
                if (!string.IsNullOrEmpty(fields[3])) sb.AppendLine("  ,SORTING_NO ");
                if (!string.IsNullOrEmpty(fields[4])) sb.AppendLine("  ,PREFECTURES_CODE ");
                if (!string.IsNullOrEmpty(fields[5])) sb.AppendLine("  ,MUNICIPALITY_CODE ");
                sb.AppendLine("  ,UPDATE_DATE ");
                sb.AppendLine("  ,UPDATE_USER ");
                sb.AppendLine(" ) VALUES (");
                if (!string.IsNullOrEmpty(fields[0])) sb.AppendLine("  '" + fields[0] + "'");
                if (!string.IsNullOrEmpty(fields[1])) sb.AppendLine(" ,'" + fields[1] + "'");
                if (!string.IsNullOrEmpty(fields[2])) sb.AppendLine(" ,'" + fields[2] + "'");
                if (!string.IsNullOrEmpty(fields[3])) sb.AppendLine(" ,'" + fields[3] + "'");
                if (!string.IsNullOrEmpty(fields[4])) sb.AppendLine(" ,'" + fields[4] + "'");
                if (!string.IsNullOrEmpty(fields[5])) sb.AppendLine(" ,'" + fields[5] + "'");
                sb.AppendLine(" ,SYSDATE ");
                sb.AppendLine(" ,'" + staff_name + "'");
                sb.AppendLine(")");

                logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            finally
            {
                logger.Info("仕分けコード追加 終了");
            }
        }
        #endregion

        #endregion

        #region "UPDATE"

        #region "仕分けテーブルデータ削除"
        /// <summary>
        /// 仕分けテーブルデータ削除
        /// </summary>
        /// <return>none</return>
        public void delete_M_SORTING_CODE()
        {
            try
            {
                logger.Info("仕分けテーブルデータ削除 開始");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                sb.AppendLine(" DELETE FROM M_SORTING_CODE  ");

                logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            finally
            {
                logger.Info("仕分けテーブルデータ削除 終了");
            }
        }
        #endregion

        #endregion
    }
}
