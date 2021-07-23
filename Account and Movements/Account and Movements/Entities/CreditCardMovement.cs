using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_and_Movements.Entities
{
    public enum Tipo
    {
        AMEX,
        VISA,
        MASTERCARD,
        OTHER
    }

    public class CreditCardMovement : IMovement
    {
        public double Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public int NumeroCarta { get; set; }
        public Tipo TipoCarta { get; set; }



        public CreditCardMovement(DateTime dataMovimento, double importo, int numeroCarta, Tipo tipoCarta)
        {
            Importo = importo;
            DataMovimento = dataMovimento;
            NumeroCarta = numeroCarta;
            TipoCarta = tipoCarta;    
        }

        public override string ToString()
        {
            return $"\nData Movimento: {DataMovimento}\n{TipoCarta} - Numero Carta: {NumeroCarta}\nImporto: {Importo}euro\n";
        }
    }
}
