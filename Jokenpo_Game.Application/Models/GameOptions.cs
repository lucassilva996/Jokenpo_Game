using Jokenpo_Game.Application.Enums;
using Jokenpo_Game.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jokenpo_Game.Application.Models
{
    public class GameOptions : IGameOptions
    {
        public List<Options> OptionsPaperWinning()
        {
            return new List<Options>
            {
                Options.Rock
            };
        }

        public List<Options> OptionsRockWinning()
        {
            return new List<Options>
            {
                Options.Scissors
            };
        }

        public List<Options> OptionsScissorsWinning()
        {
            return new List<Options>
            {
                Options.Paper
            };
        }
    }
}
