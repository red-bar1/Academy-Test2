using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_and_Movements.Entities
{
    public class TransfertMovement : IMovement
    {
        public double Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public string BancaOrigine { get; set; }
        public string BancaDestinazione { get; set; }

        public TransfertMovement(DateTime dataMovimento, double importo, string bancaOrigine, string bancaDestinazione)
        {
            Importo = importo;
            DataMovimento = dataMovimento;
            BancaOrigine = bancaOrigine;
            BancaDestinazione = bancaDestinazione;
        }

        public override string ToString()
        {
            return $"\nData Movimento: {DataMovimento}\nBanca di Origine: {BancaOrigine}" +
                $"\nBanca di Destinazione: {BancaDestinazione}\nImporto: {Importo}euro\n";
        }

    }
}
