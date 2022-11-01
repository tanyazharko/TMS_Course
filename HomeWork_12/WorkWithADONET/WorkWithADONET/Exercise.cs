using System;
using System.Collections.Generic;
using NodaTime;

namespace WorkWithADONET
{
    public partial class Exercise
    {
        public int Id { get; set; }
        public LocalTime? Start { get; set; }
        public LocalTime? Finish { get; set; }
        public int Userid { get; set; }
        public int Activityid { get; set; }

        public virtual Activity Activity { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
