using System;

namespace SistemaGestaoBiblioteca.Entidades.Interface
{
    interface IDevolucao
    {
        public Livro LivroDevolucao { get; }
        public Usuario UsuarioDevolucao { get; }
    }
}
