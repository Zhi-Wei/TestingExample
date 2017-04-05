namespace TestingExample.Interfaces
{
    /// <summary>
    /// 定義在特定的範圍內的方法。
    /// </summary>
    public interface IInRangeable
    {
        /// <summary>
        /// 判斷指定的數字是否在特定的範圍內。
        /// </summary>
        /// <param name="number">指定的數字。</param>
        /// <returns>
        /// 若指定的數字在特定的範圍內則回傳 <c>true</c>，否則回傳 <c>false</c>。
        /// </returns>
        bool IsInRange(int number);
    }
}