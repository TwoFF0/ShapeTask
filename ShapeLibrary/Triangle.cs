namespace ShapeLibrary;

/// <summary>
/// Класс для треугольника.
/// </summary>
public class Triangle : IShape
{
	/// <summary>
	/// Длина стороны A.
	/// </summary>
	public double SideA { get; }

	/// <summary>
	/// Длина стороны B.
	/// </summary>
	public double SideB { get; }

	/// <summary>
	/// Длина стороны C.
	/// </summary>
	public double SideC { get; }

	/// <summary>
	/// Конструктор треугольника.
	/// </summary>
	/// <param name="sideA">Длина стороны A. Должна быть положительным числом.</param>
	/// <param name="sideB">Длина стороны B. Должна быть положительным числом.</param>
	/// <param name="sideC">Длина стороны C. Должна быть положительным числом.</param>
	/// <exception cref="ArgumentException">
	/// Выбрасывается при некорректных значениях сторон треугольника.
	/// </exception>
	public Triangle(double sideA, double sideB, double sideC)
	{
		if (sideA <= 0 || sideB <= 0 || sideC <= 0 || !IsValidTriangle(sideA, sideB, sideC))
		{
			throw new ArgumentException(
				"Некорректные значения сторон треугольника. Значения должны быть положительными и соответствовать условиям построения треугольника.",
				nameof(sideA) + ", " + nameof(sideB) + ", " + nameof(sideC));
		}

		SideA = sideA;
		SideB = sideB;
		SideC = sideC;
	}

	/// <inheritdoc />
	public double CalculateArea()
	{
		double s = (SideA + SideB + SideC) / 2;

		if (s >= double.MaxValue || s - SideA >= double.MaxValue || s - SideB >= double.MaxValue || s - SideC >= double.MaxValue)
		{
			throw new ArithmeticException("Ошибка при вычислении площади треугольника. Проверьте значения сторон.");
		}

		try
		{
			return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
		}
		catch (OverflowException ex)
		{
			throw new ArithmeticException("Ошибка при вычислении площади треугольника. Проверьте значения сторон.", ex);
		}
	}

	/// <summary>
	/// Проверяет, являются ли значения сторон корректными для построения треугольника.
	/// </summary>
	public static bool IsValidTriangle(double sideA, double sideB, double sideC)
	{
		return sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA;
	}
}