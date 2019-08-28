using JogoDaVelha.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogoDaVelha.Dominio.Interfaces.Repositorios
{
    public interface IPartidaRepositorio
    {
        void SalvarPartida(Partida partida);
        Partida RetornaPartida(Guid partidaId);
        IList<Partida> RetornaTodasPartidas();
    }
}
