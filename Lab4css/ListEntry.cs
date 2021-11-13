using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4css
{
    class ListEntry
    {
        public string TitleOfCollection { get; set; }
        public Update TypeOfEvent { get; set; }
        public string NameOfProperty { get; set; }
        public string Key { get; set; }

        public ListEntry(string titleOfCollection, Update typeOfEvent, string nameOfProperty, string key)
        {
            TitleOfCollection = titleOfCollection;
            TypeOfEvent = typeOfEvent;
            NameOfProperty = nameOfProperty;
            Key = key;
        }

        public override string ToString()
        {
            return "Название коллекции: " + TitleOfCollection + "\nПричина вызова: " + TypeOfEvent +
                "\nНазвание свойства: " + NameOfProperty + "\nКлюч: " + Key + "\n";
        }
    }
}
