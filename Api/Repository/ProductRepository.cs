using System.Data;
using Api.Repository.Core;
using App.Models;
using Dapper;

namespace Api.Repository;

/*
Запрос на получение названия товара - названия категории
SELECT P.name, C.name FROM Products P 
LEFT JOIN ProductCategory PC ON PC.productId = P.id
LEFT JOIN Categories C ON PC.categoryId = C.id
*/

public class ProductRepository : IProductRepository
{
	private readonly DbContext _connection;

	public ProductRepository(DbContext connection)
	{
		_connection = connection;
	}
	public async Task<List<Product>> GetAllProductsAsync()
	{
		const string SQL = "SELECT P.id, P.name, C.id, C.name FROM Products P " + 
		                   "LEFT JOIN ProductCategory PC ON PC.productId = P.id " + 
		                   "LEFT JOIN Categories C ON PC.categoryId = C.id";

		using IDbConnection connect = _connection.CreateConnect();
		IEnumerable<Product> queryAsync = await connect.QueryAsync<Product>("SELECT * FROM Products");
		IEnumerable<Product> products = await connect.QueryAsync<Product, Category, Product>(SQL, (product, category) => {
			product.Categories.Add(category);
			return product;
		});
		return GroupProduct(products);
	}
	public async Task<List<Category>> GetAllCategoriesAsync()
	{
		const string SQL = "SELECT C.id, C.name, P.id, P.name FROM Categories C " + 
		                   "LEFT JOIN ProductCategory PC ON PC.productId = C.id " + 
		                   "LEFT JOIN Products P ON PC.categoryId = P.id";
		
		using IDbConnection connect = _connection.CreateConnect();
		IEnumerable<Category> categories = await connect.QueryAsync<Category, Product, Category>(SQL, (category, product) => {
			category.Products.Add(product);
			return category;
		});
		return GroupCategory(categories);
	}
	
	private List<Product> GroupProduct(IEnumerable<Product> products)
	{
		return products.GroupBy(o => o.Id)
		               .Select(g => {
			               Product groupedProduct = g.First();
			               groupedProduct.Categories = g.Select(p => {
				                                            Category cat = p.Categories.Single();
				                                            return cat;
			                                            })
			                                            .ToList();
			               return groupedProduct;
		               }).ToList();
	}
	private List<Category> GroupCategory(IEnumerable<Category> categories)
	{
		return categories.GroupBy(o => o.Id)
		                 .Select(g => {
			                 Category groupedCategory = g.First();
			                 groupedCategory.Products = g.Select(p => {
				                                             Product prod = p.Products.Single();
				                                             return prod;
			                                             })
			                                             .ToList();
			                 return groupedCategory;
		                 }).ToList();
	}
}