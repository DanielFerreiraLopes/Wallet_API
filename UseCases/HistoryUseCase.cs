using Wallet_API.DTOs.Requests;
using Wallet_API.Entities;
using Wallet_API.Interfaces.IRepositories;

namespace Wallet_API.UseCases
{
    public class HistoryUseCase
    {
        private readonly IWalletRepository _walletRepository;

        public HistoryUseCase(IWalletRepository walletRepository)
        {
            this._walletRepository = walletRepository;
        }

        public List<Transaction> Run(HistoryRequest request)
        {
            try
            {
                var wallet = _walletRepository.FindByID(request.WalletId);
                if (wallet == null)
                {
                    throw new Exception("Wallet Invalida");
                }
                return wallet.History();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
