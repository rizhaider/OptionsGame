using System;
using OptionsGame.Helpers;

namespace OptionsGame.Controllers
{
    public class OptionsController
    {
        private readonly AvailableOptions _availableOptions;

        public OptionsController(AvailableOptions availableOptions)
        {
            _availableOptions = availableOptions;
        }

        public void Menu()
        {
            bool options = true;

            while (options)
            {
                Console.Clear();

                GameHeading.PrintGameHeading();

                Console.WriteLine("***   Options Menu   ***\n");

                for (int i = 0; i < _availableOptions.Options.Count; i++)
                {
                    Console.Write($"{i + 1}: {_availableOptions.Options[i]}\t");
                }
                Console.WriteLine("\n===========================================\n\n");

                Console.WriteLine("Press any key to continue or 'ESC' to main screen:\t");

                ConsoleKey option = Console.ReadKey().Key;

                if (option == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return;
                }

                Console.Write("Enter new option to add:\t");
                string name = Console.ReadLine();

                Console.Write("\nEnter index where to insert in the list.\t");

                int index = 0;
                while (!int.TryParse(Console.ReadLine(), out index))
                {
                    Console.WriteLine($"Please enter numeric value only.");
                }

                _availableOptions.InsertAnOption(name, index);
            }
        }
    }
}
