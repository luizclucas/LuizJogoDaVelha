using JogoDaVelha.Dominio.Entidades;
using JogoDaVelha.Dominio.Servicos;
using JogoDaVelha.Infra.Dados.Repositorio;
using Xunit;

namespace JogoDaVelha.Infra.Tests
{
    public class ChecarVencedorTest
    {
        private PartidaServico _partidaServico;
        public ChecarVencedorTest()
        {
            _partidaServico = new PartidaServico(new PartidaRepositorio());
        }

        [Fact]
        public void Ganhar_Na_Diagonal_Nao_Principal()
        {
            Partida partida = new Partida();

            partida.Papel = new string[,]
                {
                    { Jogador.JogadorO, Jogador.JogadorO, Jogador.JogadorX},
                    { Jogador.JogadorX, Jogador.JogadorO, Jogador.JogadorX },
                    { Jogador.Empty, Jogador.Empty, Jogador.JogadorO}
                };

            var response = _partidaServico.ChecarVencedor(partida);

            Assert.Equal(Jogador.JogadorO, response.vencedor);
        }

        [Fact]
        public void Ganhar_Na_Diagonal_Principal()
        {
            Partida partida = new Partida();

            partida.Papel = new string[,]
                {
                    { Jogador.Empty, Jogador.Empty, Jogador.JogadorO},
                    { Jogador.JogadorX, Jogador.JogadorO, Jogador.JogadorX },
                    { Jogador.JogadorO, Jogador.Empty, Jogador.Empty}
                };

            var response = _partidaServico.ChecarVencedor(partida);

            Assert.Equal(Jogador.JogadorO, response.vencedor);
        }


        [Fact]
        public void Ganhar_Na_Primeira_Linha()
        {
            Partida partida = new Partida();

            partida.Papel = new string[,]
                {
                    { Jogador.JogadorO, Jogador.JogadorO, Jogador.JogadorO},
                    { Jogador.JogadorX, Jogador.JogadorX, Jogador.Empty },
                    { Jogador.JogadorO, Jogador.JogadorX, Jogador.JogadorO}
                };

            var response = _partidaServico.ChecarVencedor(partida);

            Assert.Equal(Jogador.JogadorO, response.vencedor);
        }


        [Fact]
        public void Ganhar_Na_Segunda_Linha()
        {
            Partida partida = new Partida();

            partida.Papel = new string[,]
                {
                    { Jogador.JogadorO, Jogador.JogadorO, Jogador.Empty},
                    { Jogador.JogadorX, Jogador.JogadorX, Jogador.JogadorX },
                    { Jogador.JogadorO, Jogador.JogadorX, Jogador.JogadorO}
                };

            var response = _partidaServico.ChecarVencedor(partida);

            Assert.Equal(Jogador.JogadorX, response.vencedor);
        }

        [Fact]
        public void Ganhar_Na_Terceira_Linha()
        {
            Partida partida = new Partida();

            partida.Papel = new string[,]
                {
                    { Jogador.JogadorO, Jogador.JogadorX, Jogador.Empty},
                    { Jogador.JogadorX, Jogador.JogadorX, Jogador.Empty },
                    { Jogador.JogadorO, Jogador.JogadorO, Jogador.JogadorO}
                };

            var response = _partidaServico.ChecarVencedor(partida);

            Assert.Equal(Jogador.JogadorO, response.vencedor);
        }

        [Fact]
        public void Ganhar_Na_Primeira_Coluna()
        {
            Partida partida = new Partida();

            partida.Papel = new string[,]
                {
                    { Jogador.JogadorO, Jogador.JogadorO, Jogador.JogadorX},
                    { Jogador.JogadorO, Jogador.JogadorX, Jogador.Empty },
                    { Jogador.JogadorO, Jogador.JogadorX, Jogador.Empty}
                };

            var response = _partidaServico.ChecarVencedor(partida);

            Assert.Equal(Jogador.JogadorO, response.vencedor);
        }

        [Fact]
        public void Ganhar_Na_Segunda_Coluna()
        {
            Partida partida = new Partida();

            partida.Papel = new string[,]
                {
                    { Jogador.Empty, Jogador.JogadorX, Jogador.Empty},
                    { Jogador.JogadorO, Jogador.JogadorX, Jogador.Empty },
                    { Jogador.JogadorO, Jogador.JogadorX, Jogador.Empty}
                };

            var response = _partidaServico.ChecarVencedor(partida);

            Assert.Equal(Jogador.JogadorX, response.vencedor);
        }

        [Fact]
        public void Ganhar_Na_Terceira_Coluna()
        {
            Partida partida = new Partida();

            partida.Papel = new string[,]
                {
                    { Jogador.Empty, Jogador.Empty, Jogador.JogadorO},
                    { Jogador.JogadorO, Jogador.JogadorX, Jogador.JogadorO },
                    { Jogador.JogadorX, Jogador.JogadorX, Jogador.JogadorO}
                };

            var response = _partidaServico.ChecarVencedor(partida);

            Assert.Equal(Jogador.JogadorO, response.vencedor);
        }

        [Fact]
        public void Empate()
        {
            Partida partida = new Partida();

            partida.Papel = new string[,]
                {
                    { Jogador.JogadorX, Jogador.JogadorO, Jogador.JogadorO},
                    { Jogador.JogadorO, Jogador.JogadorX, Jogador.JogadorX },
                    { Jogador.JogadorO, Jogador.JogadorX, Jogador.JogadorO}
                };

            var response = _partidaServico.ChecarVencedor(partida);

            Assert.True(response.deuEmpate);
        }
    }
}
