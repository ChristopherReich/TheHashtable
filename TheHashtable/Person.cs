using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHashtable
{
    public class Person
    {
        public string name { get; set; }
        public string adresse { get; set; }
        public int age { get; set; }

        public Person(string _name, string _adresse, int _age)
        {
            name = _name;
            adresse = _adresse;
            age = _age;
        }

        public override bool Equals(object other)
        {
            Person otherPerson = other as Person;
            return (other != null && this.name == otherPerson.name && this.adresse == otherPerson.adresse && this.age == otherPerson.age);
        }


        public override int GetHashCode()
        {
            unchecked
            {
                int result = (name != null ? name.GetHashCode() : 0);
                result = (result * 397) ^ (adresse != null ? adresse.GetHashCode() : 0);
                result = (result * 397) ^ age;
                return result;
            }
        }
    }
}
