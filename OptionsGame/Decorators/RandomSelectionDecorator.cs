using System;
using OptionsGame.Entities;

namespace OptionsGame.Decorators
{
    public class RandomSelectionDecorator : SelectionDecorator
    {
        public RandomSelectionDecorator(Player player)
        {
            _player = player;
        }

        public override void SetSelectedOption(int maxValue)
        {
            Random random = new Random();
            _player.SelectedOption = random.Next(maxValue);
        }
    }
}
