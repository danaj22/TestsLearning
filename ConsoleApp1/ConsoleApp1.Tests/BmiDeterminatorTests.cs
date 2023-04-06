namespace ConsoleApp1.Tests;

public class BmiDeterminatorTests
{
    [Theory]
    [InlineData(10.0)]
    [InlineData(15.0)]
    [InlineData(18.0)]
    public void DetermineBmi_ForBmiBelow18_5_ReturnsUnderweight(double bmiValue)
    {
        // Arrange
        var bmiDeterminator = new BmiDeterminator();

        // Act
        var result = bmiDeterminator.DetermineBmi(bmiValue);
        
        // Assert
        Assert.Equal(BmiClassification.Underweight, result);
    }
    
    [Fact]
    public void DetermineBmi_ForBmiBelow24_5_ReturnsNormal()
    {
        // Arrange
        var bmiDeterminator = new BmiDeterminator();
        var bmiValue = 24.0;

        // Act
        var result = bmiDeterminator.DetermineBmi(bmiValue);
        
        // Assert
        Assert.Equal(BmiClassification.Normal, result);
    }
    
    [Fact]
    public void DetermineBmi_ForBmiBelow29_5_ReturnsOverweght()
    {
        // Arrange
        var bmiDeterminator = new BmiDeterminator();
        var bmiValue = 29.0;

        // Act
        var result = bmiDeterminator.DetermineBmi(bmiValue);
        
        // Assert
        Assert.Equal(BmiClassification.Overweight, result);
    }
    
    [Fact]
    public void DetermineBmi_ForBmiBelow34_5_ReturnsObesity()
    {
        // Arrange
        var bmiDeterminator = new BmiDeterminator();
        var bmiValue = 34.0;

        // Act
        var result = bmiDeterminator.DetermineBmi(bmiValue);
        
        // Assert
        Assert.Equal(BmiClassification.Obesity, result);
    }
    
    [Fact]
    public void DetermineBmi_ForBmiAbove34_5_ReturnsExtremeObesity()
    {
        // Arrange
        var bmiDeterminator = new BmiDeterminator();
        var bmiValue = 35.0;

        // Act
        var result = bmiDeterminator.DetermineBmi(bmiValue);
        
        // Assert
        Assert.Equal(BmiClassification.ExtremeObesity, result);
    }
}