using System;

namespace WestcoastEd
{
    public class Admin : Edleader
    {
        public Admin(PersonInfo info, string subject, DateOnly hireDate) : base(info, subject, hireDate) {}
        
        public override string Role => "Admin";
        
    }
    
}
