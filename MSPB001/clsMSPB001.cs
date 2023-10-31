using MSPB.MSPB001.form;

namespace MSPB.MSPB001
{
    /// <summary>
    /// メインメニューメイン
    /// </summary>
    public class clsMSPB001
    {
        /// <summary>
        /// Start
        /// </summary>
        /// <param name="userName"></param>
        public void procStart(string authority, string userName)
        {
            frmMenu p = new frmMenu(authority, userName);
            p.ShowDialog();
        }
    }
}
