using System;
using System.Collections.Generic;
using SistemaGestaoBiblioteca.Entidades;

namespace SistemaGestaoBiblioteca.Entidades.Interface
{
    interface IBiblioteca
    {
        public List<Livro> LivrosDisponiveis { get; }
        public List<Usuario> UsuariosCadastrados { get; }
        public List<Emprestimo> HistoricoEmprestimos { get; set; }

        public void CadastrarLivro(Livro livro);
        public void CadastrarUsuario(Usuario usuario);
        public void RealizarEmprestimo(string titulo, string nome);
        public void DevolverLivros(string nome, string titulo);
        public void ImprimirLivrosDisponiveis();
        public void ImprimirHistorico();
    }
}
