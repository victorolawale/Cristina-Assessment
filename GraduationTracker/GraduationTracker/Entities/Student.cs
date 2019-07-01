using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Entities
{
    public class Student : BaseEntity<int>
    {
        public Course[] Courses { get; set; }
        public Standing Standing { get; set; } = Standing.None;
    }
}
