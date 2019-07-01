using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Entities
{
    public class Diploma : BaseEntity<int>
    {
        public int Credits { get; set; }
        public int[] Requirements { get; set; }

    }
}
