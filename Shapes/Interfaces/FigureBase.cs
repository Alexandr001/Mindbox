namespace Shapes.Interfaces;

public abstract class FigureBase
{
	public abstract double Square { get; }
	public static double GetSquare(FigureBase figureBase)
	{
		return figureBase.Square;
	}
}