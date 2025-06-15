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
    /// Lógica de interação para a classe User.xaml
    /// </summary>
    public partial class User : Window
    {
        /// <summary>
        /// ID estático do utilizador
        /// </summary>
        private static string _id = "";

        /// <summary>
        /// Propriedade para obter ou definir o ID do utilizador
        /// </summary>
        public string Id
{
    get { return _id; }
    set { _id = value; }
}

        public AddUser AddUser
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Construtor padrão da classe User
        /// </summary>
        public User()
        {
            InitializeComponent();
            this.Background = new SolidColorBrush(Color.FromRgb(240, 248, 255)); // Azul claro 
            txtTask.Background = Brushes.WhiteSmoke;
            txtDesc.Background = Brushes.WhiteSmoke;
            btnSubmit.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215)); // Botão azul
            btnSubmit.Foreground = Brushes.White;
            btnList.Background = Brushes.DarkSlateGray;
            btnList.Foreground = Brushes.White;
            btnExit.Background = Brushes.LightCoral;
            btnExit.Foreground = Brushes.White;

            if (rdbHard.IsChecked == true)
            {
                lblTarefa.Content = "Equipamento";
                lblProblem.Content = "Descrição da Avaria";
            }
        }

        /// <summary>
        /// Construtor que inicializa a classe User com parâmetros
        /// </summary>
        /// <param name="tipo">Tipo de problema (hardware/software)</param>
        /// <param name="task">Descrição da tarefa</param>
        /// <param name="desc">Descrição do problema</param>
        public User(string tipo, string task, string desc)
        {
            InitializeComponent();
            SetFormData(tipo, task, desc);
            DisableFormFields();
        }

        /// <summary>
        /// Define os dados do formulário com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="tipo">Tipo de problema</param>
        /// <param name="task">Descrição da tarefa</param>
        /// <param name="desc">Descrição do problema</param>
        private void SetFormData(string tipo, string task, string desc)
        {
            if (tipo == "hardware")
            {
                rdbHard.IsChecked = true;
                rdbSoft.IsChecked = false;
            }
            else
            {
                rdbHard.IsChecked = false;
                rdbSoft.IsChecked = true;
            }
            txtTask.Text = task;
            txtDesc.Text = desc;
        }

        /// <summary>
        /// Desabilita os campos do formulário para evitar edição
        /// </summary>
        private void DisableFormFields()
        {
            rdbHard.IsEnabled = false;
            rdbSoft.IsEnabled = false;
            txtTask.IsReadOnly = true;
            txtDesc.IsReadOnly = true;
            btnSubmit.IsEnabled = false; // Desabilitar o botão de submeter
            btnList.IsEnabled = false; // Desabilitar o botão de lista
        }

        /// <summary>
        /// Fecha a janela ao clicar no botão de saída
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Abre o formulário de lista de tickets ao clicar no botão de lista
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            List_User_Ticket form = new List_User_Ticket();
            form.Show();
        }

        /// <summary>
        /// Submete um novo ticket ao clicar no botão de submeter
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Obter o ID do colaborador atual
            string colaboradorId = User.getID();

            // Determinar o tipo de problema
            string tipo = rdbHard.IsChecked == true ? "hardware" : "software";

            // Coletar a descrição da tarefa e a descrição do problema
            string task = txtTask.Text;
            string desc = txtDesc.Text;

            // Obter a data atual
            string dataCriacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // SQL para inserir um novo ticket
            string sql = $"INSERT INTO Ticket (Colaborador_ID_Maker, tipo, data_criacao, status_ticket, task_ticket, info_ticket) " +
                         $"VALUES ({colaboradorId}, '{tipo}', '{dataCriacao}', 'porAtender', '{task}', '{desc}')";

            // Executar o comando SQL usando a camada DAL
            bool result = DAL.ExecBD(sql);

            // Verificar se a inserção foi bem-sucedida
            if (result)
            {
                MessageBox.Show("Ticket inserido com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao inserir o ticket.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Obtém o ID do utilizador
        /// </summary>
        /// <returns>ID do utilizador</returns>
        public static string getID()
        {
            return _id;
        }

        /// <summary>
        /// Atualiza a interface para "software" ao selecionar a opção de software
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void rdbSoft_Checked(object sender, RoutedEventArgs e)
        {
            if (lblTarefa != null)
            {
                lblTarefa.Content = "Software";
                lblProblem.Content = "Descrição da Necessidade";
            }
        }

        /// <summary>
        /// Atualiza a interface para "hardware" ao selecionar a opção de hardware
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void rdbHard_Checked(object sender, RoutedEventArgs e)
        {
            if (lblTarefa != null)
            {
                lblTarefa.Content = "Equipamento";
                lblProblem.Content = "Descrição da Avaria";
            }
        }

        /// <summary>
        /// Evento para tratar a alteração de texto na caixa de descrição
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void txtDesc_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Não implementado
        }

        /// <summary>
        /// Evento para tratar a alteração de texto na caixa de tarefa
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void txtTask_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Não implementado
        }

        /// <summary>
        /// Evento disparado quando uma TextBox recebe o foco
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
                textBox.BorderBrush = Brushes.DeepSkyBlue;
                textBox.BorderThickness = new Thickness(1.5);

            }
        }

        /// <summary>
        /// Evento disparado quando uma TextBox perde o foco
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
                textBox.BorderBrush = Brushes.Gray;
                textBox.BorderThickness = new Thickness(1);

            }
        }
    }
}
