using Shapes.Interfaces;

namespace Shapes;

public class Triangle : AbstractFigure
{
	private readonly uint _a; 
	private readonly uint _b; 
	private readonly uint _c;

	public Triangle(uint a, uint b, uint c)
	{
		if (IsExist(a, b, c) == false) {
			throw new ArgumentException($"A triangle with sides {_a}, {_b}, {_c} cannot exist!");
		}
		_c = c;
		_b = b;
		_a = a;
	}

	public override double Square
	{
		get
		{
			double p = (_a + _b + _c) / 2d;
			return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
		}
	}
	public bool IsRightTriangle
	{
		get
		{
			return (_a * _a + _b * _b == _c * _c) 
			       || (_a * _a + _c * _c == _b * _b) 
			       || (_c * _c + _b * _b == _a * _a);
		}
	}

	private bool IsExist(uint a, uint b, uint c)
	{
		return a + b > c && 
		       b + c > a && 
		       c + a > b && 
		       a != 0 && b != 0 && c != 0;
	}
}