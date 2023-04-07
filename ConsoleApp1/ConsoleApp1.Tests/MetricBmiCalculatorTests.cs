namespace ConsoleApp1.Tests;

public class MetricBmiCalculatorTests
{
    [Theory]
    [InlineData(0.1, 0.1, 100000)]
    [InlineData(1.0, 1.0, 10000)]
    [InlineData(60.0, 170.0, 20.76)]
    public void CalculateBmi_ForGivenWeightAndHeight_ReturnsCorrectBmi(double weight, double height, double bmiResult)
    {
        // arrange
        var metricBmiCalculator = new MetricBmiCalculator();

        // act 
        var result = metricBmiCalculator.CalculateBmi(weight, height);

        // assert

        Assert.Equal(bmiResult, result);
    }


    [Theory]
    [InlineData(0.0, 0.0)]
    [InlineData(-1.0, 0.0)]
    [InlineData(0.0, -1.0)]
    [InlineData(-1.0, -1.0)]
    public void CalculateBmi_ForWeightAndHeightBelowZero_ThrowsArgumentException(double weight, double height)
    {
        // arrange
        var metricBmiCalculator = new MetricBmiCalculator();

        // act 
        Action action = () => metricBmiCalculator.CalculateBmi(weight, height);

        // assert
        Assert.Throws<ArgumentException>(action);
    }
}