using MSPB.MSPB008.form;

namespace MSPB.MSPB008
{
    /// <summary>
    /// 仕分けコード更新メイン
    /// </summary>
    public class clsMSPB008
    {

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="userName"></param>
        public void procStart(string userName)
        {
            frmMSPB008 p = new frmMSPB008(userName);
            p.ShowDialog();

        }
    }
}
