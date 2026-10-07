using System.Text.Json.Serialization;

namespace WestcoastEd
{
    public class Teacher : Person
    {
        public string Subject{get;}

        //Course från JSON
        public List<string> CourseNrs {get; set;} = [];

        //Byggs upp efter inläsning 

        [JsonIgnore]
        public List<Course> Courses{get; set;}= [];

        public Teacher(PersonInfo info, string subject) : base(info) => Subject = subject;
        public override string Role => "Teacher";

            
        public void AssignCourse(Course course)     //dublettsäkra metoderna nedan
        {
            if (CourseNrs.Contains(course.CourseNr)) return;
            Courses.Add(course);
            CourseNrs.Add(course.CourseNr);
        }

        public void AssignCourses(
            IEnumerable<string> courseNrs, IEnumerable<Course> all)      //read the fucking manual
        {
            foreach (var c in all.Where(c => courseNrs.Contains(c.CourseNr)))
                AssignCourse(c);
        }

        public void LinkCourses(IEnumerable<Course> all)
        {
            Courses.Clear();
            Courses.AddRange(all.Where(c => CourseNrs.Contains(c.CourseNr)));
        }
            
            
            

        public override string ToString()
        {
            var courses = Courses.Count == 0 ? "None" : string.Join(",", Courses.Select(c => c.CourseName));
            return $"{base.ToString()}, Subject: {Subject}, Courses: {courses}";
        }
    }
}
