using System;
using System.Data;
using dnp.nulcommon.dao;

namespace MSPB.MSPB009.dao
{
    /// <summary>
    /// エスカレ_Entity
    /// </summary>
    class EscalationEntity : DbEntity
    {
        /// <summary>
        /// 承認チェック
        /// </summary>
        public bool APPROVAL_CHECK { get; set; }
        /// <summary>
        /// NO
        /// </summary>
        public Int32 NO { get; set; }
        /// <summary>
        /// 登録日
        /// </summary>
        public string REGIST_DATE { get; set; }
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
        /// ステータス
        /// </summary>
        public string STATUS { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EscalationEntity()
            : base()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EscalationEntity(DataRow row)
            : base(row)
        {

        }

    }
}
