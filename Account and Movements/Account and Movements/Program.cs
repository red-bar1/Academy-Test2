using Account_and_Movements.Entities;
using System;
using System.Collections.Generic;

namespace Account_and_Movements
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<int, Account> dictAccount = new Dictionary<int, Account>();
            int scelta = 0;
            do
            {
                scelta = Operazioni.SchermoMenu();
                Operazioni.AnalizzaScelta(scelta, dictAccount);
            } while (scelta != 4);
        }
    }
}
