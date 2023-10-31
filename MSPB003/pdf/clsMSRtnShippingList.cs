using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using log4net;
using dnp.nulcommon.pdf;
using System.Configuration;

namespace MSPB.MSPB003.pdf
{
    #region 発送リストレコードクラス
    /// <summary>
    /// 発送リストレコードクラス
    /// </summary>
    class clsMSRtnShippingListRecord
    {
        /// <summary>
        /// No
        /// </summary>
        public int NO { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// エスカレ登録日
        /// </summary>        
        public string ESCALATION_REGIST_DATE { get; set; }
        /// <summary>
        /// 管理番号
        /// </summary>        
        public string CONTROL_NO { get; set; }
        /// <summary>
        /// 証券番号
        /// </summary>        
        public string CONTRACT_NO { get; set; }
        /// <summary>
        /// 出力日
        /// </summary>        
        public string OUTPUT_DATE { get; set; }
        /// <summary>
        /// 現在ページ
        /// </summary>        
        public string CURRENT_PAGE { get; set; }
        /// <summary>
        /// 総ページ数
        /// </summary>        
        public string TOTAL_PAGES { get; set; }
        /// <summary>
        /// 返却先
        /// </summary>        
        public string RETURN_DEST { get; set; }
        /// <summary>
        /// 出荷日
        /// </summary>        
        public string SHIPPING_DATE { get; set; }
    }
    #endregion
    #region 発送リスト位置情報クラス
    /// <summary>
    /// 発送リスト位置情報クラス
    /// </summary>
    class clsMSRtnShippingListPosInfo
    {
        /// <summary>
        /// No
        /// </summary>
        public clsPosInfo No { get; set; }
        /// <summary>
        /// エスカレ登録日
        /// </summary>
        public clsPosInfo EscalationRegistDate { get; set; }
        /// <summary>
        /// 管理番号
        /// </summary>
        public clsPosInfo ControlNo { get; set; }
        /// <summary>
        /// 証券番号
        /// </summary>
        public clsPosInfo ContractNo { get; set; }
        /// <summary>
        /// 出力日
        /// </summary>
        public clsPosInfo OutputDate { get; set; }
        /// <summary>
        /// 頁/頁数
        /// </summary>
        public clsPosInfo PageCount { get; set; }
        /// <summary>
        /// 返却先
        /// </summary>
        public clsPosInfo ReturnDest { get; set; }
        /// <summary>
        /// 出荷日
        /// </summary>
        public clsPosInfo ShippingDate { get; set; }
        /// <summary>
        /// リスト情報
        /// </summary>
        public clsPosInfo ListInfo { get; set; }
    }
    #endregion
    #region 発送リスト作成クラス
    /// <summary>
    /// 発送リスト作成クラス
    /// </summary>
    class clsMSRtnShippingList
    {
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        #region プロパティ
        /// <summary>
        /// 発送リストデータ
        /// </summary>
        public List<clsMSRtnShippingListRecord> lstShippingListData { get; set; }
        /// <summary>
        /// 出荷日
        /// </summary>
        public string SHIPPING_DATE { get; set; }
        /// <summary>
        /// 発送リストタイプ
        /// </summary>
        public string SHIPPING_SLIP_TYPE { get; set; }
        /// <summary>
        /// 位置情報
        /// </summary>
        private clsMSRtnShippingListPosInfo ShippingListPosInfo { get; set; }
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public clsMSRtnShippingList()
        {
            //位置情報取得
            getPosInfo();
        }
        #endregion
        #region メソッド
        #region 発送リスト作成
        /// <summary>
        /// 発送リスト作成
        /// </summary>
        /// <returns></returns>
        public string CreateCheckSheet()
        {
            _logger.Info("発送リスト作成：開始");

            string outPath = Path.Combine(ConfigurationManager.AppSettings["MSPB003_SHIPPING_LIST_OUTPUT_PATH"], this.SHIPPING_DATE);
            string outFile = Path.Combine(outPath, string.Format(ConfigurationManager.AppSettings["MSPB003_SHIPPING_LIST_OUTPUT_FILE_NAME"], this.SHIPPING_DATE, this.SHIPPING_SLIP_TYPE, DateTime.Now.ToString("HHmmss")));
            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }
                        
            var dicCheckData = this.lstShippingListData.GroupBy(x => new
            {
                OUTPUT_DATE = x.OUTPUT_DATE,            
                RETURN_DEST = x.RETURN_DEST,
                SHIPPING_DATE = x.SHIPPING_DATE
            }).ToDictionary(keys => keys.Key, grp => grp.ToList());

            using(PdfCreator pdf = new PdfCreator(outFile, ConfigurationManager.AppSettings["MSPB003_SHIPPING_LIST_OVL"]))
            {
                int keyCount = 0;
                int dataCount = 0;
                float RowPosMargine = ShippingListPosInfo.ListInfo.RowPosMargine;
                int RowCount = ShippingListPosInfo.ListInfo.RowCount;

                int totalRowCnt = lstShippingListData.Count;
                int totalPageCount = 0;

                // 全体ページ数を取得する
                if (totalRowCnt > 0)
                {
                    totalPageCount = totalRowCnt / RowCount;
                    if (totalRowCnt % RowCount != 0)
                        totalPageCount++;
                }
                // ゼロ件の時のページ（1/1）
                if (totalPageCount == 0)
                    totalPageCount++;

                foreach (var key in dicCheckData.Keys)
                {
                    List<clsMSRtnShippingListRecord> lstData = dicCheckData[key];
                    int rowIdx = 0;
                    float RowPos = 0;

                    int currentPage = 1;

                    //if ( key.LINE_NO != wLineo || key.SHIPPING_CATEGORY != wCategoy)
                    //if (key.NO != wLineo)
                    //{
                    //    dataCount = 0;
                    //    wLineo = key.NO;                        
                    //}
                    if (keyCount > 0)
                    {
                        pdf.NextPage();
                        pdf.RepeatTemplate();
                    }

                    //ヘッダー項目出力
                    writeHeader(pdf, key.OUTPUT_DATE, string.Format("{0}/{1}", currentPage.ToString(), totalPageCount.ToString()), key.RETURN_DEST, key.SHIPPING_DATE + "　発送");
                    
                    
                    foreach (clsMSRtnShippingListRecord info in lstShippingListData)
                    {
                        if (rowIdx >= RowCount)
                        {
                            currentPage++;

                            pdf.NextPage();
                            pdf.RepeatTemplate();
                            //ヘッダー項目出力
                            writeHeader(pdf, key.OUTPUT_DATE, string.Format("{0}/{1}", currentPage.ToString(), totalPageCount.ToString()), key.RETURN_DEST, key.SHIPPING_DATE + "　発送");
                            rowIdx = 0;
                        }
                        RowPos = rowIdx * RowPosMargine;
                        dataCount += 1;
                        // No
                        pdf.WriteTextRegion(new RectangleF(
                            ShippingListPosInfo.No.XPos,
                            ShippingListPosInfo.No.YPos + RowPos,
                            ShippingListPosInfo.No.Width,
                            ShippingListPosInfo.No.Height),
                            ShippingListPosInfo.No.Font,
                            ShippingListPosInfo.No.FontSize,
                            dataCount.ToString(),
                            minSize: ShippingListPosInfo.No.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);
                        // エスカレ登録日
                        pdf.WriteTextRegion(new RectangleF(
                            ShippingListPosInfo.EscalationRegistDate.XPos,
                            ShippingListPosInfo.EscalationRegistDate.YPos + RowPos,
                            ShippingListPosInfo.EscalationRegistDate.Width,
                            ShippingListPosInfo.EscalationRegistDate.Height),
                            ShippingListPosInfo.EscalationRegistDate.Font,
                            ShippingListPosInfo.EscalationRegistDate.FontSize,
                            info.ESCALATION_REGIST_DATE,
                            minSize: ShippingListPosInfo.EscalationRegistDate.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);
                        // 管理番号
                        pdf.WriteTextRegion(new RectangleF(
                            ShippingListPosInfo.ControlNo.XPos,
                            ShippingListPosInfo.ControlNo.YPos + RowPos,
                            ShippingListPosInfo.ControlNo.Width,
                            ShippingListPosInfo.ControlNo.Height),
                            ShippingListPosInfo.ControlNo.Font,
                            ShippingListPosInfo.ControlNo.FontSize,
                            info.CONTROL_NO.Trim('#'),
                            minSize: ShippingListPosInfo.ControlNo.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);
                        // 証券番号
                        pdf.WriteTextRegion(new RectangleF(
                            ShippingListPosInfo.ContractNo.XPos,
                            ShippingListPosInfo.ContractNo.YPos + RowPos,
                            ShippingListPosInfo.ContractNo.Width,
                            ShippingListPosInfo.ContractNo.Height),
                            ShippingListPosInfo.ContractNo.Font,
                            ShippingListPosInfo.ContractNo.FontSize,
                            info.CONTRACT_NO,
                            minSize: ShippingListPosInfo.ContractNo.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);                        

                        rowIdx += 1;
                    }
                    keyCount += 1;                    
                }

            }
            _logger.Info("発送リスト作成：終了");
            return outFile;
        }
        #endregion
        #region ヘッダー出力
        /// <summary>
        /// ヘッダー出力
        /// </summary>
        /// <param name="pdf"></param>
        /// <param name="outputDate"></param>
        /// <param name="pageCnt"></param>
        /// <param name="returnDest"></param>
        /// <param name="shippingDate"></param>
        private void writeHeader(PdfCreator pdf,string outputDate, string pageCnt, string returnDest, string shippingDate)
        {

            //出力日
            pdf.WriteTextRegion(new RectangleF(
                ShippingListPosInfo.OutputDate.XPos,
                ShippingListPosInfo.OutputDate.YPos,
                ShippingListPosInfo.OutputDate.Width,
                ShippingListPosInfo.OutputDate.Height),
                ShippingListPosInfo.OutputDate.Font,
                ShippingListPosInfo.OutputDate.FontSize,
                outputDate,
                minSize: ShippingListPosInfo.OutputDate.FontSize,
                hAlign: HorizontalTextAlignment.Left,
                vAlign: VerticalTextAlignment.Middle);

            // 頁/頁数
            pdf.WriteTextRegion(new RectangleF(
                ShippingListPosInfo.PageCount.XPos,
                ShippingListPosInfo.PageCount.YPos,
                ShippingListPosInfo.PageCount.Width,
                ShippingListPosInfo.PageCount.Height),
                ShippingListPosInfo.PageCount.Font,
                ShippingListPosInfo.PageCount.FontSize,
                pageCnt,
                minSize: ShippingListPosInfo.PageCount.FontSize,
                hAlign: HorizontalTextAlignment.Right,
                vAlign: VerticalTextAlignment.Middle);

            // 返却先
            pdf.WriteTextRegion(new RectangleF(
                ShippingListPosInfo.ReturnDest.XPos,
                ShippingListPosInfo.ReturnDest.YPos,
                ShippingListPosInfo.ReturnDest.Width,
                ShippingListPosInfo.ReturnDest.Height),
                ShippingListPosInfo.ReturnDest.Font,
                ShippingListPosInfo.ReturnDest.FontSize,
                returnDest,
                minSize: ShippingListPosInfo.ReturnDest.FontSize,
                hAlign: HorizontalTextAlignment.Right,
                vAlign: VerticalTextAlignment.Middle,
                fStyle1: EFontStyle.BOLD);

            // 出荷日
            pdf.WriteTextRegion(new RectangleF(
                ShippingListPosInfo.ShippingDate.XPos,
                ShippingListPosInfo.ShippingDate.YPos,
                ShippingListPosInfo.ShippingDate.Width,
                ShippingListPosInfo.ShippingDate.Height),
                ShippingListPosInfo.ShippingDate.Font,
                ShippingListPosInfo.ShippingDate.FontSize,
                shippingDate,
                minSize: ShippingListPosInfo.ShippingDate.FontSize,
                hAlign: HorizontalTextAlignment.Right,
                vAlign: VerticalTextAlignment.Middle);

        }
        #endregion
        
        #region 位置情報取得
        /// <summary>
        /// 位置情報取得
        /// </summary>
        /// <returns></returns>
        private void getPosInfo()
        {
            this.ShippingListPosInfo = new clsMSRtnShippingListPosInfo();

            clsPdfPosition posInfo = new clsPdfPosition(ConfigurationManager.AppSettings["MSPB003_SHIPPING_LIST_POS_FILE"], "Setting/List");

            // リスト情報
            this.ShippingListPosInfo.ListInfo = posInfo.getPosInfo("ListInfo");
            // No
            this.ShippingListPosInfo.No = posInfo.getPosInfo("No");
            // エスカレ登録日
            this.ShippingListPosInfo.EscalationRegistDate = posInfo.getPosInfo("EscalationRegistDate");
            // 管理番号
            this.ShippingListPosInfo.ControlNo = posInfo.getPosInfo("ControlNo");
            // 証券番号
            this.ShippingListPosInfo.ContractNo = posInfo.getPosInfo("ContractNo");
            // 出力日
            this.ShippingListPosInfo.OutputDate = posInfo.getPosInfo("OutputDate");
            // 頁/頁数
            this.ShippingListPosInfo.PageCount = posInfo.getPosInfo("PageCount");
            // 返却先
            this.ShippingListPosInfo.ReturnDest = posInfo.getPosInfo("ReturnDest");
            // 出荷日
            this.ShippingListPosInfo.ShippingDate = posInfo.getPosInfo("ShippingDate");

        }
        #endregion
        
        #endregion
    }
    #endregion
}
