using System.Text.RegularExpressions;

namespace Services;

public static partial class CreditCardValidation
{
    // Convert to int.
    private static readonly Func<char, int> CharToInt = c => c - '0';

    private static readonly Func<int, bool> IsEven = i => i % 2 == 0;
    
    private static readonly Func<int, int> DoubleDigit = i => (i * 2).ToString().ToCharArray().Select(CharToInt).Sum();
    
    
    [GeneratedRegex(@"^\d+$")]
    private static partial Regex NumbersOnlyRegex();
    
    /// <summary>
    /// Checks that the card number passed in, passes luhn validation
    /// </summary>
    /// <param name="creditCardNumber">string</param>
    /// <returns>bool</returns>
    /// <exception cref="ArgumentException">expect creditCardNumber to only contain digits</exception>
    public static bool IsValidLuhn(string creditCardNumber)
    {
        if (!NumbersOnlyRegex().IsMatch(creditCardNumber))
        {
            throw new ArgumentException("creditCardNumber should only contain digits: ^\\d+$");
        }
        
        var checkSum = creditCardNumber
            .ToCharArray()
            .Select(CharToInt)
            .Reverse()
            .Select((digit, index) => IsEven(index + 1) ? DoubleDigit(digit) : digit)
            .Sum();

        return checkSum % 10 == 0;
    }
}
