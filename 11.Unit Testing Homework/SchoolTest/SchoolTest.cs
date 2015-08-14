using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Students_and_courses;

namespace SchoolTest
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestingSchoolCreationWithValidName()
        {
            string name = "TeleriGGG";
            var school = new School(name);
            Assert.AreEqual(name,
                school.Name,
                string.Format("The name {0} does not equal the expected name {1}",
                school.Name,
                name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestingSchoolCreationWithInvalidName()
        {
            string name = null;
            var school = new School(name);
        }

        [TestMethod]
        public void TestingSchoolAddingStudents()
        {
            string name = "TeleriGGG";
            string courseName = "Tech";
            int id = 10000;
            var school = new School(name);
            var course = new Course(courseName);
            school.AddCourse(course);

            Assert.AreEqual(
                course,
                school.Courses[0],
                string.Format("The object {0} does not equal the expected object {1}",
                school.Courses[0],
                course));
        }

        [TestMethod]
        public void TestingSchoolRemovingStudents()
        {
            string name = "TeleriGGG";
            string courseName = "Tech";
            int length = 0;
            var school = new School(name);
            var course = new Course(courseName);
            school.AddCourse(course);
            school.RemoveCourse(course);

            Assert.AreEqual(
                            length,
                            school.Courses.Count,
                            string.Format("The length {0} does not equal the expected length {1}",
                            school.Courses.Count,
                            length));
        }
    }
}
