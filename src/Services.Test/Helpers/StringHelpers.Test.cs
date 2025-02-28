using Services.Helpers;

namespace Services.Test.Helpers;

public class StringHelpersTest
{
    [Theory]
    [InlineData("4111 1111 1111 1111")]
    [InlineData("4111-1111-1111-1111")]
    [InlineData("x4111-1111-1111-1111x")]
    public void DigitsOnly_ShouldOnlyReturnDigits(string cardNumber)
    {
        // arrange
        var expectedResult = "4111111111111111";
        
        // asert
        Assert.Equal(expectedResult, StringHelpers.DigitsOnly(cardNumber));
        
        // assert
        Assert.Throws<ArgumentException>(() => CreditCardValidation.IsValidLuhn(cardNumber));
    }
}