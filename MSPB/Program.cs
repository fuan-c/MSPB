using System;
using System.Windows.Forms;
using MSPB.MSPB.form;


namespace MSPB
{

    //グローバル変数
    public class GlobalVariable
    {
        public static string STAFF_NAME;        // ユーザ名        
    }

    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
