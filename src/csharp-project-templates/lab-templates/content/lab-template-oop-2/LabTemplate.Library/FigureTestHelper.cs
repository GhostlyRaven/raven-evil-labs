// ReSharper disable All

namespace LabTemplate.Library;

public static class FigureTestHelper
{
    public static TNumber CalculatePerimeter<TNumber>(bool is3DFigure, TNumber[] testData, ref uint eventCounter) where TNumber : INumber<TNumber>
    {
        // Выполнить расчет периметра для первой фигуры на основе входных данных.
        // Счетчик должен увеличиваться при каждом срабатывании событий. Каждое событие должно выполниться один раз.

        return TNumber.Zero;
    }

    public static TNumber CalculateSquare<TNumber>(bool is3DFigure, TNumber[] testData, ref uint eventCounter) where TNumber : INumber<TNumber>
    {
        // Выполнить расчет площади для первой фигуры на основе входных данных.
        // Счетчик должен увеличиваться при каждом срабатывании событий. Каждое событие должно выполниться один раз.

        return TNumber.Zero;
    }

    public static TNumber CalculateVolume<TNumber>(bool is3DFigure, TNumber[] testData, ref uint eventCounter) where TNumber : INumber<TNumber>
    {
        // Выполнить расчет объема для первой фигуры на основе входных данных.
        // Счетчик должен увеличиваться при каждом срабатывании событий. Каждое событие должно выполниться один раз.

        return TNumber.Zero;
    }
}
