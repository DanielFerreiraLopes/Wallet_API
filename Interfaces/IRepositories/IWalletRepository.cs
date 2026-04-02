using Wallet_API.Entities;

namespace Wallet_API.Interfaces.IRepositories
{
    public interface IWalletRepository
    {
        public Wallet FindByID(Guid id);
        public void Update(Wallet wallet);
    }
}
