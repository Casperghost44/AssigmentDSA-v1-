using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AssigmentDSA_v1_.Entities;

namespace AssigmentDSA_v1_.Core
{
    public class CustomDataList
    {

        private Student[] students;
        private int dataindex;
        private int count;


        public int Lenght;
        public Student First;
        public Student Last;
        public static IEnumerable<T> ReadSequenceOfElements<T>() where T : IComparable
        {


            var numbers = new List<T>();
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                T number = (T)Convert.ChangeType(input, typeof(T));
                numbers.Add(number);

                input = Console.ReadLine();
            }

            return numbers;
        }


        public void PopulateWithSampleData()
        {



#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../../TextFile1.txt"));
#endif

            var elements = ReadSequenceOfElements<string>().ToList();
            count = elements.Count;
            int len = count;
            students = new Student[len];
            char[] separators = new char[] { ',', ' ', };

            for (int i = 0; i < len; ++i)
            {
                string[] student_1 = elements[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                float Avr = float.Parse(student_1[3], CultureInfo.InvariantCulture.NumberFormat);
                students[i] = new Student
                {
                    FirstName = student_1[0],
                    LastName = student_1[1],
                    StudentNumber = student_1[2],
                    AverageScore = Avr
                };
                dataindex++;
            }
            Lenght = students.Length;

            First = students[0];
            Last = students[students.Length - 1];


        }



        public void DisplayList()
        {
            foreach (Student res in students)
            {
                Console.WriteLine(res);
            }
        }
        public void Add(Student newStudent)
        {
            IncreaseCapacity();
            students[dataindex] = newStudent;
            Last = students[dataindex];
            dataindex++;
            Lenght = dataindex;
        }
        public Student GetElement(int index)
        {

            if (index < 0 || index >= dataindex)
            {
                throw new ArgumentOutOfRangeException(
                "Invalid data index: " + dataindex);
            }
            return students[index];
        }
        public void RemoveByIndex(int index)
        {
            Student rems = students[index];
            if (index < 0 || index >= dataindex)
            {
                throw new ArgumentOutOfRangeException(
                "Invalid data index: " + dataindex);
            }

            for (int i = index; i < dataindex - 1; i++)
            {
                students[i] = students[i + 1];
            }

            students[dataindex - 1] = default;

            dataindex--;
            Lenght = dataindex;
            Last = students[dataindex - 1];
            Console.WriteLine($"Removed student is: {rems}");
        }
        public void RemoveFirst()
        {
            Student rems = students[0];
            students[0] = null;
            for (int i = 0; i < students.Length - 1; ++i)
            {
                students[i] = students[i + 1];
            }
            First = students[0];
            dataindex--;
            Lenght = dataindex;
            Console.WriteLine($"Removed student is: {rems}");
        }
        public void RemoveLast()
        {
            Student rems = students[dataindex - 1];


            for (int i = students.Length - 1; i < dataindex - 1; i++)
            {
                students[i] = students[i + 1];
            }

            students[dataindex - 1] = default;

            dataindex--;
            Lenght = dataindex;
            Last = students[dataindex - 1];
            Console.WriteLine($"Removed student is: {rems}");

        }
        public void IncreaseCapacity()
        {
            if (dataindex >= students.Length)
            {
                Student[] resizedArray = new Student[students.Length + 1];

                Array.Copy(students, 0, resizedArray, 0, students.Length);

                students = resizedArray;
                Lenght = students.Length;

            }
        }
    }
}