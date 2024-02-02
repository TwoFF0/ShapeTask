namespace ShapeLibrary;

/// <summary>
/// Интерфейс для вычисления площади фигуры без знания типа фигуры в compile-time.
/// </summary>
public interface IDynamicAreaCalculator
{
    /// <summary>
    /// Метод для вычисления площади фигуры без знания типа фигуры в compile-time.
    /// </summary>
    /// <typeparam name="T">Тип фигуры, реализующей интерфейс IShape.</typeparam>
    /// <param name="shape">Фигура.</param>
    /// <returns>Площадь фигуры.</returns>
    double CalculateArea<T>(T shape) where T : IShape;
}