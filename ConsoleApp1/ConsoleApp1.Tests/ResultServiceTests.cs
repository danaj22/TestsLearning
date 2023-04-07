using FluentAssertions;
using Moq;

namespace ConsoleApp1.Tests;

public class ResultServiceTests
{
    [Fact]
    public void SetRecentOverweightResult_GivenOverweight_SetRecentOverweightResult()
    {
        var resultRepositoryMock = new Mock<IResultRepository>();


        var resultService = new ResultService(resultRepositoryMock.Object);
        
        resultService.SetRecentOverweightResult(new BmiResult(){BmiClassification = BmiClassification.Overweight});
        
        resultService.RecentOverweightResult.BmiClassification.Should().Be(BmiClassification.Overweight);
    }
    
    [Theory]
    [InlineData(BmiClassification.Normal)]
    [InlineData(BmiClassification.Underweight)]
    [InlineData(BmiClassification.Obesity)]
    [InlineData(BmiClassification.ExtremeObesity)]
    public void SetRecentOverweightResult_ForNotOverweight_NotSetRecentOverweightResult(BmiClassification bmiClassification)
    {
        var resultRepositoryMock = new Mock<IResultRepository>();

        var resultService = new ResultService(resultRepositoryMock.Object);
        
        resultService.SetRecentOverweightResult(new BmiResult(){BmiClassification = bmiClassification});

        resultService.RecentOverweightResult.Should().BeNull();
    }
        
    [Theory]
    [InlineData(BmiClassification.Normal)]
    [InlineData(BmiClassification.Overweight)]
    [InlineData(BmiClassification.Obesity)]
    [InlineData(BmiClassification.ExtremeObesity)]
    public async Task SaveUnderweightResultAsync_ForNotUnderweightResult_DoesNotInvokeSaveResultAsync(BmiClassification bmiClassification)
    {
        var result = new BmiResult() { BmiClassification = bmiClassification };
        
        var resultRepositoryMock = new Mock<IResultRepository>();

        var resultService = new ResultService(resultRepositoryMock.Object);
        
        await resultService.SaveUnderweightResultAsync(result);
        
        resultRepositoryMock.Verify(x => x.SaveResultAsync(result), Times.Never);
    }
    
    [Fact]
    public async Task SaveUnderweightResultAsync_ForUnderweightResult_InvokesSaveResultAsync()
    {
        var result = new BmiResult() { BmiClassification = BmiClassification.Underweight };
        var resultRepositoryMock = new Mock<IResultRepository>();

        var resultService = new ResultService(resultRepositoryMock.Object);
        
        await resultService.SaveUnderweightResultAsync(result);

        resultRepositoryMock.Verify( x => x.SaveResultAsync(result), Times.Once);
    }
}