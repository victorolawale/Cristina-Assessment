using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Services;
using GraduationTracker.Entities;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private readonly StudentRepository studentRepository = new StudentRepository();
        private readonly GraduationService tracker = new GraduationService();


        private readonly RequirementRepository requirementRepository = new RequirementRepository();
        private readonly DiplomaRepository diplomaRepository = new DiplomaRepository();

        private List<Student> LoadStoredStudents()
        {
            var students = new List<Student>()
            {

                studentRepository.GetById(1),
                studentRepository.GetById(2),
                studentRepository.GetById(3),
                studentRepository.GetById(4)
            };

            return students;
        }

        private Student GetNewStudent()
        {
            var newStudent = new Student
            {

                Id = 5,
                Courses = new Course[]
              {

                      new Course{Id = 1, Name = "Course 1", Mark=5000 },
                      new Course{Id = 2, Name = "Course 2", Mark= -1 },
                      new Course{Id = 3, Name = "Course 3", Mark=2 },
                      new Course{Id = 4, Name = "Course 4", Mark=99 }



                    }

            };

            return newStudent;
                 
        }

        [TestMethod]
        public void TestStudentHasCredits()
        {
            var diploma = diplomaRepository.GetById(1);
            var newStudent = new Student
            {
                Id = 1,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Course 1", Mark=0 },
                    new Course{Id = 2, Name = "Course 2", Mark=49},
                    new Course{Id = 3, Name = "Course 3", Mark= 50},
                    new Course{Id = 4, Name = "Course 4", Mark=51 }
                }
            };

            var result = tracker.HasGraduated(diploma, newStudent);

            Assert.AreEqual(newStudent.Courses[0].Credits, 0);
            Assert.AreEqual(newStudent.Courses[1].Credits, 0);
            Assert.AreEqual(newStudent.Courses[2].Credits, 1);
            Assert.AreEqual(newStudent.Courses[3].Credits, 1);


        }

        [TestMethod]
        public void TestStudentShouldGraduate()
        {

            var diploma = diplomaRepository.GetById(1);

            var students = LoadStoredStudents();

            var graduated = students.Where(x => tracker.HasGraduated(diploma, x).Passed);

            Assert.AreEqual(graduated.Count(), 3);



        }



        [TestMethod]
        public void TestStudentShouldNotGraduate()
        {
            var diploma = diplomaRepository.GetById(1);

            //Repository Data
            var student = studentRepository.GetById(4);

            var result = tracker.HasGraduated(diploma, student);

            Assert.IsFalse(result.Passed);
            Assert.IsTrue(result.Status == Standing.Remedial);


        }



        [TestMethod]
        public void TestStudentShouldPass()
        {
            var diploma = diplomaRepository.GetById(1);

            var newStudent = GetNewStudent();

            var newStudentResult = tracker.HasGraduated(diploma, newStudent);
            Assert.IsTrue(newStudentResult.Passed);

        }


        

        [TestMethod]
        public void TestNewStudentShouldPass()
        {

            var diploma = diplomaRepository.GetById(1);

            
            var newStudent = GetNewStudent();

            var newStudentResult = tracker.HasGraduated(diploma, newStudent);
            Assert.IsTrue(newStudentResult.Passed);
            
        }

       



   


    }
}
