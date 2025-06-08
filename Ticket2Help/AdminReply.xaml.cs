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
    /// Lógica de interação para Admin_Reply.xaml
    /// </summary>
    public partial class Admin_Reply : Window
    {
        /// <summary>
        /// Identificador do ticket.
        /// </summary>
        private string ticketId;

        /// <summary>
        /// Construtor da classe Admin_Reply que inicializa com um identificador de ticket.
        /// </summary>
        /// <param name="ticketId">O identificador do ticket.</param>
        public Admin_Reply(string ticketId)
        {
            InitializeComponent();
            this.ticketId = ticketId;
        }

        /// <summary>
        /// Construtor da classe Admin_Reply que inicializa com detalhes do ticket.
        /// </summary>
        /// <param name="ticketId">O identificador do ticket.</param>
        /// <param name="tipo">O tipo do ticket.</param>
        /// <param name="task">A tarefa do ticket.</param>
        /// <param name="desc">A descrição do ticket.</param>
        public Admin_Reply(string ticketId, string tipo, string task, string desc)
        {
            InitializeComponent();
            lblTicketNumber.Content = ticketId;
            lblTicketType.Content = tipo;
            lblTicketTask.Content = task;
            txtDesc.Text = desc;
            txtDesc.IsReadOnly = true; // Desabilitar o campo de descrição
            this.ticketId = ticketId; // Armazena o ID do ticket
        }

        /// <summary>
        /// Construtor da classe Admin_Reply que inicializa com mais detalhes do ticket.
        /// </summary>
        /// <param name="tipo">O tipo do ticket.</param>
        /// <param name="task">A tarefa do ticket.</param>
        /// <param name="desc">A descrição do ticket.</param>
        /// <param name="id">O identificador do ticket.</param>
        /// <param name="desc_atend">A descrição do atendimento.</param>
        public Admin_Reply(string tipo, string task, string desc, string id, string desc_atend)
        {
            InitializeComponent();
            lblTicketNumber.Content = id;
            lblTicketType.Content = tipo;
            lblTicketTask.Content = task;
            txtDesc.Text = desc;
            txtReply.Text = desc_atend;
            txtDesc.IsReadOnly = true; // Desabilitar o campo de descrição
            this.ticketId = id; // Armazena o ID do ticket
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
        /// Evento disparado ao clicar no botão de guardar.
        /// Atualiza o ticket com as informações fornecidas e o status de resolução.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isResolved = rdbSolve.IsChecked == true;
                string infoAtend = txtReply.Text;

                if (string.IsNullOrWhiteSpace(infoAtend))
                {
                    MessageBox.Show("Por favor, preencha a resposta.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                bool success = BLL.UpdateTicket(ticketId, isResolved, infoAtend);

                if (success)
                {
                    MessageBox.Show("Ticket atualizado com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o ticket.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar o ticket: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
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

        /// <summary>
        /// Evento disparado quando o texto da TextBox de resposta é alterado.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void txtReply_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // Não implementado
        }

        /// <summary>
        /// Evento disparado quando o texto da TextBox de descrição é alterado.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void txtDesc_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Não implementado
        }
    }
}
