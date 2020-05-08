using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EjemploSerializacion
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                Console.WriteLine("Selecciona una opción");
                Console.WriteLine("(1) Crear nueva persona");
                Console.WriteLine("(2) Ver personas");
                Console.WriteLine("(3) Cargar Personas");
                Console.WriteLine("(4) Guardar Personas");
                Console.WriteLine("(5) Salir");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        addPerson(people);
                        break;
                    case 2:
                        showPeople(people);
                        break;
                    case 3:
                        people = Load();
                        break;
                    case 4:
                        Save(people);
                        break;
                    case 5:
                        return;
                }

            }
        }

        static public void addPerson(List<Person> people)
        {
            Console.Write("Nombre: ");
            string name = Console.ReadLine();
            Console.Write("Apellido: ");
            string lastName = Console.ReadLine();
            Console.Write("Edad: ");
            int age = int.Parse(Console.ReadLine());
            people.Add(new Person(name, lastName, age));
        }

        static public void showPeople(List<Person> people)
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        static private void Save(List<Person> people)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, people);
            stream.Close();
        }

        static private List<Person> Load()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Person> people = (List<Person>)formatter.Deserialize(stream);
            stream.Close();
            return people;
        }
    }
}
