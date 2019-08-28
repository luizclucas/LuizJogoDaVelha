using JogoDaVelha.Dominio.Entidades;
using JogoDaVelha.Dominio.Servicos;
using JogoDaVelha.Infra.Dados.Repositorio;
using System;
using Xunit;

namespace JogoDaVelha.Infra.Tests
{
    public class PartidaTest
    {
        private PartidaServico _partidaServico;
        public PartidaTest()
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
    }
}
