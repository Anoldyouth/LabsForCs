using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3css
{
    delegate TKey KeySelector<TKey>(Magazine mg);
    class MagazineCollection<TKey>
    {
        private Dictionary<TKey, Magazine> magazines = new Dictionary<TKey, Magazine>();
        private KeySelector<TKey> key;

        public MagazineCollection(KeySelector<TKey> keyValue)
        {
            key = keyValue;
        }


        public Dictionary<TKey, Magazine> Magazines
        {
            get
            {
                return magazines;
            }
            set
            {
                magazines = value;
            }
        }



        public void AddDefaults(int count)
        {
            for(int i = 0; i<count; i++)
            {
                Magazine obj = new Magazine();
                magazines.Add(key(obj), obj);
            }
        }

        public void AddMagazines(params Magazine[] magazinesValue)
        {
            foreach(Magazine magazine in magazinesValue)
            {
                magazines.Add(key(magazine), magazine);
            }
        }

        public override string ToString()
        {
            string list = "";
            foreach (var magazine in magazines.Values)
            {
                list += magazine.ToString() + "\n\n";
            }
            return list;
        }

        public virtual string ToShortString()
        {
            string list = "";
            foreach (var magazine in magazines.Values)
            {
                list += magazine.ToShortString() + "\n\n";
            }
            return list;
        }

        public double MaxAverageRating
        {
            get
            {
                if (magazines.Count == 0)
                    return -1;
                else
                {
                    List<double> rating = new List<double>();
                    foreach(var magazine in magazines.Values)
                    {
                        rating.Add(magazine.Rating);
                    }
                    return Enumerable.Max(rating);
                }
            }
        }

        IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
        {
            return magazines.Where(obj => obj.Value.Period == value);
        }

        IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> GroupElement
        {
            get
            {
                return magazines.GroupBy(magazine => magazine.Value.Period);
            }
        }
    }
}
