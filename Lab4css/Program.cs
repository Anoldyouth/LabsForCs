using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Lab4css
{
    class Program
    {
        

        static void Main(string[] args)
        {
            KeySelector<String> selector = magazine => magazine.GetHashCode().ToString();
            MagazineCollection<string> first = new MagazineCollection<string>(selector);
            MagazineCollection<string> second = new MagazineCollection<string>(selector);
            first.TitleOfCollection = "First collection";
            second.TitleOfCollection = "Second collection";

            Listener listener = new Listener();
            first.MagazinesChanged += listener.addEntry;
            second.MagazinesChanged += listener.addEntry;

            Magazine obj = new Magazine("test title", Frequency.Yearly, new DateTime(2020, 12, 03), 25);
            first.AddDefaults(1);
            first.AddMagazines(obj);
            obj.Circulation = 35;
            first.Replace(new Magazine(), new Magazine("title", Frequency.Yearly, new DateTime(2020, 12, 03), 25));
            first.Replace(new Magazine(), new Magazine("try to change object", Frequency.Yearly, new DateTime(2020, 12, 03), 25));

            Console.WriteLine(listener.ToString());

        }
    }
}
