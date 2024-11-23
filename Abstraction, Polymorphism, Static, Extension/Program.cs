using Abstraction__Polymorphism__Static__Extension.Models;
using System.Threading;

namespace Abstraction__Polymorphism__Static__Extension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Fullname of the User:");
            string fullnameUser = Console.ReadLine();

            Console.WriteLine("\nEnter the Email of the User:");
            string emailUser = Console.ReadLine();

            Console.WriteLine("\nEnter the Password of the User:");
            string passwordUser = Console.ReadLine();

            var user = User.Create(fullnameUser, emailUser, passwordUser);

            if (user == null)
            {
                Console.WriteLine("Invalid Credentials for the User! Exiting the Program...");
                System.Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("User has been successfully created!");
                Thread.Sleep(1000);
            }

            ConsoleKeyInfo keyinfo;
            do
            {
                Console.Clear();
                Console.WriteLine("1 -- Show Info");
                Console.WriteLine("2 -- Create new group");
                Console.WriteLine("Escape -- Quit");

                keyinfo = Console.ReadKey(intercept: true);

                switch (keyinfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Show Info");
                        user.ShowInfo();
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Create a new group");
                        Console.WriteLine("\nEnter the group number:");

                        string groupno = Console.ReadLine();

                        Console.WriteLine("Enter the student limit for the group:");

                        int studentlimit = int.Parse(Console.ReadLine());

                        var group = Group.Create(groupno, studentlimit);

                        if (group == null)
                        {
                            Console.WriteLine("Invalid Credentials for the Group! Press any key to return to the main menu...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"The group {groupno} has been successfully created!");
                            Thread.Sleep(1000);

                            ConsoleKeyInfo groupKeyInfo;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"Group {groupno} Menu:");
                                Console.WriteLine("\n1 -- Show all students");
                                Console.WriteLine("2 -- Get student by ID");
                                Console.WriteLine("3 -- Add student");
                                Console.WriteLine("Escape -- Return to main menu");

                                groupKeyInfo = Console.ReadKey(intercept: true);

                                switch (groupKeyInfo.Key)
                                {
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        Console.WriteLine($"\nThe students in the group {groupno}: ");
                                        var allStudents = group.GetAllStudents();
                                        if (allStudents == null || !allStudents.Any())
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\nThere is no student in the group yet!");
                                        }
                                        else
                                        {
                                            foreach (Student stud in allStudents)
                                            {
                                                stud.StudentInfo();
                                            }
                                        }

                                        Console.WriteLine("\nPress any key to return to the group menu...");
                                        Console.ReadKey();
                                        break;

                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Console.WriteLine("Enter the ID of the student to get info:");

                                        int studentId = int.Parse(Console.ReadLine());



                                        if (group.GetStudent(studentId) == null)
                                        {
                                            Console.WriteLine("The student which matches the id provided is not found!");
                                        }
                                        else
                                        {
                                            group.GetStudent(studentId).StudentInfo();
                                        }




                                        Console.WriteLine("\nPress any key to return to the group menu...");
                                        Console.ReadKey();
                                        break;

                                    case ConsoleKey.D3:
                                        Console.Clear();
                                        Console.WriteLine("Enter the credentials of the student:");
                                        Console.WriteLine("\nEnter student Fullname:");
                                        string fullnameStudent = Console.ReadLine();

                                        Console.WriteLine("Enter student Email:");
                                        string emailStudent = Console.ReadLine();

                                        Console.WriteLine("Enter student Password:");
                                        string passwordStudent = Console.ReadLine();

                                        Console.WriteLine("Enter student Point:");
                                        double point = Convert.ToDouble(Console.ReadLine());
                                        


                                        var student = Student.Create(fullnameStudent, emailStudent, passwordStudent, point);

                                        if (student == null)
                                        {
                                            Console.WriteLine("Invalid Credentials for the Student! Press any key to return to the main menu...");
                                        }
                                        else
                                        {
                                            group.AddStudent(student);
                                            Console.WriteLine($"\nStudent: {student.Fullname} has been sucessfully added to {groupno} Group!");
                                        }



                                        Console.WriteLine("\nPress any key to return to the group menu...");
                                        Console.ReadKey();
                                        break;

                                    case ConsoleKey.Escape:
                                        Console.Clear();
                                        break;

                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Invalid operation. Press any key to return to the group menu...");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            while (groupKeyInfo.Key != ConsoleKey.Escape);
                        }
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("Exiting the program...");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid operation. Press any key to return to the main menu...");
                        Console.ReadKey();
                        break;
                }
            }
            while (keyinfo.Key != ConsoleKey.Escape);
        }
    }
}
