using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPB.MSPB005.form;

namespace MSPB.MSPB005
{
    /// <summary>
    /// エスカレシート出力メイン
    /// </summary>
    public class clsMSPB005
    {

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="userName"></param>
        public void procStart(string userName)
        {
            frmMSPB005 p = new frmMSPB005(userName);
            p.ShowDialog();

        }


    }
}
