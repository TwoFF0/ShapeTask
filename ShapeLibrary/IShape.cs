namespace ShapeLibrary;

/// <summary>
/// Интерфейс для всех фигур.
/// </summary>
public interface IShape
{
    /// <summary>
    /// Метод для вычисления площади фигуры.
    /// </summary>
    /// <returns>Площадь фигуры.</returns>
    double CalculateArea();
}