using App.Models;

namespace Api.Repository;

public interface IProductRepository
{
	Task<List<Product>> GetAllProductsAsync();
	Task<List<Category>> GetAllCategoriesAsync();
}