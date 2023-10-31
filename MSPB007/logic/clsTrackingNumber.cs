using System;

namespace MSPB.MSPB007.logic
{
    class clsTrackingNumber
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
        /// 追跡番号１１桁
        /// </summary>
        public string TRACKING_NO11
        {
            get
            {
                return this.TRACKING_NO.Replace("a", "").Substring(0, 11);
            }

        }
    }
}
