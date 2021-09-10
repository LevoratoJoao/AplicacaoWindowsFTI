using System;

namespace CrudConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = 0;
            string resp = "s";
            Produto p = new Produto();

            Console.WriteLine("CRUD Console");
            
            Connection c = new Connection();
            c.conectar();

            Produto produto = new Produto();

            while (resp == "s" || resp == "S")
            {
                Console.WriteLine("Que operação deseja fazer:");
                Console.WriteLine("1.Inserir \n2.Alterar \n3.Excluir \n4.Pesquisar \n5.Sair");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Digite o ID do produto, a descrição, quantidade no estoque e o valor:");
                        produto.SetIdprod(int.Parse(Console.ReadLine()));
                        produto.SetDescricao(Console.ReadLine());
                        produto.SetEstoque(int.Parse(Console.ReadLine()));
                        produto.SetValor(double.Parse(Console.ReadLine()));
                        c.InserirProduto(produto.GetIdProd(),produto.GetDescricao(),
                                         produto.GetEstoque(),produto.GetValor());
                        break;

                    case 2:
                        Console.WriteLine("Digite o código do produto que deseja alterar");
                        produto.SetIdprod(int.Parse(Console.ReadLine()));
                        Console.WriteLine("--Informe os novos dados do Produto.");
                        Console.WriteLine("Produto..:");
                        produto.SetDescricao(Console.ReadLine());
                        Console.WriteLine("Estoque..:");
                        produto.SetEstoque(int.Parse(Console.ReadLine()));
                        Console.WriteLine("Valor..:");
                        produto.SetValor(double.Parse(Console.ReadLine()));
                        c.AlterarProduto(produto.GetDescricao(), produto.GetEstoque(), 
                                         produto.GetValor(), produto.GetIdProd());
                        break;

                    case 3:
                        Console.WriteLine("Digite o código do produto que deseja excluir do banco:");
                        produto.SetIdprod(int.Parse(Console.ReadLine()));
                        c.DeleteProduto(produto.GetIdProd());
                        break;

                    case 4:

                        produto.SetIdprod(0);
                        produto.SetDescricao(null);
                        produto.SetEstoque(0);
                        produto.SetValor(0);
                        
                        Console.WriteLine("Digite o código do produto que deseja pesquisar:");
                        produto.SetIdprod(int.Parse(Console.ReadLine()));
                        c.PesquisarProduto(produto.GetIdProd(), produto);

                        if (produto.GetDescricao() == null)
                        {
                            Console.WriteLine("Produto não existente!!");
                        }
                        else
                        {
                            Console.WriteLine(produto.GetIdProd());
                            Console.WriteLine(produto.GetDescricao());
                            Console.WriteLine(produto.GetEstoque());
                            Console.WriteLine(produto.GetValor());
                        }
                        break;

                    case 5:
                        resp = "N";
                        break;
                }
                if (op != 5)
                {
                    Console.WriteLine("Deseja continuar ? S-Sim // N-Não");
                    resp = Console.ReadLine();
                }
            }
            
            Console.WriteLine("Fim da operação!!!");
            Console.ReadKey();
        }
    }
}
