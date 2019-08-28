using JogoDaVelha.Dominio.Entidades;
using JogoDaVelha.Dominio.Exceptions;
using JogoDaVelha.Dominio.Interfaces.Repositorios;
using JogoDaVelha.Dominio.Responses;
using System;
using System.Linq;

namespace JogoDaVelha.Dominio.Servicos
{
    public class PartidaServico
    {

        #region [ PROPRIEDADES ]
        private IPartidaRepositorio PartidaRepositorio { get; }
        #endregion

        #region [ CONSTRUTOR ]
        public PartidaServico(IPartidaRepositorio partidaRepositorio)
        {
            PartidaRepositorio = partidaRepositorio;
        }
        #endregion

        #region [ MÉTODOS ]
        public Partida CriarPartida()
        {
            var partida = new Partida();

            var random = new Random();
            if (random.NextDouble() <= 0.5)
            {
                partida.SetProximoJogador(Jogador.JogadorX);
            }
            else
            {
                partida.SetProximoJogador(Jogador.JogadorO);
            }

            PartidaRepositorio.SalvarPartida(partida);
            return partida;
        }

        public Response FazerJogada(Guid partidaId, string jogador, int posicaoX, int posicaoY)
        {
            var partida = PartidaRepositorio.RetornaPartida(partidaId);

            if (partida == null)
            {
                throw new PartidaInexistenteException("Partida não encontrada");
            }

            if (partida.Terminou)
            {
                throw new PartidaInexistenteException("Partida finalizada");
            }

            if (partida.ProximoJogador != jogador.ToUpper())
            {
                throw new ProximoJogadorException("Não é turno do jogador");
            }

            if (posicaoX > 2 || posicaoY > 2)
            {
                throw new PosicaoInvalidaException("Posição inválida");
            }

            if (partida.Papel[posicaoX, posicaoY] != Jogador.Empty)
            {
                throw new PosicaoJaUtilizadaException("Posição já utilizada");
            }

            partida.Papel[posicaoX, posicaoY] = jogador;
            partida.SetProximoJogador(jogador.ToUpper() == Jogador.JogadorX ? Jogador.JogadorO : Jogador.JogadorX);

            var retornoFimPartida = ChecarVencedor(partida);     

            Response response = new Response();

            if (retornoFimPartida.vencedor != null || retornoFimPartida.deuEmpate)
            {
                response.PartidaFinalizada = true;
                response.DeuEmpate = retornoFimPartida.deuEmpate;
                response.Winner = retornoFimPartida.vencedor;
            }

            response.JogadaRealizadaComSucesso = true;

            PartidaRepositorio.SalvarPartida(partida);

            return response;
        }

        public (string vencedor, bool deuEmpate) ChecarVencedor(Partida partida)
        {
            var retorno = ChecarColunas(partida);

            if (retorno.vencedor != null || retorno.deuEmpate)
            {
                return retorno;
            }

            retorno.vencedor = ChecarLinhas(partida);

            if (retorno.vencedor != null)
                return (retorno.vencedor, false);

            return (ChecarDiagonal(partida), false);
        }

        public (string vencedor, bool deuEmpate) ChecarColunas(Partida partida)
        {
            int countEmpate = 0;

            for (int x = 0; x < 3; x++)
            {
                int countJogadorX = 0;
                int countJogadorO = 0;

                for (int y = 0; y < 3; y++)
                {
                    if (partida.Papel[x, y].ToUpper() == Jogador.JogadorO)
                    {
                        countJogadorO++;
                        countEmpate++;
                    }
                    else if (partida.Papel[x, y].ToUpper() == Jogador.JogadorX)
                    {
                        countJogadorX++;
                        countEmpate++;
                    }

                    if (countJogadorX == 3)
                    {
                        return (Jogador.JogadorX, false);
                    }
                    if (countJogadorO == 3)
                    {
                        return (Jogador.JogadorO, false);
                    }
                }
            }

            if (countEmpate == 9)
                return (null, true);

            return (null, false);
        }

        public string ChecarLinhas(Partida partida)
        {
            for (int y = 0; y < 3; y++)
            {
                int countJogadorX = 0;
                int countJogadorO = 0;

                for (int x = 0; x < 3; x++)
                {
                    if (partida.Papel[x, y].ToUpper() == Jogador.JogadorO)
                    {
                        countJogadorO++;
                    }
                    else if (partida.Papel[x, y].ToUpper() == Jogador.JogadorX)
                    {
                        countJogadorX++;
                    }

                    if (countJogadorX == 3)
                    {
                        return Jogador.JogadorX;
                    }
                    if (countJogadorO == 3)
                    {
                        return Jogador.JogadorO;
                    }
                }
            }

            return null;
        }

        public string ChecarDiagonal(Partida partida)
        {
            int countJogadorX = 0;
            int countJogadorO = 0;

            for (int x = 0; x < 3; x++)
            {      
                for (int y = 0; y < 3; y++)
                {
                    if (y == x && partida.Papel[x, y].ToUpper() == Jogador.JogadorO)
                    {
                        countJogadorO++;
                    }
                    else if (y == x && partida.Papel[x, y].ToUpper() == Jogador.JogadorX)
                    {
                        countJogadorX++;
                    }


                    if (countJogadorX == 3)
                    {
                        return Jogador.JogadorX;
                    }
                    if (countJogadorO == 3)
                    {
                        return Jogador.JogadorO;
                    }
                }
            }

            countJogadorX = 0;
            countJogadorO = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (y + x == 2 && partida.Papel[x, y].ToUpper() == Jogador.JogadorO)
                    {
                        countJogadorO++;
                    }
                    else if (y + x == 2 && partida.Papel[x, y].ToUpper() == Jogador.JogadorX)
                    {
                        countJogadorX++;
                    }

                    if (countJogadorX == 3)
                    {
                        return Jogador.JogadorX;
                    }
                    if (countJogadorO == 3)
                    {
                        return Jogador.JogadorO;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
