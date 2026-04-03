using Wallet_API.DTOs.Requests;
using Wallet_API.Interfaces.IRepositories;

namespace Wallet_API.UseCases
{
    public class DepositUseCase
    {
        private readonly IWalletRepository _walletRepository;

        public DepositUseCase(IWalletRepository walletRepository)
        {
            this._walletRepository = walletRepository;
        }

        public void Run(TransactionRequest request)
        {
            try
            {
                var wallet = _walletRepository.FindByUserID(request.UserId);

                if (wallet == null)
                {
                    throw new Exception("Wallet Invalida");
                }

                wallet.Deposit(request.Amount);
                _walletRepository.Update(wallet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
