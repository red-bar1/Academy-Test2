using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_and_Movements.Entities
{
    public class CashMovement : IMovement
    {
        public double Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public string Esecutore { get; set; }

        public CashMovement(string esecutore, DateTime dataMovimento, double importo)
        {
            Importo = importo;
            DataMovimento = dataMovimento;
            Esecutore = esecutore;
        }

        public override string ToString()
        {
            return $"\nEsecutore: {Esecutore}\nData Movimento: {DataMovimento}\nImporto: {Importo}euro\n";
        }


    }
}
