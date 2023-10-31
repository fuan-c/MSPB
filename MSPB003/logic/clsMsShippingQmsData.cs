using System;

namespace MSPB.MSPB003.logic
{
    /// <summary>
    /// 発送QMSデータ
    /// </summary>
    class clsMsShippingQmsData
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 出荷日
        /// </summary>
        public string SHIPPING_DATE { get; set; }
        /// <summary>
        /// お問合せ番号
        /// </summary>
        public string CONTACT_NO { get; set; }
        /// <summary>
        /// 管理番号
        /// </summary>
        public string CONTROL_NO { get; set; }        
        /// <summary>
        /// 証券番号
        /// </summary>
        public string CONTRACT_NO { get; set; }
        /// <summary>
        /// 読取配送伝票管理番号
        /// </summary>
        public string READ_DELIVERY_SLIP_CONTROL_NO { get; set; }
        /// <summary>
        /// 読取配送伝票管理番号
        /// </summary>
        public string READ_CONTROL_LABEL { get; set; }
        /// <summary>
        /// 梱包担当者名
        /// </summary>
        public string PACKING_USER_NAME { get; set; }
        /// <summary>
        /// 梱包日時
        /// </summary>
        public string PACKING_DATE { get; set; }
        /// <summary>
        /// 出荷完了日
        /// </summary>
        public string SHIPPING_COMPLEATE_DATE { get; set; }
        /// <summary>
        /// 登録日時
        /// </summary>
        public DateTime REGIST_DATE { get; set; }
        /// <summary>
        /// 登録担当者名
        /// </summary>
        public string REGIST_USER_NAME { get; set; }
        /// <summary>
        /// 処理No
        /// </summary>
        public int PROCESS_NO { get; set; }


        /// <summary>
        /// 配送伝票管理番号
        /// </summary>
        public string DELIVERY_SLIP_CONTROL_NO
        {
            get
            {                   
                //「出荷日(yymmdd)」+ 品目識別（"1"）+ 配送伝票媒体コード("0")  + 処理No +C / D + "#"
                string code = this.SHIPPING_DATE.Substring(2, 6) + "1" + "0" + this.PROCESS_NO.ToString("0000");
                code = code + (long.Parse(code) % 7).ToString() + "#";

                return code;

            }
        }

    }
}
