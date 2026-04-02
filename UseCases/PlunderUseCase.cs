using Wallet_API.DTOs.Requests;
using Wallet_API.Interfaces.IRepositories;

namespace Wallet_API.UseCases
{
    public class PlunderUseCase
    {
        private readonly IWalletRepository _walletRepository;

        public PlunderUseCase(IWalletRepository walletRepository)
        {
            this._walletRepository = walletRepository;
        }

        public void Run(TransactionRequest request)
        {
            try
            {
                var wallet = _walletRepository.FindByID(request.WalletId);
                if (wallet == null)
                {
                    throw new Exception("Wallet Invalida");
                }
                wallet.Plunder(request.Amount);
                _walletRepository.Update(wallet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
