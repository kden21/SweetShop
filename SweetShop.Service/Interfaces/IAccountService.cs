using SweetShop.Domain.Entities;
using SweetShop.Domain.Responses;
using SweetShop.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Service.Interfaces
{
    public interface IAccountService
    {
		Task<BaseResponse<IEnumerable<Account>>> GetAccounts();
		Task<BaseResponse<Account>> GetAccount(int id);
		Task<BaseResponse<bool>> CreateAccount(Account productViewModel);
		Task<BaseResponse<bool>> DeleteAccount(int id);
		Task<BaseResponse<Account>> GetAccountByLogin(string login);
		Task<BaseResponse<Account>> EditAccount(int id, Account model);
		Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
		Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
	}
}
