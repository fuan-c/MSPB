using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Configuration;
using Microsoft.VisualBasic;
using log4net;
using dnp.nulcommon.pdf;

namespace MSPB.MSPB003.pdf
{

    #region 配送伝票レコードクラス
    /// <summary>
    /// 配送伝票レコードクラス
    /// </summary>
    class clsDeliverySlipRecord
    {
        /// <summary>
        /// 出荷日
        /// </summary>
        public string SHIPPING_DATE { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public Int32 ID { get; set; }
        /// <summary>
        /// 証券番号
        /// </summary>
        public string CONTRACT_NO { get; set; }
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
        /// 配送伝票管理番号
        /// </summary>
        public string DELIVERY_SLIP_CONTROL_NO { get; set; }
        /// <summary>
        /// お問合せ番号
        /// </summary>
        public string CONTACT_NO { get; set; }
        /// <summary>
        /// お問合せ番号(出力用)
        /// </summary>
        public string CONTACT_NO_Edit
        {
            get
            {
                return string.Format("{0}ー{1}ー{2}",
                    Microsoft.VisualBasic.Strings.StrConv(this.CONTACT_NO.Substring(1, 4), VbStrConv.Wide),
                    Microsoft.VisualBasic.Strings.StrConv(this.CONTACT_NO.Substring(5, 4), VbStrConv.Wide),
                    Microsoft.VisualBasic.Strings.StrConv(this.CONTACT_NO.Substring(9, 4), VbStrConv.Wide));
            }
        }
        /// <summary>
        /// 仕分番号
        /// </summary>
        public string SORTING_NO { get; set; }
        /// <summary>
        /// 配送先電話番号
        /// </summary>
        public string SEND_DEST_TEL_NO { get; set; }
        /// <summary>
        /// 配送先電話番号（出力用）
        /// </summary>
        public string SEND_DEST_TEL_NO_Edit
        {
            get
            {
                return "TEL:" + this.SEND_DEST_TEL_NO;
            }
        }
        /// <summary>
        /// ゆうパック顧客番号
        /// </summary>
        public string YUPACK_CUSTOMER_NO { get; set; }
        /// <summary>
        /// 発送先名（出力用）
        /// </summary>
        public string SEND_DEST_NAME_Edit
        {
            get
            {
                return this.SEND_DEST_NAME + "　様";
            }
        }

        /// <summary>
        /// 発送先郵便番号（出力用）
        /// </summary>
        public string POSTAL_CODE_Edit
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
                    code = this.SEND_DEST_POSTAL_CODE.Insert(3, "-");
                }

                return code;

            }
        }
        /// <summary>
        /// 仕分番号（出力用）
        /// </summary>
        public string SORTING_NO_Edit
        {
            get
            {
                string code = string.Empty;

                if (string.IsNullOrEmpty(this.SORTING_NO))
                {
                    code = string.Empty;
                }
                else
                {
                    code = string.Format("{0}-{1}-",
                    this.SORTING_NO.Substring(0, 2),
                    this.SORTING_NO.Substring(2, 2));
                }

                return code;
            }
        }
        /// <summary>
        /// 仕分番号（出力用）
        /// </summary>
        public string SORTING_NO_Edit2
        {

            get
            {

                string code = string.Empty;

                if (string.IsNullOrEmpty(this.SORTING_NO))
                {
                    code = string.Empty;
                }
                else
                {
                    code = string.Format("{0}",
                    this.SORTING_NO.Substring(4, 2));
                }

                return code;
            }
        }
    }
    #endregion

    #region 配送伝票位置情報クラス
    /// <summary>
    /// 配送伝票位置情報クラス
    /// </summary>
    class clsDeliverySlipPosInfo
    {
        /// <summary>
        /// ラベル情報
        /// </summary>
        public clsPosInfo LabelInfo { get; set; }
        /// <summary>
        /// 宛先郵便番号
        /// </summary>
        public clsPosInfo SendestPostalNo { get; set; }
        /// <summary>
        /// 宛先郵便番号
        /// </summary>
        public clsPosInfo SendestPostalNo_No21 { get; set; }
        /// <summary>
        /// 宛先住所
        /// </summary>
        public clsPosInfo SendestAddress { get; set; }
        /// <summary>
        /// 宛先住所
        /// </summary>
        public clsPosInfo SendestAddress_No22 { get; set; }
        /// <summary>
        /// 宛先氏名
        /// </summary>
        public clsPosInfo SendestName { get; set; }
        /// <summary>
        /// 宛先氏名
        /// </summary>
        public clsPosInfo SendestName_No24 { get; set; }
        /// <summary>
        /// 証券番号
        /// </summary>
        public clsPosInfo PolycyNo_No25 { get; set; }
        /// <summary>
        /// 証券番号
        /// </summary>
        public clsPosInfo PolycyNo { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public clsPosInfo ProductName { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public clsPosInfo ProductName_No30 { get; set; }
        /// <summary>
        /// 差出人郵便番号
        /// </summary>
        public clsPosInfo SederPostalNo { get; set; }
        /// <summary>
        /// 差出人郵便番号
        /// </summary>
        public clsPosInfo SederPostalNo_No26 { get; set; }
        /// <summary>
        /// 差出人
        /// </summary>
        public clsPosInfo Sender { get; set; }
        /// <summary>
        /// 差出人
        /// </summary>
        public clsPosInfo Sender_No27 { get; set; }
        /// <summary>
        /// ご依頼主住所
        /// </summary>
        public clsPosInfo SenderAddress { get; set; }
        /// <summary>
        /// ご依頼主住所
        /// </summary>
        public clsPosInfo SenderAddress_No28 { get; set; }
        /// <summary>
        /// 還付先①
        /// </summary>
        public clsPosInfo SenderRefund1 { get; set; }
        /// <summary>
        /// 還付先①
        /// </summary>
        public clsPosInfo SenderRefund1_No29 { get; set; }
        /// <summary>
        /// 還付先②
        /// </summary>
        public clsPosInfo SenderRefund2 { get; set; }
        /// <summary>
        /// 還付先②
        /// </summary>
        public clsPosInfo SenderRefund2_No29 { get; set; }
        /// <summary>
        /// 還付先③
        /// </summary>
        public clsPosInfo SenderRefund3 { get; set; }
        /// <summary>
        /// 還付先③
        /// </summary>
        public clsPosInfo SenderRefund3_No29 { get; set; }
        /// <summary>
        /// 仕分番号バーコード
        /// </summary>
        public clsPosInfo SortingNoBarCode { get; set; }
        public clsPosInfo SortingNoBarCodeStr { get; set; }
        /// <summary>
        /// 仕分番号
        /// </summary>
        public clsPosInfo SortingNo { get; set; }
        /// <summary>
        /// 仕分番号
        /// </summary>
        public clsPosInfo SortingNo_No2 { get; set; }
        /// <summary>
        /// 電話番号
        /// </summary>
        public clsPosInfo SendDestTelNo { get; set; }
        /// <summary>
        /// 電話番号
        /// </summary>
        public clsPosInfo SendDestTelNo_No23 { get; set; }
        /// <summary>
        /// 問合せ番号バーコード
        /// </summary>
        public clsPosInfo ContactNoBarCode { get; set; }
        public clsPosInfo ContactNoBarCodeStr { get; set; }
        /// <summary>
        /// 問合せ番号バーコード
        /// </summary>
        public clsPosInfo ContactNoBarCode_No19 { get; set; }
        public clsPosInfo ContactNoBarCodeStr_No19 { get; set; }
        /// <summary>
        /// 問合せ番号
        /// </summary>
        public clsPosInfo ContactNo { get; set; }
        /// <summary>
        /// 問合せ番号
        /// </summary>
        public clsPosInfo ContactNo_No32 { get; set; }
        /// <summary>
        ///ご依頼主用番号/配送伝票管理番号
        /// </summary>
        public clsPosInfo DeliverySlipControlNo { get; set; }
        public clsPosInfo DeliverySlipControlNo_No31 { get; set; }
        public clsPosInfo News { get; set; }
        public clsPosInfo News_No33 { get; set; }
        public clsPosInfo Size { get; set; }
        public clsPosInfo Size_No34 { get; set; }
        public clsPosInfo Dealer { get; set; }
        public clsPosInfo Dealer_No35 { get; set; }
        public clsPosInfo CustomerCode { get; set; }

    }
    #endregion
    
    #region 配送伝票作成クラス
    /// <summary>
    /// 配送伝票作成クラス
    /// </summary>
    class clsDeliverySlip
    {
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region プロパティ
        /// <summary>
        /// 配送伝票データ
        /// </summary>
        public List<clsDeliverySlipRecord> lstDeliverySlipData { get; set; }
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
        private clsDeliverySlipPosInfo SlipPosInfo { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public clsDeliverySlip()
        {
            //位置情報取得
            getPosInfo();

        }
        #endregion

        #region メソッド

        #region MSゆうパック配送伝票作成
        /// <summary>
        /// MSゆうパック配送伝票作成
        /// </summary>
        /// <returns></returns>
        public string CreateDeliverySlip()
        {
                        
            _logger.Debug("MSゆうパック配送伝票作成");

            string outPath = Path.Combine(ConfigurationManager.AppSettings["MSPB003_YU_PACK_DELIVERY_SLIP_OUTPUT_PATH"], this.SHIPPING_DATE);
            string outFile = Path.Combine(outPath,
                string.Format(ConfigurationManager.AppSettings["MSPB003_YU_PACK_DELIVERY_SLIP_FILE"],
                this.SHIPPING_DATE, this.SHIPPING_SLIP_TYPE, DateTime.Now.ToString("HHmmss")));

            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }

            var dicSlipData = this.lstDeliverySlipData.GroupBy(x => new
            {
                SHIPPING_DATE = x.SHIPPING_DATE
            }).ToDictionary(keys => keys.Key, grp => grp.ToList());

            using (PdfCreator pdf = new PdfCreator(outFile, ConfigurationManager.AppSettings["MSPB003_YU_PACK_DELIVERY_SLIP_OVL"]))
            {
                int keyCount = 0;
                float RowPosMargine = SlipPosInfo.LabelInfo.RowPosMargine;
                float ColPosMargine = SlipPosInfo.LabelInfo.ColPosMargine;
                int RowCount = SlipPosInfo.LabelInfo.RowCount;
                int ColCount = SlipPosInfo.LabelInfo.ColCount;

                foreach (var key in dicSlipData.Keys)
                {
                    if (keyCount > 0)
                    {
                        pdf.NextPage();
                        pdf.RepeatTemplate();
                    }

                    List<clsDeliverySlipRecord> lstSlipData = dicSlipData[key];

                    int colidx = 0;
                    int rowIdx = 0;
                    float ColPos = 0;
                    float RowPos = 0;
                    foreach (clsDeliverySlipRecord info in lstSlipData)
                    {
                        if (rowIdx >= RowCount)
                        {
                            pdf.NextPage();
                            pdf.RepeatTemplate();
                            colidx = 0;
                            rowIdx = 0;
                        }

                        ColPos = colidx * ColPosMargine;
                        RowPos = rowIdx * RowPosMargine;


                        //発送先郵便番号
                        pdf.WriteTextRegion(new RectangleF(
                                SlipPosInfo.SendestPostalNo.XPos + ColPos,
                                SlipPosInfo.SendestPostalNo.YPos + RowPos,
                                SlipPosInfo.SendestPostalNo.Width,
                                SlipPosInfo.SendestPostalNo.Height),
                                SlipPosInfo.SendestPostalNo.Font,
                                SlipPosInfo.SendestPostalNo.FontSize,
                                !string.IsNullOrEmpty(info.SEND_DEST_POSTAL_CODE) ?
                                info.POSTAL_CODE_Edit : string.Empty,
                                minSize: SlipPosInfo.SendestPostalNo.FontSize,
                                vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SendestPostalNo_No21.XPos + ColPos,
                            SlipPosInfo.SendestPostalNo_No21.YPos + RowPos,
                            SlipPosInfo.SendestPostalNo_No21.Width,
                            SlipPosInfo.SendestPostalNo_No21.Height),
                            SlipPosInfo.SendestPostalNo_No21.Font,
                            SlipPosInfo.SendestPostalNo_No21.FontSize,
                            !string.IsNullOrEmpty(info.SEND_DEST_POSTAL_CODE) ?
                            info.POSTAL_CODE_Edit : string.Empty,
                            minSize: SlipPosInfo.SendestPostalNo_No21.FontSize,
                            vAlign: VerticalTextAlignment.Top);

                        //発送先住所
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SendestAddress.XPos + ColPos,
                            SlipPosInfo.SendestAddress.YPos + RowPos,
                            SlipPosInfo.SendestAddress.Width,
                            SlipPosInfo.SendestAddress.Height),
                            SlipPosInfo.SendestAddress.Font,
                            SlipPosInfo.SendestAddress.FontSize,
                            !string.IsNullOrEmpty(info.SEND_DEST_ADDRESS) ?
                            info.SEND_DEST_ADDRESS : string.Empty,
                            minSize: SlipPosInfo.SendestAddress.FontSize,
                            vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SendestAddress_No22.XPos + ColPos,
                            SlipPosInfo.SendestAddress_No22.YPos + RowPos,
                            SlipPosInfo.SendestAddress_No22.Width,
                            SlipPosInfo.SendestAddress_No22.Height),
                            SlipPosInfo.SendestAddress_No22.Font,
                            SlipPosInfo.SendestAddress_No22.FontSize,
                            !string.IsNullOrEmpty(info.SEND_DEST_ADDRESS) ?
                            info.SEND_DEST_ADDRESS : string.Empty,
                            minSize: SlipPosInfo.SendestAddress_No22.FontSize,
                            vAlign: VerticalTextAlignment.Top);

                        //発送先名
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SendestName.XPos + ColPos,
                            SlipPosInfo.SendestName.YPos + RowPos,
                            SlipPosInfo.SendestName.Width,
                            SlipPosInfo.SendestName.Height),
                            SlipPosInfo.SendestName.Font,
                            SlipPosInfo.SendestName.FontSize,
                            !string.IsNullOrEmpty(info.SEND_DEST_NAME) ?
                            info.SEND_DEST_NAME_Edit : string.Empty,
                            minSize: SlipPosInfo.SendestName.FontSize,
                            vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                             SlipPosInfo.SendestName_No24.XPos + ColPos,
                             SlipPosInfo.SendestName_No24.YPos + RowPos,
                             SlipPosInfo.SendestName_No24.Width,
                             SlipPosInfo.SendestName_No24.Height),
                             SlipPosInfo.SendestName_No24.Font,
                             SlipPosInfo.SendestName_No24.FontSize,
                             !string.IsNullOrEmpty(info.SEND_DEST_NAME) ?
                             info.SEND_DEST_NAME_Edit : string.Empty,
                             minSize: SlipPosInfo.SendestName_No24.FontSize,
                             vAlign: VerticalTextAlignment.Top);

                        //証券番号
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.PolycyNo.XPos + ColPos,
                            SlipPosInfo.PolycyNo.YPos + RowPos,
                            SlipPosInfo.PolycyNo.Width,
                            SlipPosInfo.PolycyNo.Height),
                            SlipPosInfo.PolycyNo.Font,
                            SlipPosInfo.PolycyNo.FontSize,
                            info.CONTRACT_NO,
                            minSize: SlipPosInfo.PolycyNo.FontSize,
                            vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.PolycyNo_No25.XPos + ColPos,
                            SlipPosInfo.PolycyNo_No25.YPos + RowPos,
                            SlipPosInfo.PolycyNo_No25.Width,
                            SlipPosInfo.PolycyNo_No25.Height),
                            SlipPosInfo.PolycyNo_No25.Font,
                            SlipPosInfo.PolycyNo_No25.FontSize,
                            info.CONTRACT_NO,
                            minSize: SlipPosInfo.PolycyNo_No25.FontSize,
                            vAlign: VerticalTextAlignment.Top);

                        //品名
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.ProductName.XPos + ColPos,
                            SlipPosInfo.ProductName.YPos + RowPos,
                            SlipPosInfo.ProductName.Width,
                            SlipPosInfo.ProductName.Height),
                            SlipPosInfo.ProductName.Font,
                            SlipPosInfo.ProductName.FontSize,
                            info.ITEM_NAME,
                            minSize: SlipPosInfo.ProductName.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.ProductName_No30.XPos + ColPos,
                            SlipPosInfo.ProductName_No30.YPos + RowPos,
                            SlipPosInfo.ProductName_No30.Width,
                            SlipPosInfo.ProductName_No30.Height),
                            SlipPosInfo.ProductName_No30.Font,
                            SlipPosInfo.ProductName_No30.FontSize,
                            info.ITEM_NAME,
                            minSize: SlipPosInfo.ProductName_No30.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);

                        //仕分コードバーコード
                        pdf.DrawBarCode128(new RectangleF(
                            SlipPosInfo.SortingNoBarCode.XPos + ColPos,
                            SlipPosInfo.SortingNoBarCode.YPos + RowPos,
                            SlipPosInfo.SortingNoBarCode.Width,
                            SlipPosInfo.SortingNoBarCode.Height),
                            info.SORTING_NO);

                        //仕分コード
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SortingNo.XPos + ColPos,
                            SlipPosInfo.SortingNo.YPos + RowPos,
                            SlipPosInfo.SortingNo.Width,
                            SlipPosInfo.SortingNo.Height),
                            SlipPosInfo.SortingNo.Font,
                            SlipPosInfo.SortingNo.FontSize,
                            info.SORTING_NO_Edit,
                            minSize: SlipPosInfo.SortingNo.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Top);

                        //仕分コード
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SortingNo_No2.XPos + ColPos,
                            SlipPosInfo.SortingNo_No2.YPos + RowPos,
                            SlipPosInfo.SortingNo_No2.Width,
                            SlipPosInfo.SortingNo_No2.Height),
                            SlipPosInfo.SortingNo_No2.Font,
                            SlipPosInfo.SortingNo_No2.FontSize,
                            info.SORTING_NO_Edit2,
                            minSize: SlipPosInfo.SortingNo_No2.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Bottom);

                        //仕分コード下文字
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SortingNoBarCodeStr.XPos + ColPos,
                            SlipPosInfo.SortingNoBarCodeStr.YPos + RowPos,
                            SlipPosInfo.SortingNoBarCodeStr.Width,
                            SlipPosInfo.SortingNoBarCodeStr.Height),
                            SlipPosInfo.SortingNoBarCodeStr.Font,
                            SlipPosInfo.SortingNoBarCodeStr.FontSize,
                            info.SORTING_NO,
                            minSize: SlipPosInfo.SortingNoBarCodeStr.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Bottom);

                        //問合せ番号バーコード
                        pdf.DrawBarCode(new RectangleF(
                            SlipPosInfo.ContactNoBarCode.XPos + ColPos,
                            SlipPosInfo.ContactNoBarCode.YPos + RowPos,
                            SlipPosInfo.ContactNoBarCode.Width,
                            SlipPosInfo.ContactNoBarCode.Height),
                            info.CONTACT_NO);
                        pdf.DrawBarCode(new RectangleF(
                            SlipPosInfo.ContactNoBarCode_No19.XPos + ColPos,
                            SlipPosInfo.ContactNoBarCode_No19.YPos + RowPos,
                            SlipPosInfo.ContactNoBarCode_No19.Width,
                            SlipPosInfo.ContactNoBarCode_No19.Height),
                            info.CONTACT_NO);

                        //問合せ番号バーコード下文字
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.ContactNoBarCodeStr.XPos + ColPos,
                            SlipPosInfo.ContactNoBarCodeStr.YPos + RowPos,
                            SlipPosInfo.ContactNoBarCodeStr.Width,
                            SlipPosInfo.ContactNoBarCodeStr.Height),
                            SlipPosInfo.ContactNoBarCodeStr.Font,
                            SlipPosInfo.ContactNoBarCodeStr.FontSize,
                            info.CONTACT_NO,
                            minSize: SlipPosInfo.ContactNoBarCodeStr.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Bottom);

                        //問合せ番号バーコード下文字
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.ContactNoBarCodeStr_No19.XPos + ColPos,
                            SlipPosInfo.ContactNoBarCodeStr_No19.YPos + RowPos,
                            SlipPosInfo.ContactNoBarCodeStr_No19.Width,
                            SlipPosInfo.ContactNoBarCodeStr_No19.Height),
                            SlipPosInfo.ContactNoBarCodeStr_No19.Font,
                            SlipPosInfo.ContactNoBarCodeStr_No19.FontSize,
                            info.CONTACT_NO,
                            minSize: SlipPosInfo.ContactNoBarCodeStr_No19.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Bottom);

                        //問合せ番号
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.ContactNo.XPos + ColPos,
                            SlipPosInfo.ContactNo.YPos + RowPos,
                            SlipPosInfo.ContactNo.Width,
                            SlipPosInfo.ContactNo.Height),
                            SlipPosInfo.ContactNo.Font,
                            SlipPosInfo.ContactNo.FontSize,
                            info.CONTACT_NO_Edit,
                            minSize: SlipPosInfo.ContactNo.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.ContactNo_No32.XPos + ColPos,
                            SlipPosInfo.ContactNo_No32.YPos + RowPos,
                            SlipPosInfo.ContactNo_No32.Width,
                            SlipPosInfo.ContactNo_No32.Height),
                            SlipPosInfo.ContactNo_No32.Font,
                            SlipPosInfo.ContactNo_No32.FontSize,
                            info.CONTACT_NO_Edit,
                            minSize: SlipPosInfo.ContactNo_No32.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Top);

                        //差出人郵便番号
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SederPostalNo.XPos + ColPos,
                            SlipPosInfo.SederPostalNo.YPos + RowPos,
                            SlipPosInfo.SederPostalNo.Width,
                            SlipPosInfo.SederPostalNo.Height),
                            SlipPosInfo.SederPostalNo.Font,
                            SlipPosInfo.SederPostalNo.FontSize,
                            SlipPosInfo.SederPostalNo.Text,
                            minSize: SlipPosInfo.SederPostalNo.FontSize,
                            vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SederPostalNo_No26.XPos + ColPos,
                            SlipPosInfo.SederPostalNo_No26.YPos + RowPos,
                            SlipPosInfo.SederPostalNo_No26.Width,
                            SlipPosInfo.SederPostalNo_No26.Height),
                            SlipPosInfo.SederPostalNo_No26.Font,
                            SlipPosInfo.SederPostalNo_No26.FontSize,
                            SlipPosInfo.SederPostalNo_No26.Text,
                            minSize: SlipPosInfo.SederPostalNo_No26.FontSize,
                            vAlign: VerticalTextAlignment.Top);

                        //差出人
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.Sender.XPos + ColPos,
                            SlipPosInfo.Sender.YPos + RowPos,
                            SlipPosInfo.Sender.Width,
                            SlipPosInfo.Sender.Height),
                            SlipPosInfo.Sender.Font,
                            SlipPosInfo.Sender.FontSize,
                            SlipPosInfo.Sender.Text,
                            minSize: SlipPosInfo.Sender.FontSize,
                            vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.Sender_No27.XPos + ColPos,
                            SlipPosInfo.Sender_No27.YPos + RowPos,
                            SlipPosInfo.Sender_No27.Width,
                            SlipPosInfo.Sender_No27.Height),
                            SlipPosInfo.Sender_No27.Font,
                            SlipPosInfo.Sender_No27.FontSize,
                            SlipPosInfo.Sender_No27.Text,
                            minSize: SlipPosInfo.Sender_No27.FontSize,
                            vAlign: VerticalTextAlignment.Top);

                        //ご依頼主住所
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SenderAddress.XPos + ColPos,
                            SlipPosInfo.SenderAddress.YPos + RowPos,
                            SlipPosInfo.SenderAddress.Width,
                            SlipPosInfo.SenderAddress.Height),
                            SlipPosInfo.SenderAddress.Font,
                            SlipPosInfo.SenderAddress.FontSize,
                            SlipPosInfo.SenderAddress.Text,
                            minSize: SlipPosInfo.SenderAddress.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SenderAddress_No28.XPos + ColPos,
                            SlipPosInfo.SenderAddress_No28.YPos + RowPos,
                            SlipPosInfo.SenderAddress_No28.Width,
                            SlipPosInfo.SenderAddress_No28.Height),
                            SlipPosInfo.SenderAddress_No28.Font,
                            SlipPosInfo.SenderAddress_No28.FontSize,
                            SlipPosInfo.SenderAddress_No28.Text,
                            minSize: SlipPosInfo.SenderAddress_No28.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Top);

                        //還付先①
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SenderRefund1.XPos + ColPos,
                            SlipPosInfo.SenderRefund1.YPos + RowPos,
                            SlipPosInfo.SenderRefund1.Width,
                            SlipPosInfo.SenderRefund1.Height),
                            SlipPosInfo.SenderRefund1.Font,
                            SlipPosInfo.SenderRefund1.FontSize,
                            SlipPosInfo.SenderRefund1.Text.Replace(",", "\r\n"),
                            minSize: SlipPosInfo.SenderRefund1.FontSize,
                            vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SenderRefund1_No29.XPos + ColPos,
                            SlipPosInfo.SenderRefund1_No29.YPos + RowPos,
                            SlipPosInfo.SenderRefund1_No29.Width,
                            SlipPosInfo.SenderRefund1_No29.Height),
                            SlipPosInfo.SenderRefund1_No29.Font,
                            SlipPosInfo.SenderRefund1_No29.FontSize,
                            SlipPosInfo.SenderRefund1_No29.Text.Replace(",", "\r\n"),
                            minSize: SlipPosInfo.SenderRefund1_No29.FontSize,
                            vAlign: VerticalTextAlignment.Top);

                        //還付先②
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SenderRefund2.XPos + ColPos,
                            SlipPosInfo.SenderRefund2.YPos + RowPos,
                            SlipPosInfo.SenderRefund2.Width,
                            SlipPosInfo.SenderRefund2.Height),
                            SlipPosInfo.SenderRefund2.Font,
                            SlipPosInfo.SenderRefund2.FontSize,
                            SlipPosInfo.SenderRefund2.Text.Replace(",", "\r\n"),
                            minSize: SlipPosInfo.SenderRefund2.FontSize,
                            vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SenderRefund2_No29.XPos + ColPos,
                            SlipPosInfo.SenderRefund2_No29.YPos + RowPos,
                            SlipPosInfo.SenderRefund2_No29.Width,
                            SlipPosInfo.SenderRefund2_No29.Height),
                            SlipPosInfo.SenderRefund2_No29.Font,
                            SlipPosInfo.SenderRefund2_No29.FontSize,
                            SlipPosInfo.SenderRefund2_No29.Text.Replace(",", "\r\n"),
                            minSize: SlipPosInfo.SenderRefund2_No29.FontSize,
                            vAlign: VerticalTextAlignment.Top);

                        //還付先③
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SenderRefund3.XPos + ColPos,
                            SlipPosInfo.SenderRefund3.YPos + RowPos,
                            SlipPosInfo.SenderRefund3.Width,
                            SlipPosInfo.SenderRefund3.Height),
                            SlipPosInfo.SenderRefund3.Font,
                            SlipPosInfo.SenderRefund3.FontSize,
                            SlipPosInfo.SenderRefund3.Text.Replace(",", "\r\n"),
                            minSize: SlipPosInfo.SenderRefund3.FontSize,
                            vAlign: VerticalTextAlignment.Top);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SenderRefund3_No29.XPos + ColPos,
                            SlipPosInfo.SenderRefund3_No29.YPos + RowPos,
                            SlipPosInfo.SenderRefund3_No29.Width,
                            SlipPosInfo.SenderRefund3_No29.Height),
                            SlipPosInfo.SenderRefund3_No29.Font,
                            SlipPosInfo.SenderRefund3_No29.FontSize,
                            SlipPosInfo.SenderRefund3_No29.Text.Replace(",", "\r\n"),
                            minSize: SlipPosInfo.SenderRefund3_No29.FontSize,
                            vAlign: VerticalTextAlignment.Top);

                        //ご依頼主用番号/配送伝票管理番号
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.DeliverySlipControlNo.XPos + ColPos,
                            SlipPosInfo.DeliverySlipControlNo.YPos + RowPos,
                            SlipPosInfo.DeliverySlipControlNo.Width,
                            SlipPosInfo.DeliverySlipControlNo.Height),
                            SlipPosInfo.DeliverySlipControlNo.Font,
                            SlipPosInfo.DeliverySlipControlNo.FontSize,
                            info.DELIVERY_SLIP_CONTROL_NO,
                            minSize: SlipPosInfo.DeliverySlipControlNo.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.DeliverySlipControlNo_No31.XPos + ColPos,
                            SlipPosInfo.DeliverySlipControlNo_No31.YPos + RowPos,
                            SlipPosInfo.DeliverySlipControlNo_No31.Width,
                            SlipPosInfo.DeliverySlipControlNo_No31.Height),
                            SlipPosInfo.DeliverySlipControlNo_No31.Font,
                            SlipPosInfo.DeliverySlipControlNo_No31.FontSize,
                            info.DELIVERY_SLIP_CONTROL_NO,
                            minSize: SlipPosInfo.DeliverySlipControlNo_No31.FontSize,
                            hAlign: HorizontalTextAlignment.Center,
                            vAlign: VerticalTextAlignment.Middle);

                        //電話番号
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SendDestTelNo.XPos + ColPos,
                            SlipPosInfo.SendDestTelNo.YPos + RowPos,
                            SlipPosInfo.SendDestTelNo.Width,
                            SlipPosInfo.SendDestTelNo.Height),
                            SlipPosInfo.SendDestTelNo.Font,
                            SlipPosInfo.SendDestTelNo.FontSize,
                            info.SEND_DEST_TEL_NO_Edit,
                            minSize: SlipPosInfo.SendDestTelNo.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.SendDestTelNo_No23.XPos + ColPos,
                            SlipPosInfo.SendDestTelNo_No23.YPos + RowPos,
                            SlipPosInfo.SendDestTelNo_No23.Width,
                            SlipPosInfo.SendDestTelNo_No23.Height),
                            SlipPosInfo.SendDestTelNo_No23.Font,
                            SlipPosInfo.SendDestTelNo_No23.FontSize,
                            info.SEND_DEST_TEL_NO_Edit,
                            minSize: SlipPosInfo.SendDestTelNo_No23.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);

                        //記事
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.News.XPos + ColPos,
                            SlipPosInfo.News.YPos + RowPos,
                            SlipPosInfo.News.Width,
                            SlipPosInfo.News.Height),
                            SlipPosInfo.News.Font,
                            SlipPosInfo.News.FontSize,
                            SlipPosInfo.News.Text,
                            minSize: SlipPosInfo.News.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.News_No33.XPos + ColPos,
                            SlipPosInfo.News_No33.YPos + RowPos,
                            SlipPosInfo.News_No33.Width,
                            SlipPosInfo.News_No33.Height),
                            SlipPosInfo.News_No33.Font,
                            SlipPosInfo.News_No33.FontSize,
                            SlipPosInfo.News_No33.Text,
                            minSize: SlipPosInfo.News_No33.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);

                        //サイズ
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.Size.XPos + ColPos,
                            SlipPosInfo.Size.YPos + RowPos,
                            SlipPosInfo.Size.Width,
                            SlipPosInfo.Size.Height),
                            SlipPosInfo.Size.Font,
                            SlipPosInfo.Size.FontSize,
                            SlipPosInfo.Size.Text,
                            minSize: SlipPosInfo.Size.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.Size_No34.XPos + ColPos,
                            SlipPosInfo.Size_No34.YPos + RowPos,
                            SlipPosInfo.Size_No34.Width,
                            SlipPosInfo.Size_No34.Height),
                            SlipPosInfo.Size_No34.Font,
                            SlipPosInfo.Size_No34.FontSize,
                            SlipPosInfo.Size_No34.Text,
                            minSize: SlipPosInfo.Size_No34.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);

                        //受付店
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.Dealer.XPos + ColPos,
                            SlipPosInfo.Dealer.YPos + RowPos,
                            SlipPosInfo.Dealer.Width,
                            SlipPosInfo.Dealer.Height),
                            SlipPosInfo.Dealer.Font,
                            SlipPosInfo.Dealer.FontSize,
                            SlipPosInfo.Dealer.Text,
                            minSize: SlipPosInfo.Dealer.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.Dealer_No35.XPos + ColPos,
                            SlipPosInfo.Dealer_No35.YPos + RowPos,
                            SlipPosInfo.Dealer_No35.Width,
                            SlipPosInfo.Dealer_No35.Height),
                            SlipPosInfo.Dealer_No35.Font,
                            SlipPosInfo.Dealer_No35.FontSize,
                            SlipPosInfo.Dealer_No35.Text,
                            minSize: SlipPosInfo.Dealer_No35.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);

                        //顧客コード
                        pdf.WriteTextRegion(new RectangleF(
                            SlipPosInfo.CustomerCode.XPos + ColPos,
                            SlipPosInfo.CustomerCode.YPos + RowPos,
                            SlipPosInfo.CustomerCode.Width,
                            SlipPosInfo.CustomerCode.Height),
                            SlipPosInfo.CustomerCode.Font,
                            SlipPosInfo.CustomerCode.FontSize,
                            info.YUPACK_CUSTOMER_NO,
                            minSize: SlipPosInfo.CustomerCode.FontSize,
                            hAlign: HorizontalTextAlignment.Left,
                            vAlign: VerticalTextAlignment.Middle);

                        if (colidx == ColCount - 1)
                        {
                            colidx = 0;
                            rowIdx += 1;
                        }
                        else
                        {
                            colidx += 1;
                        }

                    }
                    keyCount += 1;
                }
            }

            _logger.DebugFormat("MSゆうパック配送伝票ファイル[{0}]", outFile);
            return outFile;
        }
        #endregion

        #region 位置情報取得
        /// <summary>
        /// 位置情報取得
        /// </summary>
        private void getPosInfo()
        {
            _logger.Debug("位置情報取得");
            
            this.SlipPosInfo = new clsDeliverySlipPosInfo();
            clsPdfPosition posinfo = new clsPdfPosition(ConfigurationManager.AppSettings["MSPB003_YU_PACK_DELIVERY_SLIP_POS_FILE"], "Setting/Label");
            //ラベル情報
            this.SlipPosInfo.LabelInfo = posinfo.getPosInfo("LabelInfo");
            //宛先郵便番号
            this.SlipPosInfo.SendestPostalNo = posinfo.getPosInfo("SendestPostalNo");
            this.SlipPosInfo.SendestPostalNo_No21 = posinfo.getPosInfo("SendestPostalNo_No21");
            //宛先住所
            this.SlipPosInfo.SendestAddress = posinfo.getPosInfo("SendestAddress");
            this.SlipPosInfo.SendestAddress_No22 = posinfo.getPosInfo("SendestAddress_No22");
            //宛先氏名
            this.SlipPosInfo.SendestName = posinfo.getPosInfo("SendestName");
            this.SlipPosInfo.SendestName_No24 = posinfo.getPosInfo("SendestName_No24");
            //証券番号
            this.SlipPosInfo.PolycyNo = posinfo.getPosInfo("PolycyNo");
            this.SlipPosInfo.PolycyNo_No25 = posinfo.getPosInfo("PolycyNo_No25");
            //品名
            this.SlipPosInfo.ProductName = posinfo.getPosInfo("ProductName");
            this.SlipPosInfo.ProductName_No30 = posinfo.getPosInfo("ProductName_No30");
            //差出人郵便番号
            this.SlipPosInfo.SederPostalNo = posinfo.getPosInfo("SederPostalNo");
            this.SlipPosInfo.SederPostalNo_No26 = posinfo.getPosInfo("SederPostalNo_No26");
            //差出人
            this.SlipPosInfo.Sender = posinfo.getPosInfo("Sender");
            this.SlipPosInfo.Sender_No27 = posinfo.getPosInfo("Sender_No27");
            //ご依頼主住所
            this.SlipPosInfo.SenderAddress = posinfo.getPosInfo("SenderAddress");
            this.SlipPosInfo.SenderAddress_No28 = posinfo.getPosInfo("SenderAddress_No28");
            //還付先①
            this.SlipPosInfo.SenderRefund1 = posinfo.getPosInfo("SenderRefund1");
            this.SlipPosInfo.SenderRefund1_No29 = posinfo.getPosInfo("SenderRefund1_No29");
            //還付先②
            this.SlipPosInfo.SenderRefund2 = posinfo.getPosInfo("SenderRefund2");
            this.SlipPosInfo.SenderRefund2_No29 = posinfo.getPosInfo("SenderRefund2_No29");
            //還付先③
            this.SlipPosInfo.SenderRefund3 = posinfo.getPosInfo("SenderRefund3");
            this.SlipPosInfo.SenderRefund3_No29 = posinfo.getPosInfo("SenderRefund3_No29");
            //仕分番号バーコード
            this.SlipPosInfo.SortingNoBarCode = posinfo.getPosInfo("SortingNoBarCode");
            //仕分番号バーコード下文字
            this.SlipPosInfo.SortingNoBarCodeStr = posinfo.getPosInfo("SortingNoBarCodeStr");
            //仕分番号
            this.SlipPosInfo.SortingNo = posinfo.getPosInfo("SortingNo");
            this.SlipPosInfo.SortingNo_No2 = posinfo.getPosInfo("SortingNo_No2");
            //問合せ番号バーコード
            this.SlipPosInfo.ContactNoBarCode = posinfo.getPosInfo("ContactNoBarCode");
            this.SlipPosInfo.ContactNoBarCode_No19 = posinfo.getPosInfo("ContactNoBarCode_No19");
            //問合せ番号バーコード下文字
            this.SlipPosInfo.ContactNoBarCodeStr = posinfo.getPosInfo("ContactNoBarCodeStr");
            this.SlipPosInfo.ContactNoBarCodeStr_No19 = posinfo.getPosInfo("ContactNoBarCodeStr_No19");
            //問合せ番号
            this.SlipPosInfo.ContactNo = posinfo.getPosInfo("ContactNo");
            this.SlipPosInfo.ContactNo_No32 = posinfo.getPosInfo("ContactNo_No32");
            //DNP管理番号
            this.SlipPosInfo.DeliverySlipControlNo = posinfo.getPosInfo("DeliverySlipControlNo");
            this.SlipPosInfo.DeliverySlipControlNo_No31 = posinfo.getPosInfo("DeliverySlipControlNo_No31");

            this.SlipPosInfo.SendDestTelNo = posinfo.getPosInfo("SendDestTelNo");
            this.SlipPosInfo.SendDestTelNo_No23 = posinfo.getPosInfo("SendDestTelNo_No23");
            this.SlipPosInfo.News = posinfo.getPosInfo("News");
            this.SlipPosInfo.News_No33 = posinfo.getPosInfo("News_No33");
            this.SlipPosInfo.Size = posinfo.getPosInfo("Size");
            this.SlipPosInfo.Size_No34 = posinfo.getPosInfo("Size_No34");
            this.SlipPosInfo.Dealer = posinfo.getPosInfo("Dealer");
            this.SlipPosInfo.Dealer_No35 = posinfo.getPosInfo("Dealer_No35");

            this.SlipPosInfo.CustomerCode = posinfo.getPosInfo("CustomerCode");
        }
        #endregion

        #endregion

    }
    #endregion

}
