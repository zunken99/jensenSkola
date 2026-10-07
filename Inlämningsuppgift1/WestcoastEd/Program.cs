using static WestcoastEd.ConsoleInput;

namespace WestcoastEd
{
    class Program
    {
        static void Main()  
        {
            var courses = new Repository<Course>("course.json");
            var students = new Repository<Student>("student.json");
            var teachers = new Repository<Teacher>("teacher.json");
            var leaders = new Repository<Edleader>("leader.json");
            var admins = new Repository<Admin>("admin.json");

            foreach (var t in teachers.Items
                         .Concat(leaders.Items)
                         .Concat(admins.Items))
                t.LinkCourses(courses.Items);

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
                    case "1": courses.Add(Prompts.ReadCourse()); break;
                    case "2": teachers.Add(Prompts.ReadTeacher(courses)); break;
                    case "3": students.Add(new Student(Prompts.ReadPerson())); break;
                    case "4": leaders.Add(Prompts.ReadLeader(courses)); break;
                    case "5": admins.Add(Prompts.ReadAdmin(courses)); break;
                    case "6": courses.PrintAll("Kurser"); break;
                    case "7": students.PrintAll("Studerande"); break;
                    case "8": teachers.PrintAll("Lärare"); break;
                    case "0": return;
                    default: Console.WriteLine("Ogiltigt val."); break;
                }
            }
        }
    }
}