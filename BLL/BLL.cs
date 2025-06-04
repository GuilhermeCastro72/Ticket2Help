using System.Data;

namespace Ticket2Help
{
    /// <summary>
    /// Classe BLL (Business Logic Layer) responsável pela lógica de negócios da aplicação.
    /// </summary>
    public class BLL
    {
        /// <summary>
        /// Classe que representa os detalhes de um ticket.
        /// </summary>
        public class TicketDetails
        {
            /// <summary>
            /// Identificador do ticket.
            /// </summary>
            public string Id { get; set; } = string.Empty;

            /// <summary>
            /// Nome do colaborador associado ao ticket.
            /// </summary>
            public string Nome { get; set; } = string.Empty;

            /// <summary>
            /// Tipo de ticket.
            /// </summary>
            public string Tipo { get; set; } = string.Empty;

            /// <summary>
            /// Data de criação do ticket.
            /// </summary>
            public string DataCriacao { get; set; } = string.Empty;

            /// <summary>
            /// Data de atendimento do ticket.
            /// </summary>
            public string DataAtendimento { get; set; } = string.Empty;

            /// <summary>
            /// Status atual do ticket.
            /// </summary>
            public string StatusTicket { get; set; } = string.Empty;

            /// <summary>
            /// Informação adicional sobre o ticket.
            /// </summary>
            public string Informacao { get; set; } = string.Empty;

            /// <summary>
            /// Status do atendimento do ticket.
            /// </summary>
            public string StatusAtendimento { get; set; } = string.Empty;

            /// <summary>
            /// Descrição do ticket.
            /// </summary>
            public string Descricao { get; set; } = string.Empty;

            /// <summary>
            /// Assunto do ticket.
            /// </summary>
            public string Assunto { get; set; } = string.Empty;

            /// <summary>
            /// Tarefa associada ao ticket.
            /// </summary>
            public string Task { get; set; } = string.Empty;

            /// <summary>
            /// Informações adicionais sobre o atendimento do ticket.
            /// </summary>
            public string InfoAtend { get; set; } = string.Empty;
        }

        public class ColaboradorDetails
        {
            /// <summary>
            /// Identificador do colaborador.
            /// </summary>
            public string Id { get; set; } = string.Empty;

            /// <summary>
            /// Indica se o colaborador é administrador.
            /// </summary>
            public string Admin { get; set; } = string.Empty;

            /// <summary>
            /// Nome do colaborador.
            /// </summary>
            public string Nome { get; set; } = string.Empty;

            /// <summary>
            /// Nome de utilizador do colaborador.
            /// </summary>
            public string Username { get; set; } = string.Empty;

            /// <summary>
            /// Senha do colaborador.
            /// </summary>
            public string Password { get; set; } = string.Empty;
        }

        /// <summary>
        /// Valida o login do colaborador.
        /// </summary>
        /// <param name="username">Nome de utilizador do colaborador.</param>
        /// <param name="password">Senha do colaborador.</param>
        /// <returns>Retorna true se o login for válido, caso contrário, retorna false.</returns>
        public static bool ValidateLogin(string username, string password)
        {
            int count = DAL.GetUserCount(username, password);
            return count == 1;
        }

        /// <summary>
        /// Obtém os tickets para um colaborador específico.
        /// </summary>
        /// <param name="colaboradorId">Identificador do colaborador.</param>
        /// <returns>Retorna uma lista de tickets associados ao colaborador.</returns>
        /// <exception cref="Exception">Lança uma exceção se houver um erro ao acessar o banco de dados.</exception>
        public static List<TicketDetails> GetTicketsForUser(string colaboradorId)
        {
            DataTable dt = DAL.GetTicketsByColaboradorId(colaboradorId);

            if (dt != null)
            {
                return ConvertDataTableToList(dt);
            }
            else
            {
                throw new Exception("Erro ao ler a Base de dados.");
            }
        }

        /// <summary>
        /// Converte um DataTable em uma lista de TicketDetails.
        /// </summary>
        /// <param name="dt">DataTable contendo os dados dos tickets.</param>
        /// <returns>Retorna uma lista de TicketDetails.</returns>
        private static List<TicketDetails> ConvertDataTableToList(DataTable dt)
        {
            var dataList = new List<TicketDetails>();
            foreach (DataRow row in dt.Rows)
            {
                var item = new TicketDetails
                {
                    Id = row["ID"].ToString(),
                    Tipo = row["tipo"].ToString(),
                    Assunto = row["task_ticket"].ToString(),
                    DataCriacao = row["data_criacao"].ToString(),
                    StatusTicket = row["status_ticket"].ToString()
                };
                dataList.Add(item);
            }
            return dataList;
        }

        /// <summary>
        /// Converte um DataTable em uma lista de TicketDetails com mais informações.
        /// </summary>
        /// <param name="dt">DataTable contendo os dados dos tickets.</param>
        /// <returns>Retorna uma lista de TicketDetails.</returns>
        private static List<TicketDetails> ConvertTicketDataTableToList(DataTable dt)
        {
            var dataList = new List<TicketDetails>();
            foreach (DataRow row in dt.Rows)
            {
                var item = new TicketDetails
                {
                    Id = row["ID"].ToString(),
                    Nome = row["ColaboradorNome"].ToString(),
                    Tipo = row["tipo"].ToString(),
                    DataCriacao = row["data_criacao"].ToString(),
                    StatusTicket = row["status_ticket"].ToString(),
                    Informacao = row["task_ticket"].ToString(),
                    StatusAtendimento = row["status_atend"].ToString(),
                    DataAtendimento = row["data_atendimento"].ToString(),
                    Descricao = row["info_ticket"].ToString()
                };
                dataList.Add(item);
            }
            return dataList;
        }

        /// <summary>
        /// Obtém todos os tickets com os nomes dos colaboradores.
        /// </summary>
        /// <returns>Retorna uma lista de todos os tickets com os nomes dos colaboradores.</returns>
        /// <exception cref="Exception">Lança uma exceção se houver um erro ao acessar o banco de dados.</exception>
        public static List<TicketDetails> GetAllTicketsWithCollaboratorName()
        {
            DataTable dt = DAL.GetAllTicketsWithCollaboratorName();

            if (dt != null)
            {
                return ConvertTicketDataTableToList(dt);
            }
            else
            {
                throw new Exception("Failed to retrieve data from database.");
            }
        }

        /// <summary>
        /// Obtém os detalhes de um ticket pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do ticket.</param>
        /// <returns>Retorna os detalhes do ticket.</returns>
        /// <exception cref="Exception">Lança uma exceção se houver um erro ao acessar o banco de dados.</exception>
        public static TicketDetails GetTicketDetailsById(string id)
        {
            DataTable dt = DAL.GetTicketDetailsById(id);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new TicketDetails
                {
                    Task = row["task_ticket"].ToString(),
                    Descricao = row["info_ticket"].ToString(),
                    InfoAtend = row["info_atend"].ToString()
                };
            }
            else
            {
                throw new Exception("Failed to retrieve ticket details from database.");
            }
        }

        /// <summary>
        /// Obtém o ticket pendente mais antigo.
        /// </summary>
        /// <returns>Retorna o ticket pendente mais antigo, ou null se não houver tickets pendentes.</returns>
        public static TicketDetails GetOldestPendingTicket()
        {
            DataTable dt = DAL.GetOldestPendingTicket();

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new TicketDetails
                {
                    Id = row["ID"].ToString(),
                    Tipo = row["tipo"].ToString(),
                    Task = row["task_ticket"].ToString(),
                    Descricao = row["info_ticket"].ToString()
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Atualiza o status de um ticket.
        /// </summary>
        /// <param name="ticketId">Identificador do ticket.</param>
        /// <param name="colaboradorIdAtend">Identificador do colaborador que está atendendo o ticket.</param>
        /// <returns>Retorna true se a atualização for bem-sucedida, caso contrário, retorna false.</returns>
        public static bool UpdateTicketStatus(string ticketId, string colaboradorIdAtend)
        {
            string dataAtendimento = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return DAL.UpdateTicketStatus(ticketId, colaboradorIdAtend, dataAtendimento);
        }

        /// <summary>
        /// Obtém todos os colaboradores.
        /// </summary>
        /// <returns>Retorna uma lista de todos os colaboradores.</returns>
        /// <exception cref="Exception">Lança uma exceção se houver um erro ao acessar o banco de dados.</exception>
        public static List<ColaboradorDetails> GetAllColaboradores()
        {
            DataTable dt = DAL.GetAllColaboradores();

            if (dt != null)
            {
                return ConvertColaboradorDataTableToList(dt);
            }
            else
            {
                throw new Exception("Failed to retrieve data from database.");
            }
        }

        /// <summary>
        /// Converte um DataTable em uma lista de ColaboradorDetails.
        /// </summary>
        /// <param name="dt">DataTable contendo os dados dos colaboradores.</param>
        /// <returns>Retorna uma lista de ColaboradorDetails.</returns>
        private static List<ColaboradorDetails> ConvertColaboradorDataTableToList(DataTable dt)
        {
            var dataList = new List<ColaboradorDetails>();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ColaboradorDetails
                {
                    Id = row["ID"].ToString(),
                    Admin = row["admin"].ToString(),
                    Nome = row["nome"].ToString(),
                    Username = row["username"].ToString(),
                    Password = row["password"].ToString(),
                };
                dataList.Add(item);
            }
            return dataList;
        }

        /// <summary>
        /// Adiciona um novo colaborador.
        /// </summary>
        /// <param name="nome">Nome do colaborador.</param>
        /// <param name="username">Nome de utilizador do colaborador.</param>
        /// <param name="password">Password do colaborador.</param>
        /// <returns>Retorna true se a adição for bem-sucedida, caso contrário, retorna false.</returns>
        /// <exception cref="ArgumentException">Lança uma exceção se os campos não forem preenchidos corretamente ou se o nome de utilizador já existir.</exception>
        public static bool AddColaborador(string nome, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Todos os campos têm de ser preenchidos.");
            }

            // Validate name
            if (nome.Equals("Nome", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("O campo Nome não pode ser 'Nome'. Por favor introduza um nome válido.");
            }

            // Validate username
            if (username.Equals("Username", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("O campo Username não pode ser 'Username'. Por favor introduza um username válido.");
            }

            // Validate password (basic example, consider using a password complexity check)
            if (password.Equals("Password", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("O campo Password não pode ser 'Password'. Por favor introduza uma password válida.");
            }

            // Check if username is unique
            if (DAL.UsernameExists(username))
            {
                throw new ArgumentException("Username já existe. Por favor escolha um username diferente.");
            }

            return DAL.AddColaborador(nome, username, password);
        }

        /// <summary>
        /// Obtém os detalhes de um ticket pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do ticket.</param>
        /// <returns>Retorna os detalhes do ticket.</returns>
        /// <exception cref="Exception">Lança uma exceção se o ticket não for encontrado.</exception>
        public static TicketDetails GetTicketDetails(int id)
        {
            DataTable dt = DAL.GetTicketDetails(id);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new TicketDetails
                {
                    Task = row["task_ticket"].ToString(),
                    Descricao = row["info_ticket"].ToString()
                };
            }
            else
            {
                throw new Exception("Ticket not found.");
            }
        }

        /// <summary>
        /// Atualiza as informações de um ticket.
        /// </summary>
        /// <param name="ticketId">Identificador do ticket.</param>
        /// <param name="isResolved">Indica se o ticket foi resolvido.</param>
        /// <param name="infoAtend">Informações adicionais sobre o atendimento.</param>
        /// <returns>Retorna true se a atualização for bem-sucedida, caso contrário, retorna false.</returns>
        public static bool UpdateTicket(string ticketId, bool isResolved, string infoAtend)
        {
            string statusAtend = "aberto";
            string statusTicket = "emAtendimento";
            if (isResolved)
            {
                statusAtend = "resolvido";
                statusTicket = "atendido";
            }
            else
            {
                statusAtend = "naoResolvido";
                statusTicket = "emAtendimento";
            }

            string dataAtendimento = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return DAL.UpdateTicket(ticketId, statusTicket, statusAtend, infoAtend, dataAtendimento);
        }

        /// <summary>
        /// Exclui um colaborador pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do colaborador.</param>
        /// <returns>Retorna true se a exclusão for bem-sucedida, caso contrário, retorna false.</returns>
        public static bool DeleteColaborador(int id)
        {
            return DAL.DeleteColaborador(id);
        }
    }

    /// <summary>
    /// Classe UserService que fornece serviços relacionados a usuários.
    /// </summary>
    public class UserService
    {
        private readonly IUserDAL _dal;

        /// <summary>
        /// Construtor da classe UserService.
        /// </summary>
        /// <param name="dal">Instância da interface IUserDAL.</param>
        public UserService(IUserDAL dal)
        {
            _dal = dal;
        }

        /// <summary>
        /// Valida o login do usuário.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <param name="password">Senha do usuário.</param>
        /// <returns>Retorna true se o login for válido, caso contrário, retorna false.</returns>
        public bool ValidateLogin(string username, string password)
        {
            int count = _dal.GetUserCount(username, password);
            return count == 1;
        }
    }
}
