using JogoDaVelha.Api.ViewModel;
using JogoDaVelha.Dominio.Exceptions;
using JogoDaVelha.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JogoDaVelha.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        #region [ PROPRIEDADES ]
        private PartidaServico _partidaServico;
        #endregion

        public GameController(PartidaServico partidaServico)
        {
            _partidaServico = partidaServico;
        }

        [HttpPost]
        public IActionResult CreateGame()
        {
            var partida = _partidaServico.CriarPartida();
            PartidaCriadaViewModel partidaVM = new PartidaCriadaViewModel()
            {
                FirstPlayer = partida.ProximoJogador,
                Id = partida.PartidaId
            };

            return Ok(partidaVM);
        }

        [HttpPost("{id}/movement")]
        public IActionResult FazerJogada([FromBody] JogadaViewModel jogada)
        {
            try
            {
                var response = _partidaServico.FazerJogada(jogada.Id, jogada.Player, jogada.Position.X, jogada.Position.Y);

                if(response.DeuEmpate)
                {
                    return Ok(new { msg = "Partida finalizada", winner = "Draw" });
                }

                if(response.PartidaFinalizada && !string.IsNullOrEmpty(response.Winner))
                {
                    return Ok(new { msg = "Partida finalizada", winner = response.Winner });
                }

                return Ok();
            }
            catch (Exception e) when (e is BusinessException)
            {
                return NotFound(new { msg = e.Message });
            }
        }
    }
}