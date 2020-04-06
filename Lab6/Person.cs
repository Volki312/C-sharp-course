using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class Person
    {
        private static List<Person> ALL_PEOPLE = new List<Person>() { 
            new Person("Josip", "Volarević", "Split", 35),
            new Person("Ante", "Antić", "Zagreb", 30),
            new Person("Mate", "Matić", "Split", 20),
            new Person("Ivan", "Ivić", "Zagreb", 20),
            new Person("Jure", "Jurić", "Rijeka", 20),
        };
        public string _name { get; set; }
        public string _lastName { get; set; }
        public string _city { get; set; }
        public int _age { get; set; }

        public Person(string name, string lastName, string city, int age)
        {
            _name = name;
            _lastName = lastName;
            _city = city;
            this._age = age;
        }

        public static List<Person> getAllPeopleList()
        {
            return ALL_PEOPLE;
        }

        public static Person getPersonByIndex(int index)
        {
            return ALL_PEOPLE[index];
        }

        public static void addNewPerson(Person person)
        {
            ALL_PEOPLE.Add(person);
        }

        public static void updatePerson(Person updatedPerson, int index)
        {
            ALL_PEOPLE[index] = updatedPerson;
        }

        public static void removePerson(int index)
        {
            ALL_PEOPLE.RemoveAt(index);
        }
    }
}
