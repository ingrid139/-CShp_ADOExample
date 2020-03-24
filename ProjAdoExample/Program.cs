using System;
using System.Linq;

namespace ProjAdoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ADO.NET EXAMPLE!");

            try
            {
                //GravarUsandoAdoNet();
                AlterandoUsandoAdoNet();
                RecuperarUsandoAdoNet();
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Erro no Ado Net");
            }
            Console.ReadKey();
        }
        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }

        }

        private static void AlterandoUsandoAdoNet()
        {
            var repo = new ProdutoDAO();

            var produto = repo.Produtos().Where(x => x.Id == 1).FirstOrDefault();
            produto.Nome = "Harry Potter e a Camera Secreta";

            repo.Atualizar(produto);
        }

        private static void RecuperarUsandoAdoNet()
        {
            var repo = new ProdutoDAO();
            var produtos = repo.Produtos();

            foreach (var produto in produtos)
            {
                Console.WriteLine(produto.Id);
                Console.WriteLine(produto.Nome);
                Console.WriteLine(produto.Categoria);
                Console.WriteLine(produto.Preco);
            }
        }
    }
}
