using System;
using System.Collections.Generic;

namespace WorkWithADONET
{
    public partial class Food
    {
        public Food()
        {
            Meals = new HashSet<Meal>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Callories { get; set; }
        public int Proteins { get; set; }
        public int Fats { get; set; }
        public int Carbohydates { get; set; }
        public decimal Weight { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
