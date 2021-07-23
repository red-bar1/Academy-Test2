using System;

namespace Account_and_Movements.Entities
{
    public interface IMovement
    {
        public double Importo { get; set; }
        public DateTime DataMovimento { get; set; }
    }
}