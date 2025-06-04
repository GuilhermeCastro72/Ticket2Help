using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ticket2Help
{
    /// <summary>
    /// Lógica interna para AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        /// <summary>
        /// Construtor da classe AddUser.
        /// Inicializa os componentes.
        /// </summary>
        public AddUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de sair.
        /// Fecha a janela atual.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de adicionar.
        /// Adiciona um novo colaborador utilizando os dados fornecidos.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Password;


            try
            {
                bool success = BLL.AddColaborador(nome, username, password);

                if (success)
                {
                    MessageBox.Show("Utilizador adicionado com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Limpar os campos após adicionar
                    txtNome.Text = "";
                    txtUsername.Text = "";
                    txtPassword.Clear();

                }
                else
                {
                    MessageBox.Show("Erro ao adicionar o utilizador.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Evento disparado quando uma TextBox recebe o foco.
        /// Remove o placeholder da TextBox.
        /// </summary>
        /// <param name="sender">TextBox que recebeu o foco.</param>
        /// <param name="e">Dados do evento.</param>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == (string)textBox.GetValue(PlaceholderService.PlaceholderTextProperty))
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        /// <summary>
        /// Evento disparado quando uma TextBox perde o foco.
        /// Adiciona o placeholder na TextBox se estiver vazia.
        /// </summary>
        /// <param name="sender">TextBox que perdeu o foco.</param>
        /// <param name="e">Dados do evento.</param>
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = (string)textBox.GetValue(PlaceholderService.PlaceholderTextProperty);
                textBox.Foreground = Brushes.LightGray;
            }
        }
    }
}
