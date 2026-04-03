using Wallet_API.ValueObjects;

namespace Wallet_API.DTOs.Requests
{
    public class TransactionRequest
    {
        public Guid UserId { get; set; }
        public Amount Amount { get; set; }
    }
}
