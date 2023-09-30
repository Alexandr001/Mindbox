import pyspark.sql as ps


spark = ps.SparkSession.builder \
    .master("local[*]") \
    .appName("mindbox_sql_task") \
    .getOrCreate()

products = spark.read.csv("data/products.csv", header=True, inferSchema=True)
categories = spark.read.csv("data/categories.csv", header=True, inferSchema=True)
product_category = spark.read.csv("data/product_category.csv", header=True, inferSchema=True)

# products.join(product_category, product_category["product_id"] == products["id"], "left") \
#     .join(categories, categories["id"] == product_category["category_id"], "left") \
#     .select([products["name"], categories["name"]]) \
#     .show()

products.createTempView("products")
categories.createTempView("categories")
product_category.createTempView("product_category")

spark.sql("""SELECT P.name AS product_name, C.name AS categories_name FROM products P
            LEFT JOIN product_category PC ON PC.product_id = P.id 
            LEFT JOIN categories C ON C.id = PC.category_id""") \
    .show()

spark.sparkContext.stop()
