using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Drawing;
using System.IO;
using dnp.nulcommon.util;

namespace dnp.nulcommon.pdf
{
    /// <summary>
    /// フォント
    /// </summary>
    public enum EFont
    {
        /// <summary>
        /// MS 明朝
        /// </summary>
        MsMincho,
        /// <summary>
        /// MS ゴシック
        /// </summary>
        MsGothic,
        /// <summary>
        /// OCR-B
        /// </summary>
        OCRB,
        /// <summary>
        /// メイリオ
        /// </summary>
        meiryo,
        /// <summary>
        /// MS Pゴシック
        /// </summary>
        MSPGothic
    }
    /// <summary>
    /// フォントスタイル
    /// </summary>
    public enum EFontStyle
    {
        BOLD,
        BOLDITALIC,
        DEFAULTSIZE,
        ITALIC,
        NORMAL,
        STRIKETHRU,
        UNDEFINED,
        UNDERLINE
    }



    #region iTextSharp関連
    public enum HorizontalTextAlignment
    {
        Left,
        Center,
        Right,
    }

    public enum VerticalTextAlignment
    {
        Top,
        Middle,
        Bottom,
    }

    public class DefinedPageSize
    {
        public enum SizeName
        {
            _11X17,
            A0,
            A1,
            A2,
            A3,
            A4,
            A4_LANDSCAPE,
            A5,
            A6,
            A7,
            A8,
            A9,
            A10,
            ARCH_A,
            ARCH_B,
            ARCH_C,
            ARCH_D,
            ARCH_E,
            B0,
            B1,
            B2,
            B3,
            B4,
            B5,
            B6,
            B7,
            B8,
            B9,
            B10,
            CROWN_OCTAVO,
            CROWN_QUARTO,
            DEMY_OCTAVO,
            DEMY_QUARTO,
            EXECUTIVE,
            FLSA,
            FLSE,
            HALFLETTER,
            ID_1,
            ID_2,
            ID_3,
            LARGE_CROWN_OCTAVO,
            LARGE_CROWN_QUARTO,
            LEDGER,
            LEGAL,
            LEGAL_LANDSCAPE,
            LETTER,
            LETTER_LANDSCAPE,
            NOTE,
            PENGUIN_LARGE_PAPERBACK,
            PENGUIN_SMALL_PAPERBACK,
            POSTCARD,
            ROYAL_OCTAVO,
            ROYAL_QUARTO,
            SMALL_PAPERBACK,
            TABLOID,
        }

        public SizeName Name { get; private set; }
        public bool Rotation { get; private set; }

        public DefinedPageSize(SizeName name, bool rotation = false)
        {
            this.Name = name;
            this.Rotation = rotation;
        }

        public iTextSharp.text.Rectangle GetItextPageSize()
        {
            iTextSharp.text.Rectangle rect = iTextSharp.text.PageSize.A4;
            switch(this.Name)
            {
                case SizeName._11X17:
                    rect = iTextSharp.text.PageSize._11X17;
                    break;
                case SizeName.A0:
                    rect = iTextSharp.text.PageSize.A0;
                    break;
                case SizeName.A1:
                    rect = iTextSharp.text.PageSize.A1;
                    break;
                case SizeName.A2:
                    rect = iTextSharp.text.PageSize.A2;
                    break;
                case SizeName.A3:
                    rect = iTextSharp.text.PageSize.A3;
                    break;
                case SizeName.A4:
                    rect = iTextSharp.text.PageSize.A4;
                    break;
                case SizeName.A5:
                    rect = iTextSharp.text.PageSize.A5;
                    break;
                case SizeName.A6:
                    rect = iTextSharp.text.PageSize.A6;
                    break;
                case SizeName.A7:
                    rect = iTextSharp.text.PageSize.A7;
                    break;
                case SizeName.A8:
                    rect = iTextSharp.text.PageSize.A8;
                    break;
                case SizeName.A9:
                    rect = iTextSharp.text.PageSize.A9;
                    break;
                case SizeName.A10:
                    rect = iTextSharp.text.PageSize.A10;
                    break;
                case SizeName.ARCH_A:
                    rect = iTextSharp.text.PageSize.ARCH_A;
                    break;
                case SizeName.ARCH_B:
                    rect = iTextSharp.text.PageSize.ARCH_B;
                    break;
                case SizeName.ARCH_C:
                    rect = iTextSharp.text.PageSize.ARCH_C;
                    break;
                case SizeName.ARCH_D:
                    rect = iTextSharp.text.PageSize.ARCH_D;
                    break;
                case SizeName.ARCH_E:
                    rect = iTextSharp.text.PageSize.ARCH_E;
                    break;
                case SizeName.B0:
                    rect = iTextSharp.text.PageSize.B0;
                    break;
                case SizeName.B1:
                    rect = iTextSharp.text.PageSize.B1;
                    break;
                case SizeName.B2:
                    rect = iTextSharp.text.PageSize.B2;
                    break;
                case SizeName.B3:
                    rect = iTextSharp.text.PageSize.B3;
                    break;
                case SizeName.B4:
                    rect = iTextSharp.text.PageSize.B4;
                    break;
                case SizeName.B5:
                    rect = iTextSharp.text.PageSize.B5;
                    break;
                case SizeName.B6:
                    rect = iTextSharp.text.PageSize.B6;
                    break;
                case SizeName.B7:
                    rect = iTextSharp.text.PageSize.B7;
                    break;
                case SizeName.B8:
                    rect = iTextSharp.text.PageSize.B8;
                    break;
                case SizeName.B9:
                    rect = iTextSharp.text.PageSize.B9;
                    break;
                case SizeName.B10:
                    rect = iTextSharp.text.PageSize.B10;
                    break;
                case SizeName.CROWN_OCTAVO:
                    rect = iTextSharp.text.PageSize.CROWN_OCTAVO;
                    break;
                case SizeName.CROWN_QUARTO:
                    rect = iTextSharp.text.PageSize.CROWN_QUARTO;
                    break;
                case SizeName.DEMY_OCTAVO:
                    rect = iTextSharp.text.PageSize.DEMY_OCTAVO;
                    break;
                case SizeName.DEMY_QUARTO:
                    rect = iTextSharp.text.PageSize.DEMY_QUARTO;
                    break;
                case SizeName.EXECUTIVE:
                    rect = iTextSharp.text.PageSize.EXECUTIVE;
                    break;
                case SizeName.FLSA:
                    rect = iTextSharp.text.PageSize.FLSA;
                    break;
                case SizeName.FLSE:
                    rect = iTextSharp.text.PageSize.FLSE;
                    break;
                case SizeName.HALFLETTER:
                    rect = iTextSharp.text.PageSize.HALFLETTER;
                    break;
                case SizeName.ID_1:
                    rect = iTextSharp.text.PageSize.ID_1;
                    break;
                case SizeName.ID_2:
                    rect = iTextSharp.text.PageSize.ID_2;
                    break;
                case SizeName.ID_3:
                    rect = iTextSharp.text.PageSize.ID_3;
                    break;
                case SizeName.LARGE_CROWN_OCTAVO:
                    rect = iTextSharp.text.PageSize.LARGE_CROWN_OCTAVO;
                    break;
                case SizeName.LARGE_CROWN_QUARTO:
                    rect = iTextSharp.text.PageSize.LARGE_CROWN_QUARTO;
                    break;
                case SizeName.LEDGER:
                    rect = iTextSharp.text.PageSize.LEDGER;
                    break;
                case SizeName.LEGAL:
                    rect = iTextSharp.text.PageSize.LEGAL;
                    break;
                case SizeName.LETTER:
                    rect = iTextSharp.text.PageSize.LETTER;
                    break;
                case SizeName.NOTE:
                    rect = iTextSharp.text.PageSize.NOTE;
                    break;
                case SizeName.PENGUIN_LARGE_PAPERBACK:
                    rect = iTextSharp.text.PageSize.PENGUIN_LARGE_PAPERBACK;
                    break;
                case SizeName.PENGUIN_SMALL_PAPERBACK:
                    rect = iTextSharp.text.PageSize.PENGUIN_SMALL_PAPERBACK;
                    break;
                case SizeName.POSTCARD:
                    rect = iTextSharp.text.PageSize.POSTCARD;
                    break;
                case SizeName.ROYAL_OCTAVO:
                    rect = iTextSharp.text.PageSize.ROYAL_OCTAVO;
                    break;
                case SizeName.ROYAL_QUARTO:
                    rect = iTextSharp.text.PageSize.ROYAL_QUARTO;
                    break;
                case SizeName.SMALL_PAPERBACK:
                    rect = iTextSharp.text.PageSize.SMALL_PAPERBACK;
                    break;
                case SizeName.TABLOID:
                    rect = iTextSharp.text.PageSize.TABLOID;
                    break;
            }

            if (this.Rotation) rect = rect.Rotate();
            return rect;
        }
    }
    #endregion iTextSharp関連

    /// <summary>
    /// PDF作成クラスインターフェース
    /// </summary>
    public interface IPdfCreator
    {
        /// <summary>
        /// 処理中ページ高
        /// </summary>
        float PageHeight { get; }

        /// <summary>
        /// 処理中ページ幅
        /// </summary>
        float PageWidth { get; }

        /// <summary>
        /// テンプレートPDF設定
        /// </summary>
        /// <param name="pathTemplate">追加テンプレートPDFファイルパス</param>
        /// <param name="pageTemplate">PDFページ番号</param>
        void AddTemplate(string pathTemplate, int pageTemplate = 1);

        /// <summary>
        /// テンプレートPDF再設定
        /// </summary>
        /// <param name="pageTemplate">PDFページ番号</param>
        void RepeatTemplate(int pageTemplate = 1);

        /// <summary>
        /// 次ページ作成
        /// </summary>
        void NextPage();

        /// <summary>
        /// テキスト描画
        /// </summary>
        /// <param name="pos">描画位置</param>
        /// <param name="efont">フォント</param>
        /// <param name="fontsize">フォントサイズ</param>
        /// <param name="text">描画文字列</param>
        /// <param name="elem">位置属性<seealso cref="PdfContentByte"/></param>
        /// <param name="rotation">回転</param>
        void WriteText(PointF pos, EFont efont, float fontsize, string text, HorizontalTextAlignment align = HorizontalTextAlignment.Left, float rotation = 0.0f);

        /// <summary>
        /// テキスト範囲描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="fnt">フォント</param>
        /// <param name="fontsize">フォントサイズ</param>
        /// <param name="text">描画文字列</param>
        /// <param name="minSize">最小フォントサイズ</param>
        /// <param name="maxRows">最大行数</param>
        /// <param name="hAlign">水平位置属性</param>
        /// <param name="vAlign">垂直位置属性</param>
        /// <param name="cellPadding">描画位置パディング</param>
        /// <param name="fontDecrementStep">フォント縮小段階</param>
        /// <param name="characterSpacing">文字間隔</param>
        /// <param name="horizontalScaling">水平文字倍率</param>
        /// <param name="fStyle1">フォントスタイル１</param>
        /// <param name="fStyle2">フォントスタイル２</param>
        void WriteTextRegion(RectangleF rect, EFont fnt, float fontsize, string text, float minSize = 6.0f, int maxRows = 0, HorizontalTextAlignment hAlign = HorizontalTextAlignment.Left, VerticalTextAlignment vAlign = VerticalTextAlignment.Middle, float cellPadding = 0.0f, float fontDecrementStep = 0.5f, float characterSpacing = 0.0f, float horizontalScaling = 1.0f, EFontStyle fStyle1 = EFontStyle.UNDEFINED, EFontStyle fStyle2 = EFontStyle.UNDEFINED);

        /// <summary>
        /// テキスト範囲描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="fnt">フォント</param>
        /// <param name="fontsize">フォントサイズ</param>
        /// <param name="text">描画文字列</param>
        /// <param name="color">文字色</param>
        /// <param name="minSize">最小フォントサイズ</param>
        /// <param name="maxRows">最大行数</param>
        /// <param name="hAlign">水平位置属性</param>
        /// <param name="vAlign">垂直位置属性</param>
        /// <param name="cellPadding">描画位置パディング</param>
        /// <param name="fontDecrementStep">フォント縮小段階</param>
        /// <param name="characterSpacing">文字間隔</param>
        /// <param name="horizontalScaling">水平文字倍率</param>
        /// <param name="fStyle1">フォントスタイル１</param>
        /// <param name="fStyle2">フォントスタイル２</param>
        void WriteTextRegion(RectangleF rect, EFont fnt, float fontsize, string text, Color color, float minSize = 6.0f, int maxRows = 0, HorizontalTextAlignment hAlign = HorizontalTextAlignment.Left, VerticalTextAlignment vAlign = VerticalTextAlignment.Middle, float cellPadding = 0.0f, float fontDecrementStep = 0.5f, float characterSpacing = 0.0f, float horizontalScaling = 1.0f, EFontStyle fStyle1 = EFontStyle.UNDEFINED, EFontStyle fStyle2 = EFontStyle.UNDEFINED);
        /// <summary>
        /// テキスト範囲描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="fnt">フォント</param>
        /// <param name="fontsize">フォントサイズ</param>
        /// <param name="text">描画文字列</param>
        /// <param name="color">文字色</param>
        /// <param name="minSize">最小フォントサイズ</param>
        /// <param name="maxRows">最大行数</param>
        /// <param name="hAlign">水平位置属性</param>
        /// <param name="vAlign">垂直位置属性</param>
        /// <param name="cellPadding">描画位置パディング</param>
        /// <param name="fontDecrementStep">フォント縮小段階</param>
        /// <param name="characterSpacing">文字間隔</param>
        /// <param name="horizontalScaling">水平文字倍率</param>
        /// <param name="fStyle1">フォントスタイル１</param>
        /// <param name="fStyle2">フォントスタイル２</param>
        void WriteTextRegion(RectangleF rect, string fnt, float fontsize, string text, Color color, float minSize = 6.0f, int maxRows = 0, HorizontalTextAlignment hAlign = HorizontalTextAlignment.Left, VerticalTextAlignment vAlign = VerticalTextAlignment.Middle, float cellPadding = 0.0f, float fontDecrementStep = 0.5f, float characterSpacing = 0.0f, float horizontalScaling = 1.0f, EFontStyle fStyle1 = EFontStyle.UNDEFINED, EFontStyle fStyle2 = EFontStyle.UNDEFINED);

        /// <summary>
        /// 直線描画
        /// </summary>
        /// <param name="posFrom">描画開始位置</param>
        /// <param name="posTo">描画終了位置</param>
        /// <param name="linewidth">線幅</param>
        void DrawLine(PointF posFrom, PointF posTo, float linewidth = 0.5f);

        /// <summary>
        /// 方形描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="linewidth">線幅</param>
        /// <param name="radian">回転</param>
        void DrawRect(RectangleF rect, float linewidth = 0.5F, float radian = 0.0f);

        /// <summary>
        /// バーコード描画
        /// </summary>
        void DrawBarCode(RectangleF rect, string code);

        /// <summary>
        /// QRコード描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="code">コード値</param>
        /// <param name="qrEccRate">誤り訂正レベル</param>
        /// <param name="qrTextType">文字タイプ</param>
        /// <param name="qrVersion">QRバージョン</param>
        /// <param name="qrQuitZone">余白ドット数</param>
        void DrawQrCode(RectangleF rect, string code, QRECCRates qrEccRate, QRTextTypes qrTextType, int qrVersion, int qrQuitZone = 2);

        /// <summary>
        /// バーコード描画(CODE39)
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="code"></param>
        void DrawBarCode39(RectangleF rect, string code);
    
        /// <summary>
        /// 画像描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="file">ファイル名</param>
        void DrawPicImage(RectangleF rect, string file);
        /// <summary>
        /// 画像イメージ描画
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="drowImg"></param>
        void DrawImage(RectangleF rect, System.Drawing.Image drowImg);


    }

    public class PdfCreator : IPdfCreator, IDisposable
    {
        #region コンフィグ設定値
        private const string CONFIGNAME_DRAWGRID = "PDFC_DRAWGRID";
        private bool isDrawGrid = false;

        private const string CONFIGNAME_GRIDINTERVAL = "PDFC_GRIDINTERVAL";
        private float gridInterval = 10.0f;

        private const string CONFIGNAME_DRAWTEXTRECT = "PDFC_DRAWTEXTRECT";
        private bool isDrawTextRect = false;
        #endregion コンフィグ設定値

        private FileStream _fs;
        private Document _doc;
        private PdfWriter _pw;
        protected PdfContentByte _pcb;
        private IList<PdfReader> _pr_list = new List<PdfReader>();

        /// <summary>
        /// 処理中ページ高
        /// </summary>
        public float PageHeight
        {
            get { return this._doc.PageSize.Height; }
        }

        /// <summary>
        /// 処理中ページ幅
        /// </summary>
        public float PageWidth
        {
            get { return this._doc.PageSize.Width; }
        }

        #region コンストラクタ
        public PdfCreator(string pathOutput, DefinedPageSize name)
        {
            LoadConfig();

            FontFactory.RegisterDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts));

            this._fs = new FileStream(pathOutput, FileMode.Create);
            this._doc = new Document(name.GetItextPageSize());
            this._pw = PdfWriter.GetInstance(this._doc, this._fs);
            this._doc.Open();
            this._pcb = this._pw.DirectContent;
            if (this.isDrawGrid) this.DrawGrid();
        }

        public PdfCreator(string pathOutput, string pathTemplate, int pageTemplate = 1)
        {
            LoadConfig();

            FontFactory.RegisterDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts));

            this._fs = new FileStream(pathOutput, FileMode.Create);
            PdfReader pr = new PdfReader(pathTemplate);
            this._pr_list.Add(pr);
            this._doc = new Document(pr.GetPageSize(pageTemplate));
            this._pw = PdfWriter.GetInstance(this._doc, this._fs);
            this._doc.Open();
            this._pcb = this._pw.DirectContent;
            this._pcb.AddTemplate(this._pw.GetImportedPage(pr, pageTemplate), 0, 0);
            if (this.isDrawGrid) this.DrawGrid();
        }
        #endregion コンストラクタ

        /// <summary>
        /// Config読み込み
        /// </summary>
        private void LoadConfig()
        {
            this.isDrawGrid = !string.IsNullOrEmpty(ConfigurationManager.AppSettings[CONFIGNAME_DRAWGRID]) && "true".Equals(ConfigurationManager.AppSettings[CONFIGNAME_DRAWGRID].ToLower());
            if (isDrawGrid)
            {
                float val;
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CONFIGNAME_GRIDINTERVAL]) && float.TryParse(ConfigurationManager.AppSettings[CONFIGNAME_GRIDINTERVAL], out val))
                {
                    this.gridInterval = val;
                }
            }

            this.isDrawTextRect = !string.IsNullOrEmpty(ConfigurationManager.AppSettings[CONFIGNAME_DRAWTEXTRECT]) && "true".Equals(ConfigurationManager.AppSettings[CONFIGNAME_DRAWTEXTRECT].ToLower());
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (this._doc != null) this._doc.Dispose();
            if (this._fs != null) this._fs.Dispose();
            if (this._pw != null) this._pw.Dispose();
            foreach (PdfReader pr in this._pr_list)
            {
                pr.Dispose();
            }
        }

        /// <summary>
        /// テンプレートPDF設定
        /// </summary>
        /// <param name="pathTemplate">追加テンプレートPDFファイルパス</param>
        /// <param name="pageTemplate">PDFページ番号</param>
        public void AddTemplate(string pathTemplate, int pageTemplate = 1)
        {
            PdfReader pr = new PdfReader(pathTemplate);
            this._pr_list.Add(pr);
            this._pcb.AddTemplate(this._pw.GetImportedPage(pr, pageTemplate), 0, 0);
        }

        /// <summary>
        /// テンプレートPDF再設定
        /// </summary>
        /// <param name="pageTemplate">PDFページ番号</param>
        public void RepeatTemplate(int pageTemplate = 1)
        {
            if (this._pr_list.Count > 0)
            {
                this._pcb.AddTemplate(this._pw.GetImportedPage(this._pr_list.Last(), pageTemplate), 0, 0);
            }
        }

        /// <summary>
        /// 次ページ作成
        /// </summary>
        public void NextPage()
        {
            this._doc.NewPage();
            if (this.isDrawGrid) this.DrawGrid();
        }

        /// <summary>
        /// テキスト描画
        /// </summary>
        /// <param name="pos">描画位置</param>
        /// <param name="efont">フォント</param>
        /// <param name="fontsize">フォントサイズ</param>
        /// <param name="text">描画文字列</param>
        /// <param name="align">位置属性</param>
        /// <param name="rotation">回転</param>
        public void WriteText(PointF pos, EFont efont, float fontsize, string text, HorizontalTextAlignment align = HorizontalTextAlignment.Left, float rotation = 0.0f)
        {
            int alignment = PdfContentByte.ALIGN_LEFT;
            switch (align)
            {
                case HorizontalTextAlignment.Left:
                    alignment = PdfContentByte.ALIGN_LEFT;
                    break;
                case HorizontalTextAlignment.Center:
                    alignment = PdfContentByte.ALIGN_CENTER;
                    break;
                case HorizontalTextAlignment.Right:
                    alignment = PdfContentByte.ALIGN_RIGHT;
                    break;
            }

            this._pcb.SetFontAndSize(GetIFont(efont).BaseFont, fontsize);
            this._pcb.BeginText();
            this._pcb.ShowTextAligned(
                alignment,
                text,
                pos.X,
                this.PageHeight - fontsize - pos.Y,
                rotation);
            this._pcb.EndText();
            if (this.isDrawTextRect) DrawRect(new RectangleF(pos, new SizeF(100, fontsize)), 0.1f);
        }

        private class SplitCharacter : ISplitCharacter
        {
            public bool IsSplitCharacter(int start, int current, int end, char[] cc, PdfChunk[] ck)
            {
                return false;
            }
        }
        /// <summary>
        /// テキスト範囲描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="fnt">フォント</param>
        /// <param name="fontsize">フォントサイズ</param>
        /// <param name="text">描画文字列</param>
        /// <param name="minSize">最小フォントサイズ</param>
        /// <param name="maxRows">最大行数</param>
        /// <param name="hAlign">水平位置属性</param>
        /// <param name="vAlign">垂直位置属性</param>
        /// <param name="cellPadding">描画位置パディング</param>
        /// <param name="fontDecrementStep">フォント縮小段階</param>
        /// <param name="characterSpacing">文字間隔</param>
        /// <param name="horizontalScaling">水平文字倍率</param>
        /// <param name="fStyle1">フォントスタイル１</param>
        /// <param name="fStyle2">フォントスタイル２</param>
        public void WriteTextRegion(RectangleF rect, EFont fnt, float fontsize, string text, float minSize = 6.0f, int maxRows = 0, HorizontalTextAlignment hAlign = HorizontalTextAlignment.Left, VerticalTextAlignment vAlign = VerticalTextAlignment.Middle, float cellPadding = 0.0f, float fontDecrementStep = 0.5f, float characterSpacing = 0.0f, float horizontalScaling = 1.0f, EFontStyle fStyle1 = EFontStyle.UNDEFINED, EFontStyle fStyle2 = EFontStyle.UNDEFINED)
        {
            WriteTextRegion(rect, fnt, fontsize, text, Color.Black, minSize, maxRows, hAlign, vAlign, cellPadding, fontDecrementStep, characterSpacing, horizontalScaling, fStyle1, fStyle2);
        }

        /// <summary>
        /// テキスト範囲描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="fnt">フォント</param>
        /// <param name="fontsize">フォントサイズ</param>
        /// <param name="text">描画文字列</param>
        /// <param name="color">文字色</param>
        /// <param name="minSize">最小フォントサイズ</param>
        /// <param name="maxRows">最大行数</param>
        /// <param name="hAlign">水平位置属性</param>
        /// <param name="vAlign">垂直位置属性</param>
        /// <param name="cellPadding">描画位置パディング</param>
        /// <param name="fontDecrementStep">フォント縮小段階</param>
        /// <param name="characterSpacing">文字間隔</param>
        /// <param name="horizontalScaling">水平文字倍率</param>
        /// <param name="fStyle1">フォントスタイル１</param>
        /// <param name="fStyle2">フォントスタイル２</param>
        public void WriteTextRegion(RectangleF rect, EFont fnt, float fontsize, string text, Color color, float minSize = 6.0f, int maxRows = 0, HorizontalTextAlignment hAlign = HorizontalTextAlignment.Left, VerticalTextAlignment vAlign = VerticalTextAlignment.Middle, float cellPadding = 0.0f, float fontDecrementStep = 0.5f, float characterSpacing = 0.0f, float horizontalScaling = 1.0f, EFontStyle fStyle1 = EFontStyle.UNDEFINED, EFontStyle fStyle2 = EFontStyle.UNDEFINED)
        {
            int horizontalAlignment = Element.ALIGN_LEFT;
            switch (hAlign)
            {
                case HorizontalTextAlignment.Left:
                    horizontalAlignment = Element.ALIGN_LEFT;
                    break;
                case HorizontalTextAlignment.Center:
                    horizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case HorizontalTextAlignment.Right:
                    horizontalAlignment = Element.ALIGN_RIGHT;
                    break;
            }

            int verticalAlignment = Element.ALIGN_MIDDLE;
            switch (vAlign)
            {
                case VerticalTextAlignment.Top:
                    verticalAlignment = Element.ALIGN_TOP;
                    break;
                case VerticalTextAlignment.Middle:
                    verticalAlignment = Element.ALIGN_MIDDLE;
                    break;
                case VerticalTextAlignment.Bottom:
                    verticalAlignment = Element.ALIGN_BOTTOM;
                    break;
            }
            iTextSharp.text.Font iFont = GetIFont(fnt);
            iFont.Color = new BaseColor(color);

            //フォントスタイル
            int style = 0;

            switch(fStyle1)
            {
                case EFontStyle.BOLD:
                    style = iTextSharp.text.Font.BOLD;
                    break;
                case EFontStyle.DEFAULTSIZE:
                    style = iTextSharp.text.Font.DEFAULTSIZE;
                    break;
                case EFontStyle.ITALIC:
                    style = iTextSharp.text.Font.ITALIC;
                    break;
                case EFontStyle.NORMAL:
                    style = iTextSharp.text.Font.NORMAL;
                    break;
                case EFontStyle.STRIKETHRU:
                    style = iTextSharp.text.Font.STRIKETHRU;
                    break;
                case EFontStyle.UNDEFINED:
                    style = iTextSharp.text.Font.UNDEFINED;
                    break;
                case EFontStyle.UNDERLINE:
                    style = iTextSharp.text.Font.UNDERLINE;
                    break;
            }

            switch (fStyle2)
            {
                case EFontStyle.BOLD:
                    style = style | iTextSharp.text.Font.BOLD;
                    break;
                case EFontStyle.DEFAULTSIZE:
                    style = style | iTextSharp.text.Font.DEFAULTSIZE;
                    break;
                case EFontStyle.ITALIC:
                    style = style | iTextSharp.text.Font.ITALIC;
                    break;
                case EFontStyle.NORMAL:
                    style = style | iTextSharp.text.Font.NORMAL;
                    break;
                case EFontStyle.STRIKETHRU:
                    style = style | iTextSharp.text.Font.STRIKETHRU;
                    break;
                case EFontStyle.UNDEFINED:
                    if(fStyle1 == EFontStyle.UNDEFINED)
                    {
                        style = style | iTextSharp.text.Font.UNDEFINED;
                    }
                    break;
                case EFontStyle.UNDERLINE:
                    style = style | iTextSharp.text.Font.UNDERLINE;
                    break;
            }

            iFont.SetStyle(style);


            PdfPTable pdfpt = new PdfPTable(1);
            bool isWrite = false;

            pdfpt.SetTotalWidth(new float[] { rect.Width });
            for (float fsize = fontsize; fsize >= minSize; fsize -= fontDecrementStep)
            {
                iFont.Size = fsize;
                Chunk ck = new Chunk(text, iFont);
                ck.SetSplitCharacter(new SplitCharacter());
                ck.SetHorizontalScaling(horizontalScaling);
                ck.SetCharacterSpacing(characterSpacing);

                for (int rowCount = 1; rowCount <= text.Length && (maxRows <= 0 || rowCount <= maxRows); rowCount++)
                {
                    if ((rect.Height - cellPadding * 2) >= fsize * rowCount)
                    {
                        int singleLineChars = (text.Length - 1) / rowCount + 1;
                        if ((rect.Width - cellPadding * 2) >= iFont.BaseFont.GetWidthPoint(text.Substring(0, singleLineChars), fsize) * horizontalScaling)
                        {
                            if (this.isDrawTextRect)
                            {
                                pdfpt.AddCell(new PdfPCell(new Paragraph(ck)) { FixedHeight = rect.Height, HorizontalAlignment = horizontalAlignment, VerticalAlignment = verticalAlignment, Padding = cellPadding, BorderWidth = 0.1f });
                            }
                            else
                            {
                                pdfpt.AddCell(new PdfPCell(new Paragraph(ck)) { FixedHeight = rect.Height, HorizontalAlignment = horizontalAlignment, VerticalAlignment = verticalAlignment, Padding = cellPadding, Border = iTextSharp.text.Rectangle.NO_BORDER });
                            }
                            isWrite = true;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (isWrite) break;
            }
            if (!isWrite)
            {
                Chunk ck = new Chunk(text, iFont);
                ck.SetSplitCharacter(new SplitCharacter());

                if (this.isDrawTextRect)
                {
                    pdfpt.AddCell(new PdfPCell(new Paragraph(ck)) { FixedHeight = rect.Height, HorizontalAlignment = horizontalAlignment, VerticalAlignment = verticalAlignment, Padding = cellPadding });
                }
                else
                {
                    pdfpt.AddCell(new PdfPCell(new Paragraph(ck)) { FixedHeight = rect.Height, HorizontalAlignment = horizontalAlignment, VerticalAlignment = verticalAlignment, Padding = cellPadding, Border = iTextSharp.text.Rectangle.NO_BORDER });
                }
            }

            pdfpt.WriteSelectedRows(0, -1, rect.X + characterSpacing / 2, this.PageHeight - rect.Y, this._pcb);
        }
        /// <summary>
        /// テキスト範囲描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="fnt">フォント</param>
        /// <param name="fontsize">フォントサイズ</param>
        /// <param name="text">描画文字列</param>
        /// <param name="minSize">最小フォントサイズ</param>
        /// <param name="maxRows">最大行数</param>
        /// <param name="hAlign">水平位置属性</param>
        /// <param name="vAlign">垂直位置属性</param>
        /// <param name="cellPadding">描画位置パディング</param>
        /// <param name="fontDecrementStep">フォント縮小段階</param>
        /// <param name="characterSpacing">文字間隔</param>
        /// <param name="horizontalScaling">水平文字倍率</param>
        /// <param name="fStyle1">フォントスタイル１</param>
        /// <param name="fStyle2">フォントスタイル２</param>
        public void WriteTextRegion(RectangleF rect, string fnt, float fontsize, string text, float minSize = 6.0f, int maxRows = 0, HorizontalTextAlignment hAlign = HorizontalTextAlignment.Left, VerticalTextAlignment vAlign = VerticalTextAlignment.Middle, float cellPadding = 0.0f, float fontDecrementStep = 0.5f, float characterSpacing = 0.0f, float horizontalScaling = 1.0f, EFontStyle fStyle1 = EFontStyle.UNDEFINED, EFontStyle fStyle2 = EFontStyle.UNDEFINED)
        {
            WriteTextRegion(rect, fnt, fontsize, text, Color.Black, minSize, maxRows, hAlign, vAlign, cellPadding, fontDecrementStep, characterSpacing, horizontalScaling, fStyle1, fStyle2);
        }
        /// <summary>
        /// テキスト範囲描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="fnt">フォント</param>
        /// <param name="fontsize">フォントサイズ</param>
        /// <param name="text">描画文字列</param>
        /// <param name="color">文字色</param>
        /// <param name="minSize">最小フォントサイズ</param>
        /// <param name="maxRows">最大行数</param>
        /// <param name="hAlign">水平位置属性</param>
        /// <param name="vAlign">垂直位置属性</param>
        /// <param name="cellPadding">描画位置パディング</param>
        /// <param name="fontDecrementStep">フォント縮小段階</param>
        /// <param name="characterSpacing">文字間隔</param>
        /// <param name="horizontalScaling">水平文字倍率</param>
        /// <param name="fStyle1">フォントスタイル１</param>
        /// <param name="fStyle2">フォントスタイル２</param>
        //public void WriteTextRegion(RectangleF rect, string fnt, float fontsize, string text, Color color, float minSize = 6.0f, int maxRows = 0, HorizontalTextAlignment hAlign = HorizontalTextAlignment.Left, VerticalTextAlignment vAlign = VerticalTextAlignment.Middle, float cellPadding = 0.0f, float fontDecrementStep = 0.5f, float characterSpacing = 0.0f, float horizontalScaling = 1.0f, EFontStyle fStyle1 = EFontStyle.UNDEFINED, EFontStyle fStyle2 = EFontStyle.UNDEFINED)
        public void WriteTextRegion(RectangleF rect, string fnt, float fontsize, string text, Color color, float minSize = 6.0f, int maxRows = 0, HorizontalTextAlignment hAlign = HorizontalTextAlignment.Left, VerticalTextAlignment vAlign = VerticalTextAlignment.Middle, float cellPadding = 0.0f, float fontDecrementStep = 0.5f, float characterSpacing = 0.0f, float horizontalScaling = 1.0f, EFontStyle fStyle1 = EFontStyle.UNDEFINED, EFontStyle fStyle2 = EFontStyle.UNDEFINED)
        {
            if (text == "") text = " ";
            if (string.IsNullOrEmpty(text)) text = " ";

            int horizontalAlignment = Element.ALIGN_LEFT; 
            switch (hAlign)
            {
                case HorizontalTextAlignment.Left:
                    horizontalAlignment = Element.ALIGN_LEFT;
                    break;
                case HorizontalTextAlignment.Center:
                    horizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case HorizontalTextAlignment.Right:
                    horizontalAlignment = Element.ALIGN_RIGHT;
                    break;
            }

            int verticalAlignment = Element.ALIGN_MIDDLE;
            switch (vAlign)
            {
                case VerticalTextAlignment.Top:
                    verticalAlignment = Element.ALIGN_TOP;
                    break;
                case VerticalTextAlignment.Middle:
                    verticalAlignment = Element.ALIGN_MIDDLE;
                    break;
                case VerticalTextAlignment.Bottom:
                    verticalAlignment = Element.ALIGN_BOTTOM;
                    break;
            }
            iTextSharp.text.Font iFont = GetIFont(fnt);
            iFont.Color = new BaseColor(color);

            //フォントスタイル
            int style = 0;

            switch (fStyle1)
            {
                case EFontStyle.BOLD:
                    style = iTextSharp.text.Font.BOLD;
                    break;
                case EFontStyle.DEFAULTSIZE:
                    style = iTextSharp.text.Font.DEFAULTSIZE;
                    break;
                case EFontStyle.ITALIC:
                    style = iTextSharp.text.Font.ITALIC;
                    break;
                case EFontStyle.NORMAL:
                    style = iTextSharp.text.Font.NORMAL;
                    break;
                case EFontStyle.STRIKETHRU:
                    style = iTextSharp.text.Font.STRIKETHRU;
                    break;
                case EFontStyle.UNDEFINED:
                    style = iTextSharp.text.Font.UNDEFINED;
                    break;
                case EFontStyle.UNDERLINE:
                    style = iTextSharp.text.Font.UNDERLINE;
                    break;
            }

            switch (fStyle2)
            {
                case EFontStyle.BOLD:
                    style = style | iTextSharp.text.Font.BOLD;
                    break;
                case EFontStyle.DEFAULTSIZE:
                    style = style | iTextSharp.text.Font.DEFAULTSIZE;
                    break;
                case EFontStyle.ITALIC:
                    style = style | iTextSharp.text.Font.ITALIC;
                    break;
                case EFontStyle.NORMAL:
                    style = style | iTextSharp.text.Font.NORMAL;
                    break;
                case EFontStyle.STRIKETHRU:
                    style = style | iTextSharp.text.Font.STRIKETHRU;
                    break;
                case EFontStyle.UNDEFINED:
                    if (fStyle1 == EFontStyle.UNDEFINED)
                    {
                        style = style | iTextSharp.text.Font.UNDEFINED;
                    }
                    break;
                case EFontStyle.UNDERLINE:
                    style = style | iTextSharp.text.Font.UNDERLINE;
                    break;
            }

            iFont.SetStyle(style);


            PdfPTable pdfpt = new PdfPTable(1);
            bool isWrite = false;

            pdfpt.SetTotalWidth(new float[] { rect.Width });
            for (float fsize = fontsize; fsize >= minSize; fsize -= fontDecrementStep)
            {
                iFont.Size = fsize;
                Chunk ck = new Chunk(text, iFont);
                ck.SetSplitCharacter(new SplitCharacter());
                ck.SetHorizontalScaling(horizontalScaling);
                ck.SetCharacterSpacing(characterSpacing);

                for (int rowCount = 1; rowCount <= text.Length && (maxRows <= 0 || rowCount <= maxRows); rowCount++)
                {
                    if ((rect.Height - cellPadding * 2) >= fsize * rowCount)
                    {
                        int singleLineChars = (text.Length - 1) / rowCount + 1;
                        if ((rect.Width - cellPadding * 2) >= iFont.BaseFont.GetWidthPoint(text.Substring(0, singleLineChars), fsize) * horizontalScaling)
                        {
                            if (this.isDrawTextRect)
                            {
                                pdfpt.AddCell(new PdfPCell(new Paragraph(ck)) { FixedHeight = rect.Height, HorizontalAlignment = horizontalAlignment, VerticalAlignment = verticalAlignment, Padding = cellPadding, BorderWidth = 0.1f });
                            }
                            else
                            {
                                pdfpt.AddCell(new PdfPCell(new Paragraph(ck)) { FixedHeight = rect.Height, HorizontalAlignment = horizontalAlignment, VerticalAlignment = verticalAlignment, Padding = cellPadding, Border = iTextSharp.text.Rectangle.NO_BORDER });
                            }
                            isWrite = true;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (isWrite) break;
            }
            if (!isWrite)
            {
                Chunk ck = new Chunk(text, iFont);
                ck.SetSplitCharacter(new SplitCharacter());

                if (this.isDrawTextRect)
                {
                    pdfpt.AddCell(new PdfPCell(new Paragraph(ck)) { FixedHeight = rect.Height, HorizontalAlignment = horizontalAlignment, VerticalAlignment = verticalAlignment, Padding = cellPadding });
                }
                else
                {
                    pdfpt.AddCell(new PdfPCell(new Paragraph(ck)) { FixedHeight = rect.Height, HorizontalAlignment = horizontalAlignment, VerticalAlignment = verticalAlignment, Padding = cellPadding, Border = iTextSharp.text.Rectangle.NO_BORDER });
                }
            }

            pdfpt.WriteSelectedRows(0, -1, rect.X + characterSpacing / 2, this.PageHeight - rect.Y, this._pcb);
        }


        /// <summary>
        /// 直線描画
        /// </summary>
        /// <param name="posFrom">描画開始位置</param>
        /// <param name="posTo">描画終了位置</param>
        /// <param name="linewidth">線幅</param>
        public void DrawLine(PointF posFrom, PointF posTo, float linewidth = 0.5f)
        {
            this._pcb.SetLineWidth(linewidth);
            this._pcb.MoveTo(posFrom.X, this.PageHeight - posFrom.Y);
            this._pcb.LineTo(posTo.X, this.PageHeight - posTo.Y);
            this._pcb.ClosePathStroke();
        }

        /// <summary>
        /// 方形描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="linewidth">線幅</param>
        /// <param name="radian">回転</param>
        public void DrawRect(RectangleF rect, float linewidth = 0.5F, float radian = 0.0f)
        {
            this._pcb.SetLineWidth(linewidth);
            this._pcb.RoundRectangle(
                rect.X,
                this.PageHeight - rect.Height - rect.Top,
                rect.Width,
                rect.Height,
                radian);
            this._pcb.ClosePathStroke();
        }

        /// <summary>
        /// 方形描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="linewidth">線幅</param>
        /// <param name="radian">回転</param>
        public void DrawRect(RectangleF rect, Color colorBack, float linewidth = 0.5F, float radian = 0.0f)
        {
            this._pcb.SetLineWidth(linewidth);
            this._pcb.SetColorFill(new BaseColor(colorBack));
            this._pcb.RoundRectangle(
                rect.X,
                this.PageHeight - rect.Height - rect.Top,
                rect.Width,
                rect.Height,
                radian);
            this._pcb.FillStroke();
            this._pcb.ClosePathStroke();
        }

        /// <summary>
        /// 方眼描画
        /// </summary>
        private void DrawGrid()
        {
            float lineWidth = 0.1f;
            for (float x = 0.0f; x < this.PageWidth; x += this.gridInterval)
            {
                DrawLine(new PointF(x, 0), new PointF(x, this.PageHeight), (x / this.gridInterval) % 10 == 0 ? lineWidth * 5 : lineWidth);
            }
            for (float y = 0.0f; y < this.PageHeight; y += this.gridInterval)
            {
                DrawLine(new PointF(0, y), new PointF(this.PageWidth, y), (y / this.gridInterval) % 10 == 0 ? lineWidth * 5 : lineWidth);
            }
        }

        /// <summary>
        /// バーコード描画
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="code"></param>
        public void DrawBarCode(RectangleF rect, string code)
        {
            BarcodeCodabar bc = new BarcodeCodabar
            {
                Code = code,
                AltText = string.Empty,
                BarHeight = 8.0f,
                Size = 8.0f,
            };
            iTextSharp.text.Image img = bc.CreateImageWithBarcode(this._pcb, BaseColor.BLACK, BaseColor.BLACK);
            img.SetAbsolutePosition(rect.X, this.PageHeight - rect.Y - rect.Height * 2);
            img.ScaleAbsolute(rect.Width, rect.Height * 2);
            this._pcb.AddImage(img);
        }

        /// <summary>
        /// バーコード描画(CODE39)
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="code"></param>
        public void DrawBarCode39(RectangleF rect, string code)
        {
            Barcode39 bc = new Barcode39
            {
                Code = code,
                StartStopText = true,
                AltText = string.Empty,
                BarHeight = 8.0f,
                Size = 8.0f,
                GenerateChecksum = false,
                N = 1.6f,
            };
            iTextSharp.text.Image img = bc.CreateImageWithBarcode(this._pcb, BaseColor.BLACK, BaseColor.BLACK);
            img.SetAbsolutePosition(rect.X, this.PageHeight - rect.Y - rect.Height * 2);
            img.ScaleAbsolute(rect.Width, rect.Height * 2);
            this._pcb.AddImage(img);
        }

        /// <summary>
        /// バーコード描画(CODE128)
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="code"></param>
        public void DrawBarCode128(RectangleF rect, string code)
        {
            if (string.IsNullOrEmpty(code)) return;
            Barcode128 bc = new Barcode128
            {
                Code = code,
                StartStopText = true,
                AltText = string.Empty,
                BarHeight = 8.0f,
                Size = 8.0f,
                GenerateChecksum = false,
            };
            iTextSharp.text.Image img = bc.CreateImageWithBarcode(this._pcb, BaseColor.BLACK, BaseColor.BLACK);
            img.SetAbsolutePosition(rect.X, this.PageHeight - rect.Y - rect.Height * 2);
            img.ScaleAbsolute(rect.Width, rect.Height * 2);
            this._pcb.AddImage(img);

        }


        /// <summary>
        /// QRコード描画
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="code">コード値</param>
        /// <param name="qrEccRate">誤り訂正レベル</param>
        /// <param name="qrTextType">文字タイプ</param>
        /// <param name="qrVersion">QRバージョン</param>
        /// <param name="qrQuitZone">余白ドット数</param>
        public void DrawQrCode(
            RectangleF rect,
            string code,
            QRECCRates qrEccRate,
            QRTextTypes qrTextType,
            int qrVersion,
            int qrQuitZone = 2)
        {
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(DotNetBarcodeWrapper.CreateBitmap(code, qrEccRate, qrTextType, qrVersion, qrQuitZone, 1), (BaseColor)null);
            img.SetAbsolutePosition(rect.X, this.PageHeight - rect.Y - rect.Height);
            img.ScaleAbsolute(rect.Width, rect.Height);
            this._pcb.AddImage(img);
        }

        /// <summary>
        /// 画像描画
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="file"></param>
        public void DrawPicImage(RectangleF rect, string file)
        {
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(file);

            img.SetAbsolutePosition(rect.X, this.PageHeight - rect.Y - rect.Height);
            img.ScaleAbsolute(rect.Width, rect.Height);
            this._pcb.AddImage(img);

        }

        /// <summary>
        /// 画像イメージ描画
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="drowImg"></param>
        public void DrawImage(RectangleF rect, System.Drawing.Image drowImg)
        {
            if(drowImg == null)
            {
                return;
            }
            
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(drowImg, (BaseColor)null);

            img.SetAbsolutePosition(rect.X, this.PageHeight - rect.Y - rect.Height);
            img.ScaleAbsolute(rect.Width, rect.Height);
            this._pcb.AddImage(img);

        }


        private static iTextSharp.text.Font GetIFont(EFont font)
        {
            switch (font)
            {
                case EFont.MsGothic:
                default:
                    return FontFactory.GetFont("MS Gothic", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                case EFont.MsMincho:
                    return FontFactory.GetFont("MS Mincho", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                case EFont.OCRB:
                    return FontFactory.GetFont("OCRB", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                case EFont.meiryo:
                    return FontFactory.GetFont("meiryo", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                case EFont.MSPGothic:
                    return FontFactory.GetFont("MS PGothic", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            }
        }

        private static iTextSharp.text.Font GetIFont(string font)
        {
            return FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }

    }
}
