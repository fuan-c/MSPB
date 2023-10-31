using System;
using System.Data;
using dnp.nulcommon.dao;

namespace MSPB.MSPB002.dao
{
    /// <summary>
    /// 回答_TEMP_Entity
    /// </summary>
    class ResponseTMPEntity : DbEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int32 ID { get; set; }
        /// <summary>
        /// 登録日
        /// </summary>
        public string REPORT_DATE { get; set; }
        /// <summary>
        /// 種別
        /// </summary>
        public string PRODUCT_TYPE { get; set; }
        /// <summary>
        /// 管理番号
        /// </summary>
        public string CONTROL_NO { get; set; }
        /// <summary>
        /// 証券番号
        /// </summary>
        public string CONTRACT_NO { get; set; }
        /// <summary>
        /// エスカレ回答
        /// </summary>
        public string ESCALATION_RESPONSE { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResponseTMPEntity()
            : base()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResponseTMPEntity(DataRow row)
            : base(row)
        {

        }

    }
}
