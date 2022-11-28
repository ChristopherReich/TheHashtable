using libHashtable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TheHashtable
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //------------------------------------------------------------
            // Aufgabe 1
            //------------------------------------------------------------
            if (false)
            {
                Hashtable<string, string> hashtable = new Hashtable<string, string>();
                for (int i = 0; i < 100; i++)
                {
                    string idx = i.ToString();
                    hashtable.Put(idx, "Wert" + idx);
                    //Console.WriteLine("Belegungsfaktor: {0}", hashtable.CalculateAlpha());
                }

                Console.WriteLine(hashtable.Get("1"));
                Console.WriteLine(hashtable.Remove("8"));
                Console.WriteLine(hashtable.Remove("8"));
                Console.WriteLine(hashtable.Get("99"));
                Console.WriteLine(hashtable.Get("100"));
            }

            //------------------------------------------------------------
            // Aufgabe 2
            //------------------------------------------------------------
            if (true)
            {
                Hashtable<Person, string> hashtable = new Hashtable<Person, string>();

                Person sumsi = new Person("Simon", "Fritzging", 27);
                Person cheese = new Person("Simon", "Fritzging", 27);
                Person fritzi = new Person("Fritz", "Fritzging", 28);

                hashtable.Put(sumsi, "sumsi");
                hashtable.Put(cheese, "cheese");
                hashtable.Put(fritzi, "fritzi");

                Console.WriteLine(hashtable.Get(sumsi));

                sumsi.age = 30;

                Console.WriteLine(hashtable.Get(sumsi));


            }
            




            Console.ReadKey();

        }
    }
}
