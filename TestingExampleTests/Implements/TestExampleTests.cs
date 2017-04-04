using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestingExample.Implements.Tests
{
    [TestClass()]
    public class TestExampleTests
    {
        #region -- 前置準備 --

        private TestExample GetSystemUnderTestInstance()
        {
            return new TestExample();
        }

        #endregion -- 前置準備 --

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Edge Coverage")]
        [TestProperty("Edge Coverage", "1")]
        [TestCategory("Test Path Coverage")]
        [TestProperty("Test Path Coverage", "1")]
        public void Contains_當傳入引數source為Null時_應拋出ArgumentNullException的例外狀況()
        {
            // Arrange
            IEnumerable<int> source = null;
            var value = 1;
            var message = $"值不能為 null。{Environment.NewLine}參數名稱: source";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            Action action = () => sut.Contains(source, value);

            // Assert
            action.ShouldThrow<ArgumentNullException>().And.Message.Should().Be(message);
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Edge-Pair Coverage")]
        [TestProperty("Edge-Pair Coverage", "1")]
        [TestCategory("Test Path Coverage")]
        [TestProperty("Test Path Coverage", "2")]
        public void Contains_當傳入引數source為空集合時_應回傳False()
        {
            // Arrange
            var source = new List<int>();
            var value = 1;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Test Path Coverage")]
        [TestProperty("Test Path Coverage", "3")]
        public void Contains_當傳入引數source為只有單元素集合與value為集合內沒有的項目時_應回傳False()
        {
            // Arrange
            var source = new List<int> { 1 };
            var value = 0;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Edge Coverage")]
        [TestProperty("Edge Coverage", "2")]
        [TestCategory("Edge-Pair Coverage")]
        [TestProperty("Edge-Pair Coverage", "2")]
        public void Contains_當傳入引數source為多元素集合與value為集合內沒有的項目時_應回傳False()
        {
            // Arrange
            var source = new List<int> { 1, 2, 3 };
            var value = 0;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Test Path Coverage")]
        [TestProperty("Test Path Coverage", "4")]
        public void Contains_當傳入引數source為只有單元素集合與value為集合內有的項目時_應回傳True()
        {
            // Arrange
            var source = new List<int> { 1 };
            var value = 1;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Edge Coverage")]
        [TestProperty("Edge Coverage", "3")]
        [TestCategory("Edge-Pair Coverage")]
        [TestProperty("Edge-Pair Coverage", "3")]
        [TestCategory("Test Path Coverage")]
        [TestProperty("Test Path Coverage", "5")]
        public void Contains_當傳入引數source為多元素集合與value為集合內有的項目時_應回傳True()
        {
            // Arrange
            var source = new List<int> { 1, 2, 3 };
            var value = 2;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }
    }
}