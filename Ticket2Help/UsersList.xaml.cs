using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ticket2Help
{/// <summary>
 /// Lógica de interação para Users_List.xaml
 /// </summary>
    public partial class Users_List : Window
    {
        /// <summary>
        /// Inicializa uma nova instância da classe Users_List.
        /// </summary>
        public Users_List()
        {
            InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// Carrega os dados dos utilizadores na lista.
        /// </summary>
        private void LoadData()
        {
            try
            {
                List<BLL.ColaboradorDetails> dataList = BLL.GetAllColaboradores();
                listView.ItemsSource = dataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Manipula o clique no botão para adicionar um utilizador.
        /// </summary>
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser frmAddUser = new AddUser();
            frmAddUser.ShowDialog();
            LoadData();
        }

        /// <summary>
        /// Manipula o clique no botão para editar um utilizador.
        /// </summary>
        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione uma linha da tabela", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            dynamic selectedItem = listView.SelectedItem;
            var nome = selectedItem.Nome;
            var username = selectedItem.Username;
            var password = selectedItem.Password;
            var admin = selectedItem.Admin;
            var id = selectedItem.Id;

            EditUser frmEditUser = new EditUser();
            frmEditUser.txtNome.Text = nome;
            frmEditUser.txtUsername.Text = username;
            frmEditUser.txtPassword.Text = password;
            frmEditUser.lblIsAdmin.Content = admin;
            frmEditUser.lblIdNumber.Content = id;
            frmEditUser.ShowDialog();
            LoadData();
        }

        /// <summary>
        /// Manipula o clique no botão para excluir um utilizador.
        /// </summary>
        private void btnDelUser_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um item para excluir.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Tem a certeza que deseja eliminar este utilizador?", "Confirmar Eliminação", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                dynamic selectedItem = listView.SelectedItem;
                int id = Convert.ToInt32(selectedItem.Id);

                try
                {
                    if (BLL.DeleteColaborador(id))
                    {
                        LoadData();
                        MessageBox.Show("Utilizador eliminado com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao eliminar o utilizador.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao eliminar o utilizador: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Manipula o clique no botão para sair da janela.
        /// </summary>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
