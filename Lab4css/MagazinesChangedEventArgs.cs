namespace Lab4css
{
    class MagazinesChangedEventArgs<TKey> : System.EventArgs
    {
        public string TitleOfCollection { get; set; }
        public Update TypeOfEvent { get; set; }
        public string NameOfProperty { get; set; }
        public TKey Key { get; set; }
        public MagazinesChangedEventArgs(string titleOfCollection, Update typeOfEvent, string nameOfProperty, TKey key)
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