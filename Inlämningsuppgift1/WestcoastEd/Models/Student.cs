namespace WestcoastEd
{
    public class Student : Person
    {
        public Student(PersonInfo info) : base(info){}
        public override string Role => "Student";
    }

}
