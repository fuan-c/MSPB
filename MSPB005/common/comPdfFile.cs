using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.IO;
using log4net;

namespace MSPB.MSPB005.common
{
    class comPdfFile
    {
        /// <summary>
        /// ログ
        /// </summary>
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// PDF印刷
        /// </summary>
        /// <param name="pdffile"></param>
        public void pdfPrintOpen(string pdffile)
        {

            logger.Debug("PDF印刷開始");
            Process pro = new Process();

            //Acrobatのフルパス設定
            pro.StartInfo.FileName = ConfigurationManager.AppSettings["AdobeReaderPath"];

            pro.StartInfo.Verb = "open";


            for(int cnt = 0; cnt < 10; cnt++)
            {
                if (!File.Exists(pdffile))
                {
                    break;
                }
                Thread.Sleep(1000);
            }

            //引数設定
            pro.StartInfo.Arguments = " /p  " + pdffile;
            logger.DebugFormat("印刷引数:{0}", pro.StartInfo.Arguments);

            pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //プロセスを新しいWindowで起動
            pro.StartInfo.CreateNoWindow = true;
            //プロセス起動
            pro.Start();
        }
    }
}
