using SweetShop.DAL.Interfaces;
using SweetShop.Domain;
using SweetShop.Domain.Enums;
using SweetShop.Domain.Responses;
using SweetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Service.Implementations
{
	public class ProductService : IProductService
	{
		public readonly IProductRepository _productRepository;
		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<BaseResponse<Product>> GetProduct(int id)
		{
			var baseResponse = new BaseResponse<Product>();
			try
			{
				var product = await _productRepository.GetAsync(id);
				if(product == null)
				{
					baseResponse.Description = "Product not found";
					baseResponse.StatusCode = StatusCode.ProductNotFound;
					return baseResponse;
				}
				baseResponse.Data = product;
				baseResponse.Description = product.Description;
				baseResponse.StatusCode = StatusCode.OK;
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Product>()
				{
					Description = $"[GetProduct] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<Product>> GetProductByName(string name)
		{
			var baseResponse = new BaseResponse<Product>();
			try
			{
				var product = await _productRepository.GetByNameAsync(name);
				if (product == null)
				{
					baseResponse.Description = "Product not found";
					baseResponse.StatusCode = StatusCode.ProductNotFound;
					return baseResponse;
				}
				baseResponse.Data = product;
				baseResponse.StatusCode = StatusCode.OK;
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Product>()
				{
					Description = $"[GetProductByName] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<IEnumerable<Product>>> GetProducts()
		{
			var baseResponse = new BaseResponse<IEnumerable<Product>>();
			try
			{
				var products = await _productRepository.SelectAsync();
				if(products.Count == 0)
				{
					baseResponse.Data = products;
					baseResponse.Description = "Найдено 0 элементов";
					baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
					return baseResponse;
				}
				baseResponse.Data = products;
				baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<IEnumerable<Product>>()
				{
					Description = $"[GetProducts] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<bool>> CreateProduct(Product model)
		{
			var baseResponse = new BaseResponse<bool>();
			try
			{
				var product = new Product() 
				{ 
					Name = model.Name,
					Description = model.Description,
					Weight = model.Weight,
					Price = model.Price					
				};
				await _productRepository.CreateAsync(product);
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>()
				{
					Description = $"[CreateProduct] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<bool>> DeleteProduct(int id)
		{
			var baseResponse = new BaseResponse<bool>();
			try
			{
				var product = await _productRepository.GetAsync(id);
				if(product == null)
				{
					baseResponse.Description = "Product not found";
					baseResponse.StatusCode = StatusCode.ProductNotFound;
					return baseResponse;
				}
				await _productRepository.DeleteAsync(product);
				return baseResponse;
			}
			catch(Exception ex)
			{
				return new BaseResponse<bool>()
				{
					Description = $"[GetProducts] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}


		public async Task<BaseResponse<Product>> EditProduct(int id, Product model)
		{
			var baseResponse = new BaseResponse<Product>();
			try
			{
				var product = await _productRepository.GetAsync(id);
				if(product == null)
				{
					baseResponse.StatusCode = StatusCode.ProductNotFound;
					baseResponse.Description = "Product not found";
					return baseResponse;
				}
				product.Description = model.Description;
				product.Price = model.Price;
				product.Weight = model.Weight;
				product.Name = model.Name;
				await _productRepository.Update(product);
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Product>()
				{
					Description = $"[EditProduct] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}
	}
}
