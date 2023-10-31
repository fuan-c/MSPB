using System;
using System.Data;
using dnp.nulcommon.dao;

namespace MSPB.MSPB003.dao
{
    /// <summary>
    /// 処理履歴データEntity
    /// </summary>
    class ProcessHistoryEnity : DbEntity
    {
        /// <summary>
        /// SEQ_NO
        /// </summary>
        public int SEQ_NO { get; set; }
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
        public int INPUT_COUNT { get; set; }
        /// <summary>
        /// 出力ファイル名
        /// </summary>
        public string OUTPUT_FILE_NAME { get; set; }
        /// <summary>
        /// 出力件数
        /// </summary>
        public int OUTPUT_COUNT { get; set; }
        /// <summary>
        /// 処理日時
        /// </summary>
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 処理担当者名
        /// </summary>
        public string UPDATE_USER { get; set; }        

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ProcessHistoryEnity()
            : base()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ProcessHistoryEnity(DataRow row)
            : base(row)
        {

        }





    }
}
