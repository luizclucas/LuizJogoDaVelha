using System;

namespace JogoDaVelha.Dominio.Exceptions
{
    public class PartidaFinalizadaException : BusinessException
    {
        public PartidaFinalizadaException(string message) : base (message)
        {

        }
    }
}
