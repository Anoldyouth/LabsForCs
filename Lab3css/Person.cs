using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3css
{

    class Person
    {
        string name;
        string surname;
        DateTime birthday;
       
        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;
        }

        public Person():this("Иван", "Иванов", new DateTime(2000, 1, 1))
        {
        }
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }

        public int Year
        {
            get
            {
                return Birthday.Year;
            }
            set
            {
                Birthday = new DateTime(value, Birthday.Month, Birthday.Day);
            }
        }

        public override string ToString()
        {
            return "Имя: " + Name + "\nФамилия: " + Surname + "\nДата рождения: " + Birthday.ToShortDateString();
        }

        public virtual string ToShortString()
        {
            return "Имя: " + Name + "\nФамилия: " + Surname;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) 
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return ((name == p.name) && (surname == p.surname) && (birthday == p.birthday));
            }
        }

        public static bool operator ==(Person obj1, Person obj2)
        {
            return ((obj1.name == obj2.name) && (obj1.surname == obj2.surname) && (obj1.birthday == obj2.birthday));
        }

        public static bool operator !=(Person obj1, Person obj2)
        {
            return !(obj1 == obj2);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + surname.GetHashCode() + birthday.GetHashCode();
        }

        virtual public object DeepCopy()
        {
            return (new Person(name, surname, birthday));
        }
    }
}
