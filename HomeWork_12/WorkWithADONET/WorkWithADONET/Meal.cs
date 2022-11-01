using System;
using System.Collections.Generic;
using NodaTime;

namespace WorkWithADONET
{
    public partial class Meal
    {
        public int Id { get; set; }
        public LocalTime? Mealtime { get; set; }
        public int Userid { get; set; }
        public int Foodid { get; set; }

        public virtual Food Food { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
