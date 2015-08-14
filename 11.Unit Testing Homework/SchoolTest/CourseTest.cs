namespace SchoolTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task_1.Students_and_courses;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestingCourseCreationWithValidName()
        {
            string name = "Tech class";
            var course = new Course(name);
            Assert.AreEqual(
                name,
                course.Name,
                string.Format("The name {0} does not equal the expected name {1}",
                course.Name,
                name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestingCourseCreationWithInvalidName()
        {
            string name = null;
            var course = new Course(name);
        }

        [TestMethod]
        public void TestingCourseAddingStudents()
        {
            string name = "Tech class";
            string studentName = "John";
            int id = 10000;
            var student = new Student(studentName, id);
            var course = new Course(name);
            course.AddStudent(student);

            Assert.AreEqual(
                student,
                course.Students[0],
                string.Format("The object {0} does not equal the expected object {1}",
                course.Students[0],
                student));
        }

        [TestMethod]
        public void TestingCourseRemovingStudents()
        {
            string name = "Tech class";
            string studentName = "John";
            int id = 10000;
            var student = new Student(studentName, id);
            var course = new Course(name);
            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.AreEqual(
                0,
                course.Students.Count,
                string.Format("The length {0} does not equal the expected length {1}",
                course.Students.Count,
                0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestingCourseAddingInvalidNumberOfStudents()
        {
            string name = "Tech class";
            string studentName = "John";
            int id = 10000;
            var student = new Student(studentName, id);
            var course = new Course(name);

            for (var i = 0; i < 32; i += 1)
            {
                course.AddStudent(student);
            }
        }
    }
}
