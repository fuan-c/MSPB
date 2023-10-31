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
    #region 発送チェックシートレコードクラス
    /// <summary>
    /// 発送チェックシートレコードクラス
    /// </summary>
    class clsShippingCheckSheetRecord
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 出荷日
        /// </summary>        
        public string SHIPPING_DATE { get; set; }
        /// <summary>
        /// 配送伝票管理番号
        /// </summary>        
        public string DELIVERY_SLIP_CONTROL_NO { get; set; }
        /// <summary>
        /// 発送先名
        /// </summary>        
        public string SEND_DEST_NAME { get; set; }
        /// <summary>
        /// 発送先郵便番号
        /// </summary>        
        public string SEND_DEST_POSTAL_CODE { get; set; }
        /// <summary>
        /// 発送先住所
        /// </summary>        
        public string SEND_DEST_ADDRESS { get; set; }
        /// <summary>
        /// 発送区分
        /// </summary>        
        public string SHIPPING_CATEGORY { get; set; }
        /// <summary>
        /// お問合せ番号
        /// </summary>        
        public string CONTACT_NO { get; set; }
        /// <summary>
        /// 管理番号
        /// </summary>        
        public string CONTROL_NO { get; set; }
        /// <summary>
        /// ラインNO
        /// </summary>        
        public int LINE_NO { get; set; }
        /// <summary>
        /// 件数
        /// </summary>        
        public int PACKING_COUNT { get; set; }
        /// <summary>
        /// 総件数
        /// </summary>
        public int TOTAL_COUNT { get; set; }
        /// <summary>
        /// 発送名称
        /// </summary>
        public string SHIPPING_NAME { get; set; }

        public string INVITATION_CONTROL_NO { get; set; }

        public string MATURITY_DATE { get; set; }

        public Int32 LINE_COUNT { get; set; }

        public string CONTRACTOR_NAME { get; set; }

        public string VEHICLE_REGIST_NO { get; set; }

        public string CONTRACT_NO { get; set; }

        public string SEND_DEST_TEL_NO { get; set; }

        public string BUG_REPLACE_FLAG { get; set; }

        /// <summary>
        /// 郵便区分
        /// </summary>
        public string POSTAL_CATEGORY
        {

            get
            {
                return "12";
                //return this.SEND_DEST_POSTAL_CODE.Substring(0, 2);
            }
        }
        /// <summary>
        /// パレット区分
        /// </summary>
        public string PALLET_KBN { get; set; }
        /// <summary>
        /// エリア
        /// </summary>
        public string AREA { get; set; }
    }
    #endregion
    #region 発送チェックシート位置情報クラス
    /// <summary>
    /// 発送チェックシート位置情報クラス
    /// </summary>
    class clsShippingCheckSheetPosInfo
    {
        /// <summary>
        /// No
        /// </summary>
        public clsPosInfo No { get; set; }
        /// <summary>
        /// DNP管理番号
        /// </summary>
        public clsPosInfo ShippingControlNo { get; set; }
        /// <summary>
        /// 発送先郵便番号
        /// </summary>
        public clsPosInfo PostNo { get; set; }
        /// <summary>
        /// 発送先住所
        /// </summary>
        public clsPosInfo SendDestAddress { get; set; }
        /// <summary>
        /// 発送先名
        /// </summary>
        public clsPosInfo SendDestName { get; set; }
        /// <summary>
        /// お問合せ番号
        /// </summary>
        public clsPosInfo TelNo { get; set; }

        /// <summary>
        /// 出荷日
        /// </summary>
        public clsPosInfo ShippingDate { get; set; }
        
        /// <summary>
        /// 出荷総数
        /// </summary>
        public clsPosInfo ShippingTotalCount { get; set; }
        /// <summary>
        /// ライン番号
        /// </summary>
        public clsPosInfo LineNo { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public clsPosInfo PackingCount { get; set; }
        /// <summary>
        /// 発送区分名
        /// </summary>
        public clsPosInfo ShippingName { get; set; }
        /// <summary>
        /// リスト情報
        /// </summary>
        public clsPosInfo ListInfo { get; set; }

        public clsPosInfo InvitationControlNo { get; set; }

        public clsPosInfo PageNo { get; set; }

        public clsPosInfo Header { get; set; }

        public clsPosInfo SystemDate { get; set; }

        public clsPosInfo Return { get; set; }        

    }
    #endregion
    #region 発送チェックシート作成クラス
    /// <summary>
    /// 発送チェックシート作成クラス
    /// </summary>
    class clsShippingCheckSheet
    {
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        #region プロパティ
        /// <summary>
        /// チェックシートデータ
        /// </summary>
        public List<clsShippingCheckSheetRecord> lstChecsheetData { get; set; }
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
        private clsShippingCheckSheetPosInfo CheckSheetPosInfo { get; set; }
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public clsShippingCheckSheet()
        {
            //位置情報取得
            getPosInfo();
        }
        #endregion
        #region メソッド
        #region チェックシート作成
        /// <summary>
        /// チェックシート作成
        /// </summary>
        /// <returns></returns>
        public string CreateShippingCheckSheet()
        {
            string outPath = Path.Combine(ConfigurationManager.AppSettings["MSPB003_SHIPPING_CHECK_SHEET_OUTPUT_PATH"], this.SHIPPING_DATE);
            string outFile = Path.Combine(outPath, string.Format(ConfigurationManager.AppSettings["MSPB003_SHIPPING_CHECK_SHEET_FILE"], this.SHIPPING_DATE, this.SHIPPING_SLIP_TYPE, DateTime.Now.ToString("HHmmss")));
            
            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }
                        
            var dicCheckData = this.lstChecsheetData.GroupBy(x => new
            {
                SHIPPING_DATE = x.SHIPPING_DATE
            }).ToDictionary(keys => keys.Key, grp => grp.ToList());

            using (PdfCreator pdf = new PdfCreator(outFile, ConfigurationManager.AppSettings["MSPB003_SHIPPING_CHECK_SHEET_OVL"]))
            {
                int keyCount = 0;
                int dataCount = 0;
                float RowPosMargine = CheckSheetPosInfo.ListInfo.RowPosMargine;
                int RowCount = CheckSheetPosInfo.ListInfo.RowCount;
                                
                int max_page = 0;
                int Page_No = 0;
                string palletKbn = string.Empty;

                //ページ数カウント
                foreach (var key in dicCheckData.Keys)
                {
                    List<clsShippingCheckSheetRecord> lstData = dicCheckData[key];
                    int rowIdx = 0;
                    max_page = max_page + 1;
                    foreach (clsShippingCheckSheetRecord info in lstData)
                    {
                        if (rowIdx >= RowCount)
                        {
                            max_page = max_page + 1;
                            rowIdx = 0;
                        }
                        rowIdx += 1;
                    }
                }

                foreach (var key in dicCheckData.Keys)
                {
                    List<clsShippingCheckSheetRecord> lstData = dicCheckData[key];
                    int rowIdx = 0;
                    float RowPos = 0;
                    Page_No = Page_No + 1;
                    
                    if (keyCount > 0)
                    {
                        pdf.NextPage();
                        pdf.RepeatTemplate();
                    }
                    //ヘッダー項目出力
                    writeHeader(pdf, key.SHIPPING_DATE, Page_No, max_page);
                    foreach (clsShippingCheckSheetRecord info in lstData)
                    {
                        if (rowIdx >= RowCount)
                        {
                            pdf.NextPage();
                            pdf.RepeatTemplate();
                            //ヘッダー項目出力
                            Page_No = Page_No + 1;
                            writeHeader(pdf, key.SHIPPING_DATE, Page_No, max_page);                            
                            rowIdx = 0;
                        }
                        RowPos = rowIdx * RowPosMargine;
                        dataCount += 1;
                        //No
                        pdf.WriteTextRegion(new RectangleF(
                            CheckSheetPosInfo.No.XPos,
                            CheckSheetPosInfo.No.YPos + RowPos,
                            CheckSheetPosInfo.No.Width,
                            CheckSheetPosInfo.No.Height),
                            CheckSheetPosInfo.No.Font,
                            CheckSheetPosInfo.No.FontSize,
                            dataCount.ToString(),
                            minSize: CheckSheetPosInfo.No.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);
                        //伝票管理番号
                        pdf.WriteTextRegion(new RectangleF(
                            CheckSheetPosInfo.ShippingControlNo.XPos,
                            CheckSheetPosInfo.ShippingControlNo.YPos + RowPos,
                            CheckSheetPosInfo.ShippingControlNo.Width,
                            CheckSheetPosInfo.ShippingControlNo.Height),
                            CheckSheetPosInfo.ShippingControlNo.Font,
                            CheckSheetPosInfo.ShippingControlNo.FontSize,
                            info.DELIVERY_SLIP_CONTROL_NO,
                            minSize: CheckSheetPosInfo.ShippingControlNo.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);
                        //郵便番号
                        pdf.WriteTextRegion(new RectangleF(
                            CheckSheetPosInfo.PostNo.XPos,
                            CheckSheetPosInfo.PostNo.YPos + RowPos,
                            CheckSheetPosInfo.PostNo.Width,
                            CheckSheetPosInfo.PostNo.Height),
                            CheckSheetPosInfo.PostNo.Font,
                            CheckSheetPosInfo.PostNo.FontSize,
                            info.SEND_DEST_POSTAL_CODE,
                            minSize: CheckSheetPosInfo.PostNo.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);
                        //住所
                        pdf.WriteTextRegion(new RectangleF(
                            CheckSheetPosInfo.SendDestAddress.XPos,
                            CheckSheetPosInfo.SendDestAddress.YPos + RowPos,
                            CheckSheetPosInfo.SendDestAddress.Width,
                            CheckSheetPosInfo.SendDestAddress.Height),
                            CheckSheetPosInfo.SendDestAddress.Font,
                            CheckSheetPosInfo.SendDestAddress.FontSize,
                            info.SEND_DEST_ADDRESS,
                            minSize: CheckSheetPosInfo.SendDestAddress.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);
                        //名前
                        pdf.WriteTextRegion(new RectangleF(
                            CheckSheetPosInfo.SendDestName.XPos,
                            CheckSheetPosInfo.SendDestName.YPos + RowPos,
                            CheckSheetPosInfo.SendDestName.Width,
                            CheckSheetPosInfo.SendDestName.Height),
                            CheckSheetPosInfo.SendDestName.Font,
                            CheckSheetPosInfo.SendDestName.FontSize,
                            info.SEND_DEST_NAME,
                            minSize: CheckSheetPosInfo.SendDestName.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);
                        //電話番号
                        pdf.WriteTextRegion(new RectangleF(
                            CheckSheetPosInfo.TelNo.XPos,
                            CheckSheetPosInfo.TelNo.YPos + RowPos,
                            CheckSheetPosInfo.TelNo.Width,
                            CheckSheetPosInfo.TelNo.Height),
                            CheckSheetPosInfo.TelNo.Font,
                            CheckSheetPosInfo.TelNo.FontSize,
                            info.SEND_DEST_TEL_NO,
                            minSize: CheckSheetPosInfo.TelNo.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);

                        rowIdx += 1;
                    }
                    keyCount += 1;
                }
            }
            
            
            return outFile;
        }

        #endregion

        #region ヘッダー出力
        /// <summary>
        /// ヘッダー出力
        /// </summary>
        /// <param name="pdf"></param>
        /// <param name="shipDate"></param>
        /// <param name="Page_No"></param>
        /// <param name="max_page"></param>
        private void writeHeader(PdfCreator pdf, string shipDate, int Page_No, int max_page)
        {            

            //発送区分名
            pdf.WriteTextRegion(new RectangleF(
                CheckSheetPosInfo.Header.XPos,
                CheckSheetPosInfo.Header.YPos,
                CheckSheetPosInfo.Header.Width,
                CheckSheetPosInfo.Header.Height),
                CheckSheetPosInfo.Header.Font,
                CheckSheetPosInfo.Header.FontSize,
                "見守る　返却　伝票チェック＜MS＞",
                minSize: CheckSheetPosInfo.Header.FontSize,
                hAlign: HorizontalTextAlignment.Left,
                vAlign: VerticalTextAlignment.Middle);

            //出荷日・年
            pdf.WriteTextRegion(new RectangleF(
                CheckSheetPosInfo.ShippingDate.XPos,
                CheckSheetPosInfo.ShippingDate.YPos,
                CheckSheetPosInfo.ShippingDate.Width,
                CheckSheetPosInfo.ShippingDate.Height),
                CheckSheetPosInfo.ShippingDate.Font,
                CheckSheetPosInfo.ShippingDate.FontSize,
                shipDate.Substring(0, 4) + "年" + shipDate.Substring(4, 2) + "月" + shipDate.Substring(6, 2) + "日" + "　発送",
                minSize: CheckSheetPosInfo.ShippingDate.FontSize,
                hAlign: HorizontalTextAlignment.Left,
                vAlign: VerticalTextAlignment.Middle);
            //ページNO
            pdf.WriteTextRegion(new RectangleF(
                CheckSheetPosInfo.PageNo.XPos,
                CheckSheetPosInfo.PageNo.YPos,
                CheckSheetPosInfo.PageNo.Width,
                CheckSheetPosInfo.PageNo.Height),
                CheckSheetPosInfo.PageNo.Font,
                CheckSheetPosInfo.PageNo.FontSize,
                Page_No.ToString() + "/" + max_page.ToString(),
                minSize: CheckSheetPosInfo.PageNo.FontSize,
                hAlign: HorizontalTextAlignment.Right,
                vAlign: VerticalTextAlignment.Middle);

            //システム日付
            pdf.WriteTextRegion(new RectangleF(
                CheckSheetPosInfo.SystemDate.XPos,
                CheckSheetPosInfo.SystemDate.YPos,
                CheckSheetPosInfo.SystemDate.Width,
                CheckSheetPosInfo.SystemDate.Height),
                CheckSheetPosInfo.SystemDate.Font,
                CheckSheetPosInfo.SystemDate.FontSize,
                DateTime.Now.ToString("yyyyy/MM/dd").Substring(1, (DateTime.Now.ToString("yyyyy/MM/dd")).Length-1),
                minSize: CheckSheetPosInfo.SystemDate.FontSize,
                hAlign: HorizontalTextAlignment.Left,
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
            this.CheckSheetPosInfo = new clsShippingCheckSheetPosInfo();

            clsPdfPosition posInfo = new clsPdfPosition(ConfigurationManager.AppSettings["MSPB003_SHIPPING_CHECK_SHEET_POS_FILE"], "Setting/List");

            //リスト情報
            this.CheckSheetPosInfo.ListInfo = posInfo.getPosInfo("ListInfo");
            //No
            this.CheckSheetPosInfo.No = posInfo.getPosInfo("No");
            //ShippingControlNo
            this.CheckSheetPosInfo.ShippingControlNo = posInfo.getPosInfo("ShippingControlNo");
            //発送先郵便番号
            this.CheckSheetPosInfo.PostNo = posInfo.getPosInfo("PostNo");
            //発送先住所
            this.CheckSheetPosInfo.SendDestAddress = posInfo.getPosInfo("SendDestAddress");
            //お名前
            this.CheckSheetPosInfo.SendDestName = posInfo.getPosInfo("SendDestName");
            //電話番号
            this.CheckSheetPosInfo.TelNo = posInfo.getPosInfo("TelNo");

            //表題
            this.CheckSheetPosInfo.Header = posInfo.getPosInfo("Header");
            //出荷日
            this.CheckSheetPosInfo.ShippingDate = posInfo.getPosInfo("ShippingDate");
            //返送先
            this.CheckSheetPosInfo.Return = posInfo.getPosInfo("Return");
            //ページ
            this.CheckSheetPosInfo.PageNo = posInfo.getPosInfo("PageNo");
            //システム日付
            this.CheckSheetPosInfo.SystemDate = posInfo.getPosInfo("SystemDate");

        }
        #endregion
        #endregion
    }
    #endregion
}
