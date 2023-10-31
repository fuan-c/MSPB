using System;
using System.Data;
using dnp.nulcommon.dao;

namespace MSPB.MSPB012.dao
{
    /// <summary>
    /// 管理者Entity
    /// </summary>
    class EmployeeEntity : DbEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int32 ID { get; set; }
        /// <summary>
        /// ログインID
        /// </summary>
        public string USER_ID { get; set; }
        /// <summary>
        /// 担当者名
        /// </summary>
        public string USER_NAME { get; set; }
        /// <summary>
        /// 権限
        /// </summary>
        public string USER_AUTHORITY { get; set; }
        /// <summary>
        /// パスワード
        /// </summary>
        public string USER_PASSWORD { get; set; }
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmployeeEntity()
            : base()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmployeeEntity(DataRow row)
            : base(row)
        {

        }

    }
}
