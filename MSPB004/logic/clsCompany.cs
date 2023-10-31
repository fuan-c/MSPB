namespace MSPB.MSPB004.logic
{
    /// <summary>
    /// 会社情報
    /// </summary>
    class clsCompany
    {
        /// <summary>
        /// 会社コード
        /// </summary>
        public string COMPANY_CODE { get; set; }
        /// <summary>
        /// 会社略称
        /// </summary>
        public string COMPANY_RYAKU { get; set; }
        /// <summary>
        /// 社名略称
        /// </summary>
        public string COMPANY_NAME_RYAKU { get; set; }
        /// <summary>
        /// 正式名称
        /// </summary>
        public string FORMAL_NAME { get; set; }
        /// <summary>
        /// 郵便番号
        /// </summary>
        public string POSTAL_CODE { get; set; }
        /// <summary>
        /// 住所
        /// </summary>
        public string ADDRESS { get; set; }
        /// <summary>
        /// ゆうパック顧客番号
        /// </summary>
        public string YUPACK_CUSTOMER_NO { get; set; }
        /// <summary>
        /// リターンパック顧客番号
        /// </summary>
        public string RETURNPACK_CUSTOMER_NO { get; set; }
        /// <summary>
        /// ゆうパケット顧客番号
        /// </summary>
        public string YUPACKET_CUSTOMER_NO { get; set; }
        /// <summary>
        /// 普通郵便顧客番号
        /// </summary>
        public string REGULAR_MAIL_COUSTOMER_NO { get; set; }
    }
}
