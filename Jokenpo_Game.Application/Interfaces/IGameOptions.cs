using Jokenpo_Game.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jokenpo_Game.Application.Interfaces
{
    public interface IGameOptions
    {
        public List<Options> OptionsRockWinning();
        public List<Options> OptionsPaperWinning();
        public List<Options> OptionsScissorsWinning();

    }
}
