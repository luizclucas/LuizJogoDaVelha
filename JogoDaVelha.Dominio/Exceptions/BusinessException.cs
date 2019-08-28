using System;

namespace JogoDaVelha.Dominio.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base (message)
        {

        }
    }
}
