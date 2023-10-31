using MSPB.MSPB010.form;

namespace MSPB.MSPB010
{
    /// <summary>
    /// 検索メイン
    /// </summary>
    public class clsMSPB010
    {

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="userName"></param>
        public void procStart(string userName)
        {
            frmMSPB010 p = new frmMSPB010(userName);
            p.ShowDialog();
        }
    }
}
