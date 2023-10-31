using MSPB.MSPB009.form;

namespace MSPB.MSPB009
{
    /// <summary>
    /// エスカレ回答承認メイン
    /// </summary>
    public class clsMSPB009
    {

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="userName"></param>
        public void procStart(string userName)
        {
            frmMSPB009 p = new frmMSPB009(userName);
            p.ShowDialog();

        }


    }
}
