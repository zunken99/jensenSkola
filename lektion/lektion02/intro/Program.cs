namespace intro;

class Program
{
    static void Main(string[] args)
    {
        /*
        Console.WriteLine("Skriv in två tal som ska adderas:");
        int tal1 = int.Parse(Console.ReadLine());
        int tal2 = int.Parse(Console.ReadLine());
        Console.WriteLine(Add(tal1, tal2));
        */

        Console.WriteLine(Calc(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
    }

    public static int Add(int a, int b)
    {
        return a + b;
    }

    static int Calc(params int[] args)
    {
        return args.Sum();
    }
}
