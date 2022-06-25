using OptionsGame.Entities;

namespace OptionsGame.Decorators
{
    public abstract class SelectionDecorator
    {
        protected Player _player;

        public abstract void SetSelectedOption(int maxValue);
    }
}
