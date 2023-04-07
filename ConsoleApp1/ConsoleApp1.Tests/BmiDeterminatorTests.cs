namespace ConsoleApp1.Tests;

public class BmiDeterminatorTests
{
    [Theory]
    [InlineData(18.0, BmiClassification.Underweight)]
    [InlineData(24.0, BmiClassification.Normal)]
    [InlineData(29.0, BmiClassification.Overweight)]
    [InlineData(34.0, BmiClassification.Obesity)]
    [InlineData(50.0, BmiClassification.ExtremeObesity)]
    public void DetermineBmi_ForGivenBmi_ReturnsCorrectClassification(double bmiValue, BmiClassification classification)
    {
        // Arrange
        var bmiDeterminator = new BmiDeterminator();

        // Act
        var result = bmiDeterminator.DetermineBmi(bmiValue);
        
        // Assert
        Assert.Equal(classification, result);
    }
}