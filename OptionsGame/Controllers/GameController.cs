using System;
using System.Collections.Generic;
using OptionsGame.Decorators;
using OptionsGame.Entities;
using OptionsGame.Helpers;

namespace OptionsGame.Controllers
{
    public class GameController
    {
        private readonly AvailableOptions _availableOptions;
        private Player _player1;
        private Player _player2;
        private int _gameOption;
        SelectionDecorator _selectionDecorator;
        private readonly List<string> _options;
        public GameController(AvailableOptions availableOptions)
        {
            _availableOptions = availableOptions;
            _options = _availableOptions.Options;
            _player1 = new Player();
            _player2 = new Player();
        }

        public void StartGame()
        {
            Console.Clear();
            GameHeading.PrintGameHeading();
            Console.WriteLine("***   PLAY MENU   ***\n");
            Console.WriteLine("Select playing options");
            Console.WriteLine("======================");
            Console.Write("1: One Player (with Computer) | 2: Two Player (two humans) | 3: One Player (with Computer - Random)\t");
            bool validOption = false;

            do
            {
                _gameOption = GetParsedSelectedValue(3);
                Console.WriteLine();

                Console.Write("Enter Player 1 name:");
                _player1.Name = Console.ReadLine();

                Console.WriteLine();


                switch (_gameOption)
                {
                    case 1:
                        validOption = true;
                        _player2.Name = "(Computer)";
                        _selectionDecorator = new ComputerPlayerDecorator(_player2);
                        break;
                    case 2:
                        validOption = true;
                        Console.Write("Enter Player 2 name:");
                        _player2.Name = Console.ReadLine();
                        break;
                    case 3:
                        validOption = true;
                        _player2.Name = "(Computer - Random)";
                        _selectionDecorator = new RandomSelectionDecorator(_player2);
                        break;

                    default:
                        validOption = false;
                        break;
                }
            } while (!validOption);

            Console.Clear();

            PlayGame();
        }

        private void PlayGame()
        {
            Console.WriteLine("Please select one of the options below:\n");
            for (int i = 0; i < _options.Count; i++)
            {
                Console.Write($"{i + 1}: {_options[i]}\t");
            }
            Console.WriteLine("\n===========================================\n\n");

            int round = 1;
            bool gameEnded = false;
            while (!gameEnded)
            {
                Console.WriteLine($"###### Round {round} ######");
                Console.Write($"{_player1.Name}:\t");
                _player1.SelectedOption = GetSelectedValue();

                switch(_gameOption)
                {
                    case 1:
                    case 3:
                        _selectionDecorator.SetSelectedOption(_options.Count);
                        break;
                    case 2:
                        Console.Write($"\n{_player2.Name}:\t");
                        _player2.SelectedOption = GetSelectedValue();
                        break;

                }

                Console.WriteLine($"\n{_player1.Name} selected: {_options[_player1.SelectedOption]} \t {_player2.Name} selected: {_options[_player2.SelectedOption]}");

                int result = _availableOptions.Win(_player1.SelectedOption, _player2.SelectedOption);

                if (result == 0)
                {
                    Console.WriteLine("Both players selected same values, the round will be restarted");
                    continue;
                } else if (result > 0)
                {
                    _player1.RoundsWin++;
                } else
                {
                    _player2.RoundsWin++;
                }

                if (_player1.RoundsWin == 3 || _player2.RoundsWin == 3)
                {
                    gameEnded = true;
                }

                round++;
                Console.WriteLine("\n### Score ###");
                Console.WriteLine($"{_player1.Name}: {_player1.RoundsWin} | {_player2.Name}: {_player2.RoundsWin}\n");
            }

            Console.WriteLine("\n\n#########################");
            Console.WriteLine(_player1.RoundsWin - _player2.RoundsWin > 0 ? $"***   {_player1.Name} Wins!!   ***" : $"***   {_player2.Name} Wins!!   ***");
            Console.WriteLine("#########################\n\n");

        }

        private int GetSelectedValue()
        {
            int selectedOption = 0;
            bool isSelectionValid = false;
            do
            {
                selectedOption = GetParsedSelectedValue(_options.Count);

                isSelectionValid = _availableOptions.IsSelectedOptionValid(selectedOption);
                if (!isSelectionValid)
                {
                    Console.WriteLine($"Please select values from 1 to {_options.Count}");
                }
            } while (!isSelectionValid);

            return selectedOption - 1;
        }

        private int GetParsedSelectedValue(int maxValue)
        {
            int selectedOption = 0;
            while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out selectedOption))
            {
                Console.WriteLine($"Please select valid numeric values from 1 to {maxValue}");
            }
            return selectedOption;
        }
    }
}
