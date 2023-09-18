// ReSharper disable All

namespace LabTemplate.Tests;

[TestCaseOrderer(XunitOrderer.OrdererTypeName, XunitOrderer.OrdererAssemblyName)]
public sealed class CircleAndPyramid
{
    [InlineData(false, new double[] { 0, -2, -2, -2 })]     // OK - throw new ArgumentOutOfRangeException();
    [InlineData(false, new double[] { 6, 2, 2, 2 })]        // OK;
    [InlineData(true, new double[] { 0, -2, -2 })]          // OK - throw new ArgumentOutOfRangeException();
    [InlineData(true, new double[] { 12.56, 2, 2 })]        // OK;
    [Theory, XunitOrdererFact(1)]
    public static void CalculatePerimeter(bool is3DFigure, double[] testData)
    {
        double result;
        uint counter = 0;

        try
        {
            result = FigureTestHelper.CalculatePerimeter(is3DFigure, testData[1..], ref counter);
        }
        catch (InvalidOperationException)
        {
            return;
        }
        catch (ArgumentOutOfRangeException)
        {
            return;
        }
        catch (Exception error)
        {
            Assert.Fail($"Внимательно читаем сообщение об ошибке. Сообщение: «{error.Message}»");

            return;
        }

        Assert.True(counter > 0, "Значение счётчика должно быть больше нуля.");

        Assert.Equal(testData[0], result);
    }

    [InlineData(false, new double[] { 0, -2, -2, -2 })]     // OK - throw new ArgumentOutOfRangeException();
    [InlineData(false, new double[] { 1.732, 2, 2, 2 })]    // OK;
    [InlineData(true, new double[] { 0, -2, -2 })]          // OK - throw new ArgumentOutOfRangeException();
    [InlineData(true, new double[] { 12.56, 2, 2 })]        // OK;
    [Theory, XunitOrdererFact(2)]
    public static void CalculateSquare(bool is3DFigure, double[] testData)
    {
        double result;
        uint counter = 0;

        try
        {
            result = FigureTestHelper.CalculateSquare(is3DFigure, testData[1..], ref counter);
        }
        catch (InvalidOperationException)
        {
            return;
        }
        catch (ArgumentOutOfRangeException)
        {
            return;
        }
        catch (Exception error)
        {
            Assert.Fail($"Внимательно читаем сообщение об ошибке. Сообщение: «{error.Message}»");

            return;
        }

        Assert.True(counter > 0, "Значение счётчика должно быть больше нуля.");

        Assert.Equal(testData[0], result);
    }

    [InlineData(false, new double[] { 0, -2, -2, -2 })]     // OK - throw new ArgumentOutOfRangeException();
    [InlineData(false, new double[] { 0, 2, 2, 2 })]        // OK - throw new InvalidOperationException();
    [InlineData(true, new double[] { 0, -2, -2 })]          // OK - throw new ArgumentOutOfRangeException();
    [InlineData(true, new double[] { 8.377, 2, 2 })]        // OK;
    [Theory, XunitOrdererFact(3)]
    public static void CalculateVolume(bool is3DFigure, double[] testData)
    {
        double result;
        uint counter = 0;

        try
        {
            result = FigureTestHelper.CalculateVolume(is3DFigure, testData[1..], ref counter);
        }
        catch (InvalidOperationException)
        {
            return;
        }
        catch (ArgumentOutOfRangeException)
        {
            return;
        }
        catch (Exception error)
        {
            Assert.Fail($"Внимательно читаем сообщение об ошибке. Сообщение: «{error.Message}»");

            return;
        }

        Assert.True(counter > 0, "Значение счётчика должно быть больше нуля.");

        Assert.Equal(testData[0], result);
    }
}
