namespace MSPB.MSPB003.logic
{
    /// <summary>
    /// 梱包ラインデータ
    /// </summary>
    class clsMsPackingLineData
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
        /// 保険会社コード
        /// </summary>
        public string INSURANCE_CODE { get; set; }
        /// <summary>
        /// 返却先
        /// </summary>
        public string RETURN_PLACE { get; set; }        
        /// <summary>
        /// 件数
        /// </summary>
        public string PACKING_COUNT { get; set; }
        /// <summary>
        /// 登録日
        /// </summary>
        public string REGIST_DATE { get; set; }
        /// <summary>
        /// 担当者名
        /// </summary>
        public string REGIST_USER_NAME { get; set; }
        /// <summary>
        /// 梱包ステータス
        /// </summary>
        public string PACKING_STATUS { get; set; }
        /// <summary>
        /// 出荷完了日
        /// </summary>
        public string SHIPPING_COMPLEATE_DATE { get; set; }       

    }
}
