using System;

namespace JogoDaVelha.Dominio.Exceptions
{
    public class PosicaoInvalidaException : BusinessException
    {
        public PosicaoInvalidaException(string message) : base (message)
        {

        }
    }
}
