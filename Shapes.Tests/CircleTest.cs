namespace Shapes.Tests;

public class CircleTest
{
	[Theory]
	[InlineData(0)]
	public void CircleCreate_ResultError_Test(uint radius)
	{
		Assert.Throws<ArgumentException>(() => {
			Circle circle = new(radius);
		});
	}
	
	[Theory]
	[InlineData(3)]
	[InlineData(1)]
	public void CircleCreate_ResultSuccess_Test(uint radius)
	{
		Circle circle = new(radius);
		Assert.NotNull(circle);
	}
	
	[Theory]
	[InlineData(3, 28.27)]
	[InlineData(6, 113.10)]
	public void SquareCircle_Test(uint radius, double result)
	{
		Circle circle = new(radius);
		Assert.Equal(result, Math.Round(circle.Square, 2));
	}
}