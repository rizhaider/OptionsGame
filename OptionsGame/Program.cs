using System;
using OptionsGame.Controllers;
using OptionsGame.Helpers;

namespace OptionsGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            AvailableOptions availableOptions = new AvailableOptions();
            MainMenu(availableOptions);
        }

        private static void MainMenu(AvailableOptions availableOptions)
        {
            bool invalidOption = true;
            Console.Clear();

            while (invalidOption)
            {
                GameHeading.PrintGameHeading();
                Console.WriteLine("***  MAIN MENU ***\n");
                Console.WriteLine("Press 'P' to play game or 'O' for Options or 'ESC' to exit:\t");
                
                ConsoleKey option = Console.ReadKey().Key;

                switch (option)
                {
                    case ConsoleKey.Escape:
                        invalidOption = false;
                        break;
                    case ConsoleKey.O:
                        OptionsController optionsController = new OptionsController(availableOptions);
                        optionsController.Menu();
                        break;
                    case ConsoleKey.P:
                        GameController gameController = new GameController(availableOptions);
                        gameController.StartGame();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
