using System.Text.Json.Serialization;

namespace WestcoastEd

{   

    //överkurs förmodligen men stötte på ett problem när mina kurser lästes in, eftersom Course är en abstract klass med två varianter
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ClassroomCourse), "classroom")]
    [JsonDerivedType(typeof(DistanceCourse), "distance")]
    public abstract class Course
    {
        public string CourseNr{get;}
        public string CourseName{get;}
        public DateOnly StartDate{get;}
        public DateOnly EndDate{get;}

        public int DurationDays => EndDate.DayNumber - StartDate.DayNumber + 1;
        public double DurationWeeks => Math.Round(DurationDays / 7.0, 1);

        protected Course(string courseNr, string courseName, DateOnly startDate, DateOnly endDate)
        {
            CourseNr = courseNr;
            CourseName = courseName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public abstract string CourseType {get;}

        public override string ToString() => $"{CourseType} Course: {CourseNr} - {CourseName}, Start Date: {StartDate:yyyy-MM-dd}, End Date: {EndDate:yyyy-MM-dd}, Duration: {DurationDays} days ({DurationWeeks} weeks)";

    }
}
