using System.Text.Encodings.Web;
using System.Text.Json;


namespace WestcoastEd
{
    class Program
    {
        private static readonly string jsonFolderPath=
            string.Concat(Environment.CurrentDirectory, "/data");
        private static readonly string StudentFilePath =
            string.Concat(jsonFolderPath, "/student.json");
        private static readonly string TeacherFilePath =
            string.Concat(jsonFolderPath, "/teacher.json");

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        static void Main()
        {
            var students = new Repository<Student>();
            var teachers = new Repository<Teacher>();   
            var leaders = new Repository<Edleader>();
            var admins = new Repository<Admin>();
            var courses = new Repository<Course>();

            foreach (var student in LoadItems<Student>(StudentFilePath))
                students.Add(student);

            foreach (var teacher in LoadItems<Teacher>(TeacherFilePath))
                teachers.Add(teacher);

            

            while (true)
            {
                Console.WriteLine("""

                    1. Lägg till kurs
                    2. Lägg till lärare
                    3. Lägg till studerande
                    4. Lägg till utbildningsledare
                    5. Lägg till administratör
                    6. Lista kurser
                    7. Lista studerande
                    8. Lista lärare
                    0. Avsluta
                    """);

                switch (Ask("Val"))
                {
                    case "1": AddCourse(); break;
                    case "2": AddTeacher(); break;
                    case "3": AddStudent(); break;
                    case "4": AddLeader(); break;
                    case "5": AddAdmin(); break;
                    case "6": courses.PrintAll("Kurser"); break;
                    case "7": students.PrintAll("Studerande"); break;
                    case "8": teachers.PrintAll("Lärare"); break;
                    case "0": return;
                    default: Console.WriteLine("Ogiltigt val."); break;
                }
            }

            

            void AddCourse()
            {
                var number = Ask("Kursnummer");
                var title = Ask("Titel");
                var start = AskDate("Startdatum");
                var end = AskDate("Slutdatum");

                Course course = Ask("Typ (1 = klassrum, 2 = distans)") == "1"
                    ? new ClassroomCourse(number, title, start, end)
                    : new DistanceCourse(number, title, start, end);

                courses.Add(course);
            }

            void AddTeacher()
            {
                var teacher = new Teacher(ReadPerson(), Ask("Kunskapsområde"));
                AssignCourses(teacher);
                teachers.Add(teacher);
                SaveItems(TeacherFilePath, teachers.Items);
            }

            void AddStudent()
            {
                students.Add(new Student(ReadPerson()));
                SaveItems(StudentFilePath, students.Items);
            }

            void AddLeader()
            {
                leaders.Add(new Edleader(
                    ReadPerson(), Ask("Kunskapsområde"),
                    AskDate("Anställningsdatum")));
            }

            void AddAdmin()
            {
                admins.Add(new Admin(
                    ReadPerson(), Ask("Kunskapsområde"),
                    AskDate("Anställningsdatum")));
            }

            void AssignCourses(Teacher teacher)
            {
                var wanted = Ask("Ansvarig för kursnummer " +
                                "(kommaseparerade, tomt = inga)")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries
                            | StringSplitOptions.TrimEntries)
                    .ToHashSet();

                teacher.Courses.AddRange(
                    courses.Items.Where(c => wanted.Contains(c.CourseNr)));
            }

            PersonInfo ReadPerson() => new(
                Ask("Förnamn"), Ask("Efternamn"), Ask("Telefon"),
                Ask("Personnummer"), Ask("Adress"),
                Ask("Postnummer"), Ask("Ort"));

            string Ask(string label)
            {
                Console.Write($"{label}: ");
                return Console.ReadLine()?.Trim() ?? "";
            }

            DateOnly AskDate(string label)
            {
                while (true)
                {
                    var input = Ask($"{label} (åååå-mm-dd)");
                    if (DateOnly.TryParse(input, out var d)) return d;
                    Console.WriteLine("Ogiltigt datum.");
                }
            }

            

        }

        private static List<T> LoadItems<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return [];

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json, JsonOptions) ?? [];
        }

        private static void SaveItems<T>(string filePath, IReadOnlyList<T> items)
        {
            Directory.CreateDirectory(jsonFolderPath);
            var json = JsonSerializer.Serialize(items, JsonOptions);
            File.WriteAllText(filePath, json);
        }

    }
}
