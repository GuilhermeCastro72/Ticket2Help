using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Ticket2Help.DAL; // Importa os membros estáticos da classe DAL

namespace Ticket2Help
{
    /// <summary>
    /// ViewModel para a janela de Dashboard.
    /// </summary>
    public class DashboardViewModel : INotifyPropertyChanged
    {
        // Declaração das propriedades para armazenar as séries de dados dos gráficos
        private SeriesCollection _ticketsAttendedSeries;
        private SeriesCollection _ticketsResolvedSeries;

        /// <summary>
        /// Construtor da classe DashboardViewModel.
        /// </summary>
        public DashboardViewModel()
        {
            LoadData(); // Carrega os dados ao inicializar o ViewModel
        }

        // Propriedades para as séries de dados dos gráficos
        /// <summary>
        /// Coleção de séries para o gráfico de tickets atendidos.
        /// </summary>
        public SeriesCollection TicketsAttendedSeries
        {
            get => _ticketsAttendedSeries;
            set
            {
                _ticketsAttendedSeries = value;
                OnPropertyChanged(); // Notifica a alteração da propriedade
            }
        }

        /// <summary>
        /// Coleção de séries para o gráfico de tickets resolvidos/não resolvidos.
        /// </summary>
        public SeriesCollection TicketsResolvedSeries
        {
            get => _ticketsResolvedSeries;
            set
            {
                _ticketsResolvedSeries = value;
                OnPropertyChanged(); // Notifica a alteração da propriedade
            }
        }

        // Propriedades para os tipos de tickets e o formatador de rótulos
        /// <summary>
        /// Array de strings contendo os tipos de tickets.
        /// </summary>
        public string[] TicketTypes { get; set; }

        /// <summary>
        /// Delegado para formatar os rótulos dos gráficos.
        /// </summary>
        public Func<double, string> Formatter { get; set; }

        // Método para carregar os dados dos gráficos
        private void LoadData()
        {
            // Carrega os dados para o gráfico de tickets atendidos
            var (porAtender, emAtendimento, atendido) = DAL.GetTicketCounts();
            int totalTickets = porAtender + emAtendimento + atendido;

            TicketsAttendedSeries = new SeriesCollection
            {
                // Cria as séries de dados para os diferentes estados dos tickets
                new PieSeries
                {
                    Title = "Por Atender",
                    Values = new ChartValues<double> { porAtender },
                    DataLabels = true,
                    LabelPoint = chartPoint => string.Format("{0}", (int)chartPoint.Y) // Define o rótulo como o valor inteiro
                },
                new PieSeries
                {
                    Title = "Em Atendimento",
                    Values = new ChartValues<double> { emAtendimento },
                    DataLabels = true,
                    LabelPoint = chartPoint => string.Format("{0}", (int)chartPoint.Y) // Define o rótulo como o valor inteiro
                },
                new PieSeries
                {
                    Title = "Atendido",
                    Values = new ChartValues<double> { atendido },
                    DataLabels = true,
                    LabelPoint = chartPoint => string.Format("{0}", (int)chartPoint.Y) // Define o rótulo como o valor inteiro
                }
            };

            // Carrega os dados para o gráfico de tickets resolvidos/não resolvidos
            var (resolvido, naoResolvido) = DAL.GetResolvedTicketCounts();

            TicketsResolvedSeries = new SeriesCollection
            {
                // Cria as séries de dados para os tickets resolvidos e não resolvidos
                new PieSeries
                {
                    Title = "Resolvido",
                    Values = new ChartValues<double> { resolvido },
                    DataLabels = true,
                    LabelPoint = chartPoint => string.Format("{0}", (int)chartPoint.Y) // Define o rótulo como o valor inteiro
                },
                new PieSeries
                {
                    Title = "Não Resolvido",
                    Values = new ChartValues<double> { naoResolvido },
                    DataLabels = true,
                    LabelPoint = chartPoint => string.Format("{0}", (int)chartPoint.Y) // Define o rótulo como o valor inteiro
                }
            };

            Formatter = value => value.ToString("N0"); // Define o formatador para números inteiros
        }

        // Evento para notificar alterações nas propriedades
        /// <summary>
        /// Evento acionado quando uma propriedade é alterada.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // Método para notificar alterações nas propriedades
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
