using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Students_and_courses;

namespace SchoolTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestingStudentCreationWithVaildName()
        {
            var name = "John";
            var id = 50000;
            var student = new Student(name, id);
            Assert.AreEqual(
                name,
                student.Name,
                string.Format("The name of the student {0} does not match {1} ",
                student.Name,
                name));
        }

        [TestMethod]
        public void TestingStudentCreationWithValidId()
        {
            var name = "John";
            var id = 50000;
            var student = new Student(name, id);
            Assert.AreEqual(
                id,
                student.Id,
                string.Format("The id of the student {0} does not match {1} ",
                student.Id,
                id));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void TestingStudentCreationWithInvalidName()
        {
            string name = null;
            var id = 60000;
            var student = new Student(name, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestingStudentCreationWithInvalidId()
        {
            string name = "John";
            int id = 1;
            var student = new Student(name, id);
        }
    }
}
