namespace ShapeLibrary.Tests;

/// <summary>
/// Набор юнит-тестов для библиотеки геометрических фигур.
/// </summary>
[TestFixture]
public class GeometryLibraryTests
{
	/// <summary>
	/// Погрешность для сравнения результатов с плавающей точкой.
	/// </summary>
	private readonly double Delta = 0.001;

	/// <summary>
	/// Тест вычисления площади круга.
	/// </summary>
	[Test]
	public void CircleAreaCalculation()
	{
		Circle circle = new Circle(1);
		double expectedArea = Math.PI;

		Assert.That(circle.CalculateArea(), Is.EqualTo(expectedArea).Within(Delta));
	}

	/// <summary>
	/// Тест вычисления площади треугольника.
	/// </summary>
	[Test]
	public void TriangleAreaCalculation()
	{
		Triangle triangle = new Triangle(3, 4, 5);
		double expectedArea = 6;

		Assert.That(triangle.CalculateArea(), Is.EqualTo(expectedArea).Within(Delta));
	}

	/// <summary>
	/// Тест проверки, является ли треугольник прямоугольным.
	/// </summary>
	[Test]
	public void RightTriangleCheck()
	{
		Assert.That(Triangle.IsValidTriangle(3, 4, 5), Is.True);
		Assert.That(Triangle.IsValidTriangle(1, 2, 3), Is.False);
	}

	/// <summary>
	/// Тест использования DynamicAreaCalculator для вычисления площади без знания типа фигуры.
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
	/// Тест негативного случая с отрицательным радиусом круга.
	/// </summary>
	[Test]
	public void NegativeRadiusCircleConstruction()
	{
		Assert.Throws<ArgumentException>(() => new Circle(-1));
	}

	/// <summary>
	/// Тест негативного случая с некорректными значениями сторон треугольника.
	/// </summary>
	[Test]
	public void InvalidTriangleConstruction()
	{
		Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 5));
	}

	/// <summary>
	/// Тест негативного случая с переполнением при вычислении площади круга.
	/// </summary>
	[Test]
	public void OverflowCircleAreaCalculation()
	{
		Circle circle = new Circle(double.MaxValue);
		Assert.Throws<ArithmeticException>(() => circle.CalculateArea());
	}

	/// <summary>
	/// Тест негативного случая с переполнением при вычислении площади треугольника.
	/// </summary>
	[Test]
	public void OverflowTriangleAreaCalculation()
	{
		Triangle triangle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);
		Assert.Throws<ArithmeticException>(() => triangle.CalculateArea());
	}
}
