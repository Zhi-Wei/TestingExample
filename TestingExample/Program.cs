using System;
using System.Collections.Generic;
using TestingExample.Implements;

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
            var testExample = new TestExample();
            Console.WriteLine(testExample.Contains(list, value));

            Console.ReadLine();
        }
    }
}