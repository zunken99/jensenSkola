namespace atm;

class Program
{
    static void Main()
    {
        // Deklarera en variabel för aktuellt saldo
        int balance;
        // Insättning
        Console.WriteLine("Hur mycket vill du sätta in?");
        // Deklarera en variabel för insättningen
        var depositInput = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(depositInput))
        {
            Console.WriteLine("Inget belopp angivet.");
            Environment.Exit(0);
        }

        balance = int.Parse(depositInput);

        Console.WriteLine($"Ditt saldo är nu: {balance} kr");
    }
}
