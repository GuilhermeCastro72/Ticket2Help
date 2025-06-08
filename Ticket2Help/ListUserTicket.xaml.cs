using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
using static Ticket2Help.Users_List;

namespace Ticket2Help
{
    /// <summary>
    /// Lógica interna para List_User_Ticket.xaml
    /// </summary>
    public partial class List_User_Ticket : Window
    {
        /// <summary>
        /// ID do utilizador.
        /// </summary>
        private string _id = "";

        /// <summary>
        /// Propriedade para obter ou definir o ID do utilizador.
        /// </summary>
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Construtor da classe List_User_Ticket.
        /// </summary>
        public List_User_Ticket()
        {
            InitializeComponent();
            OnLoad();
        }

        /// <summary>
        /// Método chamado ao carregar a janela. 
        /// Carrega os tickets do utilizador atual na listView.
        /// </summary>
        private void OnLoad()
        {
            try
            {
                // Obter o ID do colaborador atual.
                string colaboradorId = User.getID();
                // Obter a lista de tickets para o utilizador.
                List<BLL.TicketDetails> dataList = BLL.GetTicketsForUser(colaboradorId);
                // Definir a fonte de dados da listView.
                listView.ItemsSource = dataList;
            }
            catch (Exception ex)
            {
                // Exibir mensagem de erro caso ocorra uma exceção.
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Evento chamado ao clicar no botão de detalhes.
        /// Mostra os detalhes do ticket selecionado.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            // Verificar se nenhuma linha da tabela foi selecionada.
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione uma linha da tabela", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Obter o item selecionado na listView.
            dynamic selectedItem = listView.SelectedItem;
            // Converter o ID do item selecionado para inteiro.
            int id = Convert.ToInt32(selectedItem.Id);
            // Obter o tipo do item selecionado.
            string tipo = selectedItem.Tipo;

            try
            {
                // Obter os detalhes do ticket usando o BLL.
                BLL.TicketDetails details = BLL.GetTicketDetails(id);

                // Criar uma nova instância da janela User com os detalhes do ticket.
                User userForm = new User(tipo, details.Task, details.Descricao);
                userForm.Show();
            }
            catch (Exception ex)
            {
                // Exibir mensagem de erro caso ocorra uma exceção ao recuperar os detalhes do ticket.
                MessageBox.Show("Erro ao recuperar detalhes do ticket: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Evento chamado ao clicar no botão de saída.
        /// Fecha a janela atual.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
