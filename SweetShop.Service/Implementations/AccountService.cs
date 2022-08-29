using SweetShop.DAL.Interfaces;
using SweetShop.Domain.Entities;
using SweetShop.Domain.Enums;
using SweetShop.Domain.Helpers;
using SweetShop.Domain.Responses;
using SweetShop.Domain.ViewModels.Account;
using SweetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

namespace SweetShop.Service.Implementations
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<BaseResponse<bool>> CreateAccount(Account model)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var account = new Account()
                {
                    Username = model.Username,
                    Role = model.Role,
                    Password = model.Password
                };
                await _accountRepository.CreateAsync(account);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateAccount] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<bool>> DeleteAccount(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var account = await _accountRepository.GetAsync(id);
                if (account == null)
                {
                    baseResponse.Description = "Account not found";
                    baseResponse.StatusCode = StatusCode.AccountNotFound;
                    return baseResponse;
                }
                await _accountRepository.DeleteAsync(account);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[GetAccounts] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<Account>> EditAccount(int id, Account model)
        {
            var baseResponse = new BaseResponse<Account>();
            try
            {
                var account = await _accountRepository.GetAsync(id);
                if (account == null)
                {
                    baseResponse.StatusCode = StatusCode.AccountNotFound;
                    baseResponse.Description = "Account not found";
                    return baseResponse;
                }
                account.Purchases = model.Purchases;
                account.Password = model.Password;
                account.Role = model.Role;
                account.Username = model.Username;
                await _accountRepository.Update(account);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Account>()
                {
                    Description = $"[EditAccount] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<Account>> GetAccount(int id)
        {
            var baseResponse = new BaseResponse<Account>();
            try 
            {
                var account = await _accountRepository.GetAsync(id);
                if (account == null)
                {
                    baseResponse.Description = "Account not found";
                    baseResponse.StatusCode = StatusCode.AccountNotFound;
                    return baseResponse;
                }
                baseResponse.Data = account;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<Account>()
                {
                    Description = $"[GetAccount] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            };
        }

        public async Task<BaseResponse<Account>> GetAccountByLogin(string login)
        {
            var baseResponse = new BaseResponse<Account>();
            try
            {
                var account = await _accountRepository.GetByLoginAsync(login);
                if (account == null)
                {
                    baseResponse.Description = "Account not found";
                    baseResponse.StatusCode = StatusCode.AccountNotFound;
                    return baseResponse;
                }
                baseResponse.Data = account;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Account>()
                {
                    Description = $"[GetAccountByLogin] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<Account>>> GetAccounts()
        {
            var baseResponse = new BaseResponse<IEnumerable<Account>>();
            try
            {
                
                var accounts = await _accountRepository.SelectAsync();
                if (accounts.Count == 0)
                {
                    baseResponse.Data = accounts;
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = accounts;
                baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Account>>()
                {
                    Description = $"[GetAccounts] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var accounts = await _accountRepository.SelectAsync();
                Account? account = accounts.FirstOrDefault(x => x.Username == model.Name);
                if(account == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден",
                    };
                }
                if(account.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль",
                    };
                }
                var result = Authenticate(account);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = $"[Login] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        
        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                var accounts = await _accountRepository.SelectAsync();
                var account = accounts.FirstOrDefault(x => x.Username == model.Name);
                if(account != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Этот логин занят, попробуйте другой",
                    };
                }
                account = new Account()
                {
                    Username = model.Name,
                    Role = Role.User,
                    Password = HashPasswordHelper.HashPassword(model.Password),
                };
                await _accountRepository.CreateAsync(account);
                var result = Authenticate(account);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Пользователь успешно добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = $"[Registr] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        ClaimsIdentity Authenticate(Account account)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, account.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, account.Role.ToString())
            };
            return new ClaimsIdentity(claims,"ApplicationCookie", 
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
