using System;

namespace WestcoastEd;

public class ClassroomCourse : Course
{
    public ClassroomCourse(string courseNr, string courseName, DateOnly startDate, DateOnly endDate) : base(courseNr, courseName, startDate, endDate){}
    public override string CourseType => "Classroom";
    
}
