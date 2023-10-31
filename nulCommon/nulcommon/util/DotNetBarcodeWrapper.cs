using System;
using System.Drawing;

namespace dnp.nulcommon.util
{
    /// <summary>
    /// 誤り訂正レベル
    /// </summary>
    public enum QRECCRates
    {
        HighQuality,
        Quality,
        Medium,
        Low,
    }

    /// <summary>
    /// 文字タイプ
    /// </summary>
    public enum QRTextTypes
    {
        /// <summary>
        /// 数字
        /// </summary>
        Numeric,
        /// <summary>
        /// 英数字
        /// </summary>
        AlphaNumeric,
        /// <summary>
        /// バイナリ
        /// </summary>
        Binary,
        /// <summary>
        /// 漢字
        /// </summary>
        Kanji,
    }

    /// <summary>
    /// DotNetBarcodeラッパークラス
    /// </summary>
    public static class DotNetBarcodeWrapper
    {
        /// <summary>
        /// QRコードビットマップイメージ生成
        /// </summary>
        /// <param name="code">コード値</param>
        /// <param name="qrEccRate">誤り訂正レベル</param>
        /// <param name="qrTextType">文字タイプ</param>
        /// <param name="qrVersion">QRバージョン</param>
        /// <param name="qrQuitZone">余白ドット数</param>
        /// <param name="dotSize">ドットサイズ</param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(
            string code,
            QRECCRates qrEccRate,
            QRTextTypes qrTextType,
            int qrVersion,
            int qrQuitZone,
            int dotSize)
        {
            if (qrVersion < 1 || qrVersion > 40) throw new Exception("QRコードのバージョンが正しくありません。");

            int moduleSize = (17 + qrVersion * 4 + qrQuitZone * 2) * dotSize;
            Bitmap bmp = new Bitmap(moduleSize, moduleSize);

            new DotNetBarcode()
            {
                Type = DotNetBarcode.Types.QRCode,
                QRSetECCRate = ConvertQRECCRates(qrEccRate),
                QRSetTextType = ConvertQRTextTypes(qrTextType),
                QRSetVersion = ConvertQRVersions(qrVersion),
                QRQuitZone = qrQuitZone,
            }.QRWriteBar(code, 0, 0, dotSize, Graphics.FromImage(bmp));

            return bmp;
        }

        /// <summary>
        /// QRコードビットマップイメージ描画
        /// </summary>
        /// <param name="g">グラフィクス</param>
        /// <param name="point">描画位置</param>
        /// <param name="code">コード値</param>
        /// <param name="qrEccRate">誤り訂正レベル</param>
        /// <param name="qrTextType">文字タイプ</param>
        /// <param name="qrVersion">QRバージョン</param>
        /// <param name="qrQuitZone">余白ドット数</param>
        /// <param name="dotSize">ドットサイズ</param>
        public static void DrawGraphics(
            Graphics g,
            PointF point,
            string code,
            QRECCRates qrEccRate,
            QRTextTypes qrTextType,
            int qrVersion,
            int qrQuitZone,
            int dotSize)
        {
            new DotNetBarcode()
            {
                Type = DotNetBarcode.Types.QRCode,
                QRSetECCRate = ConvertQRECCRates(qrEccRate),
                QRSetTextType = ConvertQRTextTypes(qrTextType),
                QRSetVersion = ConvertQRVersions(qrVersion),
                QRQuitZone = qrQuitZone,
            }.QRWriteBar(code, point.X, point.Y, dotSize, g);
        }

        private static DotNetBarcode.QRECCRates ConvertQRECCRates(QRECCRates qrEccRate)
        {
            switch (qrEccRate)
            {
                case QRECCRates.HighQuality:
                    return DotNetBarcode.QRECCRates.HighQuality30Percent;
                case QRECCRates.Quality:
                    return DotNetBarcode.QRECCRates.Quality25Percent;
                case QRECCRates.Medium:
                    return DotNetBarcode.QRECCRates.Medium15Percent;
                case QRECCRates.Low:
                    return DotNetBarcode.QRECCRates.Low7Percent;
            }
            return DotNetBarcode.QRECCRates.Low7Percent;
        }

        private static DotNetBarcode.QRTextTypes ConvertQRTextTypes(QRTextTypes qrTextType)
        {
            switch (qrTextType)
            {
                case QRTextTypes.Numeric:
                    return DotNetBarcode.QRTextTypes.Numeric;
                case QRTextTypes.AlphaNumeric:
                    return DotNetBarcode.QRTextTypes.AlphaNumeric;
                case QRTextTypes.Binary:
                    return DotNetBarcode.QRTextTypes.Binary;
                case QRTextTypes.Kanji:
                    return DotNetBarcode.QRTextTypes.Kanji;
            }
            return DotNetBarcode.QRTextTypes.Automatic;
        }

        private static DotNetBarcode.QRVersions ConvertQRVersions(int qrVersion)
        {
            switch (qrVersion)
            {
                case 1:
                    return DotNetBarcode.QRVersions.Ver01;
                case 2:
                    return DotNetBarcode.QRVersions.Ver02;
                case 3:
                    return DotNetBarcode.QRVersions.Ver03;
                case 4:
                    return DotNetBarcode.QRVersions.Ver04;
                case 5:
                    return DotNetBarcode.QRVersions.Ver05;
                case 6:
                    return DotNetBarcode.QRVersions.Ver06;
                case 7:
                    return DotNetBarcode.QRVersions.Ver07;
                case 8:
                    return DotNetBarcode.QRVersions.Ver08;
                case 9:
                    return DotNetBarcode.QRVersions.Ver09;
                case 10:
                    return DotNetBarcode.QRVersions.Ver10;
                case 11:
                    return DotNetBarcode.QRVersions.Ver11;
                case 12:
                    return DotNetBarcode.QRVersions.Ver12;
                case 13:
                    return DotNetBarcode.QRVersions.Ver13;
                case 14:
                    return DotNetBarcode.QRVersions.Ver14;
                case 15:
                    return DotNetBarcode.QRVersions.Ver15;
                case 16:
                    return DotNetBarcode.QRVersions.Ver16;
                case 17:
                    return DotNetBarcode.QRVersions.Ver17;
                case 18:
                    return DotNetBarcode.QRVersions.Ver18;
                case 19:
                    return DotNetBarcode.QRVersions.Ver19;
                case 20:
                    return DotNetBarcode.QRVersions.Ver20;
                case 21:
                    return DotNetBarcode.QRVersions.Ver21;
                case 22:
                    return DotNetBarcode.QRVersions.Ver22;
                case 23:
                    return DotNetBarcode.QRVersions.Ver23;
                case 24:
                    return DotNetBarcode.QRVersions.Ver24;
                case 25:
                    return DotNetBarcode.QRVersions.Ver25;
                case 26:
                    return DotNetBarcode.QRVersions.Ver26;
                case 27:
                    return DotNetBarcode.QRVersions.Ver27;
                case 28:
                    return DotNetBarcode.QRVersions.Ver28;
                case 29:
                    return DotNetBarcode.QRVersions.Ver29;
                case 30:
                    return DotNetBarcode.QRVersions.Ver30;
                case 31:
                    return DotNetBarcode.QRVersions.Ver31;
                case 32:
                    return DotNetBarcode.QRVersions.Ver32;
                case 33:
                    return DotNetBarcode.QRVersions.Ver33;
                case 34:
                    return DotNetBarcode.QRVersions.Ver34;
                case 35:
                    return DotNetBarcode.QRVersions.Ver35;
                case 36:
                    return DotNetBarcode.QRVersions.Ver36;
                case 37:
                    return DotNetBarcode.QRVersions.Ver37;
                case 38:
                    return DotNetBarcode.QRVersions.Ver38;
                case 39:
                    return DotNetBarcode.QRVersions.Ver39;
                case 40:
                    return DotNetBarcode.QRVersions.Ver40;
            }
            throw new Exception("QRコードのバージョンが正しくありません。");
        }
    }
}
