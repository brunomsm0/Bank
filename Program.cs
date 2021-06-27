using System;
using System.Collections.Generic;
using DIO.Bank.Enum;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {

           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch(opcaoUsuario)
               {
                   case "1":
                   ListarContas();
                   break;
                   case "2":
                   InserirConta();
                   break;
                   case "3":
                   Transferir();
                   break;
                   case "4":
                   Sacar();
                   break;
                   case "5":
                   Depositar();
                   break;
                   case "6":
                   PixTransferir();
                   break;
                   case "C":
                   Console.Clear();
                   break;

                   default:
                   throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
           Console.WriteLine("Obrigado por utilizar nossos serviços.");
           Console.ReadLine();
        }


        private static void InserirConta()
        {
            Console.WriteLine("Inserir Nova Conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Jurifica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite a chave do pix: ");
            string chavepix = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
                                                     saldo: entradaSaldo,
                                                     credito: entradaCredito,
                                                     nome: entradaNome,
                                                     chave: chavepix);     
            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            if(listContas.Count == 0)
            {
                Console.WriteLine("nenhuma conta cadastrada");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void Sacar()
        {
            Console.Write("Digite o numnero da Conta");
            int indiceConta = int.Parse(Console.ReadLine());

           Console.Write("Digite o valor a ser sacado");
           double valorSaque = double.Parse(Console.ReadLine());

           listContas[indiceConta].Sacar(valorSaque);
        }

         private static void Depositar()
        {
            Console.Write("Digite o numnero da Conta");
            int indiceConta = int.Parse(Console.ReadLine());

           Console.Write("Digite o valor a ser depositado");
           double valorDeposito = double.Parse(Console.ReadLine());

           listContas[indiceConta].Depositar(valorDeposito);
        }

         private static void Transferir()
        {
            Console.Write("Digite o numnero da Conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numnero da Conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

           Console.Write("Digite o valor a ser Transferido");
           double valorTransferencia = double.Parse(Console.ReadLine());

           listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void PixTransferir()
        {
            Console.Write("Digite a chave da conta de origem: ");
            int pixOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite a chave da conta de Destino: ");
            int pixDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser Trasferido");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[pixOrigem].Transferir(valorTransferencia, listContas[pixDestino]);
        }
            private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opcao desejada:");
            
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- PIX");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
