namespace ConsoleApp1.Tests;

public class BmiCalculatorFacadeTests
{
    [Theory]
    [InlineData(UnitSystem.Metric, 40.0, 170.0, 13.84, BmiClassification.Underweight)]
    [InlineData(UnitSystem.Metric, 60.0, 170.0, 20.76, BmiClassification.Normal)]
    [InlineData(UnitSystem.Metric, 80.0, 170.0, 27.68, BmiClassification.Overweight)]
    [InlineData(UnitSystem.Metric, 100.0, 170.0, 34.6, BmiClassification.Obesity)]
    [InlineData(UnitSystem.Metric, 0.1, 0.1, 100000, BmiClassification.ExtremeObesity)]
    public void GetResult_ForValidInput_ReturnsCorrectResult(UnitSystem unitSystem, double weight, double height,
        double bmiResult, BmiClassification bmiClassification)
    {
        // arrange

        var bmiCalculatorFacade = new BmiCalculatorFacade(unitSystem, new BmiDeterminator());

        // act

        var result = bmiCalculatorFacade.GetResult(weight, height);

        // assert

        Assert.Equal(bmiResult, result.Bmi);
        Assert.Equal(bmiClassification, result.BmiClassification);
    }
}