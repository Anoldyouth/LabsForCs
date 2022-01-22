using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Lab4cs
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var m = new Magazine("Not default", Frequency.Yearly, new DateTime(1970, 1, 1), 10);
            m.AddArticles(new Article());

            var mCopy = m.DeepCopy();

            Console.WriteLine("Enter filename: ");
            string filename;
            do
            {
                filename = Console.ReadLine();
            } while (filename.Length < 1);
            var fi = new FileInfo(filename);
            if (fi.Exists)
            {
                mCopy.Load(filename);
                Console.WriteLine("Loaded object:");
                Console.WriteLine(mCopy);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such file in this directory!");
                fi.Create().Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File was created");
                Console.ResetColor();
            }

            mCopy.AddFromConsole();
            mCopy.Save(filename);
            Console.WriteLine(mCopy);

            Magazine.Load(filename, mCopy);
            Console.WriteLine("\nAdd one more article:");
            mCopy.AddFromConsole();
            Console.WriteLine("Final version:");
            Console.WriteLine(mCopy);
            Magazine.Save(filename, mCopy);

        }
    }
}
