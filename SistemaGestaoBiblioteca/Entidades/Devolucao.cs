using SistemaGestaoBiblioteca.Entidades.Interface;
using System;

namespace SistemaGestaoBiblioteca.Entidades
{
    class Devolucao : IDevolucao
    {
        public Livro LivroDevolucao { get; private set; }
        public Usuario UsuarioDevolucao { get; private set; }

        public Devolucao(Usuario usuarioDevolucao, Livro livroDevolucao)
        {
            LivroDevolucao = livroDevolucao;
            UsuarioDevolucao = usuarioDevolucao;
            livroDevolucao.Devolver();
        }
    }
}
