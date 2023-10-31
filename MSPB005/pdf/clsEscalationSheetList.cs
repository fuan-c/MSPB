using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using System.IO;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using MSPB.Common;
using System.Windows.Forms;

namespace MSPB.MSPB005.pdf
{
    #region エスカレシート作成クラス
    /// <summary>
    /// エスカレシート作成クラス
    /// </summary>
    class clsEscalationSheetList
    {
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region プロパティ
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// エスカレ登録日
        /// </summary>
        public string REGIST_DATE { get; set; }

        /// <summary>
        /// 種別
        /// </summary>
        public string PRODUCT_TYPE { get; set; }

        /// <summary>
        /// 管理番号
        /// </summary>
        public string CONTROL_NO { get; set; }

        /// <summary>
        /// 証券番号
        /// </summary>
        public string CONTRACT_NO { get; set; }

        /// <summary>
        /// 私物情報
        /// </summary>
        public string PERSONAL_BELONGINGS_INFO { get; set; }

        /// <summary>
        /// ステータス
        /// </summary>
        public string STATUS { get; set; }

        /// <summary>
        /// MS返却フラグ
        /// </summary>
        public string MS_RETURN_FLAG { get; set; }

        /// <summary>
        /// 出荷日
        /// </summary>
        public string SHIPPING_DATE { get; set; }

        /// <summary>
        /// エスカレシートデータ
        /// </summary>
        public List<clsEscalationSheetList> lstEscSheetData { get; set; }
        #endregion

        #region メソッド

        #region エスカレシート作成
        /// <summary>
        /// エスカレシート作成
        /// </summary>
        /// <returns></returns>
        public string createEscalationSheetList()
        {
            _logger.Debug("エスカレシート作成");

            string outPath = string.Empty;
            string outFile = string.Empty;

            try
            {
                outPath = ConfigurationManager.AppSettings["MSPB005_ESCALATION_SHEET_OUTPUT_PATH"];
                outFile = Path.Combine(outPath, string.Format(ConfigurationManager.AppSettings["MSPB005_ESCALATION_SHEET_FILE"], DateTime.Now.ToString("yyyyMMdd")));

                // ディレクトリ存在チェック
                if (!Directory.Exists(outPath))
                {
                    Directory.CreateDirectory(outPath);
                }

                // ファイル存在チェック
                if (File.Exists(outFile))
                {
                    _logger.Info($"エスカレシート作成：[{ Path.GetFileName(outFile)}]が既に存在します。");
                    new clsMessageBox().MessageBoxOKOnly($"[{Path.GetFileName(outFile)}]が既に存在します。", "警告", MessageBoxIcon.Warning);
                    return null;
                }

                // Excel起動
                Excel.Application mApp = new Excel.Application();

                // アラートメッセージ非表示設定◆
                mApp.DisplayAlerts = false;
                // 起動したExcelからワークブックのコレクションを表すオブジェクトを取得
                Excel.Workbooks mWorkBooks = mApp.Workbooks;
                // 指定したExcelファイルを開く
                // 絶対パス
                string excel_path = System.IO.Path.GetFullPath(ConfigurationManager.AppSettings["MSPB005_ESCALATION_SHEET_OVL"]);

                Excel.Workbook mWorkBook = mWorkBooks.Open(excel_path, Type.Missing, true);
                // 開いたExcelファイルのシートのコレクションを取得
                Excel.Sheets mSheets = mWorkBook.Worksheets;
                // 1番目のワークシートを取得。
                Excel.Worksheet mWorkSheet = mSheets[1];

                // 対象件数が1件以上の場合、対象件数分行追加                    
                if (lstEscSheetData.Count > 1)
                {
                    for (int i = 0; i < lstEscSheetData.Count - 1; ++i)                        
                    {
                        var CopyRange = mWorkSheet.Range["A2:K2"];  // コピー対象Range設定
                        CopyRange.Copy();                           // コピー
                        CopyRange.Insert(2);                        // コピーした行追加
                    }
                }

                int rowCnt = 0;

                // 対象データ印字
                foreach (clsEscalationSheetList info in lstEscSheetData)
                {
                    rowCnt++;

                    // 指定したセルを変更
                    mWorkSheet.Cells[rowCnt + 1, 1] = rowCnt.ToString("#,0");                       // NO
                    mWorkSheet.Cells[rowCnt + 1, 2] = info.REGIST_DATE;                             // 登録日
                    mWorkSheet.Cells[rowCnt + 1, 3] = info.PRODUCT_TYPE;                            // 種別
                    mWorkSheet.Cells[rowCnt + 1, 4] = info.CONTROL_NO;                              // 管理番号
                    mWorkSheet.Cells[rowCnt + 1, 5] = info.CONTRACT_NO;                             // 証券番号
                    mWorkSheet.Cells[rowCnt + 1, 6] = info.PERSONAL_BELONGINGS_INFO;                // 私物情報
                    mWorkSheet.Cells[rowCnt + 1, 7] = info.STATUS;                                  // ステータス
                    mWorkSheet.Cells[rowCnt + 1, 8] = info.MS_RETURN_FLAG.Equals("1") ? "〇" : "";  // MS返却フラグが「1」の時"〇"                        
                }

                // Excelを非表示。
                mApp.Visible = false;
                //PDF変換
                //絶対パス
                //string pdf_outpath = System.IO.Path.GetFullPath(outFile);
                //mWorkBook.ActiveSheet.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, pdf_outpath);
                string excel_outpath = System.IO.Path.GetFullPath(outFile);
                mWorkBook.SaveAs(excel_outpath);
                // ワークブックを閉じる。
                mWorkBook.Close();
                // Excelを閉じる。
                mApp.Quit();
                // ガベージコレクタを実行。
                GC.Collect();

                _logger.Info($"エスカレシート作成：[{ Path.GetFileName(outFile)}]を作成しました。");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return outFile;

        }
        #endregion

        #endregion

    }
    #endregion


    class clsEscalationSheetFileInfo
    {
        /// <summary>
        /// ファイル名
        /// </summary>
        public string FILE_NAME { get; set; }
        /// <summary>
        /// ファイル件数
        /// </summary>
        public int FILE_COUNT { get; set; }
    }
}
