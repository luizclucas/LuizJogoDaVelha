using System;

namespace JogoDaVelha.Dominio.Exceptions
{
    public class PosicaoJaUtilizadaException : BusinessException
    {
        public PosicaoJaUtilizadaException(string message) : base (message)
        {

        }
    }
}
