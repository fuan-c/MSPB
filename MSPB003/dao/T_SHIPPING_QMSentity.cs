using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using dnp.nulcommon.dao;

namespace MSAD.MSAD220.dao
{
    /// <summary>
    /// 発送QMSデータ登録
    /// </summary>
    class T_SHIPPING_QMSentity : DbTableEntity
    {

        public override string TableName
        {
            get { return "T_SHIPPING_QMS"; }
        }
        public override IEnumerable<string> PrimaryKeys
        {
            get
            {
                return new string[]
                {
                    "CONTROL_NO"
                };
            }
        }
        public override IEnumerable<string> Columns
        {
            get
            {
                return new string[]
                {
                    "ID",
                    "WORK_KIND",
                    "SHIPPING_CATEGORY",
                    "SHIPPING_DATE",
                    "DELIVERY_SLIP_CONTROL_NO",
                    "INVITATION_CONTROL_NO",
                    "CONTACT_NO",
                    "CONTROL_NO",
                    "LINE_NO",
                    "LINE_COUNT",
                    "UPDATE_DATE",
                    "UPDATE_USER"
                };
            }
        }

        protected override IEnumerable<KeyValuePair<string, object>> AdditionalColumnsInsert
        {
            get
            {
                return new KeyValuePair<string, object>[] {
                };
            }
        }
        protected override IEnumerable<KeyValuePair<string, object>> AdditionalColumnsUpdate
        {
            get
            {
                return new KeyValuePair<string, object>[] {
                };
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        public int? ID { get; set; }
        /// <summary>
        /// 作業種別
        /// </summary>
        public string WORK_KIND { get; set; }
        /// <summary>
        /// 発送区分
        /// </summary>
        public string SHIPPING_CATEGORY { get; set; }
        /// <summary>
        /// 出荷日
        /// </summary>
        public string SHIPPING_DATE { get; set; }
        /// <summary>
        /// 配送伝票管理番号
        /// </summary>
        public string DELIVERY_SLIP_CONTROL_NO { get; set; }
        /// <summary>
        /// 案内状管理番号
        /// </summary>
        public string INVITATION_CONTROL_NO { get; set; }
        /// <summary>
        /// お問合せ番号
        /// </summary>
        public string CONTACT_NO { get; set; }
        /// <summary>
        /// 管理番号
        /// </summary>
        public string CONTROL_NO { get; set; }
        /// <summary>
        /// ラインNO
        /// </summary>
        public int? LINE_NO { get; set; }
        /// <summary>
        /// ライン数
        /// </summary>
        public int? LINE_COUNT { get; set; }
        /// <summary>
        /// 処理日時
        /// </summary>
        public DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 処理担当者名
        /// </summary>
        public string UPDATE_USER { get; set; }

        public T_SHIPPING_QMSentity()
            : base()
        {

        }

        public T_SHIPPING_QMSentity(DataRow row)
            : base(row)
        {

        }




    }
}
