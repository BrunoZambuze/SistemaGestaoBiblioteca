using System;
using SistemaGestaoBiblioteca.Entidades;

namespace SistemaGestaoBiblioteca.Entidades.Interface
{
    interface IEmprestimo
    {
        public Livro LivroEmprestado { get; }
        public Usuario UsuarioEmprestimo { get; }
    }
}
