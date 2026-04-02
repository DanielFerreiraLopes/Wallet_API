using Wallet_API.Entities.Enum;
using Wallet_API.ValueObjects;

namespace Wallet_API.Entities
{
    public class Transaction : EntityBase
    {
        public Guid WalletId { get; set; }
        public Amount Amount { get; set; }
        public TransactionType TransactionType { get; set; }

        public Transaction(Guid walletId, Amount amount, TransactionType transactionType)
        {
            if (walletId == null)
            {
                throw new Exception("WalletId Invalido");
            }
            if (amount == null)
            {
                throw new Exception("Valor Invalido");
            }
            this.WalletId = walletId;
            this.Amount = amount;
            this.TransactionType = transactionType;
        }
    }
}
