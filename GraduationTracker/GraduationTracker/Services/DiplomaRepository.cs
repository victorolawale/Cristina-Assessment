using GraduationTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Services
{
    public class DiplomaRepository : Repository<Diploma, int>
    {
        protected override IEnumerable<Diploma> GetAll()
        {
             return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[]{100,102,103,104}
                }
            };
        }
    }
}
