namespace TestingExample.Interfaces
{
    /// <summary>
    /// 定義密碼驗證方法。
    /// </summary>
    public interface IPasswordValidator
    {
        /// <summary>
        /// 驗證密碼是否符合指定的規則。
        /// </summary>
        /// <param name="password">要被驗證的密碼。</param>
        /// <returns>符合指定的規則為 <c>true</c>，否則為 <c>false</c>。</returns>
        bool Validate(string password);
    }
}