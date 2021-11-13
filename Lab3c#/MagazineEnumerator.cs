using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab3cs
{
    class MagazineEnumerator : IEnumerator
    {
        public List<Article> articlesAutorsNotRedactors = new List<Article>();
        

        int position = -1;

        public MagazineEnumerator(List<Article> listOfArticles, List<Person> listOfRedactors)
        {
            bool check;
            foreach (Article article in listOfArticles)
            {
                check = true;
                foreach (Person person in listOfRedactors)
                {
                    if (article.person == person)
                    {
                        check = false;
                        break;
                    }
                }
                if (check == true)
                    articlesAutorsNotRedactors.Add(article);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Article Current
        {
            get
            {
                try
                {
                    return (Article)articlesAutorsNotRedactors[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < articlesAutorsNotRedactors.Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
