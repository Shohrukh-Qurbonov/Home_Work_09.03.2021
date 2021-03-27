using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    //ДЗ 2
    class MyDictionary<TKey, TValue>
    {
        List<Entry<TKey,TValue>> records = new List<Entry<TKey,TValue>>();
        public IEnumerator<Entry<TKey,TValue>> GetEnumerator()
        {
            return records.GetEnumerator();
        }
        public List<TKey> Keys 
        { 
            get 
            {
                List<TKey> j = new List<TKey>();
                for (int i = 0; i < records.Count; i++)
                {
                    j.Add(records[i].Key);
                }
                return j; 
            } 
        }
        public List<TValue> Values 
        {
            get 
            {
                List<TValue> j = new List<TValue>();
                for (int i = 0; i < records.Count; i++)
                {
                    j.Add(records[i].Value);
                }
                return j; 
            } 
        }
        public int Count 
        { 
            get 
            { 
                return records.Count; 
            } 
        }
        public TValue this[TKey index]
        {
            get 
            {
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].Key == (dynamic)index)
                        return records[i].Value;
                }
                throw new KeyNotFoundException(); 
            }
            set
            {
                int j = records.Count;
                for (int i = 0; i < records.Count; i++)
                {

                    if (records[i].Key == (dynamic)index)
                    {
                        records[i].Value = value;
                    }
                    else {
                        j--;
                    }
                }
                if(j==0)
                throw new KeyNotFoundException();
            }
        }
        public void Add(TKey keyy,TValue valuee)
        {
            records.Add(new Entry<TKey, TValue>() { Key = keyy,Value = valuee});
        }
    }


    //ДЗ 1
    class MyList<T>
    {
        static T[] myList = new T[0];
        public int Count 
        { 
            get 
            { 
                return myList.Length; 
            } 
        }
        public T this[int index]
        {
            get
            {
                return myList[index];
            }
            set
            {
                myList[index] = value;
            }
        }
        public void Add(T element)
        {
            Array.Resize(ref myList, myList.Length + 1);
            myList[myList.Length - 1] = element;
        }
        public int IndexOf(T element)
        {
            for (int i = 0; i < myList.Length; i++)
            {
                if (myList[i] == (dynamic)element)
                return i;
            }
            throw new IndexOutOfRangeException();
        }
    }

    class Entry<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }

    class Person
    {
        public string name { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> my = new MyDictionary<int, string>();
            my.Add(1, "5");
            my[1] = "6";
            Console.WriteLine(my[1]);
            MyDictionary<string, int> m = new MyDictionary<string,int>();
            m.Add("1", 1);
            m["1"] = 1234;
            Console.WriteLine(m["1"]);
            int a = m["1"];
            Console.WriteLine(m["1"]);
            MyDictionary<int, Person> l = new MyDictionary<int, Person>();
            l.Add(1, new Person());
            l.Values[0].name = "ABCDE";
            l[1].name = "E";
            MyDictionary<int,string> dsa = new MyDictionary<int,string>();
            dsa.Add(1,"A");
            dsa.Add(23212, "2");
            foreach (var keys in dsa.Keys)
            {
                Console.WriteLine(keys);
            }
            foreach (var values in dsa.Values)
            {
                Console.WriteLine(values);
            }

            Dictionary<int, string> mydiction = new Dictionary<int, string>();
            mydiction.Add(1, "1");
            mydiction.Add(2, "2");
            foreach (var items in mydiction)
            {
                Console.WriteLine(items);
                Console.WriteLine(items.Key);
                Console.WriteLine(items.Value);
            }
        }
    }
}