using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace WorkWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var classes = new[]
            {
            new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
            new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
            new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
            };

            var allStudents = GetAllStudents(classes);

            Console.WriteLine(string.Join(" ", allStudents));
        }

        static string[] GetAllStudents(Classroom[] classes)
        {

            List<string> studentsNames = new List<string>();

            // Напишите метод, который соберет всех учеников всех классов в один список, используя LINQ.
            var studs = classes.Select(cls => new
            {
                StudNames = cls.Students.Select(name => name)
            });

            foreach (var st in studs)
            {
                foreach (string name in st.StudNames)
                    studentsNames.Add(name);
            }

            return studentsNames.ToArray();
        }

        public class Classroom
        {
            public List<string> Students = new List<string>();
        }

    }
}

