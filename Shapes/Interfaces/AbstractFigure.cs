namespace Shapes.Interfaces;

public abstract class AbstractFigure
{
	public abstract double Square { get; }
	public static double GetSquare(AbstractFigure figure)
	{
		return figure.Square;
	}
}