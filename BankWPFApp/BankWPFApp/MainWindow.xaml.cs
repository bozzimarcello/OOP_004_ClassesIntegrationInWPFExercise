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
        // DA FARE: dichiarare un campo privato di tipo Bank, per gestire i conti correnti

        // DA FARE: dichiarare un campo privato di tipo string per il percorso del file CSV


        public MainWindow()
        {
            InitializeComponent();
            // DA FARE: inizializzare il campo privato di tipo Bank

        }

        private void RefreshListView()
        {
            // DA FARE: svuotare la ListView

            // DA FARE: aggiungere tutti gli account presenti nella banca alla ListView

        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: verificare che tutti i campi siano stati compilati,
            // altrimenti visualizzare un messaggio di errore

            // DA FARE: verificare che il saldo iniziale sia un numero usando il TryParse,
            // altrimenti visualizzare un messaggio di errore

            // DA FARE: recuperare i valori dai campi di testo

            // DA FARE: creare un nuovo account corrente e aggiungerlo alla banca

            // DA FARE: aggiornare la ListView

        }

        private void btnRemoveAccount_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: verificare che il campo di ricerca per il numero di conto sia stato compilato,
            // altrimenti visualizzare un messaggio di errore

            // DA FARE: recuperare il numero di conto dal campo di ricerca

            // DA FARE: cercare l'account corrispondente al numero di conto,
            // se assente visualizzare un messaggio di errore

            // DA FARE: rimuovere l'account corrente dalla banca

            // DA FARE: aggiornare la ListView

        }

        private void btnSaveAccounts_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: salvare tutti gli account correnti in un file CSV,
            // gestendo eventuali eccezioni
        }

        private void btnLoadAccounts_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: caricare tutti gli account correnti da un file CSV,
            // gestendo eventuali eccezioni

            // DA FARE: aggiornare la ListView

        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: verificare che il campo di ricerca per il numero di conto sia stato compilato,
            // altrimenti visualizzare un messaggio di errore

            // DA FARE: recuperare il numero di conto dal campo di ricerca

            // DA FARE: verificare che l'importo sia un numero usando il TryParse,
            // altrimenti visualizzare un messaggio di errore

            // DA FARE: cercare l'account corrispondente al numero di conto,
            // se assente visualizzare un messaggio di errore

            // DA FARE: depositare l'importo sull'account corrente,
            // gestendo eventuali eccezioni

            // DA FARE: aggiornare la ListView

        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: verificare che il campo di ricerca per il numero di conto sia stato compilato,
            // altrimenti visualizzare un messaggio di errore

            // DA FARE: recuperare il numero di conto dal campo di ricerca

            // DA FARE: verificare che l'importo sia un numero usando il TryParse,
            // altrimenti visualizzare un messaggio di errore

            // DA FARE: cercare l'account corrispondente al numero di conto,
            // se assente visualizzare un messaggio di errore

            // DA FARE: prelevare l'importo dall'account corrente,
            // gestendo eventuali eccezioni

            // DA FARE: aggiornare la ListView

        }

        private void btnShowTotalBalance_Click(object sender, RoutedEventArgs e)
        {
            // DA FARE: visualizzare il saldo totale di tutti gli account correnti
        }
    }
}