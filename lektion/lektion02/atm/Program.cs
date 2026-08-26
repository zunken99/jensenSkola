using System.Security.Cryptography;
using System.Text.Json;
namespace atm;

class User 
{
    public string UserId { get; set; } = "";
    public string PinHash { get; set; } = "";
    public string PinSalt { get; set; } = "";
    public int Balance { get; set; }
    
}
class Program
{
    static string filePath = "users.json";
    static List<User> users = new List<User>();
    
    static void Main()
    {
        LoadUsers();
        ChooseOption();
    }
    static void LoadUsers()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
    }
    static void SaveUsers()
    {
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText(filePath, json);
    }

    static string HashPin(string pin, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);
        byte[] hashBytes = Rfc2898DeriveBytes.Pbkdf2(
            pin,
            saltBytes,
            100_000,
            HashAlgorithmName.SHA256,
            32);

        return Convert.ToBase64String(hashBytes);
    }

    static bool VerifyPin(string pin, User user)
    {
        string hash = HashPin(pin, user.PinSalt);
        return CryptographicOperations.FixedTimeEquals(
            Convert.FromBase64String(hash),
            Convert.FromBase64String(user.PinHash));
    }

//Metod för att välja mellan skapa användare eller logga in
    static bool ChooseOption()
    {
        Console.WriteLine("Välj ett alternativ:");
        Console.WriteLine("1. Skapa användare");
        Console.WriteLine("2. Logga in");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            CreateUser(12345); // Exempel på ett användar-ID
            return true;
        }
        else if (choice == 2)
        {
            return Login(12345); // Exempel på ett användar-ID
        }
        else
        {
            Console.WriteLine("Ogiltigt val.");
            return ChooseOption();
        }
    }
// Metod för att logga in användaren och kontrollera användar-ID och pinkod 
    static bool Login(int userId)
    {
        Console.Write("Ange ditt användar-ID: ");
        string inputId = Console.ReadLine();
        Console.Write("Ange din pinkod: ");
        string inputPin = Console.ReadLine();
        User? user = users.FirstOrDefault(currentUser =>
            currentUser.UserId == inputId);

        if (user != null && VerifyPin(inputPin, user))
        {
            Console.WriteLine("Inloggning lyckades.");
            RunMenu(user);
            return true;
        }
        else
        {
            Console.WriteLine("Felaktigt användar-ID.");
            return false;
        }
    }
    

// Metod för att skriva ut aktuellt saldo
    static void PrintBalance(int balance)
    {
        Console.WriteLine($"Ditt saldo är nu: {balance} kr");
    }

    //metod för att skapa en användare och välja pinkod    
    static void CreateUser(int userId)
    {
        Console.Write("Ange ditt användar-ID: ");
        string inputId = Console.ReadLine();
        Console.Write("Välj en pinkod: ");
        string pin = Console.ReadLine();
        string salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
        User newUser = new User
        {
            UserId = inputId,
            PinHash = HashPin(pin, salt),
            PinSalt = salt,
            Balance = 0
        };

        users.Add(newUser);
        SaveUsers();
        Console.WriteLine($"Användare med ID {inputId} har skapats.");

        RunMenu(newUser);
    }

    static void RunMenu(User user)
    {
        int balance = user.Balance;
        while (true)
        {
            ShowMenu();
            int choice = int.Parse(Console.ReadLine());
            bool shouldContinue = HandleUserChoice(choice, ref balance);
            user.Balance = balance;
            SaveUsers();

            if (!shouldContinue)
            {
                break;
            }
        }
    }
    
    // Metod för att sätta in pengar
    static int Deposit(int balance, int amount)
    {
        balance += amount;
        Console.WriteLine($"Du har satt in {amount} kr.");
        PrintBalance(balance);
        SaveUsers();
        return balance;
    }
    // Metod för att ta ut pengar
    static int Withdraw(int balance, int amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Otillräckligt saldo för uttag.");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"Du har tagit ut {amount} kr.");
            PrintBalance(balance);
            SaveUsers();
        }
        return balance;
    }
    // Metod för att visa menyn
    static void ShowMenu()
    {
        Console.WriteLine("Välj ett alternativ:");
        Console.WriteLine("1. Sätt in pengar");
        Console.WriteLine("2. Ta ut pengar");
        Console.WriteLine("3. Visa saldo");
        Console.WriteLine("4. Avsluta");
    }
    // Metod för att hantera användarens val
    static bool HandleUserChoice(int choice, ref int balance)
    {
        switch (choice)
        {
            case 1:
                Console.Write("Ange belopp att sätta in: ");
                int depositAmount = int.Parse(Console.ReadLine());
                balance = Deposit(balance, depositAmount);
                break;
            case 2:
                Console.Write("Ange belopp att ta ut: ");
                int withdrawAmount = int.Parse(Console.ReadLine());
                balance = Withdraw(balance, withdrawAmount);
                break;
            case 3:
                PrintBalance(balance);
                break;
            case 4:
                Console.WriteLine("Avslutar programmet.");
                return false;
        }

        return true;
    }
}