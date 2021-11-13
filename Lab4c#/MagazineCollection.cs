using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lab4cs
{
    delegate TKey KeySelector<TKey>(Magazine mg);

    delegate void MagazinesChangedHandler<TKey>(object source, MagazinesChangedEventArgs<TKey> args);
    class MagazineCollection<TKey>
    {
        private Dictionary<TKey, Magazine> magazines = new Dictionary<TKey, Magazine>();
        private KeySelector<TKey> key;
        
        public MagazineCollection(KeySelector<TKey> keyValue)
        {
            key = keyValue;
        }

        public string TitleOfCollection { get; set; }

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

        public event MagazinesChangedHandler<TKey> MagazinesChanged;
        private void OnMagazinesChanged(Update typeOfProperty, string nameOfProperty, TKey key)
        {
            if (MagazinesChanged != null)
            {
                MagazinesChanged(this, new MagazinesChangedEventArgs<TKey>(TitleOfCollection, typeOfProperty, nameOfProperty, key));
            }
        }

        public void AddDefaults(int count)
        {
            for(int i = 0; i<count; i++)
            {
                Magazine obj = new Magazine();
                magazines.Add(key(obj), obj);
                OnMagazinesChanged(Update.Add, "", key(obj));
                obj.PropertyChanged += HandleEvent;
            }
        }

        public void AddMagazines(params Magazine[] magazinesValue)
        {
            foreach(Magazine magazine in magazinesValue)
            {
                magazines.Add(key(magazine), magazine);
                OnMagazinesChanged(Update.Add, "", key(magazine));
                magazine.PropertyChanged += HandleEvent;
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

        public bool Replace(Magazine mold, Magazine mnew)
        {
            foreach(TKey keyObj in magazines.Keys)
            {
                if(key(mold).Equals(keyObj))
                {
                    OnMagazinesChanged(Update.Replace, "", keyObj);
                    magazines[keyObj].PropertyChanged -= HandleEvent;
                    magazines.Remove(keyObj);
                    magazines.Add(key(mnew), mnew);
                    magazines[key(mnew)].PropertyChanged += HandleEvent;
                    return true;
                }
            }
            return false;
        }

        private void HandleEvent(object sender, PropertyChangedEventArgs args)
        {
            OnMagazinesChanged(Update.Property, args.PropertyName, key((Magazine)sender));
        }
    }
}
