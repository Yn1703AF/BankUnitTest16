using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;


namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 11.99;
            //Создание объекта класса BankAccount
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
            account.Debit(debitAmount));
        }


        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        //Проверка на превышение колличества цифр в PIN-коде


        [TestMethod]
        public void CheckMaxLength_ValidPassword_ReturnsFalse()
        {
            BankAccount ba = new BankAccount("Password", 12345);
            string password = "12345";
            bool result = BankAccount.CheckFormatPassword(password);
            Assert.IsFalse(result, "Password is too long");
        }

        //Проверка на недостаточное колличество цифр в PIN-коде


        [TestMethod]
        public void CheckMinLength_ValidPassword_ReturnsFalse()
        {
            BankAccount ba = new BankAccount("Password", 123);
            string password = "123";
            bool result = BankAccount.CheckFormatPassword(password);
            Assert.IsFalse(result, "Password is too short");
        }

        // Провекра на ввод только цифр в PIN-коде


        [TestMethod]
        public void CheckDigitsOnly_ValidPassword_ReturnsTrue()
        {
            BankAccount ba = new BankAccount("Password", 123);
            string password = "dokf";
            bool result = BankAccount.CheckFormatPassword(password);
            Assert.IsFalse(result, "Password contains non-digit characters");
        }
    }
}