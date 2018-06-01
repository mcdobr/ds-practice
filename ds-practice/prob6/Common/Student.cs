using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Student
    {
        private int id;
        private string nume;
        private string grupa;

        public Student() {}
        public Student(int id, string nume, string grupa)
        {
            Id = id;
            Nume = nume;
            Grupa = grupa;
        }

        public int Id { get; set; }
        public string Nume {get; set;}
        public string Grupa {get; set;}

        // Ar trebui si un ToString ca sa fie frumos
    }

    // Cârpeală fiindcă KeyValuePair<K, V> nu poate fi serializat :(
    public struct KVP<K, V>
    {
        public K key;
        public V value;

        public KVP(K _key, V _value)
        {
            key = _key;
            value = _value;
        }
    }
}
