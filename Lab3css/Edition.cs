using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab3css
{
    class Edition
    {
        protected string title; //Название издания
        protected DateTime dateOfRelease; //Дата выхода
        protected int circulation; //Тираж

        public Edition(string titleValue, DateTime dateOfReleaseValue, int circulationValue)
        {
            title = titleValue;
            dateOfRelease = dateOfReleaseValue;
            circulation = circulationValue;
        }

        public Edition()
        {
            title = " ";
            dateOfRelease = new DateTime();
            circulation = 0;
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public DateTime DateOfRelease
        {
            get
            {
                return dateOfRelease;
            }
            set
            {
                dateOfRelease = value;
            }
        }

        public int Circulation
        {
            get
            {
                return circulation;
            }
            set
            {
                try
                {
                    if (value >= 0)
                    {
                        circulation = value;
                    }
                    else
                        throw new Exception("The value below zero");
                }
                catch (Exception)
                {
                    Console.WriteLine("The value below zero, try again");
                }
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Edition p = (Edition)obj;
                return ((title == p.title) && (dateOfRelease == p.dateOfRelease)
                    && (circulation == p.circulation));
            }
        }

        public static bool operator ==(Edition obj1, Edition obj2)
        {
            return ((obj1.title == obj2.title) &&
                (obj1.dateOfRelease == obj2.dateOfRelease)
                && (obj1.circulation == obj2.circulation));
        }

        public static bool operator !=(Edition obj1, Edition obj2)
        {
            return !((obj1.title == obj2.title) &&
                (obj1.dateOfRelease == obj2.dateOfRelease)
                && (obj1.circulation == obj2.circulation));
        }

        public override int GetHashCode()
        {
            return title.GetHashCode() + dateOfRelease.GetHashCode() + circulation.GetHashCode();
        }

        public override string ToString()
        {
            return ("Название издания: " + title + "\nДата выхода: " +  dateOfRelease.ToShortDateString() + "\nТираж: " + circulation.ToString());
        }

        public virtual object DeepCopy()
        {
            return (new Edition(title, dateOfRelease, circulation));
        }
    }
}
