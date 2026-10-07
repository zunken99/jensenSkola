using System;

namespace WestcoastEd;

public class DistanceCourse : Course
{
    public DistanceCourse(string courseNr, string courseName, DateOnly startDate, DateOnly endDate) : base(courseNr, courseName, startDate, endDate){}
    public override string CourseType => "Distance";

}
