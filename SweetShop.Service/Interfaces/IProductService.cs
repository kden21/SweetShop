using SweetShop.Domain;
using SweetShop.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Service.Interfaces
{
	public interface IProductService
	{
		Task<BaseResponse<IEnumerable<Product>>> GetProducts();
		Task<BaseResponse<Product>> GetProduct(int id);
		Task<BaseResponse<bool>> CreateProduct(Product product);
		Task<BaseResponse<bool>> DeleteProduct(int id);
		Task<BaseResponse<Product>> GetProductByName(string name);
		Task<BaseResponse<Product>> EditProduct(int id, Product model);
	}
}
