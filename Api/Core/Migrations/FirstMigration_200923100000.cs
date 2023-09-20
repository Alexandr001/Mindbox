using FluentMigrator;

namespace Api.Core.Migrations;

[Migration(20230920100000)]
public class FirstMigrate_20230920100000 : Migration
{
	
	public override void Up()
	{
		
		Create.Table("Products")
		      .WithColumn("id").AsInt32().NotNullable().PrimaryKey()
		      .WithColumn("name").AsString(30).NotNullable();

		Create.Table("Categories")
		      .WithColumn("id").AsInt32().NotNullable().PrimaryKey()
		      .WithColumn("name").AsString(30).NotNullable();
		Create.Table("ProductCategory")
		      .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
		      .WithColumn("productId").AsInt32().ForeignKey("Products", "id")
		      .WithColumn("categoryId").AsInt32().ForeignKey("Categories", "id");

		Insert.IntoTable("Products")
		      .Row(new {Id = 1, Name = "apple"})
		      .Row(new {Id = 2, Name = "potato"})
		      .Row(new {Id = 3, Name = "carrot"})
		      .Row(new {Id = 4, Name = "banana"})
		      .Row(new {Id = 5, Name = "tomato"});
		Insert.IntoTable("Categories")
		      .Row(new {Id = 1, Name = "vegetables"})
		      .Row(new {Id = 2, Name = "fruits"})
		      .Row(new {Id = 3, Name = "fresh"})
		      .Row(new {Id = 4, Name = "not fresh"});
		Insert.IntoTable("ProductCategory")
		      .Row(new {ProductId = 1, CategoryId = 2})
		      .Row(new {ProductId = 1, CategoryId = 3})
		      .Row(new {ProductId = 2, CategoryId = 1})
		      .Row(new {ProductId = 2, CategoryId = 4})
		      .Row(new {ProductId = 3, CategoryId = 1})
		      .Row(new {ProductId = 3, CategoryId = 3})
		      .Row(new {ProductId = 4, CategoryId = 2})
		      .Row(new {ProductId = 4, CategoryId = 4});

	}

	public override void Down()
	{
		
	}
}