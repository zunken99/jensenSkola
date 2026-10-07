namespace WestcoastEd;

public static class ConsoleInput
{
    public static string Ask(string label)
    {
        Console.Write($"{label}: ");
        return Console.ReadLine()?.Trim() ?? "";
    }

    public static DateOnly AskDate(string label)
    {
        while (true)
        {
            var input = Ask($"{label} (åååå-mm-dd)");
            if (DateOnly.TryParseExact(input, "yyyy-MM-dd",
                    out var date)) return date;
            Console.WriteLine("Ogiltigt datum.");
        }
    }
}