using System;

namespace SistemaGestaoBiblioteca.Entidades.Exception
{
    internal class ExceptionDomain : ApplicationException
    {
        public ExceptionDomain(string mensage) : base(mensage)
        {
        }
    }
}
