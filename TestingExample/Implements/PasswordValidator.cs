using System;
using System.Collections.Generic;
using System.Linq;
using TestingExample.Interfaces;
using TestingExample.Models;

namespace TestingExample.Implements
{
    /// <summary>
    /// 密碼驗證器。
    /// </summary>
    /// <seealso cref="TestingExample.Interfaces.IPasswordValidator" />
    public class PasswordValidator : IPasswordValidator
    {
        /// <summary>
        /// 必要的最小長度。
        /// </summary>
        private int _requiredMinimumLength;

        /// <summary>
        /// 必要的最大長度。
        /// </summary>
        private int _requiredMaximumLength;

        /// <summary>
        /// 須要非字母或數字。
        /// </summary>
        private bool _requireNonLetterOrDigit;

        /// <summary>
        /// 須要小寫字母。
        /// </summary>
        private bool _requireLowercase;

        /// <summary>
        /// 須要大寫字母。
        /// </summary>
        private bool _requireUppercase;

        /// <summary>
        /// 須要數字。
        /// </summary>
        private bool _requireDigit;

        /// <summary>
        /// 初始化 <see cref="PasswordValidator"/> 類別新的執行個體。
        /// </summary>
        public PasswordValidator()
        {
            this.Initialize(new PasswordPolicy
            {
                RequiredMinimumLength = 8,
                RequiredMaximumLength = 32,
                RequireNonLetterOrDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
                RequireDigit = true
            });
        }

        /// <summary>
        /// 初始化 <see cref="PasswordValidator"/> 類別新的執行個體。
        /// </summary>
        /// <param name="policy">密碼原則。</param>
        public PasswordValidator(PasswordPolicy policy)
        {
            this.Initialize(policy);
        }

        /// <summary>
        /// 初始化指定的密碼原則。
        /// </summary>
        /// <param name="policy">密碼原則。</param>
        private void Initialize(PasswordPolicy policy)
        {
            this._requiredMinimumLength = policy.RequiredMinimumLength;
            this._requiredMaximumLength = policy.RequiredMaximumLength;
            this._requireNonLetterOrDigit = policy.RequireNonLetterOrDigit;
            this._requireLowercase = policy.RequireLowercase;
            this._requireUppercase = policy.RequireUppercase;
            this._requireDigit = policy.RequireDigit;
        }

        /// <summary>
        /// 驗證密碼是否符合指定的規則。
        /// </summary>
        /// <param name="password">要被驗證的密碼。</param>
        /// <returns>
        /// 符合指定的規則為 <c>true</c>，否則為 <c>false</c>。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">password</exception>
        public bool Validate(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var checkList = new List<Func<string, bool>>
            {
                item => string.IsNullOrWhiteSpace(item),
                item => item.Length < this._requiredMinimumLength,
                item => item.Length > this._requiredMaximumLength,
                item => this._requireNonLetterOrDigit && item.All(this.IsLetterOrDigit),
                item => this._requireDigit && item.All(c => this.IsDigit(c) == false),
                item => this._requireLowercase && item.All(c => this.IsLower(c) == false),
                item => this._requireUppercase && item.All(c => this.IsUpper(c) == false)
            };

            foreach (var func in checkList)
            {
                if (func(password))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 判斷指定的字元是否為數字。
        /// </summary>
        /// <param name="c">指定的字元。</param>
        /// <returns>
        /// 若指定的字元是數字為 <c>true</c>，否則為 <c>false</c>。
        /// </returns>
        private bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        /// <summary>
        /// 判斷指定的字元是否為小寫字母。
        /// </summary>
        /// <param name="c">指定的字元。</param>
        /// <returns>
        /// 若指定的字元是小寫字母為 <c>true</c>，否則為 <c>false</c>。
        /// </returns>
        private bool IsLower(char c)
        {
            return c >= 'a' && c <= 'z';
        }

        /// <summary>
        /// 判斷指定的字元是否為大寫字母。
        /// </summary>
        /// <param name="c">指定的字元。</param>
        /// <returns>
        /// 若指定的字元是大寫字母為 <c>true</c>，否則為 <c>false</c>。
        /// </returns>
        private bool IsUpper(char c)
        {
            return c >= 'A' && c <= 'Z';
        }

        /// <summary>
        /// 判斷指定的字元是否為字母或數字。
        /// </summary>
        /// <param name="c">指定的字元。</param>
        /// <returns>
        /// 若指定的字元是字母或數字為 <c>true</c>，否則為 <c>false</c>。
        /// </returns>
        private bool IsLetterOrDigit(char c)
        {
            return this.IsUpper(c) || this.IsLower(c) || this.IsDigit(c);
        }
    }
}