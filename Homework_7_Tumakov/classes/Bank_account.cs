
namespace Homework_7_Tumakov
{
    enum Account_bank
    {
        current = 1,
        savings = 2
    }

    internal class Bank_account
    {
        #region Поля
        private int _id;
        private decimal _currentAccount;
        private decimal _savingsAccount;
        #endregion

        #region Конструктор
        public Bank_account(decimal currentAccount, decimal savingsAccount)
        {
            _currentAccount = currentAccount;
            _savingsAccount = savingsAccount;
        }

        public Bank_account() { }
        #endregion

        #region Свойства
        public int Id
        { get { return _id; } set { _id = value; } }

        public decimal CurrentAccount
        { get { return _currentAccount; } set { _currentAccount = value; } }

        public decimal SavingsAccount
        { get { return _savingsAccount; } set { _savingsAccount = value; } }
        #endregion

        #region Метод
        public void TransferFunds(Bank_account fromAccount, Bank_account toAccount, decimal amount)
        {
           
            if (fromAccount == null || toAccount == null)
            {
                throw new ArgumentNullException("Счет не может быть null.");
            }

            
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма перевода должна быть больше нуля.", nameof(amount));
            }

            
            if (fromAccount.CurrentAccount < amount && fromAccount.SavingsAccount < amount)
            {
                throw new InvalidOperationException("Недостаточно средств на счете для выполнения перевода.");
            }

           
            if (fromAccount.CurrentAccount >= amount)
            {
                fromAccount.CurrentAccount -= amount;          
                toAccount.CurrentAccount += amount;            
                Console.WriteLine($"Перевод {amount} выполнен успешно с текущего счета на счет {toAccount.Id}.");
            }
            else
            {
                fromAccount.SavingsAccount -= amount;          
                toAccount.CurrentAccount += amount;            
                Console.WriteLine($"Перевод {amount} выполнен успешно со сберегательного счета на счет {toAccount.Id}.");
            }
        }
        #endregion
    }




}
