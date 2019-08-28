using System;

namespace JogoDaVelha.Dominio.Entidades
{
    public class Partida
    {

        #region [ PROPRIEDADES ]
        public Guid PartidaId { get; protected set; }
        public bool Terminou { get; protected set; }
        public string Resultado { get; protected set; }
        public string ProximoJogador { get; protected set; }
        public string[,] Papel { get; set; }
        #endregion


        #region [ CONSTRUTOR ]
        public Partida()
        {
            PartidaId = Guid.NewGuid();
            Terminou = false;
            Papel = new string[3, 3];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Papel[x, y] = Jogador.Empty;
                }
            }
        }
        #endregion

        #region [ MÉTODOS ]
        public void SetProximoJogador(string jogador)
        {
            ProximoJogador = jogador;
        }
        #endregion
    }
}
