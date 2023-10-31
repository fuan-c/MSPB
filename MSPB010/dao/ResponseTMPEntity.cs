using System;
using System.Data;
using dnp.nulcommon.dao;

namespace MSPB.MSPB010.dao
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
        /// 証券番号・契約番号
        /// </summary>
        public string CONTRACT_NO { get; set; }

        /// <summary>
        /// ステータス
        /// </summary>
        public string STATUS { get; set; }

        /// <summary>
        /// 私物情報
        /// </summary>
        public string PERSONAL_BELONGINGS_INFO { get; set; }

        /// <summary>
        /// 報告日
        /// </summary>
        public string REPORT_DATE { get; set; }


        /// <summary>
        /// 保管基準日
        /// </summary>
        public string STORAGE_REFERENCE_DATE { get; set; }

        /// <summary>
        /// 保管期限
        /// </summary>
        public string STORAGE_PERIOD { get; set; }

        /// <summary>
        ///回答日
        /// </summary>
        public string RESPONSE_DATE { get; set; }

        /// <summary>
        ///返却先
        /// </summary>
        public string RETURN_PLACE { get; set; }

        /// <summary>
        /// エスカレ回答
        /// </summary>
        public string ESCALATION_RESPONSE { get; set; }

        /// <summary>
        /// 追跡番号
        /// </summary>
        public string TRACKING_NO { get; set; }

        /// <summary>
        /// 出荷日
        /// </summary>
        public string SHIPPING_DATE { get; set; }


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
