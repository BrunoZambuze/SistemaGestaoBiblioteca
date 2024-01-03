using System;
using SistemaGestaoBiblioteca.Entidades;
using SistemaGestaoBiblioteca.Entidades.Exception;

namespace SistemaGestaoBiblioteca
{
    class Program
    {
        //Função que verificar se o que foi digitado é uma string ou não
        static bool Verificacao(string texto)
        {
            //Percorrer cada caractere do texto digitado
            foreach (char caractere in texto)
            {
                //Verificar se a string digitada possui algum caractere que não está dentro do alfabeto
                if (!char.IsLetter(caractere))
                {
                    //Se for identificado que possui um caractere fora do alfabeto, o programa irá retornar 'verdadeiro'
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            //Vou deixar alguns livros já cadastrados para ir adiantando o processo
            Biblioteca biblioteca = new Biblioteca();
            biblioteca.CadastrarLivro(new Livro("Tim Peters", "A Filosofia do Python", 2004));
            biblioteca.CadastrarLivro(new Livro("Kyle Simpson", "Você Não Sabe JS: Escopo & Closures", 2014));
            biblioteca.CadastrarLivro(new Livro(" Donald E. Knuth", "A Arte de Programar Computadores", 2011));
            biblioteca.CadastrarLivro(new Livro("Venkat Subramaniam", "Programação Funcional em Java", 2011));

            try
            {
                int resp;
                //Interação com o usuário
                do
                {
                    Console.WriteLine("\n-------Biblioteca-------");
                    Console.WriteLine("[1] Cadastrar Usuário");
                    Console.WriteLine("[2] Exibir Livros Disponíveis");
                    Console.WriteLine("[3] Emprestar Livro");
                    Console.WriteLine("[4] Exibir Histórico de Empréstimo");
                    Console.WriteLine("[5] Devolver Livro");
                    Console.WriteLine("[0] Sair");
                    Console.Write("Entre com a opção desejada: ");
                    resp = int.Parse(Console.ReadLine());
                    switch (resp)
                    {
                        case 1:
                            Console.WriteLine("\n\n***Cadastrar Usuário***\n");
                                Console.Write("Digite seu nome: ");
                                string nome = Console.ReadLine();
                            if (Verificacao(nome))
                            {
                                throw new FormatException("---*Sintaxe não permitida, por favor insira um nome válido*---");
                            }
                                biblioteca.CadastrarUsuario(new Usuario(nome));
                            break;
                        case 2:
                            Console.WriteLine("\n\n***Livros disponíveis***\n");
                            biblioteca.ImprimirLivrosDisponiveis();
                            break;
                        case 3:
                            Console.WriteLine("\n\n***Empréstimo***\n");
                            Console.Write("Digite seu nome de usuário: ");
                            string nomeUsu = Console.ReadLine();
                            Console.Write("Digite o titulo do livro que deseja solicitar o emprestimo: ");
                            string tituloLivr = Console.ReadLine();
                            biblioteca.RealizarEmprestimo(tituloLivr, nomeUsu);
                            break;
                        case 4:
                            Console.WriteLine("\n\n**Histórico de Empréstimo**\n");
                            biblioteca.ImprimirHistorico();
                            break;
                        case 5:
                            Console.WriteLine("\n\n**Devolver Livro**\n");
                            Console.Write("Digite seu nome de usuário: ");
                            string nomeDev = Console.ReadLine();
                            Console.Write("Digite o titulo do livro que deseja devolver: ");
                            string tituloDev = Console.ReadLine();
                            biblioteca.DevolverLivros(nomeDev, tituloDev);
                            break;
                    }
                }
                while (resp != 0);
            }
            catch (ExceptionDomain error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
            catch (FormatException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}