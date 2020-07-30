using System;
using System.Collections.Generic;
using System.Text;

namespace _07302020_MovieList
{
    class Movie
    {
        #region _fields
        private string _title;
        private string _category;
        #endregion

        #region properties
        public string Title
        {
            get { return _title; }
            set { _title = value; } 
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        #endregion

        #region Constructor
        public Movie() { }
        public Movie(string Title, string Category) 
        {
            _title = Title; _category = Category;
        }
        #endregion

        #region Methods
        public static void ListMovies(List<Movie> movieList,string category)
        {
            for (int i = 0; i < movieList.Count; i++)
            {
                if(movieList[i].Category ==category)
                {
                    Console.WriteLine(movieList[i].Title);
                }
            }

        }
        #endregion

    }
}
