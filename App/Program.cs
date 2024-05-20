using Shapes;
using Shapes.Interfaces;

FigureBase figure1 = new Circle(5);
Console.WriteLine("Площадь круга: " + figure1.Square);
Console.WriteLine("Площадь круга (Не зная типа): " + FigureBase.GetSquare(figure1));

FigureBase figure2 = new Triangle(3, 4, 5);
Triangle triangle = figure2 as Triangle ?? 
                    throw new ArgumentException($"Failed to convert {typeof(FigureBase)} type to {typeof(Triangle)} type!");

string isRightTriangle = triangle.IsRightTriangle ? "Да" : "Нет";

Console.WriteLine("Треугольник прямоугольный? - " + isRightTriangle);
Console.WriteLine("Площадь треугольника: " + figure2.Square);
Console.WriteLine("Площадь треугольника (Не зная типа): " + FigureBase.GetSquare(figure2));

Console.ReadKey();

/*
SELECT P.name AS product_name, C.name AS categories_name FROM products P
LEFT JOIN product_category PC ON PC.product_id = P.id 
LEFT JOIN categories C ON C.id = PC.category_id
*/