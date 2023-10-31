using MSPB.MSPB003.form;

namespace MSPB.MSPB003
{
    /// <summary>
    /// 発送帳票出力メイン
    /// </summary>
    public class clsMSPB003
    {

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="userName"></param>
        public void procStart(string userName)
        {
            frmMSPB003 p = new frmMSPB003(userName);
            p.ShowDialog();

        }


    }
}
