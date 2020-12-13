using System;

namespace BirthdayManagement.WebApp.Models
{
    public class Person
    {        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
    }
}
