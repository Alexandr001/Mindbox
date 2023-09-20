namespace Shapes.Tests;

public class TriangleTest
{
	[Theory]
	[InlineData(2, 2, 5)]
	[InlineData(1, 0, 1)]
	public void TriangleCreate_ResultError_Test(uint a, uint b, uint c)
	{
		Assert.Throws<ArgumentException>(() => {
			Triangle triangle = new(a, b, c);
		});
	}
	
	[Theory]
	[InlineData(3, 4, 5)]
	[InlineData(1, 1, 1)]
	public void TriangleCreate_ResultSuccess_Test(uint a, uint b, uint c)
	{
		Triangle triangle = new(a, b, c);
		Assert.NotNull(triangle);
	}
	
	[Theory]
	[InlineData(3, 4, 5, true)]
	[InlineData(6, 7, 8, false)]
	public void IsRightTriangle_Test(uint a, uint b, uint c, bool result)
	{
		Triangle triangle = new(a, b, c);
		Assert.Equal(result, triangle.IsRightTriangle);
	}
	
	
	[Theory]
	[InlineData(3, 4, 5, 6)]
	[InlineData(6, 7, 8, 20.33)]
	public void SquareTriangle_Test(uint a, uint b, uint c, double result)
	{
		Triangle triangle = new(a, b, c);
		Assert.Equal(result, Math.Round(triangle.Square, 2));
	}
}