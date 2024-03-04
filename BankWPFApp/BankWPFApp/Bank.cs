using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFApp
{
    public class Bank
    {
        // 
        // Collezione di conti correnti
        //
        private List<BankAccount> _accounts;

        //
        // Costruttore
        //
        public Bank()
        {
            // DA FARE: Inizializza la collezione di conti correnti
            _accounts = new List<BankAccount>();
        }

        //
        // Metodi pubblici
        //

        public List<BankAccount> GetAccounts()
        {
            return _accounts;
        }

        public void AddAccount(BankAccount account)
        {
            // DA FARE: verificare che l'account non sia nullo
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account cannot be null");
            }

            // DA FARE: Aggiungi un conto corrente alla collezione
            _accounts.Add(account);
        }

        public void RemoveAccount(BankAccount account)
        {
            // DA FARE: verificare che l'account non sia nullo
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account cannot be null");
            }

            // DA FARE: verificare che l'account esista nella collezione
            if (!_accounts.Contains(account))
            {
                throw new InvalidOperationException("Account does not exist in the bank");
            }

            // DA FARE: Rimuovi un conto corrente dalla collezione
            _accounts.Remove(account);
        }

        public BankAccount FindAccount(string accountNumber)
        {
            // DA FARE: Cerca un conto corrente per numero di conto
            // e restituisci l'account corrispondente
            foreach (BankAccount account in _accounts)
            {
                if (account.GetAccountNumber() == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        public double GetTotalBalance()
        {
            // DA FARE: Calcola il saldo totale di tutti i conti correnti
            double totalBalance = 0;
            foreach (BankAccount account in _accounts)
            {
                totalBalance += account.GetBalance();
            }
            return totalBalance;
        }

        public void ReadAccountsFromCsv(string filePath)
        {
            // DA FARE: verifica che il percorso del file non sia nullo o vuoto,
            // altrimenti lancia un'eccezione ArgumentNullException
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty");
            }

            // DA FARE: Verifica che il file esista,
            // altrimenti lancia un'eccezione FileNotFoundException
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            // DA FARE: Leggi i conti correnti da un file CSV e aggiungili alla collezione
            //
            // Il formato del file CSV deve essere:
            // accountNumber,balance,owner,type
            // Esempio:
            // 123,1000,Pino Deipalazzi,Savings
            // 456,2000,Olga Lazingara,Investiments
            // 
            // se una riga del file ' nulla o vuota, lancia un'eccezione InvalidOperationException
            // se una riga non restituisce esattamente 4 valori, lancia un'eccezione InvalidOperationException
            using (StreamReader stream = new StreamReader(filePath))
            {
                while (!stream.EndOfStream)
                {
                    string? line = stream.ReadLine();

                    if (line == null)
                    {
                        throw new InvalidOperationException("Invalid CSV file");
                    }

                    string[] values = line.Split(',');

                    if (values.Length != 4)
                    {
                        throw new InvalidOperationException("Invalid CSV file");
                    }

                    string accountNumber = values[0];
                    double balance = double.Parse(values[1]);
                    string owner = values[2];
                    string type = values[3];

                    BankAccount account = new BankAccount(accountNumber, balance, owner, type);

                    _accounts.Add(account);
                }
            }
        }

        public void WriteAccountsToCsv(string filePath)
        {
            // DA FARE: Verifica che il file esista, altrimenti crealo
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            // DA FARE: Scrivi i conti correnti su un file CSV
            using (StreamWriter stream = new StreamWriter(filePath))
            {
                foreach (BankAccount account in _accounts)
                {
                    string line = $"{account.GetAccountNumber()},{account.GetBalance()},{account.GetOwnerName()},{account.GetAccountType()}";
                    stream.WriteLine(line);
                }
            }
        }
    }
}