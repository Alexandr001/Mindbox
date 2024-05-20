using Shapes.Interfaces;

namespace Shapes;

public class Circle : FigureBase
{
	private readonly uint _radius;

	public Circle(uint radius)
	{
		if (IsExist(radius) == false) {
			throw new ArgumentException("The radius cannot be equal to 0!");
		}
		_radius = radius;
	}

	public override double Square
	{
		get
		{
			return Math.PI * _radius * _radius;
		}
	}

	private bool IsExist(uint radius)
	{
		return radius != 0;
	}
}