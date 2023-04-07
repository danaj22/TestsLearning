using FluentAssertions;
using Moq;

namespace ConsoleApp1.Tests;

public class BmiCalculatorFacadeTests
{
    private const string UNDERWEIGHT = "You are underweight, you should put on some weight";
    private const string NORMAL = "Your weight is normal, keep it up";
    private const string OVERWEIGHT = "You are a bit overweight";
    private const string OBESITY = "You should take care of your obesity";
    private const string EXTREME_OBESITY = "Your extreme obesity might cause health problems";
    
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
    
    [Theory]
    [InlineData(UnitSystem.Metric, 40.0, 170.0, 13.84, BmiClassification.Underweight)]
    [InlineData(UnitSystem.Metric, 60.0, 170.0, 20.76, BmiClassification.Normal)]
    [InlineData(UnitSystem.Metric, 80.0, 170.0, 27.68, BmiClassification.Overweight)]
    [InlineData(UnitSystem.Metric, 100.0, 170.0, 34.6, BmiClassification.Obesity)]
    [InlineData(UnitSystem.Metric, 0.1, 0.1, 100000, BmiClassification.ExtremeObesity)]
    public void GetResult_ForValidInput_ReturnsCorrectResult_Fluent(UnitSystem unitSystem, double weight, double height,
        double bmiResult, BmiClassification bmiClassification)
    {
        // arrange
        var bmiDeterminatorMock = new Mock<IBmiDeterminator>();
        bmiDeterminatorMock.Setup(m => m.DetermineBmi(It.IsAny<double>())).Returns(bmiClassification);
        
        var bmiCalculatorFacade = new BmiCalculatorFacade(unitSystem, bmiDeterminatorMock.Object);

        // act

        var result = bmiCalculatorFacade.GetResult(weight, height);

        // assert
        result.Bmi.Should().Be(bmiResult);
        result.BmiClassification.Should().Be(bmiClassification);
    }
    
    [Theory]
    [InlineData(BmiClassification.Underweight, UNDERWEIGHT)]
    [InlineData(BmiClassification.Normal, NORMAL)]
    [InlineData(BmiClassification.Overweight, OVERWEIGHT)]
    [InlineData(BmiClassification.Obesity, OBESITY)]
    [InlineData(BmiClassification.ExtremeObesity, EXTREME_OBESITY)]
    public void GetResult_ForValidInput_ReturnsCorrectSummary(BmiClassification bmiClassification, string expectedSummary)
    {
        // arrange
        var bmiDeterminatorMock = new Mock<IBmiDeterminator>();
        bmiDeterminatorMock.Setup(m => m.DetermineBmi(It.IsAny<double>())).Returns(bmiClassification);
        
        var bmiCalculatorFacade = new BmiCalculatorFacade(UnitSystem.Metric, bmiDeterminatorMock.Object);

        // act

        var result = bmiCalculatorFacade.GetResult(1, 1);

        // assert
        
        result.Summary.Should().Be(expectedSummary);
    }
}