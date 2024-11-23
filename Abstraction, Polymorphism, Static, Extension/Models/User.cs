using Abstraction__Polymorphism__Static__Extension.Interfaces;
using System.Net.Mail;

namespace Abstraction__Polymorphism__Static__Extension.Models
{
    public class User : IAccount
    {
        private string _password;
        private string _email;
        private static int Counter = 0;
        public int Id { get; }
        public string Fullname { get; set; }

        public string Email
        {
            get => _email;
            set
            {
                if (ValidateEmail(value))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("The email does not meet the requirements!");
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (PasswordChecker(value))
                {
                    _password = value;
                }
                else
                {
                    throw new ArgumentException("The password does not meet the requirements!");
                }
            }
        }

        public User(string fullname, string email, string password)
        {
            Counter++;
            Id = Counter;
            Fullname = fullname;
            Email = email; 
            Password = password; 
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id}, Fullname: {Fullname}, Email: {Email}");
        }

        public static User Create(string fullname, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Fullname cannot be empty!");
                return null;
            }

            if (string.IsNullOrWhiteSpace(email) || !ValidateEmail(email))
            {
                Console.WriteLine("Invalid email format!");
                return null;
            }

            if (string.IsNullOrWhiteSpace(password) || !StaticPasswordChecker(password))
            {
                Console.WriteLine("Invalid password format! It must be at least 8 characters long, contain a digit, an uppercase letter, and a lowercase letter !");
                return null;
            }

            return new User(fullname, email, password);
        }

        public bool PasswordChecker(string password)
        {
            return StaticPasswordChecker(password);
        }

        public static bool StaticPasswordChecker(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 8)
                return false;

            if (!password.Any(char.IsDigit))
                return false;

            if (!password.Any(char.IsUpper))
                return false;
            
            if (!password.Any(char.IsLower))
                return false;

            
            return true;
        }

        
        public static bool ValidateEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
