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

            Console.ReadLine();
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 50));
        }
    }
}
