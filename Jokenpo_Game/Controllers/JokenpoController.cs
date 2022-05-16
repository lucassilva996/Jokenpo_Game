using Jokenpo_Game.Application.Enums;
using Jokenpo_Game.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jokenpo_Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokenpoController : ControllerBase
    {
        private readonly IGameOptions _gameOptions;

        public JokenpoController(IGameOptions gameOptions)
        {
            _gameOptions = gameOptions;
        }


        /// <summary>
        /// Bem vindo ao Jokenpo, para jogar, basta selecionar um valor de 1 a 3 para cada player e ver o resultado de cada rodada, lembrando que [1 = Pedra | 2 = Papel | 3 = Tesoura]
        /// </summary>
        /// <param name="firstPlayer"></param>
        /// <param name="secondPlayer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ToPlay")]
        public IActionResult ToPlay(Options firstPlayer, Options secondPlayer)
        {
            try
            {
                if(firstPlayer.Equals(secondPlayer))
                {
                    return Ok(new
                    {
                        status = "success",
                        message = "Draw"
                    });
                }

                bool firstPlayerWins;

                switch(firstPlayer)
                {
                    case Options.Rock:
                    {
                       firstPlayerWins = _gameOptions.OptionsRockWinning().Contains(secondPlayer);
                       break;
                    }
                    
                    case Options.Paper:
                    {
                       firstPlayerWins = _gameOptions.OptionsPaperWinning().Contains(secondPlayer);
                       break;
                    }

                    case Options.Scissors:
                    {
                       firstPlayerWins = _gameOptions.OptionsScissorsWinning().Contains(secondPlayer);
                       break;
                    }

                    default:
                        throw new ArgumentOutOfRangeException(nameof(firstPlayer), firstPlayer, null);
                }
                return Ok(new
                {
                    status = "success",
                    message = $"Player {(firstPlayerWins ? "1" : "2")} wins!"
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    status = "error",
                    message = ex.Message
                });
            }
            
        }
    }
}
