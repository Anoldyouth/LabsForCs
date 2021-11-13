using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab4css
{
    class Magazine : Edition, IRateAndCopy, IEnumerable
    {
        private Frequency period; //Периодичность выпуска
        private List<Person> listOfRedactors = new List<Person>(); //Список редакторов
        private List<Article> listOfArticle = new List<Article>(); //Список статей

        public Frequency Period
        {
            get
            {
                return period;
            }
            set
            {
                period = value;
            }
        }

        public List<Person> ListOfRedactors
        {
            get
            {
                return listOfRedactors;
            }
            set
            {
                listOfRedactors.Clear();
                listOfRedactors.AddRange(value);
            }
        }

        public List<Article> ListOfArticle

        {
            get
            {
                return listOfArticle;
            }
            set
            {
                listOfArticle.Clear();
                listOfArticle.AddRange(value);
            }
        }

        public Magazine(string titleValue, Frequency periodValue,
            DateTime dateOfReleaseValue, int circulationValue)
            : base(titleValue, dateOfReleaseValue, circulationValue)
        {
            period = periodValue;

        }

        public Magazine() : base()
        {
            period = Frequency.Weekly;
        }

        public double Rating
        {
            get
            {
                double summ = 0;
                foreach (Article obj in listOfArticle)
                    summ += obj.rating;
                return summ/listOfArticle.Count;
            }
        }

        public Edition EditionObj
        {
            get
            {
                return (Edition)base.DeepCopy();
            }
            set
            {
                title = value.Title;
                dateOfRelease = value.DateOfRelease;
                circulation = value.Circulation;
            }
        }

        public bool this[Frequency frequency]
        {
            get
            {
                return period == frequency;
            }
        }

        public IEnumerable GetRating (double minRating)
        {
            foreach(Article article in listOfArticle)
            {
                if (article.rating > minRating)
                {
                    yield return article;
                }
            }
        }

        public IEnumerable GetTitles (string titleValue) 
        { 
            foreach(Article article in listOfArticle)
            {
                if (article.title.Contains(titleValue))
                {
                    yield return article;
                }
            }
        }

        public IEnumerable GetAutorsAreRedactor()
        {
            foreach (Article article in listOfArticle)
            {
                foreach (Person person in listOfRedactors)
                {
                    if (article.person == person)
                    {
                        yield return article;
                        break;
                    }
                }
            }
        }

        public IEnumerable GetRedactorsNotAutors()
        {
            bool check;
            foreach (Person person in listOfRedactors)
            {
                check = true;
                foreach (Article article in listOfArticle)
                {
                    if (article.person == person)
                    {
                        check = false;
                        break;
                    }
                }
                if (check == true)
                    yield return person;
            }
        }

        public void AddArticles(params Article[] articles) //Добавление статей
        {
            foreach(Article article in articles)
            {
                listOfArticle.Add(article);
            }
        }

        public void AddRedactors(params Person[] persons) //Добавление редакторов
        {
            foreach (Person person in persons)
            {
                listOfRedactors.Add(person);
            }
        }

        public override string ToString() //Все переменные
        {
            String text ="Периодичность:" + period.ToString() + "\nРейтинг " + Rating.ToString() + "\nРедакторы:\n";
            foreach(Person person in listOfRedactors)
            {
                text +=person.ToString() + "\n";
            }
            text += "Статьи:\n";
            foreach (Article article in listOfArticle)
            {
                text +=article.ToString() + "\n";
            }
            return base.ToString() + "\n" + text;
        }

        public virtual string ToShortString() //Без списков статей и реакторов
        {
            return base.ToString() + "\nПериодичность: " + period.ToString();
        }

        public override object DeepCopy()
        {
            Magazine obj = new Magazine(title, period, dateOfRelease, circulation);
            obj.listOfRedactors.AddRange(listOfRedactors);
            obj.listOfArticle.AddRange(listOfArticle);
            return obj;
        }

        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(listOfArticle, listOfRedactors);
        }

        public List<Article> SortTitle
        {
            get
            {
                List<Article> listCopy = new List<Article>();
                foreach (var obj in listOfArticle)
                    listCopy.Add(obj.DeepCopy() as Article);
                listCopy.Sort();
                return listCopy;
            }
        }

        public List<Article> SortSurname
        {
            get
            {
                List<Article> listCopy = new List<Article>();
                foreach (var obj in listOfArticle)
                    listCopy.Add(obj.DeepCopy() as Article);
                listCopy.Sort(new Article());
                return listCopy;
            }
        }

        public List<Article> SortRating
        {
            get
            {
                List<Article> listCopy = new List<Article>();
                foreach (var obj in listOfArticle)
                    listCopy.Add(obj.DeepCopy() as Article);
                listCopy.Sort(new CompareRating());
                return listCopy;
            }
        }


    }
}
