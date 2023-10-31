using System;
using System.Xml;
using System.Reflection;
using log4net;
using MSPB.MSPB003.xml;

namespace MSPB.MSPB003.pdf
{
    #region 位置情報クラス
    /// <summary>
    /// 位置情報クラス
    /// </summary>
    class clsPosInfo
    {

        /// <summary>
        /// X座標
        /// </summary>
        public float XPos { get; set; }
        /// <summary>
        /// Y座標
        /// </summary>
        public float YPos { get; set; }
        /// <summary>
        /// 横幅
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// 縦幅
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// フォント
        /// </summary>
        public string Font { get; set; }
        /// <summary>
        /// フォントサイズ
        /// </summary>
        public float FontSize { get; set; }
        /// <summary>
        /// テキスト
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 列開始位置
        /// </summary>
        public float ColStartPos { get; set; }
        /// <summary>
        /// 列数
        /// </summary>
        public int ColCount { get; set; }
        /// <summary>
        /// 列マージン
        /// </summary>
        public float ColPosMargine { get; set; }
        /// <summary>
        /// 行開始位置
        /// </summary>
        public float RowStartPos { get; set; }
        /// <summary>
        /// 行数
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// 行マージン
        /// </summary>
        public float RowPosMargine { get; set; }
    }
    #endregion
    #region 位置情報取得クラス
    /// <summary>
    /// 位置情報取得クラス
    /// </summary>
    class clsPdfPosition
    {

        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// XML情報
        /// </summary>
        private clsXmlFile xmlInfo;
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <param name="xmlRoot"></param>
        public clsPdfPosition(string xmlFile,string xmlRoot)
        {
            xmlInfo = new clsXmlFile(xmlFile, xmlRoot);
        }
        #endregion
        #region メソッド

        /// <summary>
        /// 位置情報取得
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public clsPosInfo getPosInfo(string tag)
        {
            logger.DebugFormat("位置情報取得[tag:{0}]", tag);
            clsPosInfo posInfo = new clsPosInfo();
            XmlAttributeCollection Attribute = xmlInfo.attributes(tag);

            posInfo.Text = xmlInfo.InnerText(tag);


            for(int idx = 0; idx < Attribute.Count;idx++ )
            {

                // プロパティ情報の取得
                PropertyInfo property = typeof(clsPosInfo).GetProperty(Attribute[idx].Name);

                // インスタンスに値を設定
                if (!string.IsNullOrEmpty(Attribute[idx].Value))
                {
                    var value =
                    property.PropertyType == typeof(string) ? Attribute[idx].Value
                    : property.PropertyType == typeof(float) ? Convert.ChangeType(Attribute[idx].Value, typeof(float))
                    : property.PropertyType == typeof(float?) ? Convert.ChangeType(Attribute[idx].Value, typeof(float))
                    : property.PropertyType == typeof(short) ? Convert.ChangeType(Attribute[idx].Value, typeof(short))
                    : property.PropertyType == typeof(short?) ? Convert.ChangeType(Attribute[idx].Value, typeof(short))
                    : property.PropertyType == typeof(bool) ? Convert.ChangeType(Attribute[idx].Value, typeof(bool))
                    : property.PropertyType == typeof(bool?) ? Convert.ChangeType(Attribute[idx].Value, typeof(bool))
                    : property.PropertyType == typeof(int) ? Convert.ChangeType(Attribute[idx].Value, typeof(int))
                    : property.PropertyType == typeof(int?) ? Convert.ChangeType(Attribute[idx].Value, typeof(int))
                    : property.PropertyType == typeof(long) ? Convert.ChangeType(Attribute[idx].Value, typeof(long))
                    : property.PropertyType == typeof(long?) ? Convert.ChangeType(Attribute[idx].Value, typeof(long))
                    : property.PropertyType == typeof(double) ? Convert.ChangeType(Attribute[idx].Value, typeof(double))
                    : property.PropertyType == typeof(double?) ? Convert.ChangeType(Attribute[idx].Value, typeof(double))
                    : property.PropertyType == typeof(decimal) ? Convert.ChangeType(Attribute[idx].Value, typeof(decimal))
                    : property.PropertyType == typeof(decimal?) ? Convert.ChangeType(Attribute[idx].Value, typeof(decimal))
                    : property.PropertyType == typeof(DateTime) ? Convert.ChangeType(Attribute[idx].Value, typeof(DateTime))
                    : property.PropertyType == typeof(DateTime?) ? Convert.ChangeType(Attribute[idx].Value, typeof(DateTime))
                    : null;

                    property.SetValue(posInfo, value);
                }

            }

            return posInfo;

        }
        #endregion
    }
    #endregion

}
