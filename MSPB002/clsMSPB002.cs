using MSPB.MSPB002.form;

namespace MSPB.MSPB002
{
    /// <summary>
    /// エスカレ回答登録メイン
    /// </summary>
    public class clsMSPB002
    {

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="userName"></param>
        public void procStart(string userName)
        {
            frmMSPB002 p = new frmMSPB002(userName);
            p.ShowDialog();

        }


    }
}
