﻿using Services.Helpers;
using Services.Test.Data;

namespace Services.Test;

public class CreditCardValidationTest
{
    public static TheoryData<Card> Cards => TestData.Cards;

    [Theory]
    [MemberData(nameof(Cards))]
    public void IsValidLuhn_ShouldReturnTrueForValidLuhnNumbers(Card card)
    {
        // arrange - digits only
        var cardNumber = StringHelpers.DigitsOnly(card.CardNumber);
        
        // act
        var result = CreditCardValidation.IsValidLuhn(cardNumber);
        
        // assert
        Assert.True(result == card.Valid);
    }
    
    [Theory]
    [InlineData("4111 1111 1111 1111")]
    [InlineData("4111-1111-1111-1111")]
    public void IsValidLuhn_ShouldThrowExceptionIfCardContainsNonDigit(string cardNumber)
    {
        // assert
        Assert.Throws<ArgumentException>(() => CreditCardValidation.IsValidLuhn(cardNumber));
    }
}
