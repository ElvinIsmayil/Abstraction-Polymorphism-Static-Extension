namespace Abstraction__Polymorphism__Static__Extension.Models
{
    public class Student : User
    {


        private static int Counter = 0;
        public int Id { get; }

        private double _point;
        public double Point
        {
            get => _point;

            set
            {
                if (value >= 0 && value <= 100)
                {
                    _point = value;
                }
                else
                {
                    Console.WriteLine("Point should be between 0 and 100");
                }

            }

        }
        public Student(string fullname, string email, string password, double point) : base(fullname, email, password)
        {
            Counter++;
            Id = Counter;
            Point = point;

        }

        public static Student Create(string fullname, string email, string password, double point)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Fullname cannot be empty!");
                return null;
            }
            if (string.IsNullOrWhiteSpace(password) || !StaticPasswordChecker(password))
            {
                Console.WriteLine("Invalid password format! It must be at least 8 characters long, contain a digit, an uppercase letter, and a lowercase letter.");
                return null;
            }
            if (string.IsNullOrWhiteSpace(email) || !ValidateEmail(email))
            {
                return null;
            }
            if (point > 100 || point < 0)
            {
                Console.WriteLine("Point should be between 0 and 100!");
                return null;
            }

            Student student = new Student(fullname, email, password, point);
            return student;

        }

        public void StudentInfo()
        {
            Console.WriteLine($"Id: {Id} , Fullname: {Fullname} , Email: {Email} , Point: {Point}");
        }
    }
}
