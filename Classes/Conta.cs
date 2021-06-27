using System;
using DIO.Bank.Enum;

namespace DIO.Bank
{
    public class Conta
    {
        private string Nome {get; set;}

        private TipoConta TipoConta {get; set;}

        private double Saldo {get; set;}

        private double Credito {get; set;}

        private string Chave { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome, string chave)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            this.Chave = chave;
        }

        public bool Sacar(double valorSaque)
        {
              if(this.Saldo - valorSaque < (this.Credito *-1))
              {
                  Console.WriteLine("Saldo insulficiente");
                  return false;
              }

              this.Saldo -= valorSaque;
              Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
              return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
       
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {

            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public void PixTransferir(double valorTransferencia, Conta contaDestino)
        {
            Console.WriteLine("Chave pix {0} é {1}", this.Nome, this.Chave);
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Chave do pix " + this.Chave + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito + " | ";
            return retorno;
        }
    }
}