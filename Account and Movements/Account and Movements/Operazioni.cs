using Account_and_Movements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_and_Movements
{
    public static class Operazioni
    {
        public static int SchermoMenu()
        {
            Console.WriteLine("Che operazione vuoi svolgere?");
            Console.WriteLine("1. Crea un nuovo account.");
            Console.WriteLine("2. Inserisci un nuovo movimento.");
            Console.WriteLine("3. Stampa dettaglio conto.");
            Console.WriteLine("4. Esci.");
            int scelta = Verifica(4);
            return scelta;
        }

        public static int Verifica(int sceltaMax)
        {
            bool check = Int32.TryParse(Console.ReadLine(), out int scelta);
            while (!check || scelta < 1 || scelta > sceltaMax)
            {
                Console.WriteLine("Inserisci una scelta valida");
                check = Int32.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }

        public static void AnalizzaScelta(int scelta, IDictionary<int, Account> dictAccount)
        {
            switch (scelta)
            {
                case 1:
                    CreaAccout(dictAccount);
                    break;
                case 2:
                    InserisciMovimento(dictAccount); 
                    break;
                case 3:
                    StampaDettaglio(dictAccount);
                    break;
                case 4:
                    Console.WriteLine("Arrivederci");
                    break;
            }
        }

        public static void StampaDettaglio(IDictionary<int, Account> dictAccount)
        {
            Console.WriteLine("Inserisci il conto di cui vuoi conoscere i dettagli");
            bool verifica8 = Int32.TryParse(Console.ReadLine(), out int numeroContoDettagli);
            while (!verifica8)
            {
                Console.WriteLine("Inserisci un valore numerico");
                verifica8 = Int32.TryParse(Console.ReadLine(), out numeroContoDettagli);
            }
            bool verifica9 = dictAccount.TryGetValue(numeroContoDettagli, out Account accountSelezionatoDettagli);
            if (!verifica9)
            {
                Console.WriteLine("Non esiste nessun conto associato a questo numero");
            }
            accountSelezionatoDettagli.Statement();
        }

        public static void InserisciMovimento(IDictionary<int, Account> dictAccount)
        {
            //TODO: controlli su input utente con metodi riutilizabili
            Console.WriteLine("A quale conto vuoi associare il movimento? Inserisci il numero del conto.");
            bool check3 = Int32.TryParse(Console.ReadLine(), out int numeroConto3);
            while (!check3)
            {
                Console.WriteLine("Inserisci un valore numerico");
                check3 = Int32.TryParse(Console.ReadLine(), out numeroConto3);
            }
            if (dictAccount.ContainsKey(numeroConto3))
            {

                //non faccio qui la seconda verifica tanto l'ho già fatta prima(sistemo se ho tempo)
                bool verifica = dictAccount.TryGetValue(numeroConto3, out Account accountSelezionato);
                Console.WriteLine("Quale movimento desideri inserire?");
                Console.WriteLine("1. Cash Movement");
                Console.WriteLine("2. Credit Card Movement");
                Console.WriteLine("3. Transfert Movement");
                int scelta3 = Verifica(3);
                switch (scelta3)
                {
                    case 1:
                        Console.WriteLine("Si tratta di prelievo o di versamento?");
                        Console.WriteLine("1. Prelievo");
                        Console.WriteLine("2. Versamento");
                        int decisione = Verifica(2);
                        Console.WriteLine("Iserisci esecutore.");
                        string esecutore = Console.ReadLine();
                        Console.WriteLine("Inserisci la data.");
                        bool verifica1 = DateTime.TryParse(Console.ReadLine(), out DateTime dataMovimento);
                        Console.WriteLine("Inserisci l'importo");
                        bool verifica2 = double.TryParse(Console.ReadLine(), out double importo);
                        if (decisione == 1)
                        {
                            List<IMovement> listaAggiornata = accountSelezionato - new CashMovement(esecutore, dataMovimento, importo);
                        }
                        else
                        {
                            List<IMovement> listaAggiornata = accountSelezionato + new CashMovement(esecutore, dataMovimento, importo);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Si tratta di prelievo o di versamento?");
                        Console.WriteLine("1. Prelievo");
                        Console.WriteLine("2. Versamento");
                        int decisione2 = Verifica(2);
                        Console.WriteLine("Inserisci data.");
                        bool verifica3 = DateTime.TryParse(Console.ReadLine(), out DateTime dataMovimento2);
                        Console.WriteLine("Inserisci l'importo");
                        bool verifica4 = double.TryParse(Console.ReadLine(), out double importo2);
                        Console.WriteLine("Inserisci il numero carta");
                        bool verifica5 = Int32.TryParse(Console.ReadLine(), out int numeroCarta);
                        Console.WriteLine("Inserisci il tipo di carta:\n");
                        Console.WriteLine("1. AMEX");
                        Console.WriteLine("2. VISA");
                        Console.WriteLine("3. MASTERCARD");
                        Console.WriteLine("4. OTHER");
                        int tipoCarta = Verifica(4);
                        switch (tipoCarta)
                        {
                            case 1:
                                if (decisione2 == 1)
                                {
                                    List<IMovement> listaAggiornata2 = accountSelezionato - new CreditCardMovement(dataMovimento2, importo2, numeroCarta, Tipo.AMEX);
                                }
                                else
                                {
                                    List<IMovement> listaAggiornata2 = accountSelezionato + new CreditCardMovement(dataMovimento2, importo2, numeroCarta, Tipo.AMEX);
                                }
                                break;
                            case 2:
                                if (decisione2 == 1)
                                {
                                    List<IMovement> listaAggiornata3 = accountSelezionato - new CreditCardMovement(dataMovimento2, importo2, numeroCarta, Tipo.VISA);
                                }
                                else
                                {
                                    List<IMovement> listaAggiornata3 = accountSelezionato + new CreditCardMovement(dataMovimento2, importo2, numeroCarta, Tipo.VISA);
                                }

                                break;
                            case 3:
                                if (decisione2 == 1)
                                {
                                    List<IMovement> listaAggiornata4 = accountSelezionato - new CreditCardMovement(dataMovimento2, importo2, numeroCarta, Tipo.MASTERCARD);
                                }
                                else
                                {
                                    List<IMovement> listaAggiornata4 = accountSelezionato + new CreditCardMovement(dataMovimento2, importo2, numeroCarta, Tipo.MASTERCARD);
                                }
                                break;
                            case 4:
                                if (decisione2 == 1)
                                {
                                    List<IMovement> listaAggiornata5 = accountSelezionato - new CreditCardMovement(dataMovimento2, importo2, numeroCarta, Tipo.OTHER);
                                }
                                else
                                {
                                    List<IMovement> listaAggiornata5 = accountSelezionato + new CreditCardMovement(dataMovimento2, importo2, numeroCarta, Tipo.OTHER);
                                }
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Si tratta di prelievo o di versamento?");
                        Console.WriteLine("1. Prelievo");
                        Console.WriteLine("2. Versamento");
                        int decisione3 = Verifica(2);
                        Console.WriteLine("Inserisci data.");
                        bool verifica6 = DateTime.TryParse(Console.ReadLine(), out DateTime dataMovimento3);
                        Console.WriteLine("Inserisci la banca di partenza");
                        string bancaOrigine = Console.ReadLine();
                        Console.WriteLine("Inserisci la banca di destinazione");
                        string bancaDestinazione = Console.ReadLine();
                        Console.WriteLine("Inserisci l'importo");
                        bool verifica7 = double.TryParse(Console.ReadLine(), out double importo3);
                        if (decisione3 == 1)
                        {
                            List<IMovement> listaAggiornata6 = accountSelezionato - new TransfertMovement(dataMovimento3, importo3, bancaOrigine, bancaDestinazione);
                        }
                        else
                        {
                            List<IMovement> listaAggiornata6 = accountSelezionato + new TransfertMovement(dataMovimento3, importo3, bancaOrigine, bancaDestinazione);
                        }

                        break;
                }
            }
            else
            {
                Console.WriteLine("Non esiste nessun conto con questo numero");
            }
        }

        public static void CreaAccout(IDictionary<int, Account> dictAccount)
        {
            Console.WriteLine("Benvenuto alla creazione di un nuovo account");
            Console.WriteLine("Inserisci il numero del conto");
            bool check = Int32.TryParse(Console.ReadLine(), out int numeroConto);
            while (!check)
            {
                Console.WriteLine("Inserisci un valore numerico");
                check = Int32.TryParse(Console.ReadLine(), out numeroConto);
            }
            while (dictAccount.ContainsKey(numeroConto))
            {
                Console.WriteLine("Questo conto già esiste, inserisci un numero nuovo");
                bool check1 = Int32.TryParse(Console.ReadLine(), out int numeroConto1);
                while (!check1)
                {
                    Console.WriteLine("Inserisci un valore numerico");
                    check1 = Int32.TryParse(Console.ReadLine(), out numeroConto1);
                }
                numeroConto = numeroConto1;
            }
            Console.WriteLine("Inserisci il nome della banca");
            string nomeBanca = Console.ReadLine();
            Console.WriteLine("Vuoi fare un versamento iniziale?");
            Console.WriteLine("1. Versa\n2. Non versare");
            int scelta2 = Verifica(2);
            switch (scelta2)
            {
                case 1:
                    Console.WriteLine("Inserisci l'iporto da versare");
                    bool check2 = double.TryParse(Console.ReadLine(), out double saldo);
                    while (!check2)
                    {
                        Console.WriteLine("Inserisci un importo numerico");
                        check2 = double.TryParse(Console.ReadLine(), out saldo);
                    }
                    DateTime? dataUltimaOperazione = DateTime.Today;
                    dictAccount.Add(numeroConto, new Account(numeroConto, nomeBanca, saldo, dataUltimaOperazione));
                    break;
                case 2:
                    double saldo1 = 0.0;
                    DateTime? dataUltimaOperazione1 = null;
                    dictAccount.Add(numeroConto, new Account(numeroConto, nomeBanca, saldo1, dataUltimaOperazione1));
                    break;
            }
        }
    }
}
