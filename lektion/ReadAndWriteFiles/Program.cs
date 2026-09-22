namespace ReadAndWriteFiles;

class Program
{
    static void Main()
    {
        string path = Environment.CurrentDirectory + "/data/log.txt";
        string message = "Info "+ DateTime.Now.ToString("yy-MM-dd HH:mm") + " - This is a log message.";
        // File.AppendAllText(path, "\n" + message);

        // string whatsInFile = File.ReadAllText(path);
        // Console.WriteLine(whatsInFile);
        using StreamWriter sw = new(path);
        sw.WriteLine(message, true);
        string whatsInFile = File.ReadAllText(path);
       

        sw.Close();
        
        using StreamReader sr = new(path);
        string infoBack = sr.ReadToEnd();
        Console.WriteLine(infoBack);
    }
}
