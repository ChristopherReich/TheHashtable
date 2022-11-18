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

            Hashtable<int, string> hashtable= new Hashtable<int, string>();

            hashtable.Put(1, "Bayern");
            hashtable.Put(2, "Oberösterreich");
            hashtable.Put(3, "Niederösterreich");
            hashtable.Put(300, "Wieselburg");

            Console.WriteLine(hashtable.Get(3));

            Console.WriteLine("Der Eintrag mit dem Key {0} wurde entfernt: {1}",3, hashtable.Remove(3)); ;

            Console.ReadKey();

        }
    }
}
