using System;
using SistemaGestaoBiblioteca.Entidades;
using SistemaGestaoBiblioteca.Entidades.Interface;
using SistemaGestaoBiblioteca.Entidades.Exception;

namespace SistemaGestaoBiblioteca.Entidades
{
    class Emprestimo : IEmprestimo
    {
        public Livro LivroEmprestado { get; private set; }
        public Usuario UsuarioEmprestimo { get; private set; }
        public DateTime DataEmprestimo { get; private set; }

        //Construtores
        public Emprestimo(Livro livroEmprestado, Usuario usuarioEmprestimo)
        {
            LivroEmprestado = livroEmprestado;
            UsuarioEmprestimo = usuarioEmprestimo;
            DataEmprestimo = DateTime.Now;
            livroEmprestado.Emprestar();
        }

        //Função para imprimir os dados de emprestimo
        public override string ToString()
        {
            return $"{LivroEmprestado} - {DataEmprestimo.ToString("dd/MM/yyyy")} | {UsuarioEmprestimo.Nome}";
        }
    }
}
