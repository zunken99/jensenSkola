using static WestcoastEd.ConsoleInput;

namespace WestcoastEd;

public static class Prompts  //egen klass för konsollinmatningar, även detta för att rensa i upp program mainfunktionen
{
    public static PersonInfo ReadPerson() => new(
        Ask("Förnamn"), Ask("Efternamn"), Ask("Telefon"),
        Ask("Personnummer"), Ask("Adress"),
        Ask("Postnummer"), Ask("Ort"));

    public static Course ReadCourse()
    {
        var number = Ask("Kursnummer");
        var title = Ask("Titel");
        var start = AskDate("Startdatum");
        var end = AskDate("Slutdatum");

        return Ask("Typ (1 = klassrum, 2 = distans)") == "1"
            ? new ClassroomCourse(number, title, start, end)
            : new DistanceCourse(number, title, start, end);
    }

    public static Teacher ReadTeacher(Repository<Course> courses)
    {
        var teacher = new Teacher(ReadPerson(), Ask("Kunskapsområde"));
        AskCourses(teacher, courses);
        return teacher;
    }

    public static Edleader ReadLeader(Repository<Course> courses)
    {
        var leader = new Edleader(ReadPerson(),
            Ask("Kunskapsområde"), AskDate("Anställningsdatum"));
        AskCourses(leader, courses);
        return leader;
    }

    public static Admin ReadAdmin(Repository<Course> courses)
    {
        var admin = new Admin(ReadPerson(),
            Ask("Kunskapsområde"), AskDate("Anställningsdatum"));
        AskCourses(admin, courses);
        return admin;
    }

    private static void AskCourses(
        Teacher teacher, Repository<Course> courses)
    {
        var nrs = Ask("Ansvarig för kursnummer " +
                      "(kommaseparerade, tomt = inga)")
            .Split(',', StringSplitOptions.RemoveEmptyEntries
                      | StringSplitOptions.TrimEntries);

        teacher.AssignCourses(nrs, courses.Items);
    }
}