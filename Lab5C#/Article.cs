using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab4cs
{
    class Article : IRateAndCopy, IComparable, IComparer<Article>
    {
        public Person person { get; set; } //Автор статьи
        public string title { get; set; } //Название статьи

        public double rating; //Рейтинг статьи

        public double Rating 
        {
            get
            {
                return rating;
            }
        }

        public Article(Person personValue, string titleValue, double ratingValue)
        {
            person = personValue;
            title = titleValue;
            rating = ratingValue;
        }

        public Article() : this(new Person(), "name of magazine", 5.0)
        {
        }

        public override string ToString() //Строка со всеми данными
        {
            return person.ToString() + "\nНазвание статьи: " + title + "\nРейтинг: " + rating;
        }

        public object DeepCopy() //Копирование объектов
        {
            Article newObj = new Article(person, title, rating);
            return newObj;
        }



        public int Compare([AllowNull] Article x, [AllowNull] Article y)
        {
            if (x.person.Surname.CompareTo(y.person.Surname) != 0)
            {
                return x.person.Surname.CompareTo(y.person.Surname);
            }
            else return 0;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Article otherObj = obj as Article;
            if (otherObj != null)
                return this.title.CompareTo(otherObj.title);
            else
                throw new ArgumentException("Object is not a Article");
        }
    }
}
