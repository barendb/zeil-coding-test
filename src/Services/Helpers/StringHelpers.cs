namespace Services.Helpers;

public static class StringHelpers
{
    public static string DigitsOnly(string input)
    {
        return new string(input.ToCharArray()
            .Where(char.IsDigit)
            .ToArray());
    }
}