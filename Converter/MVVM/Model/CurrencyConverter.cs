namespace Converter.MVVM.Model;

public static class CurrencyConverter
{
    // Rates relative to EUR
    private static readonly Dictionary<string, decimal> RatesToEur = new()
    {
        { "EUR", 1.0m },
        { "USD", 1.08m },
        { "GBP", 0.86m },
        { "CHF", 0.97m },
        { "CZK", 25.30m },
        { "PLN", 4.32m },
        { "SEK", 11.20m },
        { "NOK", 11.50m },
        { "DKK", 7.46m },
        { "HUF", 395.0m },
        { "RON", 4.97m },
        { "BGN", 1.96m },
        { "HRK", 7.53m },
        { "RUB", 98.0m },
        { "UAH", 40.0m },
        { "TRY", 35.0m },
        { "JPY", 164.0m },
        { "CNY", 7.85m },
        { "KRW", 1450.0m },
        { "INR", 90.0m },
        { "CAD", 1.47m },
        { "AUD", 1.66m },
        { "NZD", 1.80m },
        { "BRL", 5.40m },
        { "MXN", 18.50m },
        { "ZAR", 19.80m },
        { "SGD", 1.45m },
        { "HKD", 8.45m },
        { "THB", 38.0m },
        { "AED", 3.97m }
    };

    private static readonly Dictionary<string, string> Flags = new()
    {
        { "EUR", "\U0001F1EA\U0001F1FA" },
        { "USD", "\U0001F1FA\U0001F1F8" },
        { "GBP", "\U0001F1EC\U0001F1E7" },
        { "CHF", "\U0001F1E8\U0001F1ED" },
        { "CZK", "\U0001F1E8\U0001F1FF" },
        { "PLN", "\U0001F1F5\U0001F1F1" },
        { "SEK", "\U0001F1F8\U0001F1EA" },
        { "NOK", "\U0001F1F3\U0001F1F4" },
        { "DKK", "\U0001F1E9\U0001F1F0" },
        { "HUF", "\U0001F1ED\U0001F1FA" },
        { "RON", "\U0001F1F7\U0001F1F4" },
        { "BGN", "\U0001F1E7\U0001F1EC" },
        { "HRK", "\U0001F1ED\U0001F1F7" },
        { "RUB", "\U0001F1F7\U0001F1FA" },
        { "UAH", "\U0001F1FA\U0001F1E6" },
        { "TRY", "\U0001F1F9\U0001F1F7" },
        { "JPY", "\U0001F1EF\U0001F1F5" },
        { "CNY", "\U0001F1E8\U0001F1F3" },
        { "KRW", "\U0001F1F0\U0001F1F7" },
        { "INR", "\U0001F1EE\U0001F1F3" },
        { "CAD", "\U0001F1E8\U0001F1E6" },
        { "AUD", "\U0001F1E6\U0001F1FA" },
        { "NZD", "\U0001F1F3\U0001F1FF" },
        { "BRL", "\U0001F1E7\U0001F1F7" },
        { "MXN", "\U0001F1F2\U0001F1FD" },
        { "ZAR", "\U0001F1FF\U0001F1E6" },
        { "SGD", "\U0001F1F8\U0001F1EC" },
        { "HKD", "\U0001F1ED\U0001F1F0" },
        { "THB", "\U0001F1F9\U0001F1ED" },
        { "AED", "\U0001F1E6\U0001F1EA" }
    };

    public static string[] Currencies => RatesToEur.Keys.ToArray();

    public static string GetFlag(string currency) =>
        Flags.TryGetValue(currency, out var flag) ? flag : "";

    public static decimal Convert(decimal amount, string from, string to)
    {
        if (from == to) return amount;

        // Convert from -> EUR -> to
        decimal inEur = amount / RatesToEur[from];
        return Math.Round(inEur * RatesToEur[to], 2);
    }
}
