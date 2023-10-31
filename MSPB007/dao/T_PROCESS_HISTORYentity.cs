using dnp.nulcommon.dao;
using System;
using System.Collections.Generic;

namespace MSPB.MSPB007.dao
{
    class T_PROCESS_HISTORYentity : DbTableEntity
    {
        public override string TableName
        {
            get { return "T_PROCESS_HISTORY"; }
        }
        public override IEnumerable<string> PrimaryKeys
        {
            get
            {
                return new string[]
                {
                    "SEQ_NO"
                };
            }
        }

        public override IEnumerable<string> Columns
        {
            get
            {
                return new string[]
                {
                    "SEQ_NO",
                    "PROCESS_TEXT",
                    "INPUT_FILE_NAME",
                    "INPUT_COUNT",
                    "OUTPUT_FILE_NAME",
                    "OUTPUT_COUNT",
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
        /// SEQ_NO
        /// </summary>        
        public int? SEQ_NO { get; set; }
        /// <summary>
        /// 処理内容
        /// </summary>
        public string PROCESS_TEXT { get; set; }
        /// <summary>
        /// 入力ファイル名
        /// </summary>
        public string INPUT_FILE_NAME { get; set; }
        /// <summary>
        /// 入力件数
        /// </summary>
        public int? INPUT_COUNT { get; set; }
        /// <summary>
        /// 出力ファイル名
        /// </summary>
        public string OUTPUT_FILE_NAME { get; set; }
        /// <summary>
        /// 出力件数
        /// </summary>
        public int? OUTPUT_COUNT { get; set; }
        /// <summary>
        /// 処理日時
        /// </summary>
        public DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 処理担当者名
        /// </summary>
        public string UPDATE_USER { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public T_PROCESS_HISTORYentity()
            : base()
        {

        }
    }
}
