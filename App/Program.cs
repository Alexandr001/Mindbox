using Shapes;
using Shapes.Interfaces;

/*Для задания с бд нужно создать категории: фрукты, овощи, свежие, просроченные И добавить к */


AbstractFigure figure1 = new Circle(5);
double figureSquare1 = figure1.Square;
double squareByType1 = AbstractFigure.GetSquare(figure1);

AbstractFigure figure2 = new Triangle(3, 4, 5);
Triangle triangle = figure2 as Triangle ?? 
                    throw new ArgumentException($"Failed to convert {typeof(AbstractFigure)} type to {typeof(Triangle)} type!");
bool triangleIsRightTriangle = triangle.IsRightTriangle;
double triangleSquare = triangle.Square;
double square = AbstractFigure.GetSquare(triangle);