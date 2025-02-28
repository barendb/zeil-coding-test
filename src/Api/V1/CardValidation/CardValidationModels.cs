using System.ComponentModel.DataAnnotations;

namespace Api.V1.CardValidation;

public class CardValidationRequest
{
    private const string _cardRegex = "^[0-9 -]{13,23}$"; // allow spaces dashes and numbers
    
    [Required]
    [RegularExpression(_cardRegex)]
    public string CardNumber { get; set; }
}

public class CardValidationPostResult
{
    public bool IsValid { get; set; }
}