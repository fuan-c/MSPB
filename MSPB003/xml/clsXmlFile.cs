using System.Xml;
using log4net;

namespace MSPB.MSPB003.xml
{
    #region xmlファイルクラス
    /// <summary>
    /// xmlファイルクラス
    /// </summary>
    class clsXmlFile
    {
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private XmlDocument xmlDoc;
        XmlNode xNode;
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <param name="xPath"></param>
        public clsXmlFile(string xmlFile,string xPath)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);
            xNode = xmlDoc.SelectSingleNode(xPath);
        }
        #endregion
        #region メソッド
        /// <summary>
        /// XML属性取得
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public XmlAttributeCollection attributes(string tag)
        {
            logger.DebugFormat("xml属性取得[tag:{0}]", tag);
            XmlAttributeCollection value = xNode.SelectSingleNode(tag).Attributes;
            return value;
        }
        /// <summary>
        /// XMLテキスト取得
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string InnerText(string tag)
        {
            logger.DebugFormat("xmlテキスト取得[tag:{0}]", tag);

            string value = xNode.SelectSingleNode(tag).InnerText;

            return value;

        }
        #endregion
    }
    #endregion
}
