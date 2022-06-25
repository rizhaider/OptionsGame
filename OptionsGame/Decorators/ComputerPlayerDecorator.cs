using System;
using OptionsGame.Entities;

namespace OptionsGame.Decorators
{
    public class ComputerPlayerDecorator : SelectionDecorator
    {
        public ComputerPlayerDecorator(Player player)
        {
            _player = player;
        }

        public override void SetSelectedOption(int maxValue)
        {
            if (_player.SelectedOption < 0)
            {
                Random random = new Random();
                _player.SelectedOption = random.Next(maxValue);
            }
            else if (_player.SelectedOption == 0)
            {
                _player.SelectedOption = maxValue - 1;
            }
            else
            {
                _player.SelectedOption--;
            }
        }
    }
}
