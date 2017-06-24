using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestingExample.Models;

namespace TestingExample.Implements.Tests
{
    [TestClass()]
    public class PasswordValidatorTests
    {
        #region -- 前置準備 --

        private PasswordValidator GetSystemUnderTestInstance()
        {
            return new PasswordValidator();
        }

        #endregion -- 前置準備 --

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Constructor")]
        public void PasswordValidator_當無參數建構式初始化新的執行個體時_應無拋出例外狀況()
        {
            // Arrange
            // Act
            Action actual = () => new PasswordValidator();

            // Assert
            actual.ShouldNotThrow();
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Constructor")]
        public void PasswordValidator_當有參數建構式初始化新的執行個體時_應無拋出例外狀況()
        {
            // Arrange
            PasswordPolicy policy = new PasswordPolicy
            {
                RequiredMinimumLength = 8,
                RequiredMaximumLength = 32,
                RequireNonLetterOrDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
                RequireDigit = true
            };

            // Act
            Action actual = () => new PasswordValidator(policy);

            // Assert
            actual.ShouldNotThrow();
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Validate")]
        [TestCategory("Equivalence Partition")]
        [TestProperty("Equivalence Partition", "1")]
        public void Validate_當傳入引數password為Null時_應拋出ArgumentNullException的例外狀況()
        {
            // Arrange
            string password = null;
            var message = $"值不能為 null。{Environment.NewLine}參數名稱: password";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            Action action = () => sut.Validate(password);

            // Assert
            action.ShouldThrow<ArgumentNullException>().And.Message.Should().Be(message);
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Validate")]
        [TestCategory("Equivalence Partition")]
        [TestProperty("Equivalence Partition", "2")]
        public void Validate_當傳入引數password為空字串時_應回傳False()
        {
            // Arrange
            string password = string.Empty;
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Validate(password);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Validate")]
        [TestCategory("Equivalence Partition")]
        [TestProperty("Equivalence Partition", "3")]
        public void Validate_當傳入引數password為空格字串時_應回傳False()
        {
            // Arrange
            string password = " ";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Validate(password);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Validate")]
        [TestCategory("Equivalence Partition")]
        [TestProperty("Equivalence Partition", "4")]
        public void Validate_當傳入引數password為長度小於8的字串時_應回傳False()
        {
            // Arrange
            string password = "0Ab@";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Validate(password);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Validate")]
        [TestCategory("Equivalence Partition")]
        [TestProperty("Equivalence Partition", "5")]
        public void Validate_當傳入引數password為長度大於32的字串時_應回傳False()
        {
            // Arrange
            string password = "0Ab@0Ab@0Ab@0Ab@0Ab@0Ab@0Ab@0Ab@0Ab@";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Validate(password);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Validate")]
        [TestCategory("Equivalence Partition")]
        [TestProperty("Equivalence Partition", "6")]
        public void Validate_當傳入引數password為長度大於等於8且小於等於32且包含大小寫字母與數字與符號的字串時_應回傳True()
        {
            // Arrange
            string password = "0Ab@0Ab@";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Validate(password);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Validate")]
        [TestCategory("Equivalence Partition")]
        [TestProperty("Equivalence Partition", "7")]
        public void Validate_當傳入引數password為長度等於8且無符號的字串時_應回傳False()
        {
            // Arrange
            string password = "0Abc0Abc";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Validate(password);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Validate")]
        [TestCategory("Equivalence Partition")]
        [TestProperty("Equivalence Partition", "8")]
        public void Validate_當傳入引數password為長度等於8且無數字的字串時_應回傳False()
        {
            // Arrange
            string password = "zAb@zAb@";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Validate(password);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Validate")]
        [TestCategory("Equivalence Partition")]
        [TestProperty("Equivalence Partition", "9")]
        public void Validate_當傳入引數password為長度等於8且無小寫字母的字串時_應回傳False()
        {
            // Arrange
            string password = "0AB@0AB@";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Validate(password);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [TestCategory("PasswordValidator")]
        [TestProperty("PasswordValidator", "Validate")]
        [TestCategory("Equivalence Partition")]
        [TestProperty("Equivalence Partition", "10")]
        public void Validate_當傳入引數password為長度等於8且無大寫字母的字串時_應回傳False()
        {
            // Arrange
            string password = "0ab@0ab@";
            var sut = this.GetSystemUnderTestInstance();

            // Act
            var actual = sut.Validate(password);

            // Assert
            actual.Should().BeFalse();
        }
    }
}