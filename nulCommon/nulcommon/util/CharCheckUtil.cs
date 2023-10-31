using System.Text.RegularExpressions;

namespace dnp.nulcommon.util
{
    /// <summary>
    /// 文字列チェック用ユーティリティクラス
    /// </summary>
    public static class CharCheckUtil
    {
        /// <summary>
        /// 半角文字チェック
        /// </summary>
        /// <param name="str">チェック対象文字列</param>
        /// <returns>半角文字のみで構成（空文字列は対象外）</returns>
        public static bool IsHalfWidthString(string str, bool isAllowSpace = true)
        {
            return
                isAllowSpace ?
                    Regex.IsMatch(str, @"^[ -~｡-ﾟ]+$") :
                    Regex.IsMatch(str, @"^[!-~｡-ﾟ]+$");
        }

        /// <summary>
        /// 半角数字チェック
        /// </summary>
        /// <param name="str">チェック対象文字列</param>
        /// <returns>半角数字のみで構成（空文字列は対象外）</returns>
        public static bool IsHalfWidthNumericString(string str)
        {
            //return
                //Regex.IsMatch(str, @"^\d+$");
            return
            Regex.IsMatch(str, @"^[0-9]+$");
        }

        /// <summary>
        /// 半角英字チェック
        /// </summary>
        /// <param name="str">チェック対象文字列</param>
        /// <returns>半角英字のみで構成（空文字列は対象外）</returns>
        public static bool IsHalfWidthAlphaString(string str, bool isAllowSpace = true)
        {
            return
                isAllowSpace ?
                    Regex.IsMatch(str, @"^[A-Za-z ]+$") :
                    Regex.IsMatch(str, @"^[A-Za-z]+$");
        }

        /// <summary>
        /// 半角英数字チェック
        /// </summary>
        /// <param name="str">チェック対象文字列</param>
        /// <returns>半角英数字のみで構成（空文字列は対象外）</returns>
        public static bool IsHalfWidthAlphaNumericString(string str, bool isAllowSpace = true)
        {
            return
                isAllowSpace ?
                    Regex.IsMatch(str, @"^[A-Za-z\d ]+$") :
                    Regex.IsMatch(str, @"^[A-Za-z\d]+$");
        }

        /// <summary>
        /// 半角カタカナチェック
        /// </summary>
        /// <param name="str">チェック対象文字列</param>
        /// <returns>半角カタカナのみで構成（空文字列は対象外）</returns>
        public static bool IsHalfWidthKatakanaString(string str, bool isAllowSpace = true)
        {
            return
                isAllowSpace ?
                    Regex.IsMatch(str, @"^[ｦ-ﾟ ]+$") :
                    Regex.IsMatch(str, @"^[ｦ-ﾟ]+$");
        }

        /// <summary>
        /// 全角チェック
        /// </summary>
        /// <param name="str">チェック対象文字列</param>
        /// <returns>全角のみで構成（空文字列は対象外）</returns>
        /// <returns>先頭全角スペースは False</returns>
        /// <returns>末尾全角スペースは False</returns>
        public static bool IsFullWidthString(string str)
        {
            return
                Regex.IsMatch(str, @"^[^　]+") &&
                Regex.IsMatch(str, @"^[^ -~｡-ﾟ]+$") &&
                Regex.IsMatch(str, @"[^　]+$");
        }

        /// <summary>
        /// 全角カタカナチェック
        /// </summary>
        /// <param name="str">チェック対象文字列</param>
        /// <returns>全角カタカナのみで構成（空文字列は対象外）</returns>
        /// <returns>先頭全角スペースは False</returns>
        /// <returns>末尾全角スペースは False</returns>
        /// <returns>先頭ヽヾーは False</returns>
        public static bool IsFullWidthKatakanaString(string str)
        {
            return
                Regex.IsMatch(str, @"^[ァ-ヶ]+") &&
                Regex.IsMatch(str, @"^[ァ-ヶヽヾー　]+$") &&
                Regex.IsMatch(str, @"[^　]+$");
        }
    }
}
