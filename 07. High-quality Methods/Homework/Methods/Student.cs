namespace Methods
{
    using System;
    using System.Globalization;

    internal class Student
    {
        public Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.DateOfBirth = dateOfBirth;
        }

        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string personalInfo;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                this.ValidateNameLength(1, 12, value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                this.ValidateNameLength(1, 12, value);
                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            private set
            {
                this.dateOfBirth = value;
            }
        }

        public string PersonalInfo
        {
            get
            {
                return this.personalInfo;
            }

            set
            {
                this.personalInfo = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            bool isOlder = this.DateOfBirth < other.DateOfBirth;
            return isOlder;
        }

        private void ValidateNameLength(int minLength, int maxLength, string value)
        {
            bool isValid = minLength < value.Length && value.Length < maxLength;

            if (isValid)
            {
                return;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid name length");
            }
        }
    }
}
