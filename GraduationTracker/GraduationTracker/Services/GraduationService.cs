using GraduationTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Services
{
    public class GraduationService
    {
        private readonly RequirementRepository requirementRepository;

        public GraduationService()
        {
            this.requirementRepository = new RequirementRepository(); 
        }
        /// <summary>Determines whether the specified student has been graduated for given diploma.</summary>
        /// <param name="diploma">The diploma.</param>
        /// <param name="student">The student.</param>
        /// <returns>GraduateResult</returns>
        public GraduateStatus HasGraduated(Diploma diploma, Student student)
        {
            //var credits = 0;
          

            var totalMarks = 0;
            var diplomaRequirements = diploma.Requirements.Select(x => requirementRepository.GetById(x));
            var courses = student.Courses;

            foreach (var requirement in diplomaRequirements)
                foreach (var studentCourse in courses)
                {
                   var requirementCourses =  requirement.Courses.Where(x => x == studentCourse.Id);
                    foreach (var reqCource in requirementCourses)
                    {
                        totalMarks += studentCourse.Mark;
                        studentCourse.Credits += (studentCourse.Mark >= requirement.MinimumMark) ? requirement.Credits : 0;
                    }

                 //   studentCourse.Credits = credits;
                }

            var average = totalMarks / student.Courses.Length;

            var standing = Standing.None;

             standing =
                (average < 50) ? Standing.Remedial :
                (average < 80) ? Standing.Average :
                (average < 95) ? Standing.MagnaCumLaude :
                                Standing.SumaCumLaude;


            var pass = standing == Standing.None ? false : standing < Standing.Remedial;

            return new GraduateStatus() { Passed = pass, Status = standing };
        }
    }

}

