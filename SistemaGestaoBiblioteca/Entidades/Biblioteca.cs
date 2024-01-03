using SistemaGestaoBiblioteca.Entidades.Interface;
using System;
using System.Collections.Generic;
using SistemaGestaoBiblioteca.Entidades.Exception;
using System.Linq;

namespace SistemaGestaoBiblioteca.Entidades
{
    internal class Biblioteca : IBiblioteca
    {
        public List<Livro> LivrosDisponiveis { get; set; } = new List<Livro>();
        public List<Usuario> UsuariosCadastrados { get; set; } = new List<Usuario>();
        public List<Emprestimo> HistoricoEmprestimos { get; set; } = new List<Emprestimo>();

        //Função para cadastrar um livro
        public void CadastrarLivro(Livro livro)
        {
            LivrosDisponiveis.Add(livro);
        }

        //Função para cadastrar um usuário
        public void CadastrarUsuario(Usuario usuario)
        {
            UsuariosCadastrados.Add(usuario);
        }

        //Função para realizar empréstimo
        public void RealizarEmprestimo(string titulo, string nome)
        {
            var usuario = UsuariosCadastrados.FirstOrDefault(x => x.Nome == nome);
            if (usuario == null)
            {
                throw new ExceptionDomain("Usuário não encontrado!");
            }
            var livroEmp = LivrosDisponiveis.FirstOrDefault(x => x.Titulo == titulo);
            if (livroEmp == null)
            {
                throw new ExceptionDomain("Livro não encontrado!");
            }
            var livroDisp = LivrosDisponiveis.Where(x => x.Titulo == titulo && x.Status == Enum.StatusDoLivro.Emprestado);
            if (livroDisp == null)
            {
                throw new ExceptionDomain("Livro não disponível para empréstimo!");
            }
            Emprestimo emprestimo = new Emprestimo(livroEmp, usuario);
            HistoricoEmprestimos.Add(emprestimo);
            Console.WriteLine("\nEmprestimo Realizado!\n");
        }

        //Função para devolver os livros
        public void DevolverLivros(string nome, string titulo)
        {
            var usuario = UsuariosCadastrados.FirstOrDefault(x => x.Nome == nome);
            if (usuario == null)
            {
                throw new ExceptionDomain("Usuário não encontrado!");
            }
            var livroEmp = LivrosDisponiveis.FirstOrDefault(x => x.Titulo == titulo);
            if (livroEmp == null)
            {
                throw new ExceptionDomain("Livro não encontrado!");
            }
            var empVerif = HistoricoEmprestimos.FirstOrDefault(x => x.UsuarioEmprestimo == usuario && x.LivroEmprestado == livroEmp);
            
            //Lançar um erro caso o usuário queira devolver um livro que não pegou emprestado
            if (empVerif == null)
            {
                throw new ExceptionDomain("Nehum empréstimo foi localizado!");
            }
            HistoricoEmprestimos.Remove(empVerif);
            Devolucao devolucao = new Devolucao(usuario, livroEmp);
            Console.WriteLine("\nDevolução Realizada!\n");
        }

        //Função para imprimir os livros disponíveis
        public void ImprimirLivrosDisponiveis()
        {
            int cont = 1;
            if (LivrosDisponiveis.Count <= 0)
            {
                throw new ExceptionDomain("Nenhum livro cadastrado!");
            }

            var livroDisp = LivrosDisponiveis.Where(x => x.Status == Enum.StatusDoLivro.Disponivel);
            foreach (Livro livro in livroDisp)
            {
                Console.WriteLine($"{cont} - {livro}");
                cont++;
            }
        }

        //Função para imprimir o histórico de empréstimo
        public void ImprimirHistorico()
        {
            if (HistoricoEmprestimos.Count <= 0)
            {
                throw new ExceptionDomain("--Lista Vazia | Nenhum Empréstimo foi realizado--");
            }
            foreach (Emprestimo emp in HistoricoEmprestimos)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
