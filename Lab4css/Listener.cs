using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4css
{
    class Listener
    {
        private List<ListEntry> listOfChanges = new List<ListEntry>();

        public void addEntry(object subject, EventArgs args)
        {
            var obj = args as MagazinesChangedEventArgs<string>;
            listOfChanges.Add(new ListEntry(obj.TitleOfCollection, obj.TypeOfEvent, obj.NameOfProperty, obj.Key));
        }

        public override string ToString()
        {
            string text = "";
            foreach(ListEntry change in listOfChanges)
            {
                text += change.ToString() + "\n"; 
            }
            return text;
        }

    }
}
