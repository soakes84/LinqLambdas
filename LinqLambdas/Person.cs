using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambdas
{
    class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ID { get; set; }

        public int Height { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public Person(string firstName, string lastName, int id, int height, int age, Gender gender)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = id;
            this.Height = height;
            this.Age = age;
            this.Gender = gender;
        }
    }
}
