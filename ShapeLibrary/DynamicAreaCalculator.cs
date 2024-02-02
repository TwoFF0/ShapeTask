namespace ShapeLibrary;

/// <summary>
/// Реализация интерфейса IDynamicAreaCalculator.
/// </summary>
public class DynamicAreaCalculator : IDynamicAreaCalculator
{
	/// <inheritdoc />
	public double CalculateArea<T>(T shape) where T : IShape
	{
		try
		{
			return shape.CalculateArea();
		}
		catch (Exception ex) when (ex is ArgumentException || ex is ArithmeticException)
		{
			// Логирование или обработка исключения по необходимости
			throw;
		}
		catch (Exception ex)
		{
			throw new Exception("Произошла ошибка при вычислении площади фигуры.", ex);
		}
	}
}