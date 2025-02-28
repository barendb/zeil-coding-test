using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Helpers;

namespace Api.V1.CardValidation;

[ApiController]
[Route("v1/cardvalidation")]
public class CardValidationController : ControllerBase
{
    [HttpPost]
    public ActionResult<CardValidationPostResult> Post([FromBody] CardValidationRequest request)
    {
        var cardNumber = StringHelpers.DigitsOnly(request.CardNumber);
        var isValid = CreditCardValidation.IsValidLuhn(cardNumber);

        return Ok(new CardValidationPostResult { IsValid = isValid });
    }
}

