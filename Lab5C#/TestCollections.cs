using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lab4cs
{
    delegate System.Collections.Generic.KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);

    class TestCollections<TKey, TValue>
    {
        List<TKey> keys = new List<TKey>(); 
        List<string> strings = new List<string>();
        Dictionary<TKey, TValue> keyDictionary = new Dictionary<TKey, TValue>();
        Dictionary<string, TValue> stringDictionary = new Dictionary<string, TValue>();
        GenerateElement<TKey, TValue> generator; 

        public TestCollections(int count, GenerateElement<TKey, TValue> j)
        {
            generator = j;
            for(int i = 0; i < count; i++)
            {
                var obj = generator(i);
                keys.Add(obj.Key);
                strings.Add(obj.Key.ToString());
                keyDictionary.Add(obj.Key, obj.Value);
                stringDictionary.Add(obj.Key.ToString(), obj.Value);
            }

        }

        public void checkTime()
        {
            Console.WriteLine("Проверка времени для List<TKey>");
            Stopwatch keysCheck = new Stopwatch();
            keysCheck.Start();
            keys.Contains(keys[0]);
            Console.WriteLine("Время для первого элемента: " + keysCheck.Elapsed);
            keysCheck.Restart();
            keys.Contains(keys[keys.Count-1]);
            Console.WriteLine("Время для последнего элемента: " + keysCheck.Elapsed);
            keysCheck.Restart();
            keys.Contains(keys[(keys.Count - 1) / 2]);
            Console.WriteLine("Время для среднего элемента: " + keysCheck.Elapsed);
            keysCheck.Restart();
            keys.Contains(generator(keys.Count).Key);
            keysCheck.Stop();
            Console.WriteLine("Время для несуществующего элемента: " + keysCheck.Elapsed + "\n");

            Console.WriteLine("Проверка времени для List<string>");
            Stopwatch stringCheck = new Stopwatch();
            stringCheck.Start();
            strings.Contains(strings[0]);
            Console.WriteLine("Время для первого элемента: " + stringCheck.Elapsed);
            stringCheck.Restart();
            strings.Contains(strings[strings.Count - 1]);
            Console.WriteLine("Время для последнего элемента: " + stringCheck.Elapsed);
            stringCheck.Restart();
            strings.Contains(strings[(strings.Count - 1) / 2]);
            Console.WriteLine("Время для среднего элемента: " + stringCheck.Elapsed);
            stringCheck.Restart();
            strings.Contains(generator(strings.Count).Key.ToString());
            stringCheck.Stop();
            Console.WriteLine("Время для несуществующего элемента: " + stringCheck.Elapsed + "\n");

            Console.WriteLine("Проверка времени для Dictionary<TKey, TValue>");
            Stopwatch dictionaryTKeyCheck = new Stopwatch();
            dictionaryTKeyCheck.Start();
            keyDictionary.ContainsKey(keyDictionary.ElementAt(0).Key);
            Console.WriteLine("Время для первого элемента: " + dictionaryTKeyCheck.Elapsed);
            dictionaryTKeyCheck.Restart();
            keyDictionary.ContainsKey(keyDictionary.ElementAt(keyDictionary.Count-1).Key);
            Console.WriteLine("Время для последнего элемента: " + dictionaryTKeyCheck.Elapsed);
            dictionaryTKeyCheck.Restart();
            keyDictionary.ContainsKey(keyDictionary.ElementAt((keyDictionary.Count - 1)/2).Key);
            Console.WriteLine("Время для среднего элемента: " + dictionaryTKeyCheck.Elapsed);
            dictionaryTKeyCheck.Restart();
            keyDictionary.ContainsKey(generator(keyDictionary.Count).Key);
            dictionaryTKeyCheck.Stop();
            Console.WriteLine("Время для несуществующего элемента: " + dictionaryTKeyCheck.Elapsed + "\n");

            Console.WriteLine("Проверка времени для Dictionary<string, TValue>");
            Stopwatch dictionaryStringCheck = new Stopwatch();
            dictionaryStringCheck.Start();
            stringDictionary.ContainsKey(stringDictionary.ElementAt(0).Key);
            Console.WriteLine("Время для первого элемента: " + dictionaryStringCheck.Elapsed);
            dictionaryStringCheck.Restart();
            stringDictionary.ContainsKey(stringDictionary.ElementAt(stringDictionary.Count - 1).Key);
            Console.WriteLine("Время для последнего элемента: " + dictionaryStringCheck.Elapsed);
            dictionaryStringCheck.Restart();
            stringDictionary.ContainsKey(stringDictionary.ElementAt((stringDictionary.Count - 1) / 2).Key);
            Console.WriteLine("Время для среднего элемента: " + dictionaryStringCheck.Elapsed);
            dictionaryStringCheck.Restart();
            stringDictionary.ContainsKey(generator(stringDictionary.Count).Key.ToString());
            dictionaryStringCheck.Stop();
            Console.WriteLine("Время для несуществующего элемента: " + dictionaryStringCheck.Elapsed + "\n");

            Console.WriteLine("Проверка времени для Dictionary<TKey, TValue>");
            Stopwatch lastCheck = new Stopwatch();
            lastCheck.Start();
            keyDictionary.ContainsValue(keyDictionary.ElementAt(0).Value);
            Console.WriteLine("Время для первого элемента: " + lastCheck.Elapsed);
            lastCheck.Restart();
            keyDictionary.ContainsValue(keyDictionary.ElementAt(keyDictionary.Count - 1).Value);
            Console.WriteLine("Время для последнего элемента: " + lastCheck.Elapsed);
            lastCheck.Restart();
            keyDictionary.ContainsValue(keyDictionary.ElementAt((keyDictionary.Count - 1) / 2).Value);
            Console.WriteLine("Время для среднего элемента: " + lastCheck.Elapsed);
            lastCheck.Restart();
            keyDictionary.ContainsValue(generator(keyDictionary.Count).Value);
            lastCheck.Stop();
            Console.WriteLine("Время для несуществующего элемента: " + lastCheck.Elapsed + "\n");


        }
    }
}
