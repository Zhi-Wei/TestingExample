using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private string GetUInt16MaxValueLengthString()
        {
            var builder = new StringBuilder(ushort.MaxValue);
            for (int i = 0; i < ushort.MaxValue; i++)
            {
                builder.Append("A");
            }
            return builder.ToString();
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

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Stress Testing Coverage")]
        [TestProperty("Stress Testing Coverage", "1")]
        public void Contains_當傳入引數source為包含Double最大值元素與value為Double最大值時_應回傳True()
        {
            // Arrange
            var source = new List<double> { double.MaxValue };
            var value = double.MaxValue;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Stress Testing Coverage")]
        [TestProperty("Stress Testing Coverage", "2")]
        public void Contains_當傳入引數source為包含Double最小值元素與value為Double最小值時_應回傳True()
        {
            // Arrange
            var source = new List<double> { double.MinValue };
            var value = double.MinValue;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Stress Testing Coverage")]
        [TestProperty("Stress Testing Coverage", "3")]
        public void Contains_當傳入引數source為包含Null字串元素與value為Null字串時_應回傳True()
        {
            // Arrange
            var source = new List<string> { null };
            string value = null;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Stress Testing Coverage")]
        [TestProperty("Stress Testing Coverage", "4")]
        public void Contains_當傳入引數source為包含空字串元素與value為空字串時_應回傳True()
        {
            // Arrange
            var source = new List<string> { string.Empty };
            var value = string.Empty;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Stress Testing Coverage")]
        [TestProperty("Stress Testing Coverage", "5")]
        public void Contains_當傳入引數source為包含空格字串元素與value為空格字串時_應回傳True()
        {
            // Arrange
            var source = new List<string> { " " };
            var value = " ";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Stress Testing Coverage")]
        [TestProperty("Stress Testing Coverage", "6")]
        public void Contains_當傳入引數source為包含由A字元組成UInt16最大值長度字串元素與value為由A字元組成UInt16最大值長度字串時_應回傳True()
        {
            // Arrange
            var value = this.GetUInt16MaxValueLengthString();
            var source = new List<string> { value };
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Stress Testing Coverage")]
        [TestProperty("Stress Testing Coverage", "7")]
        public void Contains_當傳入引數source為1至Int32最大值個整數元素與value為Int32最大值時_應回傳True()
        {
            // Arrange
            var source = Enumerable.Range(1, int.MaxValue);
            var value = int.MaxValue;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [TestCategory("TestExample")]
        [TestProperty("TestExample", "Contains")]
        [TestCategory("Stress Testing Coverage")]
        [TestProperty("Stress Testing Coverage", "8")]
        public void Contains_當傳入引數source為包含Object型別的整數1元素與value為Object型別的字串1時_應回傳False()
        {
            // Arrange
            var source = new List<object> { 1 };
            object value = "1";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Contains(source, value);

            // Assert
            actual.Should().BeFalse();
        }
    }
}