using System;
using System.Collections.Generic;

namespace _07302020_MovieList
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;

            #region Lists
            List<string> cat = new List<string>
                {
                    "animated",
                    "drama",
                    "horror",
                    "sci-fi",
                    "fantasy",
                    "comedy"
                };

            List<Movie> movieList = new List<Movie>
                {   new Movie("Zootopia", cat[0]),
                    new Movie("Star Wars: A New Hope", cat[4]),
                    new Movie("Star Wars: Empire Strikes Back", cat[4]),
                    new Movie("The Rescuers Down Under",cat[0]),
                    new Movie("Home Alone",cat[2]),
                    new Movie("Princess Mononoke",cat[0]),
                    new Movie("Saw 13",cat[2]),
                    new Movie("Karate Kid",cat[1]),
                    new Movie("Hot Fuzz",cat[5]),
                    new Movie("2001: A Space Odyssey",cat[3]),
                    new Movie("Spaceballs: The Movie",cat[5])
                };
            #endregion

            while (!end)
            {
                PrintGreen("Welcome to the Movie List Application!");
                PrintGreen($"There are {movieList.Count} movies in the list. We support the following categories of film: ");
                ShowMainMenu(cat);
                ListMovies(movieList, ValidateCategory(GetInput("What category are you interested in?"), cat));
                end = ContinuePlay("Do you want to search for more movies?");
            }

        }

        public static bool ContinuePlay(string message)
        {
            //This method prompts the used for "y" or "n", repeating the program if "y" is entered and terminating if "n" is entered.

            bool end = false;
            string cont = "";

            while (cont.ToLower() != "n")
            {
                cont = GetInput(message);
                if (cont == "y")
                {
                    Console.Clear();
                    break;
                }
                else if (cont == "n")
                {
                    end = true;
                }
                else
                {
                    PrintGreen("Invalid input. Please enter (y) to continue and (n) to exit.");
                }
            }
            return end;
        }
        public static void PrintGreen(string message)
        {
            //used to output green text from console

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintCyan(string message)
        {
            //Used to make output lists cyan

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string GetInput(string message)
        {
            //This method prompts the user for input, then passes the input to the console.

            string input = "";
            PrintGreen(message);
            input = Console.ReadLine();
            return input;

        }
        public static void ListMovies(List<Movie> movieList, string category)
        {
            //movieMatchList is made to house movies that match the category that the user entered, which are then sorted alphabetically.

            Console.Clear();
            List<string> movieMatchList = new List<string>();

            //This capitalizes tha first letter of the category,and provides a header
            PrintGreen($"{category.Substring(0, 1).ToUpper() + category.Substring(1)} Movies in our database: ");

            //builds list for matches
            for (int i = 0; i < movieList.Count; i++)
            {
                if (movieList[i].Category == category)
                {
                    movieMatchList.Add(movieList[i].Title);
                }
            }

            movieMatchList.Sort();
            for (int i = 0; i < movieMatchList.Count; i++)
            {
                PrintCyan($"{i+1}. {movieMatchList[i]}");
            }

        }
        public static string ValidateCategory(string input, List<string> categories)
        {
            //This method validates that an entry was entered first, and that it corresponds to the categories contained in the List<string> categories
            //Either the numeric menu choice or the word will return the corresponding category

            while (true)
            {
                int menu = 0;
                if (input.Trim() == "")
                {
                    input = GetInput("I'm sorry, what was that? Please input a  film category (Animated, Drama, Horror, Sci-fi, Fantasy, or Comedy)");

                }
                else if (int.TryParse(input, out menu))
                {
                    return categories[menu];
                }
                else if (categories.Contains(input.ToLower()))
                {
                    return input;
                }
                else
                {
                    input = GetInput("Input Error; please input a  film category (Animated, Drama, Horror, Sci-fi, Fantasy, or Comedy)");
                }
            }
        }
        public static void ShowMainMenu(List<string> list)
        {
            //This method prints out the menu of categories for the user

            Console.WriteLine("");
            for (int i = 0; i < list.Count; i++)
            {
                PrintCyan($"{i}. {list[i]}");
            }

        }
    }
}
