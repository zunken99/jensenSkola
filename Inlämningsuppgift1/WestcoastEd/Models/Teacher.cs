namespace WestcoastEd
{
    public class Teacher : Student
    {
        public string Subject{get;}
        public List<Course> Courses{get; set;}= new();

        public Teacher(PersonInfo info, string subject) : base(info) => Subject = subject;
        public override string Role => "Teacher";

        public override string ToString()
        {
            var courses = Courses.Count == 0 ? "None" : string.Join(",", Courses.Select(c => c.CourseName));
            return $"{base.ToString()}, Subject: {Subject}, Courses: {courses}";
        }
        
        

    }
}
