using dnp.nulcommon.dao;
using System;
using System.Data;

namespace MSPB.MSPB007.dao
{
    class TrackingNumberEnity : DbEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int32 ID { get; set; }

        /// <summary>
        /// 追跡番号
        /// </summary>
        public string TRACKING_NO { get; set; }

        /// <summary>
        /// 使用日
        /// </summary>
        public string USE_DATE { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TrackingNumberEnity(DataRow row)
            : base(row)
        {

        }
    }
}
