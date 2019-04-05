using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambdas
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Linq Lambdas";

            List<Person> people = new List<Person>()
            {
                new Person("Spencer", "Oakes", 1, 71, 34, Gender.Male),
                new Person("Lebron", "James", 2, 80, 34, Gender.Male),
                new Person("Sarah", "Smith", 3, 55, 22, Gender.Female),
                new Person("Krista", "Johnson", 4, 59, 54, Gender.Female),
                new Person("Mike", "Williams", 5, 67, 61, Gender.Male),
                new Person("Mary", "Annie", 6, 54, 19, Gender.Female),
                new Person("Mo", "Williams", 7, 77, 21, Gender.Male),
                new Person("Sean", "McVay", 8, 68, 27, Gender.Male),
                new Person("Josh", "Tyson", 9, 72, 35, Gender.Male),
                new Person("Kobe", "Bryant", 10, 80, 39, Gender.Male),
                new Person("Chipper","Jones",  11, 76, 40, Gender.Male),
                new Person("Lauren", "Ellie", 12, 63, 26, Gender.Female),
                new Person("Oprah", "Winfry", 13, 64, 59, Gender.Female),
                new Person("Michelle", "Jones", 14, 70, 18, Gender.Female)
            };

            IEnumerable<IGrouping<Gender, Person>> genderGroup = people                   
                                                                 .GroupBy(p => p.Gender);  

            foreach (IGrouping<Gender, Person> item in genderGroup)
            {
                Console.WriteLine("Gender: " + item.Key);

                foreach (var p in item)
                {
                    Console.WriteLine($" {p.FirstName}, Gender: {p.Gender}");
                }
            }

            SeparatingLine();

            IEnumerable<IGrouping<int, Person>> ageGroup = people                     
                                                           .Where(p => p.Age > 20)     
                                                           .GroupBy(p => p.Age);       

            foreach (IGrouping<int, Person> item in ageGroup)
            {
                Console.WriteLine("Age: " + item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.FirstName}, Age: {p.Age}");
                }
            }

            SeparatingLine();

            var alphabeticalGroup = people.OrderBy(p => p.FirstName).GroupBy(p => p.FirstName[0]);

            foreach (IGrouping<char, Person> item in alphabeticalGroup)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.FirstName}");
                }
            }

            SeparatingLine();

            var multipleGroup = people.GroupBy(p => new { p.Gender, p.Age });

            foreach (var item in multipleGroup)
            {
                Console.WriteLine($"{item.Key}");

                foreach (Person i in item)
                {
                    Console.WriteLine($" {i.FirstName}");
                }
            }

            SeparatingLine();

            var peopleMultipleGrouping = people.GroupBy(p => p.Age < 20
                                                                ? "Young"
                                                                : p.Age >= 20 && p.Age <= 30
                                                                    ? "Adult"
                                                                    : "More Adult");

            foreach (var p in peopleMultipleGrouping)
            {
                Console.WriteLine($"{p.Key}");
                foreach (var i in p)
                {
                    Console.WriteLine($" {i.Age}");
                }
            }

            SeparatingLine();

            var howManyOfEachGroup = people.GroupBy(p => p.Gender)
                                           .OrderBy(p => p.Count())
                                           .Select(p => new
                                           {
                                               Gender = p.Key,
                                               NumOfPeople = p.Count()
                                           });

            foreach (var num in howManyOfEachGroup)
            {
                Console.WriteLine($"{num.Gender}");
                Console.WriteLine($"{num.NumOfPeople}");
            }

            SeparatingLine();

            int[] arrayOfNumbers = {18, 21, 25, 45, 98234, 2, 1, 49, 94, 7, 15, 12, 11, 84, 79, 6, 5, 111};

            var numbers = arrayOfNumbers.OrderBy(n => n)
                                        .GroupBy(n => (n % 2 == 0) ? "Even" : "Odd")
                                        .OrderBy(key => key.Count());

            foreach (var num in numbers)
            {
                foreach (var n in num)
                {
                    Console.WriteLine($"  {n}");
                }
            }

            Console.ReadLine();
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 50));
        }
    }
}
