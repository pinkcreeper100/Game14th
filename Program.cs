using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Game14th
{
    internal class Game
    {
        private string _ageRating;
        public Game(string title, string ageRating)
        {
            GetSetTitle = title;
            _ageRating = ageRating;
        }
        public string GetSetTitle { get; set; }

        public string GetSetAgeRating
        {
            get => _ageRating;
            set
            {
                if (value == "7" || value == "12" || value == "16" || value == "18")
                {
                    _ageRating = value;
                }
            }
        }
    }

    internal static class Menu
    {
        public static void Return()
        {
            Console.WriteLine("Press Enter to return to the menu");
            Console.ReadLine();
            for (var i = 5; i != 0; i--)
            {
                Console.WriteLine("Returning to menu in " + i);
                Thread.Sleep(1000);
            }
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            // create list
            var games = new List<Game>
            {
                new Game("Halo infinite", "12"),
                new Game("Assassin's Creed", "18"),
                new Game("Lego Star Wars","7")
            };
            // fix capitalisation
            foreach (var game in games.Where(game=>game.GetSetTitle=="Halo infinite"))
            {
                game.GetSetTitle = "Halo Infinite";
            }
            // set ageRating of Halo Infinite to 16
            foreach (var game in games.Where(game=>game.GetSetTitle=="Halo Infinite"))
            {
                game.GetSetAgeRating = "16";
            }
            string menuSelection;
            do
            {
                Console.Clear();
                Console.WriteLine("Add game [A/a]\nOutput all games [O/o]\nOutput all games where ageRating == 18\nExit [X/x]");
                menuSelection = Console.ReadLine();
                if (menuSelection == "A" | menuSelection == "a")
                {
                    Console.WriteLine("\nEnter Game Title\n");
                    string title;
                    do
                    {
                        title = Console.ReadLine();
                        if (title == null)
                        {
                            Console.WriteLine("\nInvalid Title Length, try again\n");
                        }
                    } while (title == null);

                    Console.WriteLine("\nEnter Age Rating\n");
                    string ageRating;
                    do
                    {
                        ageRating = Console.ReadLine();

                        if (ageRating == "3")
                        {
                            Console.WriteLine("Age Rating has to be 7 or higher\n");
                        }
                        else if (ageRating != "7" && ageRating != "12" && ageRating != "16" && ageRating != "18")
                        {
                            Console.WriteLine("Invalid Age Rating, try again\n");
                        }
                    } while (ageRating != "7" && ageRating != "12" && ageRating != "16" && ageRating != "18");

                    games.Add(new Game(title, ageRating));
                    Menu.Return();
                }

                else if (menuSelection == "O" | menuSelection == "o")
                {
                    foreach (var game in games)
                    {
                        Console.WriteLine(game.GetSetTitle);
                    }
                    Menu.Return();
                }

                else if (!(menuSelection == "G" | menuSelection == "g")) continue;
                {
                    foreach (var game in games.Where(game => game.GetSetAgeRating == "18"))
                    {
                        Console.WriteLine(game.GetSetTitle);
                    }
                    Menu.Return();
                }
            } while (menuSelection != "X" || menuSelection != "x");
        }
    }
}
