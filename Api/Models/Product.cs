namespace App.Models;

public class Product
{
	public int Id { get; set; }
	public string Name { get; set; }
	public List<Category> Categories { get; set; } = new();
}

public class Category
{
	public int Id { get; set; }
	public string Name { get; set; }
	public List<Product> Products { get; set; } = new();
}