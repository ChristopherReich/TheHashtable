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

        int maxLengthLinkedList;
        int maxArrayLength;
        int lengthArrayList;
        

        public Hashtable(int _length = 32)
        {
            myArrayList = new ArrayList<SinglyLinkedList<(K, V)>>();
            maxArrayLength = _length;
            lengthArrayList = 0;
            maxLengthLinkedList = 0;
        }
      

        /// <summary>
        /// Fügt den Wert 'value' mit dem Schlüssel 'key' hinzu
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(K key, V value)
        {

            int idx = GetIndex(key);

            // Prüfe ob Array an der Stelle idx einen Wert enthält
            if (myArrayList[idx] == default)
            {
                // Falls noch keine LinkedList vorhanden --> erstellen
                myLinkedList = new SinglyLinkedList<(K,V)>();

                // Array-Zähler erhöhen
                lengthArrayList++;

                // Der ArrayList an der Stelle 'idx' die LinkedList verweisen
                myArrayList[idx] = myLinkedList;                 
            }
            else
            {
                // Die LinkedList per key suchen
                myLinkedList = myArrayList[idx];               
            }

            // Der LinkedList einen Node mit dem Tuple hinzufügen
            myLinkedList.Add((key, value));

            // Maximale LinkedList-Tiefe erhöhen, falls notwendig
            maxLengthLinkedList = Math.Max(maxLengthLinkedList, myLinkedList.Count());
        }



        /// <summary>
        /// Liefert die den Wert in der LinkedList mithilfe des Schlüssels
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            int idx = GetIndex(key);
            myLinkedList = myArrayList[idx];

            if (myLinkedList == null)
            {
                throw new Exception("Der Key existiert nicht: " + key);
            }
            else
            {
                foreach ((K, V) item in myLinkedList)
                {
                    if (key.Equals(item.Item1))
                    {
                        return item.Item2;
                    }
                }
            }
            throw new Exception("Der Key existiert nicht: " + key);
        }

        /// <summary>
        /// Entfernt den Node mit dem übergebenen Key aus der LinkedList
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(K key)
        {
            int idx = GetIndex(key);
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

        /// <summary>
        /// Gibt einen entsprechenden Index zwischen 0 und der maximalen Arraylänge zurück
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % maxArrayLength);
        }


        /// <summary>
        /// Berechne das Verhältnis zwischen Array-Länge und LinkedList-Tiefe.
        /// </summary>
        public double CalculateAlpha()
        {
            return (double)lengthArrayList / maxLengthLinkedList;
        }


        /// <summary>
        /// Prüft ob ein Element in der Hashtable existiert
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(K key)
        {
            int idx = GetIndex(key);
            myLinkedList = myArrayList[idx];

            foreach ((K, V) item in myLinkedList)
            {
                if (key.Equals(item.Item1))
                {
                    return true;
                }
            }

            return false;
        }


    }
}
