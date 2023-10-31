using MSPB.MSPB004.form;

namespace MSPB.MSPB004
{
    /// <summary>
    /// 出荷処理メイン
    /// </summary>
    public class clsMSPB004
    {

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="userName"></param>
        public void procStart(string userName)
        {
            frmMSPB004 p = new frmMSPB004(userName);
            p.ShowDialog();

        }


    }
}
