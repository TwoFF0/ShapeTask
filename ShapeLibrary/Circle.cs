namespace ShapeLibrary;

/// <summary>
/// Класс для круга.
/// </summary>
public class Circle : IShape
{
	/// <summary>
	/// Радиус круга.
	/// </summary>
	public double Radius { get; }

	/// <summary>
	/// Конструктор круга.
	/// </summary>
	/// <param name="radius">Радиус круга. Должен быть положительным числом.</param>
	/// <exception cref="ArgumentException">Выбрасывается при некорректном значении радиуса.</exception>
	public Circle(double radius)
	{
		if (radius <= 0)
			throw new ArgumentException("Радиус должен быть положительным числом.", nameof(radius));

		Radius = radius;
	}

	/// <inheritdoc />
	public double CalculateArea()
	{
		if (Math.Abs(Radius) >= Math.Sqrt(double.MaxValue / Math.PI))
		{
			throw new ArithmeticException("Ошибка при вычислении площади круга. Проверьте значение радиуса.");
		}

		return Math.PI * Math.Pow(Radius, 2);
	}
}