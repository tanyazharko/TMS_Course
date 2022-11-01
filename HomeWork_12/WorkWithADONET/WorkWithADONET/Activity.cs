using System;
using System.Collections.Generic;

namespace WorkWithADONET
{
    public partial class Activity
    {
        public Activity()
        {
            Exercises = new HashSet<Exercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CalloriesPerMinute { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
