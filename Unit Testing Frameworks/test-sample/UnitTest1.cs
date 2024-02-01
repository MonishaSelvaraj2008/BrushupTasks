
using System;
using Xunit;
namespace test_sample{
public class AddNumbersTests
{
    [Fact]
    public void Sum_ValidInput_ReturnsSum()
    {
        // Arrange
        int numberOne = 5;
        int numberTwo = 7;

        // Act
        int result = AddNumbers.Sum(numberOne, numberTwo);

        // Assert
        Assert.Equal(numberOne + numberTwo, result);
    }

    [Fact]
    public void Sum_NegativeNumbers_ReturnsSum()
    {
        // Arrange
        int numberOne = -5;
        int numberTwo = -7;

        // Act
        int result = AddNumbers.Sum(numberOne, numberTwo);

        // Assert
        Assert.Equal(numberOne + numberTwo, result);
    }

    [Fact]
    public void Sum_ZeroAndPositiveNumber_ReturnsSum()
    {
        // Arrange
        int numberOne = 0;
        int numberTwo = 10;

        // Act
        int result = AddNumbers.Sum(numberOne, numberTwo);

        // Assert
        Assert.Equal(numberOne + numberTwo, result);
    }

    [Fact]
    public void Sum_ZeroAndNegativeNumber_ReturnsSum()
    {
        // Arrange
        int numberOne = 0;
        int numberTwo = -10;

        // Act
        int result = AddNumbers.Sum(numberOne, numberTwo);

        // Assert
        Assert.Equal(numberOne + numberTwo, result);
    }
    [Fact]
public void Sum_TwentyAndOne_ReturnsTwentyOne()
{
    // Arrange
    int numberOne = 20;
    int numberTwo = 1;

    // Act
    int result = AddNumbers.Sum(numberOne, numberTwo);

    // Assert
    Assert.Equal(21, result);
}


}
}