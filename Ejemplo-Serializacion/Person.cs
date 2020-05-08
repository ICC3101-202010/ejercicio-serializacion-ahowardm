using System;
namespace EjemploSerializacion
{
    [Serializable]
    public class Person
    {
        private string name;
        private string lastName;
        private int age;

        public Person(string name, string lastName, int age)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
        }

        public override string ToString()
        {
            return name + " " + lastName + ": " + age;
        }
    }
}
