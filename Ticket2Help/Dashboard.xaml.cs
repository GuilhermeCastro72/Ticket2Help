using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    /// Lógica de interação para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        /// <summary>
        /// Construtor da classe Dashboard.
        /// Inicializa os componentes e define o contexto de dados.
        /// </summary>
        public Dashboard()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de sair.
        /// Fecha a janela atual.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Evento disparado quando o gráfico de pizza (PieChart) é carregado.
        /// (Atualmente não implementado)
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento</param>
        /// <param name="e">Dados do evento</param>
        private void PieChart_Loaded(object sender, RoutedEventArgs e)
        {
            // Não implementado
        }

        private void PieChart_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
