using System;

namespace JogoDaVelha.Dominio.Exceptions
{
    public class PartidaInexistenteException : BusinessException
    {
        public PartidaInexistenteException(string message) : base(message)
        {

        }
    }
}
