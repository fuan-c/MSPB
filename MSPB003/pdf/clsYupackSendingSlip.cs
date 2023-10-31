using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using log4net;
using dnp.nulcommon.pdf;
using MSPB.MSPB003.common;
using System.Configuration;

namespace MSPB.MSPB003.pdf
{
    #region 発送チェックシートレコードクラス
    /// <summary>
    /// 発送チェックシートレコードクラス
    /// </summary>
    class clsYupackSendingSlipRecord
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 発送先名
        /// </summary>        
        public string SEND_DEST_NAME { get; set; }
        /// <summary>
        /// 発送先郵便番号
        /// </summary>        
        public string SEND_DEST_POSTAL_CODE { get; set; }
        public string SEND_DEST_POSTAL_CODE_Edit
        {
            get
            {
                string code = string.Empty;

                if (string.IsNullOrEmpty(this.SEND_DEST_POSTAL_CODE))
                {
                    code = string.Empty;
                }
                else
                {
                    code =  string.Format("{0}-{1}",
                        this.SEND_DEST_POSTAL_CODE.Substring(0, 3),
                        this.SEND_DEST_POSTAL_CODE.Substring(3, 4));
                }

                return code;

            }
        }
        /// <summary>
        /// 発送先住所
        /// </summary>        
        public string SEND_DEST_ADDRESS { get; set; }

        // Mod Start Negishi 20220823 ゆうパック確定データ対応

        /// <summary>
        /// 発送先電話番号
        /// </summary>
        public string SEND_DEST_TEL_NO { get; set; }
        /// <summary>
        /// 配送伝票管理番号
        /// </summary>        
        public string DELIVERY_SLIP_CONTROL_NO { get; set; }

        // Mod End Negishi 20220823 ゆうパック確定データ対応 

        /// <summary>
        /// お問合せ番号
        /// </summary>        
        public string CONTACT_NO { get; set; }
        public string CONTACT_NO_Edit
        {
            get
            {
                return string.Format("{0}-{1}-{2}",
                    this.CONTACT_NO.Substring(1, 4), 
                    this.CONTACT_NO.Substring(5, 4), 
                    this.CONTACT_NO.Substring(9, 4));
            }
        }
        /// <summary>
        /// 出荷日
        /// </summary>        
        public string SHIPPING_DATE { get; set; }
        /// <summary>
        /// ラインNO
        /// </summary>        
        public int LINE_NO { get; set; }
        /// <summary>
        /// 発送区分
        /// </summary>        
        public string SHIPPING_CATEGORY { get; set; }
        /// <summary>
        /// サイズ
        /// </summary>        
        public string SIZE { get; set; }
        /// <summary>
        /// 正式名称
        /// </summary>
        public string COMPANY_FORMAL_NAME { get; set; }
        /// <summary>
        /// ゆうパック顧客番号
        /// </summary>
        public string YUPACK_CUSTOMER_NO { get; set; }
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
    class clsYupackSendingSlipPosInfo
    {
        /// <summary>
        /// No
        /// </summary>
        public clsPosInfo No { get; set; }
        /// <summary>
        /// 発送先郵便番号
        /// </summary>
        public clsPosInfo SendDestPostalCode { get; set; }
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
        public clsPosInfo ContactNo { get; set; }
        /// <summary>
        /// お問合せ番号
        /// </summary>
        public clsPosInfo ContactNoBarCode { get; set; }
        /// <summary>
        /// 出荷日・年
        /// </summary>
        public clsPosInfo ShippingDate { get; set; }        
        /// <summary>
        /// ライン番号
        /// </summary>
        public clsPosInfo PageNo { get; set; }
        /// <summary>
        /// リスト情報
        /// </summary>
        public clsPosInfo ListInfo { get; set; }
        public clsPosInfo Size { get; set; }
        public clsPosInfo CustomerCode { get; set; }
        public clsPosInfo CompanyName { get; set; }        
        public clsPosInfo ShippingDepart { get; set; }

    }
    #endregion
    #region 発送チェックシート作成クラス
    /// <summary>
    /// 発送チェックシート作成クラス
    /// </summary>
    class clsYupackSendingSlip
    {
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        #region プロパティ
        /// <summary>
        /// チェックシートデータ
        /// </summary>
        public List<clsYupackSendingSlipRecord> lstYupackSendingSlipData { get; set; }
        /// <summary>
        /// 出荷日
        /// </summary>
        public string SHIPPING_DATE { get; set; }
        /// <summary>
        /// 位置情報
        /// </summary>
        private clsYupackSendingSlipPosInfo YupackSendingSlipPosInfo { get; set; }
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public clsYupackSendingSlip()
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
        public string CreateYupackSendingSlip(string output_type)
        {
            string outPath = Path.Combine(ConfigurationManager.AppSettings["MSPB003_YUPACK_LIST_OUTPUT_PATH"], this.SHIPPING_DATE);
            string outFile = Path.Combine(outPath, string.Format(ConfigurationManager.AppSettings["MSPB003_YUPACK_LIST_FILE"], this.SHIPPING_DATE, output_type,DateTime.Now.ToString("HHmmss")));
            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }
            var dicCheckData = this.lstYupackSendingSlipData.GroupBy(x => new
            {
                SHIPPING_DATE = x.SHIPPING_DATE
            }).ToDictionary(keys => keys.Key, grp => grp.ToList());

            using(PdfCreator pdf = new PdfCreator(outFile, ConfigurationManager.AppSettings["MSPB003_YUPACK_LIST_OVL"]))
            {
                int keyCount = 0;
                int dataCount = 0;
                float RowPosMargine = YupackSendingSlipPosInfo.ListInfo.RowPosMargine;
                int RowCount = YupackSendingSlipPosInfo.ListInfo.RowCount;                                
                int max_page = 0;
                int page_no = 0;
                foreach (var key in dicCheckData.Keys)
                {
                    List<clsYupackSendingSlipRecord> lstData = dicCheckData[key];
                    int rowIdx = 0;
                    max_page = max_page + 1;
                    foreach (clsYupackSendingSlipRecord info in lstData)
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
                    List<clsYupackSendingSlipRecord> lstData = dicCheckData[key];
                    int rowIdx = 0;
                    float RowPos = 0;

                    if (keyCount > 0)
                    {
                        pdf.NextPage();
                        pdf.RepeatTemplate();
                    }
                    //ヘッダー項目出力
                    page_no = page_no + 1;
                    writeHeader(pdf, key.SHIPPING_DATE, page_no, max_page);
                    string YUPACK_CUSTOMER_NO = null;
                    string COMPANY_FORMAL_NAME = null;
                    foreach (clsYupackSendingSlipRecord info in lstData)
                    {
                        YUPACK_CUSTOMER_NO = info.YUPACK_CUSTOMER_NO;
                        COMPANY_FORMAL_NAME = info.COMPANY_FORMAL_NAME;
                        if (rowIdx >= RowCount)
                        {
                            // 2021/11/08 修正 tokimori
                            //フッター項目出力
                            writeFooter(pdf, YUPACK_CUSTOMER_NO, COMPANY_FORMAL_NAME);
                            // 2021/11/08 修正 tokimori end

                            pdf.NextPage();
                            pdf.RepeatTemplate();
                            //ヘッダー項目出力
                            page_no = page_no + 1;
                            writeHeader(pdf, key.SHIPPING_DATE, page_no, max_page);
                            rowIdx = 0;
                        }
                        RowPos = rowIdx * RowPosMargine;
                        dataCount += 1;
                        //No
                        pdf.WriteTextRegion(new RectangleF(
                            YupackSendingSlipPosInfo.No.XPos,
                            YupackSendingSlipPosInfo.No.YPos + RowPos,
                            YupackSendingSlipPosInfo.No.Width,
                            YupackSendingSlipPosInfo.No.Height),
                            YupackSendingSlipPosInfo.No.Font,
                            YupackSendingSlipPosInfo.No.FontSize,
                            dataCount.ToString(),
                            minSize: YupackSendingSlipPosInfo.No.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);
                        //氏名
                        pdf.WriteTextRegion(new RectangleF(
                            YupackSendingSlipPosInfo.SendDestName.XPos,
                            YupackSendingSlipPosInfo.SendDestName.YPos + RowPos,
                            YupackSendingSlipPosInfo.SendDestName.Width,
                            YupackSendingSlipPosInfo.SendDestName.Height),
                            YupackSendingSlipPosInfo.SendDestAddress.Font,
                            YupackSendingSlipPosInfo.SendDestName.FontSize,
                            info.SEND_DEST_NAME,
                            minSize: YupackSendingSlipPosInfo.SendDestName.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);
                        //郵便番号
                        pdf.WriteTextRegion(new RectangleF(
                            YupackSendingSlipPosInfo.SendDestPostalCode.XPos,
                            YupackSendingSlipPosInfo.SendDestPostalCode.YPos + RowPos,
                            YupackSendingSlipPosInfo.SendDestPostalCode.Width,
                            YupackSendingSlipPosInfo.SendDestPostalCode.Height),
                            YupackSendingSlipPosInfo.SendDestPostalCode.Font,
                            YupackSendingSlipPosInfo.SendDestPostalCode.FontSize,
                            info.SEND_DEST_POSTAL_CODE_Edit,
                            minSize: YupackSendingSlipPosInfo.SendDestPostalCode.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);
                        //住所
                        pdf.WriteTextRegion(new RectangleF(
                            YupackSendingSlipPosInfo.SendDestAddress.XPos,
                            YupackSendingSlipPosInfo.SendDestAddress.YPos + RowPos,
                            YupackSendingSlipPosInfo.SendDestAddress.Width,
                            YupackSendingSlipPosInfo.SendDestAddress.Height),
                            YupackSendingSlipPosInfo.SendDestAddress.Font,
                            YupackSendingSlipPosInfo.SendDestAddress.FontSize,
                            info.SEND_DEST_ADDRESS,
                            minSize: YupackSendingSlipPosInfo.SendDestAddress.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);
                        //サイズ
                        pdf.WriteTextRegion(new RectangleF(
                            YupackSendingSlipPosInfo.Size.XPos,
                            YupackSendingSlipPosInfo.Size.YPos + RowPos,
                            YupackSendingSlipPosInfo.Size.Width,
                            YupackSendingSlipPosInfo.Size.Height),
                            YupackSendingSlipPosInfo.Size.Font,
                            YupackSendingSlipPosInfo.Size.FontSize,
                            YupackSendingSlipPosInfo.Size.Text,
                            minSize: YupackSendingSlipPosInfo.Size.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);
                        //お問合せ番号
                        pdf.WriteTextRegion(new RectangleF(
                            YupackSendingSlipPosInfo.ContactNo.XPos,
                            YupackSendingSlipPosInfo.ContactNo.YPos + RowPos,
                            YupackSendingSlipPosInfo.ContactNo.Width,
                            YupackSendingSlipPosInfo.ContactNo.Height),
                            YupackSendingSlipPosInfo.ContactNo.Font,
                            YupackSendingSlipPosInfo.ContactNo.FontSize,
                            info.CONTACT_NO_Edit,
                            minSize: YupackSendingSlipPosInfo.ContactNo.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);

                        //問合せ番号バーコード
                        pdf.DrawBarCode(new RectangleF(
                            YupackSendingSlipPosInfo.ContactNoBarCode.XPos,
                            YupackSendingSlipPosInfo.ContactNoBarCode.YPos + RowPos,
                            YupackSendingSlipPosInfo.ContactNoBarCode.Width,
                            YupackSendingSlipPosInfo.ContactNoBarCode.Height),
                            info.CONTACT_NO);

                        rowIdx += 1;
                    }
                    keyCount += 1;

                    //フッター項目出力
                    writeFooter(pdf, YUPACK_CUSTOMER_NO, COMPANY_FORMAL_NAME);
                }
            }
            return outFile;
        }
        #endregion
        #region ヘッダー出力
        /// <summary>
        /// ヘッダー出力
        /// </summary>
        /// <param name="pdf"></param>Data
        /// <param name="shipName"></param>
        /// <param name="shipDate"></param>
        /// <param name="lineNo"></param>
        /// <param name="packCount"></param>
        /// <param name=""></param>
        /// <param name="totalCount"></param>
        private void writeHeader(PdfCreator pdf,string shipDate,int pageNo, int max_page)
        {

            //出荷日
            pdf.WriteTextRegion(new RectangleF(
                YupackSendingSlipPosInfo.ShippingDate.XPos,
                YupackSendingSlipPosInfo.ShippingDate.YPos,
                YupackSendingSlipPosInfo.ShippingDate.Width,
                YupackSendingSlipPosInfo.ShippingDate.Height),
                YupackSendingSlipPosInfo.ShippingDate.Font,
                YupackSendingSlipPosInfo.ShippingDate.FontSize,
                shipDate.Substring(0,4) + "年" + shipDate.Substring(4, 2) + "月" + shipDate.Substring(6, 2) + "日",
                minSize: YupackSendingSlipPosInfo.ShippingDate.FontSize,
                hAlign: HorizontalTextAlignment.Right,
                vAlign: VerticalTextAlignment.Middle);

            //発送部署
            pdf.WriteTextRegion(new RectangleF(
                YupackSendingSlipPosInfo.ShippingDepart.XPos,
                YupackSendingSlipPosInfo.ShippingDepart.YPos,
                YupackSendingSlipPosInfo.ShippingDepart.Width,
                YupackSendingSlipPosInfo.ShippingDepart.Height),
                YupackSendingSlipPosInfo.ShippingDepart.Font,
                YupackSendingSlipPosInfo.ShippingDepart.FontSize,
                ConfigurationManager.AppSettings["MSPB003_YUPACK_SEND_DEPT"],
                minSize: YupackSendingSlipPosInfo.ShippingDepart.FontSize,
                hAlign: HorizontalTextAlignment.Right,
                vAlign: VerticalTextAlignment.Middle);

            //ページNO
            pdf.WriteTextRegion(new RectangleF(
                YupackSendingSlipPosInfo.PageNo.XPos,
                YupackSendingSlipPosInfo.PageNo.YPos,
                YupackSendingSlipPosInfo.PageNo.Width,
                YupackSendingSlipPosInfo.PageNo.Height),
                YupackSendingSlipPosInfo.PageNo.Font,
                YupackSendingSlipPosInfo.PageNo.FontSize,
                pageNo.ToString() + "/" + max_page.ToString(),
                minSize: YupackSendingSlipPosInfo.PageNo.FontSize,
                hAlign: HorizontalTextAlignment.Right,
                vAlign: VerticalTextAlignment.Middle);
        }
        #endregion
        #region フッター出力
        /// <summary>
        /// フッター出力
        /// </summary>
        /// <param name="pdf"></param>Data
        /// <param name="shipName"></param>
        /// <param name="shipDate"></param>
        private void writeFooter(PdfCreator pdf, string YUPACK_CUSTOMER_NO, string COMPANY_FORMAL_NAME)
        {

              //顧客コード
            pdf.WriteTextRegion(new RectangleF(
                YupackSendingSlipPosInfo.CustomerCode.XPos,
                YupackSendingSlipPosInfo.CustomerCode.YPos,
                YupackSendingSlipPosInfo.CustomerCode.Width,
                YupackSendingSlipPosInfo.CustomerCode.Height),
                YupackSendingSlipPosInfo.CustomerCode.Font,
                YupackSendingSlipPosInfo.CustomerCode.FontSize,
                YUPACK_CUSTOMER_NO,
                minSize: YupackSendingSlipPosInfo.CustomerCode.FontSize,
                hAlign: HorizontalTextAlignment.Left,
                vAlign: VerticalTextAlignment.Middle);

            //  会社名
            pdf.WriteTextRegion(new RectangleF(
                YupackSendingSlipPosInfo.CompanyName.XPos,
                YupackSendingSlipPosInfo.CompanyName.YPos,
                YupackSendingSlipPosInfo.CompanyName.Width,
                YupackSendingSlipPosInfo.CompanyName.Height),
                YupackSendingSlipPosInfo.CompanyName.Font,
                YupackSendingSlipPosInfo.CompanyName.FontSize,
                COMPANY_FORMAL_NAME,
                minSize: YupackSendingSlipPosInfo.CompanyName.FontSize,
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
            this.YupackSendingSlipPosInfo = new clsYupackSendingSlipPosInfo();

            clsPdfPosition posInfo = new clsPdfPosition(ConfigurationManager.AppSettings["MSPB003_YUPACK_LIST_POS_FILE"], "Setting/List");

            //リスト情報
            this.YupackSendingSlipPosInfo.ListInfo = posInfo.getPosInfo("ListInfo");
            //No
            this.YupackSendingSlipPosInfo.No = posInfo.getPosInfo("No");
            //発送先郵便番号
            this.YupackSendingSlipPosInfo.SendDestPostalCode = posInfo.getPosInfo("SendDestPostalCode");
            //発送先住所
            this.YupackSendingSlipPosInfo.SendDestAddress = posInfo.getPosInfo("SendDestAddress");
            //発送先名
            this.YupackSendingSlipPosInfo.SendDestName = posInfo.getPosInfo("SendDestName");
            //お問合せ番号
            this.YupackSendingSlipPosInfo.ContactNo = posInfo.getPosInfo("ContactNo");
            //問合せ番号バーコード
            this.YupackSendingSlipPosInfo.ContactNoBarCode = posInfo.getPosInfo("ContactNoBarCode");
            //出荷日
            this.YupackSendingSlipPosInfo.ShippingDate = posInfo.getPosInfo("ShippingDate");            
            //ページ番号
            this.YupackSendingSlipPosInfo.PageNo = posInfo.getPosInfo("PageNo");
            //サイズ番号
            this.YupackSendingSlipPosInfo.Size = posInfo.getPosInfo("Size");
            //顧客コード
            this.YupackSendingSlipPosInfo.CustomerCode = posInfo.getPosInfo("CustomerCode");
            //会社名
            this.YupackSendingSlipPosInfo.CompanyName = posInfo.getPosInfo("CompanyName");
            //発送部署
            this.YupackSendingSlipPosInfo.ShippingDepart = posInfo.getPosInfo("ShippingDepart");
        }
        #endregion

        #endregion
    }
    #endregion
}
