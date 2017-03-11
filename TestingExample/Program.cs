using System;
using System.Collections.Generic;

namespace TestingExample
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine($"來源序列為：{string.Join(", ", list)}");

            Console.WriteLine("請輸入要判斷的數字：");
            int value;
            int.TryParse(Console.ReadLine(), out value);

            Console.WriteLine($"來源序列是否包含指定的項目：");
            Console.WriteLine(Contains(list, value));

            Console.ReadLine();
        }

        /// <summary>
        /// 判斷來源序列是否包含指定的項目，使用預設相等比較子。
        /// </summary>
        /// <typeparam name="TSource">來源序列型別。</typeparam>
        /// <param name="source">來源序列。</param>
        /// <param name="value">指定的項目。</param>
        /// <returns>
        /// 如果來源序列包含具有指定的值為 <c>true</c>，否則為 <c>false</c>。
        /// </returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static bool Contains<TSource>(IEnumerable<TSource> source, TSource value)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var comparer = EqualityComparer<TSource>.Default;

            foreach (var item in source)
            {
                if (comparer.Equals(item, value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}