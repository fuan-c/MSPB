using System.Collections.Generic;
using System.Data;
using dnp.nulcommon.dao;

namespace MSPB.MSPB003.dao
{
    /// <summary>
    /// 追跡番号更新
    /// </summary>
    class TrackingNumberEntity : DbTableEntity
    {
        public override string TableName
        {
            get { return "T_MS_YUU_TRACKING_NUMBER"; }
        }
        public override IEnumerable<string> PrimaryKeys
        {
            get
            {
                return new string[]
                {
                    "ID"
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
                  "TRACKING_NO",
                  "USE_DATE"
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
        /// 追跡番号
        /// </summary>
        public string TRACKING_NO { get; set; }
        /// <summary>
        /// 使用日
        /// </summary>
        public string USE_DATE { get; set; }

        public TrackingNumberEntity()
            : base()
        {

        }

        public TrackingNumberEntity(DataRow row)
            : base(row)
        {

        }

    }
}
