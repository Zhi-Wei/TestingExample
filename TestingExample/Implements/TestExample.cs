﻿using System;
using System.Collections.Generic;
using TestingExample.Interfaces;

namespace TestingExample.Implements
{
    /// <summary>
    /// 測試範例。
    /// </summary>
    /// <seealso cref="TestingExample.Interfaces.IContainable" />
    public class TestExample : IContainable
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
        /// <exception cref="ArgumentNullException">source</exception>
        public bool Contains<TSource>(IEnumerable<TSource> source, TSource value)
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