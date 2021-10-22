using UniversityApp;
using System.Collections.Generic;
using System;

namespace UniversityApp
{
    class Group
    {
        public string Name { get; set; }
        public int MaxStudentCount { get; set; }
        private List<Student> Students { get; set; }

        private static int _count;
        public readonly int Id;

        private Group()
        {
            _count++;
            Id = _count;
        }

        public Group(string name, int maxstudentcount) : this()
        {
            Name = name;
            MaxStudentCount = maxstudentcount;
        }
        public override string ToString()
        {
            return $"Group: {Id} - Name: {Name} Max Student Count: {MaxStudentCount}";
        }

        public override bool Equals(object obj)
        {
            return Name == ((Group)obj).Name;
        }

        public bool AddStudent(Student student)
        {
            if (Students.Contains(student))
            {
                return false;
            }
            else
            {
                Students.Add(student);
                return true;
            }
        }

        public void PrintAllStudents()
        {
            foreach (Student item in Students)
            {
                Console.WriteLine($"{Name}-daki {item}");
            }
        }

        public void SearchAndPrintStudents(string query)
        {
            foreach (Student item in Students)
            {
                if (item.Name.Contains(query) || item.Surname.Contains(query))
                {
                    System.Console.WriteLine(item);
                }
            }
        }

    }
}