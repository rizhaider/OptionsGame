using System.Collections.Generic;

namespace OptionsGame
{
    public class AvailableOptions
    {
        public List<string> Options { get; set; }

        public AvailableOptions()
        {
            Options = new List<string>();
            Options.Add("ROCK");
            Options.Add("SCISSOR");
            Options.Add("PAPER");
        }

        public void InsertAnOption(string name, int? index)
        {
            string nameOfOption = name.Trim().ToUpper();

            if(nameOfOption.Length <= 0)
            {
                return;
            }

            if (index.HasValue)
            {
                index--;
                if (index.Value >= Options.Count)
                {
                    Options.Add(nameOfOption);
                }
                else if (index < 0)
                {
                    Options.Insert(0, nameOfOption);
                }
                else
                {
                    Options.Insert(index.Value, nameOfOption);
                }
            }
            else
            {
                Options.Add(nameOfOption);
            }
        }

        public bool IsSelectedOptionValid(int selectedOption)
        {
            return selectedOption >= 1 && selectedOption <= Options.Count;
        }

        public int Win(int p1Val, int p2Val)
        {
            if(p1Val == Options.Count - 1 && p2Val == 0)
            {
                p1Val = -1;
            }

            if (p2Val == Options.Count - 1 && p1Val == 0)
            {
                p2Val = -1;
            }

            // +ve p1 wins | -ve p2 wins | 0 tie
            return p2Val - p1Val;
        }
    }
}
