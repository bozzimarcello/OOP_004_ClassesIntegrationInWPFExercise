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
        private Bank bank;
        private string accountsFilePath = "accounts.csv";

        public MainWindow()
        {
            InitializeComponent();
            bank = new Bank();
            grdAccounts.ItemsSource = bank.GetAccounts();
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = txtAccountNumber.Text;
            double initialBalance = double.Parse(txtInitialBalance.Text);
            string ownerName = txtOwnerName.Text;
            string accountType = txtAccountType.Text;
            BankAccount account = new BankAccount(accountNumber, initialBalance, ownerName, accountType);
            bank.AddAccount(account);
            grdAccounts.Items.Refresh();
        }

        private void btnRemoveAccount_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = txtWorkingAccountNumber.Text;
            BankAccount account = bank.FindAccount(accountNumber);
            if (account == null)
            {
                MessageBox.Show("Account not found");
                return;
            }
            bank.RemoveAccount(account);
            grdAccounts.Items.Refresh();
        }

        private void btnSaveAccounts_Click(object sender, RoutedEventArgs e)
        {
            bank.WriteAccountsToCsv(accountsFilePath);
        }

        private void btnLoadAccounts_Click(object sender, RoutedEventArgs e)
        {
            bank.ReadAccountsFromCsv(accountsFilePath);
            grdAccounts.Items.Refresh();
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = txtWorkingAccountNumber.Text;
            double amount = double.Parse(txtAmount.Text);
            BankAccount account = bank.FindAccount(accountNumber);
            if (account == null)
            {
                MessageBox.Show("Account not found");
                return;
            }
            account.Deposit(amount);
            grdAccounts.Items.Refresh();
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = txtWorkingAccountNumber.Text;
            double amount = double.Parse(txtAmount.Text);
            BankAccount account = bank.FindAccount(accountNumber);
            if (account == null)
            {
                MessageBox.Show("Account not found");
                return;
            }
            account.Withdraw(amount);
            grdAccounts.Items.Refresh();
        }

        private void btnShowTotalBalance_Click(object sender, RoutedEventArgs e)
        {
            txtTotalBalance.Text = bank.GetTotalBalance().ToString();
        }
    }
}