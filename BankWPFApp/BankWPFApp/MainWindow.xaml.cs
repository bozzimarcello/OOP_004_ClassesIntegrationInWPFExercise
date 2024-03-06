using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // DA FARE: dichiarare un campo privato di tipo Bank
        private Bank bank;
        // DA FARE: dichiarare un campo privato di tipo string per il percorso del file CSV
        private string accountsFilePath = "accounts.csv";

        public MainWindow()
        {
            InitializeComponent();
            // DA FARE: inizializzare il campo privato di tipo Bank
            bank = new Bank();
        }

        private void RefreshListView()
        {
            // DA FARE: svuotare la ListView
            lstElenco.Items.Clear();
            // DA FARE: aggiungere tutti gli account presenti nella banca alla ListView
            foreach (BankAccount account in bank.GetAccounts())
            {
                lstElenco.Items.Add(account.ToString());
            }
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: verificare che tutti i campi siano stati compilati,
            // altrimenti visualizzare un messaggio di errore
            if (txtAccountNumber.Text == "" || txtOwnerName.Text == "" || txtAccountType.Text == "" || txtInitialBalance.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;
            }
            // DA FARE: verificare che il saldo iniziale sia un numero usando il TryParse,
            // altrimenti visualizzare un messaggio di errore
            if (double.TryParse(txtInitialBalance.Text, out double initialBalance) == false)
            {
                MessageBox.Show("Account number must be a number");
                return;
            }
            // DA FARE: recuperare i valori dai campi di testo
            string accountNumber = txtAccountNumber.Text;
            string ownerName = txtOwnerName.Text;
            string accountType = txtAccountType.Text;
            // DA FARE: creare un nuovo account corrente e aggiungerlo alla banca
            BankAccount account = new BankAccount(accountNumber, initialBalance, ownerName, accountType);
            bank.AddAccount(account);
            // DA FARE: aggiornare la ListView
            RefreshListView();
        }

        private void btnRemoveAccount_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: verificare che il campo di ricerca per il numero di conto sia stato compilato,
            // altrimenti visualizzare un messaggio di errore
            if (txtWorkingAccountNumber.Text == "")
            {
                MessageBox.Show("Search Account Number must be filled");
                return;
            }
            // DA FARE: recuperare il numero di conto dal campo di ricerca
            string accountNumber = txtWorkingAccountNumber.Text;
            // DA FARE: cercare l'account corrispondente al numero di conto,
            // se assente visualizzare un messaggio di errore
            BankAccount account = bank.FindAccount(accountNumber);
            if (account == null)
            {
                MessageBox.Show("Account not found");
                return;
            }
            // DA FARE: rimuovere l'account corrente dalla banca
            bank.RemoveAccount(account);
            // DA FARE: aggiornare la ListView
            RefreshListView();
        }

        private void btnSaveAccounts_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: salvare tutti gli account correnti in un file CSV,
            // gestendo eventuali eccezioni
            try
            {
                bank.WriteAccountsToCsv(accountsFilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        private void btnLoadAccounts_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: caricare tutti gli account correnti da un file CSV,
            // gestendo eventuali eccezioni
            try
            {
                bank.ReadAccountsFromCsv(accountsFilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            // DA FARE: aggiornare la ListView
            RefreshListView();
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: verificare che il campo di ricerca per il numero di conto sia stato compilato,
            // altrimenti visualizzare un messaggio di errore
            if (txtWorkingAccountNumber.Text == "")
            {
                MessageBox.Show("Search Account Number must be filled");
                return;
            }
            // DA FARE: recuperare il numero di conto dal campo di ricerca
            string accountNumber = txtWorkingAccountNumber.Text;
            // DA FARE: verificare che l'importo sia un numero usando il TryParse,
            // altrimenti visualizzare un messaggio di errore
            if (double.TryParse(txtAmount.Text, out double amount) == false)
            {
                MessageBox.Show("Amount must be a number");
                return;
            }
            // DA FARE: cercare l'account corrispondente al numero di conto,
            // se assente visualizzare un messaggio di errore
            BankAccount account = bank.FindAccount(accountNumber);
            if (account == null)
            {
                MessageBox.Show("Account not found");
                return;
            }
            // DA FARE: depositare l'importo sull'account corrente,
            // gestendo eventuali eccezioni
            try
            {
                account.Deposit(amount);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            // DA FARE: aggiornare la ListView
            RefreshListView();
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: verificare che il campo di ricerca per il numero di conto sia stato compilato,
            // altrimenti visualizzare un messaggio di errore
            if (txtWorkingAccountNumber.Text == "")
            {
                MessageBox.Show("Search Account Number must be filled");
                return;
            }
            // DA FARE: recuperare il numero di conto dal campo di ricerca
            string accountNumber = txtWorkingAccountNumber.Text;
            // DA FARE: verificare che l'importo sia un numero usando il TryParse,
            // altrimenti visualizzare un messaggio di errore
            if (double.TryParse(txtAmount.Text, out double amount) == false)
            {
                MessageBox.Show("Amount must be a number");
                return;
            }
            // DA FARE: cercare l'account corrispondente al numero di conto,
            // se assente visualizzare un messaggio di errore
            BankAccount account = bank.FindAccount(accountNumber);
            if (account == null)
            {
                MessageBox.Show("Account not found");
                return;
            }
            // DA FARE: prelevare l'importo dall'account corrente,
            // gestendo eventuali eccezioni
            try
            {
                account.Withdraw(amount);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            // DA FARE: aggiornare la ListView
            RefreshListView();
        }

        private void btnShowTotalBalance_Click(object sender, RoutedEventArgs e)
        {
            txtTotalBalance.Text = bank.GetTotalBalance().ToString();
        }
    }
}