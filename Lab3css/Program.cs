using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab3css
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Magazine magazine = new Magazine("test title", Frequency.Yearly, new DateTime(2020, 12, 03), 25);
            magazine.ListOfArticle.Add(new Article(new Person("Sergey", "Tikhomirov",
                new DateTime(2002, 03, 12)), "First title", 30));
            magazine.ListOfArticle.Add(new Article(new Person("Grigoriy", "Nikolaev",
                new DateTime(2002, 03, 29)), "Third title", 10));
            magazine.ListOfArticle.Add(new Article(new Person("Ivan", "Tikhonov",
                new DateTime(2002, 12, 7)), "Second title", 17));

            Console.WriteLine("Сортировка по названию: \n");
            foreach(var obj in magazine.SortTitle)
            {
                Console.WriteLine(obj.ToString() + "\n");
            }
            Console.WriteLine("Сортировка по фамилии: \n");
            foreach (var obj in magazine.SortSurname)
            {
                Console.WriteLine(obj.ToString() + "\n");
            }
            Console.WriteLine("Сортировка по рейтингу: \n");
            foreach (var obj in magazine.SortRating)
            {
                Console.WriteLine(obj.ToString() + "\n");
            }

            KeySelector<string> selector = delegate (Magazine magazine) { return magazine.GetHashCode().ToString(); };
            MagazineCollection<string> collection = new MagazineCollection<string>(selector);
            collection.AddMagazines(magazine, new Magazine());
            foreach(var mag in collection.Magazines.Values)
            {
                Console.WriteLine(mag.ToString() + "\n");
            }

            GenerateElement<Edition, Magazine> d = delegate (int j)
            {
                var key = new Edition("Edition", new DateTime(2000 + j % 30, 1 + j % 12, 1 + j % 30), j + 100_000);
                var value = new Magazine("Magazine", (Frequency)(j % 3), new DateTime(2000 + j % 30, 1 + j % 12, 1 + j % 30), j + 100_000);
                return new KeyValuePair<Edition, Magazine>(key, value);
            };

            TestCollections<Edition, Magazine> test = new TestCollections<Edition, Magazine>(1000000, d);
            test.checkTime();
            

        }
    }
}
