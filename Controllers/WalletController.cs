using Microsoft.AspNetCore.Mvc;
using Wallet_API.DTOs.Requests;
using Wallet_API.Entities;
using Wallet_API.UseCases;

namespace Wallet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly DepositUseCase _depositUseCase;
        private readonly PlunderUseCase _plunderUseCase;
        private readonly HistoryUseCase _historyUseCase;
        private readonly BalanceUseCase _balanceUseCase;

        public WalletController(DepositUseCase depositUseCase, PlunderUseCase plunderUseCase, HistoryUseCase historyUseCase, BalanceUseCase balanceUseCase)
        {
            this._depositUseCase = depositUseCase;
            this._plunderUseCase = plunderUseCase;
            this._historyUseCase = historyUseCase;
            this._balanceUseCase = balanceUseCase;
        }



        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] TransactionRequest request)
        {
            //JWT Authentication
            try
            {
                this._depositUseCase.Run(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Plunder")]
        public IActionResult Plunder([FromBody] TransactionRequest request)
        {
            //JWT Authentication
            try
            {
                this._plunderUseCase.Run(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("History")]
        public IActionResult History([FromBody] HistoryRequest request)
        {
            //JWT Authentication
            try
            {
                List<Transaction> history =  this._historyUseCase.Run(request);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Balance")]
        public IActionResult Balance([FromBody] BalanceRequest request)
        {
            //JWT Authentication
            try
            {
                float balance = this._balanceUseCase.Run(request);
                return Ok(balance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
