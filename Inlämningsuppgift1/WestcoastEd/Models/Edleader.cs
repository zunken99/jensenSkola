using System;

namespace WestcoastEd
{
    public class Edleader(PersonInfo info, string subject, DateOnly hireDate) : Teacher(info, subject)
    {
        public DateOnly HireDate { get; } = hireDate;

        public override string Role => "EdLeader";
        public override string ToString()=> $"{base.ToString()}, Hire Date: {HireDate:yyyy-MM-dd}";
        
    }
    
}
