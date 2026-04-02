using Wallet_API.Entities.Enum;
using Wallet_API.ValueObjects;

namespace Wallet_API.Entities
{
    public class Wallet : EntityBase
    {
        public Guid UserId { get; private set; }
        public Amount Amount { get; private set; }
        private List<Transaction> _transactions { get; set; }
        public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

        public Wallet(Guid userId, Amount amount)
        {
            if (userId == null)
            {
                throw new Exception("UserId Invalido");
            }

            this.UserId = userId;
            this.Amount = amount;
        }

        public void AddHistory(Amount amount, TransactionType type)
        {
            Transaction transaction = new Transaction(this.Id, amount, type);
            _transactions.Add(transaction);
        }
        

        public void Deposit(Amount amount)
        {
            if (amount == null)
            {
                throw new Exception("Valor Invalido");
            }
            this.Amount.Value += amount.Value;
            this.AddHistory(amount, TransactionType.Deposit);
        }

        public void Plunder(Amount amount)
        {
            if (amount == null)
            {
                throw new Exception("Valor Invalido");
            }
            if (this.Amount.Value < amount.Value)
            {
                throw new Exception("Saldo Insuficiente");
            }
            this.Amount.Value -= amount.Value;
            this.AddHistory(amount, TransactionType.Plunder);
        }

        public float Balance()
        {
            return this.Amount.Value;
        }

        public List<Transaction> History()
        {
            return this.Transactions.ToList();
        }
    }
}
