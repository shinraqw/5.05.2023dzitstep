using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._05._2023
{
    public class StudentGrades
    {
        public string Name { get; set; }
        public Dictionary<string, int> Grades { get; set; }

        public int GetMaxGrade()
        {
            int maxGrade = 0;

            foreach (int grade in Grades.Values)
            {
                if (grade > maxGrade)
                {
                    maxGrade = grade;
                }
            }

            return maxGrade;
        }

        public double GetAverageGrade()
        {
            double totalGrade = 0;

            foreach (int grade in Grades.Values)
            {
                totalGrade += grade;
            }

            return totalGrade / Grades.Count;
        }

        public static StudentGrades GetStudentWithBestGrades(List<StudentGrades> students)
        {
            StudentGrades bestStudent = null;
            double bestAverageGrade = 0;

            foreach (StudentGrades student in students)
            {
                double averageGrade = student.GetAverageGrade();

                if (averageGrade > bestAverageGrade)
                {
                    bestAverageGrade = averageGrade;
                    bestStudent = student;
                }
            }

            return bestStudent;
        }
    }


    public class DailyTemperature
    {
        public int HighestTemperature { get; set; }
        public int LowestTemperature { get; set; }

        public DailyTemperature(int[] temperatures)
        {
            // Ініціалізуємо поля максимальною та мінімальною температурами з масиву
            HighestTemperature = temperatures.Max();
            LowestTemperature = temperatures.Min();
        }

        public int GetMaxTemperatureDifferenceDay(int[] temperatures)
        {
            int maxDifference = 0;
            int maxDifferenceDay = 0;

            for (int i = 0; i < temperatures.Length; i++)
            {
                int difference = temperatures[i] - LowestTemperature;
                if (difference > maxDifference)
                {
                    maxDifference = difference;
                    maxDifferenceDay = i;
                }
            }

            return maxDifferenceDay + 1;
        }
    }



    public static class Extensions
    {
        public static bool IsFibonacci(this int number)
        {
            int a = 0, b = 1, c = 0;
            while (c < number)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return (c == number);
        }



        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            string[] words = str.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }



        public static int LastWordLength(this string str)
        {
            string[] words = str.Split(' ');
            if (words.Length == 0) // якщо рядок не містить слів
            {
                return 0;
            }
            return words[words.Length - 1].Length; // повертаємо довжину останнього слова
        }



        public static bool IsValidBrackets(this string str)
        {
            if (string.IsNullOrEmpty(str)) return true; // рядок без дужок вважаємо валідним

            var stack = new Stack<char>();
            var openingBrackets = new[] { '(', '[', '{' };
            var closingBrackets = new[] { ')', ']', '}' };

            foreach (var c in str)
            {
                if (openingBrackets.Contains(c))
                {
                    stack.Push(c);
                }
                else if (closingBrackets.Contains(c))
                {
                    if (stack.Count == 0) return false; // не має відкриваючої дужки для поточної закриваючої дужки

                    var openingBracket = stack.Pop();
                    var closingBracketIndex = Array.IndexOf(closingBrackets, c);

                    if (openingBracket != openingBrackets[closingBracketIndex]) return false; // тип закриваючої дужки не відповідає відкриваючій дужці
                }
            }

            return stack.Count == 0; // всі дужки мають бути закриті
        }




        public static int[] Filter(this int[] array, Func<int, bool> predicate)
        {
            List<int> filteredList = new List<int>();

            foreach (int element in array)
            {
                if (predicate(element))
                {
                    filteredList.Add(element);
                }
            }

            return filteredList.ToArray();
        }
    }
    internal class cs1
    {
        public static void task_1()
        {
            Console.OutputEncoding = Encoding.Unicode;

            //#1
            Console.WriteLine("Введіть число для перевірки чи являється воно числом Фібоначчі");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"{b} is Fibonacci number: {b.IsFibonacci()}");
            Console.WriteLine();

            //#2
            Console.WriteLine("Введіть рядок");
            string sentence = Console.ReadLine();
            int wordCount = sentence.WordCount();
            Console.WriteLine($"Кількість слів у рядку: {wordCount}");
            Console.WriteLine();

            //#3
            Console.WriteLine("Введіть рядок");
            string sentence1 = Console.ReadLine();
            Console.WriteLine($"Довжина останнього слова: {sentence1.LastWordLength()}");
            Console.WriteLine();

            //#4
            Console.WriteLine("Введіть {},[],() для перевірки на правильність введення дужок:");
            string bracket = Console.ReadLine();
            if (bracket.IsValidBrackets() == true)
            {
                Console.WriteLine("Дужки введені правильно");
            }
            else
            {
                Console.WriteLine("Дужки введені не правильно");
            }

            //#5
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Фільтруємо елементи, що задовольняють умову "елемент масиву є парним"
            int[] evenNumbers = numbers.Filter(x => x % 2 == 0);
            Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

            // Фільтруємо елементи, що задовольняють умову "елемент масиву є непарним"
            int[] oddNumbers = numbers.Filter(x => x % 2 != 0);
            Console.WriteLine("Odd numbers: " + string.Join(", ", oddNumbers));

            //#6
            int[] temperatures = { 20, 18, 12, 15, 22, 24, 10 };
            DailyTemperature dailyTemperature = new DailyTemperature(temperatures);

            int maxDifferenceDay = dailyTemperature.GetMaxTemperatureDifferenceDay(temperatures);
            Console.WriteLine($"Day with the maximum temperature difference is {maxDifferenceDay}");

            //#7
            List<StudentGrades> students = new List<StudentGrades>();

            // Додати студентів до списку з їх оцінками
            StudentGrades student1 = new StudentGrades
            {
                Name = "John",
                Grades = new Dictionary<string, int>
                {
                    { "Math", 80 },
                    { "Science", 90 },
                    { "English", 85 }
                }
            };
            students.Add(student1);

            StudentGrades student2 = new StudentGrades
            {
                Name = "Jane",
                Grades = new Dictionary<string, int>
                {
                    { "Math", 95 },
                    { "Science", 85 },
                    { "English", 90 }
                }
            };
            students.Add(student2);

            // Отримати студента з найвищим середнім балом
            StudentGrades bestStudent = StudentGrades.GetStudentWithBestGrades(students);

            Console.WriteLine("Student with the best grades:");
            Console.WriteLine("Name: " + bestStudent.Name);
            Console.WriteLine("Average grade: " + bestStudent.GetAverageGrade());

        }
    }
}