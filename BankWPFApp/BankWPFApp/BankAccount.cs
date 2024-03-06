using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFApp
{
    public class BankAccount
    {
        //
        // Attributi (tutti privati per incapsulamento)
        //
        private string _accountNumber;
        private double _balance;
        private string _ownerName;
        private string _accountType;

        //
        // Metodi getter pubblici
        //
        public string GetAccountNumber()
        {
            // DA FARE: Restituisci il numero di conto
            return _accountNumber;
        }

        public double GetBalance()
        {
            // DA FARE: Restituisci il saldo corrente
            return _balance;
        }

        public string GetOwnerName()
        {
            // DA FARE: restituisci il nome del proprietario
            return _ownerName;
        }

        public string GetAccountType()
        {
            // DA FARE: restituisci il tipo di conto
            return _accountType;
        }

        //
        // Metodi costruttori pubblici (personalizzare in base alle funzionalità richieste)
        //
        public BankAccount()
        {
            // DA FARE: Inizializza le proprietà con valori predefiniti
            _accountNumber = string.Empty;
            _balance = 0;
            _ownerName = string.Empty;
            _accountType = string.Empty;
        }

        public BankAccount(string accountNumber, double initialBalance)
        {
            // DA FARE: Inizializza le proprietà con i valori forniti
            _accountNumber = accountNumber;
            _balance = initialBalance;
            _ownerName = string.Empty;
            _accountType = string.Empty;
        }

        public BankAccount(string accountNumber, double initialBalance, string ownerName, string accountType)
        {
            // DA FARE: Inizializza le proprietà con tutti i dettagli
            _accountNumber = accountNumber;
            _balance = initialBalance;
            _ownerName = ownerName;
            _accountType = accountType;
        }

        //
        // Metodi pubblici per le operazioni sul conto (implementare la logica qui)
        //
        public void Deposit(double amount)
        {
            // DA FARE: Aggiorna il saldo se il deposito è valido, altrimenti solleva una eccezione
            if (amount < 0)
            {
                throw new ArgumentException();
            }
            _balance += amount;
        }

        public void Withdraw(double amount)
        {
            // DA FARE: Aggiorna il saldo se il prelievo è valido, altrimenti solleva una eccezione
            if (amount < 0 || amount > _balance)
            {
                throw new ArgumentException();
            }
            _balance -= amount;
        }

        public override string ToString()
        {
            // DA FARE: Restituisci una rappresentazione testuale dell'oggetto
        }
    }
}

