using SweetShop.DAL.Repositories;
using SweetShop.Domain.Entities;
using SweetShop.Domain.Enums;
using SweetShop.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Service.Implementations
{
    public class CartProductsService
    {
        readonly CartProductsRepository _cartProductsRepository;
        public CartProductsService(CartProductsRepository cartProductsRepository)
        {
            _cartProductsRepository = cartProductsRepository;
        }
		public async Task<BaseResponse<CartProducts>> GetCart(int id)
		{
			var baseResponse = new BaseResponse<CartProducts>();
			try
			{
				var cartProducts = await _cartProductsRepository.GetCart(id);
				if (cartProducts == null)
				{
					baseResponse.Description = "CartProducts not found";
					baseResponse.StatusCode = StatusCode.CartProductsNotFound;
					return baseResponse;
				}
				baseResponse.Data = cartProducts;
				baseResponse.StatusCode = StatusCode.OK;
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<CartProducts>()
				{
					Description = $"[GetCart] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}
	}
}
