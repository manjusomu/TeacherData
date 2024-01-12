using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace project_2
{

    class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassSection { get; set; }
    }
    class FileHandler
    {
        private const string FilePath = @"C:\Users\LENOVO\Documents\phase 1 simplilearn\phase1project2\Phase -1Project-2\\teachersData.txt";
        
        public static List<Teacher> ReadTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    string[] data = line.Split(',');
                    teachers.Add(new Teacher
                    {
                        ID = int.Parse(data[0]),
                        Name = data[1],
                        ClassSection = data[2]
                    });
                }
            }
            return teachers;
        }

        public static void WriteTeachers(List<Teacher> teachers)
        {
            List<string> lines = teachers.Select(t => $"{t.ID},{t.Name},{t.ClassSection}").ToList();
            File.WriteAllLines(FilePath, lines);
        }
    }
    class Program
    {
        static List<Teacher> teachers;

        static void Main()
        {
            teachers = FileHandler.ReadTeachers();

            while (true)
            {
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Update Teacher");
                Console.WriteLine("3. Display All Teachers");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTeacher();
                        break;
                    case "2":
                        UpdateTeacher();
                        break;
                    case "3":
                        DisplayTeachers();
                        break;
                    case "4":
                        FileHandler.WriteTeachers(teachers);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddTeacher()
        {
            Console.Write("Enter Teacher ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Teacher Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class and Section: ");
            string classSection = Console.ReadLine();

            teachers.Add(new Teacher { ID = id, Name = name, ClassSection = classSection });

            Console.WriteLine("Teacher added successfully.");
        }

        static void UpdateTeacher()
        {
            Console.Write("Enter Teacher ID to update: ");
            int idToUpdate = int.Parse(Console.ReadLine());

            Teacher teacherToUpdate = teachers.Find(t => t.ID == idToUpdate);

            if (teacherToUpdate != null)
            {
                Console.Write("Enter new Name: ");
                teacherToUpdate.Name = Console.ReadLine();

                Console.Write("Enter new Class and Section: ");
                teacherToUpdate.ClassSection = Console.ReadLine();

                Console.WriteLine("Teacher updated successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }

        static void DisplayTeachers()
        {
            Console.WriteLine("Teacher List:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class and Section: {teacher.ClassSection}");
            }
        }
    }
}
