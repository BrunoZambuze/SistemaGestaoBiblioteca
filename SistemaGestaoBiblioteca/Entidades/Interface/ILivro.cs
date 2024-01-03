using SistemaGestaoBiblioteca.Entidades.Enum;
using System;

namespace SistemaGestaoBiblioteca.Entidades.Interface
{
    interface ILivro
    {
        public string Autor { get; }
        public string Titulo { get; }
        public int AnoPublicacao { get; }
        public StatusDoLivro Status { get; }

        public void Emprestar();
        public void Devolver();
    }
}
