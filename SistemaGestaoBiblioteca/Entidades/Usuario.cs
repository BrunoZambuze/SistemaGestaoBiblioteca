using System;
using SistemaGestaoBiblioteca.Entidades.Interface;

namespace SistemaGestaoBiblioteca.Entidades
{
    class Usuario : IUsuario
    {
        public string Nome { get; private set; }

        //Construtor
        public Usuario(string nome)
        {
            Nome = nome;
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }
    }
}
