using JogoDaVelha.Dominio.Entidades;
using JogoDaVelha.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaVelha.Infra.Dados.Repositorio
{
    public class PartidaRepositorio : IPartidaRepositorio
    {
        #region [ PROPRIEDADES ]

        #endregion
        private IList<Partida> Partidas { get; set; } = new List<Partida>();

        #region [ CONSTRUTOR ]
        public PartidaRepositorio()
        {

        }
        #endregion

        #region [ MÉTODOS ]
        public void SalvarPartida(Partida partida)
        {
            var partidaASerSalva = Partidas.FirstOrDefault(p => p.PartidaId == partida.PartidaId);

            if (partidaASerSalva != null)
                Partidas.Remove(partidaASerSalva);

            Partidas.Add(partida);
        }

        public Partida RetornaPartida(Guid partidaId)
        {
            return Partidas.FirstOrDefault(p => p.PartidaId == partidaId);
        }

        public IList<Partida> RetornaTodasPartidas()
        {
            return Partidas;
        }
        #endregion



    }
}
