using Api.Repository;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MainController : ControllerBase
{
	

	private readonly ILogger<MainController> _logger;
	private readonly IProductRepository _repository;

	public MainController(ILogger<MainController> logger, IProductRepository repository)
	{
		_logger = logger;
		_repository = repository;
	}

	[HttpGet("allProducts")]
	public async Task<IActionResult> GetAllProducts()
	{
		try {
			List<Product> products = await _repository.GetAllProductsAsync();
			return Ok(products);
		} catch (Exception e) {
			_logger.LogError(e.Message);
			return BadRequest("Failed to get product data!");
		}
	}
	[HttpGet("allCategories")]
	public async Task<IActionResult> GetAllCategories()
	{
		try {
			List<Category> categories = await _repository.GetAllCategoriesAsync();
			return Ok(categories);
		} catch (Exception e) {
			_logger.LogError(e.Message);
			return BadRequest("Could not get data about categories!");
		}
	}
}