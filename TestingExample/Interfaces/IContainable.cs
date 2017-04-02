using System.Collections.Generic;

namespace TestingExample.Interfaces
{
    /// <summary>
    /// 定義可包含的方法定義。
    /// </summary>
    public interface IContainable
    {
        /// <summary>
        /// 判斷來源序列是否包含指定的項目，使用預設相等比較子。
        /// </summary>
        /// <typeparam name="TSource">來源序列型別。</typeparam>
        /// <param name="source">來源序列。</param>
        /// <param name="value">指定的項目。</param>
        /// <returns>
        /// 如果來源序列包含具有指定的值為 <c>true</c>，否則為 <c>false</c>。
        /// </returns>
        bool Contains<TSource>(IEnumerable<TSource> source, TSource value);
    }
}