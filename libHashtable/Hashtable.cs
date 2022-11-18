using libLinkedList;
using libArrayList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml.Linq;

namespace libHashtable
{ 

    public class Hashtable<K, V>
    {
        ArrayList<SinglyLinkedList<(K,V)>> myArrayList { get; set; }
        SinglyLinkedList<(K,V)> myLinkedList { get; set; }

        int alpha;

        public Hashtable()
        {
            myArrayList = new ArrayList<SinglyLinkedList<(K, V)>>();
        }
      

        /// <summary>
        /// Fügt den Wert 'value' mit dem Schlüssel 'key' hinzu
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(K key, V value)
        {

            int idx = Math.Abs(key.GetHashCode());

            // Prüfe ob Array an der Stelle idx einen Wert enthält
            if (myArrayList[idx] == default)
            {
                // Falls noch keine LinkedList vorhanden --> erstellen
                myLinkedList = new SinglyLinkedList<(K,V)>();

                // Der ArrayList an der Stelle 'idx' die LinkedList verweisen
                myArrayList[idx] = myLinkedList;

                // Der LinkedList einen Node mit dem Tuple hinzufügen
                myLinkedList.Add((key, value));
            }
            else
            {
                // Die LinkedList per key suchen
                myLinkedList = myArrayList[idx];              
            }

            // Der LinkedList einen Node mit dem Tuple hinzufügen
            myLinkedList.Add((key, value));

            // n ANzahl der Datenpunkte
            // m ANzahl der Listen
            alpha = count
        }



        /// <summary>
        /// Liefert die den Wert in der LinkedList mithilfe des Schlüssels
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            int idx = Math.Abs(key.GetHashCode());
            myLinkedList = myArrayList[idx];

            foreach ((K,V) item in myLinkedList)
            {
                if (key.Equals(item.Item1))
                {
                    return item.Item2;
                }
            }

            return default;
        }

        /// <summary>
        /// Entfernt den Node mit dem übergebenen Key aus der LinkedList
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(K key)
        {
            int idx = Math.Abs(key.GetHashCode());
            myLinkedList = myArrayList[idx];
            
            foreach ((K, V) item in myLinkedList)
            {
                if (key.Equals(item.Item1))
                {
                    myLinkedList.Remove(item);
                    return true;
                }
            }

            return false;
        }


    }
}
