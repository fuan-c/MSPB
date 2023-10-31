using MSPB.MSPB007.form;

namespace MSPB.MSPB007
{
    /// <summary>
    /// 追跡番号生成メイン
    /// </summary>
    public class clsMSPB007
    {

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="userName"></param>
        public void procStart(string userName)
        {
            frmMSPB007 p = new frmMSPB007(userName);
            p.ShowDialog();

        }
    }
}
