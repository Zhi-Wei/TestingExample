namespace TestingExample.Models
{
    /// <summary>
    /// 密碼原則資料傳輸物件。
    /// </summary>
    public class PasswordPolicy
    {
        /// <summary>
        /// 取得或設定必要的最小長度。
        /// </summary>
        /// <value>
        /// 必要的最小長度。
        /// </value>
        public int RequiredMinimumLength { get; set; }

        /// <summary>
        /// 取得或設定必要的最大長度。
        /// </summary>
        /// <value>
        /// 必要的最大長度。
        /// </value>
        public int RequiredMaximumLength { get; set; }

        /// <summary>
        /// 取得或設定須要非字母或數字。
        /// </summary>
        /// <value>
        /// 若須要非字母或數字則為 <c>true</c>，否則為 <c>false</c>。
        /// </value>
        public bool RequireNonLetterOrDigit { get; set; }

        /// <summary>
        /// 取得或設定須要小寫字母。
        /// </summary>
        /// <value>
        /// 若須要小寫字母則為 <c>true</c>，否則為 <c>false</c>。
        /// </value>
        public bool RequireLowercase { get; set; }

        /// <summary>
        /// 取得或設定須要大寫字母。
        /// </summary>
        /// <value>
        /// 若須要大寫字母則為 <c>true</c>，否則為 <c>false</c>。
        /// </value>
        public bool RequireUppercase { get; set; }

        /// <summary>
        /// 取得或設定須要數字。
        /// </summary>
        /// <value>
        /// 若須要數字則為 <c>true</c>，否則為 <c>false</c>。
        /// </value>
        public bool RequireDigit { get; set; }
    }
}