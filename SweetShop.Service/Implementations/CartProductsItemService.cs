using SweetShop.DAL.Repositories;
using SweetShop.Domain;
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
    public class CartProductsItemService
    {
        public readonly CartProductsItemRepository _cartProductsItemRepository;
        public CartProductsItemService(CartProductsItemRepository cartProductsItem)
        {
            _cartProductsItemRepository = cartProductsItem;
        }
        public async Task<BaseResponse<bool>> CreateCartProductsItem(int entityProduct, int count, int cartProductsId)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var entity = new CartProductItem()
                {
                    //Price = entityProduct.Price,
                    Count = count,
                    CartProductsId = cartProductsId,
                    ProductId = entityProduct,
                    //Product = entityProduct,
                    //проверить на CartProducts
                };
                await _cartProductsItemRepository.CreateAsync(entity);
                baseResponse.Data = true;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateCartProductItem] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<BaseResponse<bool>> DeleteCartProductsItem(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var product = await _cartProductsItemRepository.GetAsync(id);
                if (product == null)
                {
                    baseResponse.Description = "Product not found";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }
                await _cartProductsItemRepository.DeleteAsync(product);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCartProductsItem] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
