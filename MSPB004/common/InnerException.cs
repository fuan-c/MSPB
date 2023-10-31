using System;

namespace MSPB.MSPB004.common
{
    class InnerException : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param>メッセージ</param>
        public InnerException()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message">メッセージ</param>
        public InnerException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="innerException">内部Exception</param>
        public InnerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
