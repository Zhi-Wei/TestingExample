using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestingExample.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        [TestCategory("Program")]
        [TestProperty("Program", "Contains")]
        public void Contains_當傳入引數source為Null時_應拋出ArgumentNullException的例外狀況()
        {
            // Arrange
            IEnumerable<int> source = null;
            var value = 1;
            var message = $"值不能為 null。{Environment.NewLine}參數名稱: source";

            // Act
            Action action = () => Program.Contains(source, value);

            // Assert
            action.ShouldThrow<ArgumentNullException>().And.Message.Should().Be(message);
        }

        [TestMethod()]
        [TestCategory("Program")]
        [TestProperty("Program", "Contains")]
        public void Contains_當傳入引數source為空集合時_應回傳False()
        {
            // Arrange
            var source = new List<int>();
            var value = 1;

            // Act
            var actual = Program.Contains(source, value);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("Program")]
        [TestProperty("Program", "Contains")]
        public void Contains_當傳入引數source為只有單元素集合與value為集合內沒有的項目時_應回傳False()
        {
            // Arrange
            var source = new List<int> { 1 };
            var value = 0;

            // Act
            var actual = Program.Contains(source, value);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("Program")]
        [TestProperty("Program", "Contains")]
        public void Contains_當傳入引數source為多元素集合與value為集合內沒有的項目時_應回傳False()
        {
            // Arrange
            var source = new List<int> { 1, 2, 3 };
            var value = 0;

            // Act
            var actual = Program.Contains(source, value);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("Program")]
        [TestProperty("Program", "Contains")]
        public void Contains_當傳入引數source為只有單元素集合與value為集合內有的項目時_應回傳True()
        {
            // Arrange
            var source = new List<int> { 1 };
            var value = 1;

            // Act
            var actual = Program.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [TestCategory("Program")]
        [TestProperty("Program", "Contains")]
        public void Contains_當傳入引數source為多元素集合與value為集合內有的項目時_應回傳True()
        {
            // Arrange
            var source = new List<int> { 1, 2, 3 };
            var value = 2;

            // Act
            var actual = Program.Contains(source, value);

            // Assert
            actual.Should().BeTrue();
        }
    }
}