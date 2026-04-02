using Wallet_API.ValueObjects;

namespace Wallet_API.DTOs.Requests
{
    public class TransactionRequest
    {
        public Guid WalletId { get; set; }
        public Amount Amount { get; set; }
    }
}
