using dnp.nulcommon.dao;
using System;
using System.Collections.Generic;

namespace MSPB.MSPB007.dao
{
    class T_TRACKING_NUMBERentity : DbTableEntity
    {
        public override string TableName
        {
            get { return "T_TRACKING_NUMBER"; }
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
                  "TRACKING_NO"
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
        public Int32 ID { get; set; }
        /// <summary>
        /// 追跡番号
        /// </summary>
        public string TRACKING_NO { get; set; }

        public T_TRACKING_NUMBERentity()
            : base()
        {

        }
    }
}
