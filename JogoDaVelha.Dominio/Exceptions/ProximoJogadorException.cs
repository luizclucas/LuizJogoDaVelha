using System;

namespace JogoDaVelha.Dominio.Exceptions
{
    public class ProximoJogadorException : BusinessException
    {
        public ProximoJogadorException(string message) : base (message)
        {

        }
    }
}
