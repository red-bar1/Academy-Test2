using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_and_Movements.Entities
{
    public class Account
    {
        public int NumeroConto { get; set; }
        public string NomeBanca { get; set; }
        public double Saldo { get; set; } = 0.0;
        public DateTime? DataUltimaOperazione { get; set; } = DateTime.Today;

        public List<IMovement> Movimenti = new List<IMovement>();

        

        public Account (int numeroConto, string nomeBanca, double saldo, DateTime? dataUltimaOperazione)
        {
            NumeroConto = numeroConto;
            NomeBanca = nomeBanca;
            Saldo = saldo;
            DataUltimaOperazione = dataUltimaOperazione;
        }


        public static List<IMovement> operator +(Account account, IMovement movimento)
        {
            account.Movimenti.Add(movimento);
            account.Saldo += movimento.Importo;
            account.DataUltimaOperazione = DateTime.Now;
            return account.Movimenti;
        }

        public static List<IMovement> operator -(Account account, IMovement movimento)
        {
            double diff = account.Saldo - movimento.Importo;
            if (diff < 0)
            {
                Console.WriteLine("Il prelievo supera il saldo. Il prelievo non verrà eseguito.");
                return account.Movimenti;
            }
            else
            {
                account.Movimenti.Add(movimento);
                account.Saldo -= movimento.Importo;
                account.DataUltimaOperazione = DateTime.Now;
                return account.Movimenti;
            }
            
        }

        public void Statement()
        {
            Console.WriteLine($"Conto Numero: {NumeroConto}\nNome Banca: {NomeBanca}\nSaldo: {Saldo}\nData Ultima Operazione: {DataUltimaOperazione}\n");
            Console.WriteLine("==============Lista Movimenti============");
            int i = 1;
            foreach (var item in Movimenti)
            {

                Console.WriteLine($"{i}.\t {item}");
                i++;
            }
        }

    }
}
