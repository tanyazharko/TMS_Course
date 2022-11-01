using System;
using System.Collections.Generic;
using NodaTime;

namespace WorkWithADONET
{
    public partial class User
    {
        public User()
        {
            Exercises = new HashSet<Exercise>();
            Meals = new HashSet<Meal>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public LocalDate? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
