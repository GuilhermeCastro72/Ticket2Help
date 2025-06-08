using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Lógica de interação para EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        /// <summary>
        /// Construtor da classe EditUser
        /// </summary>
        public EditUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de salvar.
        /// Atualiza os dados do colaborador na base de dados.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Obter os valores dos campos da interface
            var id = lblIdNumber.Content;
            var nome = txtNome.Text;
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var admin = Convert.ToBoolean(lblIsAdmin.Content);

            // Montar a consulta SQL para atualizar os dados do colaborador
            string sql = $"UPDATE Colaboradores SET nome = '{nome}', username = '{username}', password = '{password}', admin = {Convert.ToInt32(admin)} WHERE ID = {id}";

            // Executar a consulta SQL
            bool success = DAL.ExecBD(sql);

            // Verificar se a consulta foi executada com sucesso
            if (success)
            {
                // Mostrar uma mensagem de sucesso
                MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Mostrar uma mensagem de erro
                MessageBox.Show("Erro ao salvar os dados.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de sair.
        /// Fecha a janela atual.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Evento disparado ao clicar no botão para editar o status de administrador.
        /// Alterna o status de administrador entre verdadeiro e falso.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void btnEditAdminStatus_Click(object sender, RoutedEventArgs e)
        {
            if ((string)lblIsAdmin.Content == "False")
            {
                lblIsAdmin.Content = "True";
            }
            else
            {
                lblIsAdmin.Content = "False";
            }
        }

        /// <summary>
        /// Evento disparado quando o texto do campo Nome é alterado.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void txtNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Não implementado
        }

        /// <summary>
        /// Evento disparado quando o texto do campo Username é alterado.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Não implementado
        }

        /// <summary>
        /// Evento disparado quando o texto do campo Password é alterado.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Não implementado
        }

        /// <summary>
        /// Evento disparado quando uma TextBox recebe o foco.
        /// Remove o placeholder da TextBox.
        /// </summary>
        /// <param name="sender">TextBox que recebeu o foco</param>
        /// <param name="e">Dados do evento</param>
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
        /// <param name="sender">TextBox que perdeu o foco</param>
        /// <param name="e">Dados do evento</param>
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
