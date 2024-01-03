using System;
using SistemaGestaoBiblioteca.Entidades.Enum;
using SistemaGestaoBiblioteca.Entidades.Interface;

namespace SistemaGestaoBiblioteca.Entidades
{
    class Livro : ILivro
    {
        public string Autor { get; private set; }
        public string Titulo { get; private set; }

        //Eu pensei em colocar um DateTime em vez de 'int', mas fiquei meio confuso em como colocar somente a leitura do ano
        public int AnoPublicacao { get; private set; }
        public StatusDoLivro Status { get;  set; }

        //Construtores
        public Livro(string nome, string titulo, int ano)
        {
            Autor = nome;
            Titulo = titulo;
            AnoPublicacao = ano;
            Status = StatusDoLivro.Disponivel;
        }

        public Livro(string livro)
        {
            Titulo = livro;
        }

        //Função para emprestar o livro
        public void Emprestar()
        {
            Status = StatusDoLivro.Emprestado;
        }

        //Função para devolver o livro
        public void Devolver()
        {
            Status = StatusDoLivro.Disponivel;
        }

        //Função para imprimir os livros
        public override string ToString()
        {
            return $"{Titulo} | {Autor} | {AnoPublicacao} ({Status})";
        }
    }
}
