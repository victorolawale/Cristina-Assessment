using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Entities
{
    public class Course : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Mark { get; set; }
        public int Credits { get; set; }
    }
}
