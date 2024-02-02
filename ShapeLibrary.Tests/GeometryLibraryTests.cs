namespace ShapeLibrary.Tests;

/// <summary>
/// ����� ����-������ ��� ���������� �������������� �����.
/// </summary>
[TestFixture]
public class GeometryLibraryTests
{
	/// <summary>
	/// ����������� ��� ��������� ����������� � ��������� ������.
	/// </summary>
	private readonly double Delta = 0.001;

	/// <summary>
	/// ���� ���������� ������� �����.
	/// </summary>
	[Test]
	public void CircleAreaCalculation()
	{
		Circle circle = new Circle(1);
		double expectedArea = Math.PI;

		Assert.That(circle.CalculateArea(), Is.EqualTo(expectedArea).Within(Delta));
	}

	/// <summary>
	/// ���� ���������� ������� ������������.
	/// </summary>
	[Test]
	public void TriangleAreaCalculation()
	{
		Triangle triangle = new Triangle(3, 4, 5);
		double expectedArea = 6;

		Assert.That(triangle.CalculateArea(), Is.EqualTo(expectedArea).Within(Delta));
	}

	/// <summary>
	/// ���� ��������, �������� �� ����������� �������������.
	/// </summary>
	[Test]
	public void RightTriangleCheck()
	{
		Assert.That(Triangle.IsValidTriangle(3, 4, 5), Is.True);
		Assert.That(Triangle.IsValidTriangle(1, 2, 3), Is.False);
	}

	/// <summary>
	/// ���� ������������� DynamicAreaCalculator ��� ���������� ������� ��� ������ ���� ������.
	/// </summary>
	[Test]
	public void DynamicAreaCalculation()
	{
		IDynamicAreaCalculator dynamicAreaCalculator = new DynamicAreaCalculator();

		Circle circle = new Circle(1);
		double expectedCircleArea = Math.PI;
		Assert.That(dynamicAreaCalculator.CalculateArea(circle), Is.EqualTo(expectedCircleArea).Within(Delta));

		Triangle triangle = new Triangle(3, 4, 5);
		double expectedTriangleArea = 6;
		Assert.That(dynamicAreaCalculator.CalculateArea(triangle), Is.EqualTo(expectedTriangleArea).Within(Delta));
	}

	/// <summary>
	/// ���� ����������� ������ � ������������� �������� �����.
	/// </summary>
	[Test]
	public void NegativeRadiusCircleConstruction()
	{
		Assert.Throws<ArgumentException>(() => new Circle(-1));
	}

	/// <summary>
	/// ���� ����������� ������ � ������������� ���������� ������ ������������.
	/// </summary>
	[Test]
	public void InvalidTriangleConstruction()
	{
		Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 5));
	}

	/// <summary>
	/// ���� ����������� ������ � ������������� ��� ���������� ������� �����.
	/// </summary>
	[Test]
	public void OverflowCircleAreaCalculation()
	{
		Circle circle = new Circle(double.MaxValue);
		Assert.Throws<ArithmeticException>(() => circle.CalculateArea());
	}

	/// <summary>
	/// ���� ����������� ������ � ������������� ��� ���������� ������� ������������.
	/// </summary>
	[Test]
	public void OverflowTriangleAreaCalculation()
	{
		Triangle triangle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);
		Assert.Throws<ArithmeticException>(() => triangle.CalculateArea());
	}
}
