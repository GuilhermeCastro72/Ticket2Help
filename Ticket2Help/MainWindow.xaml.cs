using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ticket2Help
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Placeholder manual
            PlaceholderService.SetPlaceholderText(txtUsername, "Nome de utilizador");
            txtUsername.Text = PlaceholderService.GetPlaceholderText(txtUsername);
            txtUsername.Foreground = Brushes.Gray;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string userId = DAL.FetchUserID(username);
            UserSession.SetID(userId);



            if (BLL.ValidateLogin(username, password))
            {
                if (DAL.FetchAdminStatus(username, password))
                {
                    Admin admin = new Admin();
                    admin.Show();
                }
                else
                {
                    User user = new User();
                    user.Id = DAL.FetchUserID(username);
                    user.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciais Erradas", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == PlaceholderService.GetPlaceholderText(tb))
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = PlaceholderService.GetPlaceholderText(tb);
                tb.Foreground = Brushes.Gray;
            }
        }
    }
}
