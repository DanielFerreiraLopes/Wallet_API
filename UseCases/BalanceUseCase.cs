using Wallet_API.DTOs.Requests;
using Wallet_API.Interfaces.IRepositories;

namespace Wallet_API.UseCases
{
    public class BalanceUseCase
    {
        private readonly IWalletRepository _walletRepository;
        public BalanceUseCase(IWalletRepository walletRepository)
        {
            this._walletRepository = walletRepository;
        }
        public float Run(BalanceRequest request)
        {
            try
            {
                var wallet = _walletRepository.FindByID(request.WelletId);
                if (wallet == null)
                {
                    throw new Exception("Wallet Invalida");
                }
                return wallet.Balance();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
}
