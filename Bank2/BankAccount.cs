using System;
namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        private BankAccount() { }

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CheckMaxLength_ValidPassword_ReturnsFalse = "Длина PIN-кода больше, чем 4 цифры. PIN-код состоит из 4 цифр";
        public const string CheckMinLength_ValidPassword_ReturnsTrue = "Длина PIN-кода меньше, чем 4 цифры. PIN-код состоит из 4 цифр";
        public const string CheckDigitsOnly_ValidPassword_ReturnsTrue = "Вводимые символы отличны от цифр. PIN-код состоит из 4 цифр";

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        public string CustomerName
        {
            get { return m_customerName; }
        }
        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount,
                DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount,
                DebitAmountLessThanZeroMessage);
            }
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);

            string password1 = "12345"; 

            if (CheckFormatPassword(password1))
            {
                Console.WriteLine("Пароль удовлетворяет всем условиям.");
            }
            else
            {
                Console.WriteLine("PIN код введён неверно");
            };
        }

        public static bool CheckFormatPassword(string password)
        {
            if (password.Length > 4)
            {
                Console.WriteLine(CheckMaxLength_ValidPassword_ReturnsFalse);
                return false;
            }
            else if (password.Length < 4)
            {
                Console.WriteLine(CheckMinLength_ValidPassword_ReturnsTrue);
                return false;
            }

            foreach (char c in password)
            {
                if (!char.IsDigit(c))
                {
                    Console.WriteLine(CheckDigitsOnly_ValidPassword_ReturnsTrue);
                    return false;
                }
            }

            return true;
        }
    }
}
  
