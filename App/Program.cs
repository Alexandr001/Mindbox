using Shapes;
using Shapes.Interfaces;

AbstractFigure figure1 = new Circle(5);
Console.WriteLine("Площадь круга: " + figure1.Square);
Console.WriteLine("Площадь круга (Не зная типа): " + AbstractFigure.GetSquare(figure1));

AbstractFigure figure2 = new Triangle(3, 4, 5);
Triangle triangle = figure2 as Triangle ?? 
                    throw new ArgumentException($"Failed to convert {typeof(AbstractFigure)} type to {typeof(Triangle)} type!");

string isRightTriangle = triangle.IsRightTriangle ? "Да" : "Нет";

Console.WriteLine("Треугольник прямоугольный? - " + isRightTriangle);
Console.WriteLine("Площадь треугольника: " + figure2.Square);
Console.WriteLine("Площадь треугольника (Не зная типа): " + AbstractFigure.GetSquare(figure2));

Console.ReadKey();