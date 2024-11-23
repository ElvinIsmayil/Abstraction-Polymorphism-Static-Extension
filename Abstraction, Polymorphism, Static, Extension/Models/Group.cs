namespace Abstraction__Polymorphism__Static__Extension.Models
{
    public class Group
    {

        private Student[] _students = Array.Empty<Student>();

        private int _studentLimit;
        public string GroupNo { get; set; }
        public int StudentLimit
        {
            get => _studentLimit;
            set
            {
                if (value >= 5 && value <= 18)
                {
                    _studentLimit = value;
                }
                else
                {
                    Console.WriteLine("The number of students in a group should be between 5 and 18");
                }
            }

        }

        public Group(string groupNo, int studentLimit)
        {
            GroupNo = groupNo;
            StudentLimit = studentLimit;
        }

        public static Group Create(string groupno, int studentlimit)
        {
            if (string.IsNullOrEmpty(groupno))
                return null;

            
            if (studentlimit < 5 || studentlimit > 18)
            {
                Console.WriteLine("The student limit must be between 5 and 18.");
                return null;

            }

            if (!CheckGroupNo(groupno))
            {
                Console.WriteLine("Group number cannot be null or empty!");
                return null;

            }

            Group group = new Group(groupno, studentlimit);

            return group;


        }

        public static bool CheckGroupNo(string groupNo)
        {
            if (groupNo == null || string.IsNullOrEmpty(groupNo.Trim()))
            {
                return false;
            }
           
            int upperLetterCount = 0;
            int digitCount = 0;

            Char[] groupNoArray  = groupNo.ToCharArray();

            for (int i = 0; i < groupNoArray.Length; i++)
            {
                if (char.IsDigit(groupNoArray[i]))
                {
                    digitCount++;
                }
                if (char.IsUpper(groupNoArray[i]))
                {
                    upperLetterCount++;
                }
            }

            if( upperLetterCount != 2)
            {
                return false;
            }

            if (digitCount != 3)
            {
                return false;
            }

            return true;


        }


        public void AddStudent(Student student)
        {

            if (_students.Length >= StudentLimit)
            {
                Console.WriteLine("Limit reached. Cannot add more students.");
                return;
            }
            else
            {
                Array.Resize(ref _students, _students.Length + 1);
                _students[^1] = student;
            }
        }


        public Student GetStudent(int id)
        {
            foreach (Student student in _students)
            {
                if(student.Id == id) 
                    return student;
                
            }

            return null;

        }

        public Student[] GetAllStudents()
        {
            return _students;

        }




    }
}

