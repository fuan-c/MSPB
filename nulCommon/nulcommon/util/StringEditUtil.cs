using System.Collections.Generic;

namespace dnp.nulcommon.util
{
    /// <summary>
    /// 文字列加工用ユーティリティクラス
    /// </summary>
    public static class StringEditUtil
    {
        /// <summary>
        /// 文字列固定文字数分割
        /// </summary>
        /// <param name="src">対象文字列</param>
        /// <param name="charCount">分割文字数</param>
        /// <returns>分割結果</returns>
        public static string[] SplitCharCount(string src, int charCount)
        {
            List<string> result = new List<string>();
            for (int groupCount = 0; groupCount * charCount < src.Length; groupCount++)
            {
                int posStart = groupCount * charCount;
                if (posStart + charCount < src.Length)
                {
                    result.Add(src.Substring(posStart, charCount));
                }
                else
                {
                    result.Add(src.Substring(posStart));
                }
            }
            return result.ToArray();
        }
    }
}
