using System;
using System.Collections.Generic;
using System.Data;
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
using static Ticket2Help.BLL;
using static Ticket2Help.DAL;

namespace Ticket2Help
{
    /// <summary>
    /// Lógica de interação para Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        /// <summary>
        /// Construtor da classe Admin.
        /// Inicializa os componentes e chama o método OnLoad.
        /// </summary>
        public Admin()
        {
            InitializeComponent();
            OnLoad();
        }

        /// <summary>
        /// Método chamado ao carregar a janela.
        /// Carrega todos os tickets com o nome do colaborador na listView.
        /// </summary>
        private void OnLoad()
        {
            try
            {
                List<TicketDetails> dataList = BLL.GetAllTicketsWithCollaboratorName();
                listView.ItemsSource = dataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de sair.
        /// Fecha a janela atual.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de detalhes.
        /// Mostra os detalhes do ticket selecionado e atualiza a listView.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione uma linha da tabela", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            dynamic selectedItem = listView.SelectedItem;
            var id = selectedItem.Id;
            var tipo = selectedItem.Tipo;

            try
            {
                TicketDetails details = BLL.GetTicketDetailsById(id);

                Admin_Reply replyForm = new Admin_Reply(tipo, details.Task, details.Descricao, id, details.InfoAtend);
                replyForm.ShowDialog();
                replyForm.txtReply.Foreground = Brushes.Black;
                OnLoad(); // Assume que o método OnLoad recarrega os dados na listView
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de verificar utilizadores.
        /// Abre a janela da lista de utilizadores.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnCheckUsers_Click(object sender, RoutedEventArgs e)
        {
            Users_List frmListaUsers = new Users_List();
            frmListaUsers.Show();
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de dashboard.
        /// Abre a janela do dashboard.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            Dashboard frmDashboard = new Dashboard();
            frmDashboard.Show();
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de resposta.
        /// Atualiza o status do ticket mais antigo pendente e abre a janela de resposta.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnReply_Click(object sender, RoutedEventArgs e)
{
    try
    {
        TicketDetails ticketDetails = BLL.GetOldestPendingTicket();

        if (ticketDetails != null)
        {
            string colaboradorIdAtend = User.getID();

            if (BLL.UpdateTicketStatus(ticketDetails.Id, colaboradorIdAtend))
            {
                Admin_Reply replyForm = new Admin_Reply(ticketDetails.Id, ticketDetails.Tipo, ticketDetails.Task, ticketDetails.Descricao);
                replyForm.ShowDialog();
                OnLoad(); // Recarrega a listView
            }
            else
            {
                MessageBox.Show("Erro ao atualizar o status do ticket.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Todos os Tickets estão Abertos ou Resolvidos.", "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Erro ao processar o ticket: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
