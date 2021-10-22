using System.Collections.Generic;

namespace UniversityApp
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        private List<int> Marks { get; set; }
        public int Average
        {
            get
            {
                int result = 0;
                foreach (int item in Marks)
                {
                    int sum = 0;
                    sum += item;
                    result = sum / Marks.Count;
                }
                return result;
            }
            set
            {

            }
        }


        private static int _count;
        public readonly int Id;
        private Student()
        {
            _count++;
            Id = _count;
        }
        public Student(string name, string surname, int age, int average) : this()
        {
            Name = name;
            Surname = surname;
            Age = age;
            Average = average;
        }

        public override string ToString()
        {
            return $"Student: {Id} - Name: {Name} Surname: {Surname} Age: {Age} Average: {Average}";
        }
        public override bool Equals(object obj)
        {
            return Name == ((Student)obj).Name;
        }
    }
}