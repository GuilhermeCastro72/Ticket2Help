using System.Data;
using System.Data.SqlClient;

namespace Ticket2Help
{
    /// <summary>
    /// Classe de acesso a dados (Data Access Layer - DAL) para a aplicação Ticket2Help.
    /// </summary>
    public class DAL
    {
        /// <summary>
        /// String de conexão com o banco de dados.
        /// </summary>
        private static string conStr = @"Data Source=DESKTOP-I4BLJ4C\SQLEXPRESS;Initial Catalog=Ticket2Help;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        /// <summary>
        /// Executa um comando SQL que não retorna resultados.
        /// </summary>
        /// <param name="sql">Comando SQL a ser executado.</param>
        /// <returns>True se a execução for bem-sucedida, false caso contrário.</returns>
        public static bool ExecBD(string sql)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Busca o ID de um usuário pelo nome de usuário.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <returns>ID do usuário como string ou "ERROR" em caso de erro.</returns>
        public static string FetchUserID(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string query = "SELECT ID FROM Colaboradores WHERE username = @Username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);

                    con.Open();

                    return Convert.ToString(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
        }

        /// <summary>
        /// Verifica o status de administrador de um usuário.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <param name="password">Senha do usuário.</param>
        /// <returns>True se o usuário for administrador, false caso contrário.</returns>
        public static bool FetchAdminStatus(string username, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string query = "SELECT admin FROM Colaboradores WHERE username = @Username AND password = @Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();

                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Conta o número de usuários com as credenciais fornecidas.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <param name="password">Senha do usuário.</param>
        /// <returns>Número de usuários encontrados.</returns>
        public static int GetUserCount(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT COUNT(1) FROM Colaboradores WHERE username = @Username AND password = @Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Obtém tickets pelo ID do colaborador.
        /// </summary>
        /// <param name="colaboradorId">ID do colaborador.</param>
        /// <returns>DataTable contendo os tickets do colaborador.</returns>
        public static DataTable GetTicketsByColaboradorId(string colaboradorId)
        {
            string sql = "SELECT * FROM Ticket WHERE Colaborador_ID_Maker = @ColaboradorId ORDER BY data_criacao";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ColaboradorId", colaboradorId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Obtém todos os tickets com o nome do colaborador.
        /// </summary>
        /// <returns>DataTable contendo todos os tickets e os nomes dos colaboradores.</returns>
        public static DataTable GetAllTicketsWithCollaboratorName()
        {
            string sql = "SELECT t.ID, t.Colaborador_ID_Maker, c.nome AS ColaboradorNome, t.tipo, t.data_criacao, t.status_ticket, t.task_ticket, t.info_ticket, t.Colaborador_ID_Atend, t.data_atendimento, t.status_atend, t.info_atend " +
                         "FROM Ticket t JOIN Colaboradores c ON t.Colaborador_ID_Maker = c.ID ORDER BY t.data_criacao;";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Obtém detalhes de um ticket pelo ID.
        /// </summary>
        /// <param name="id">ID do ticket.</param>
        /// <returns>DataTable contendo os detalhes do ticket.</returns>
        public static DataTable GetTicketDetailsById(string id)
        {
            string sql = "SELECT info_atend, task_ticket, info_ticket FROM Ticket WHERE ID = @Id";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Obtém o ticket pendente mais antigo.
        /// </summary>
        /// <returns>DataTable contendo o ticket pendente mais antigo.</returns>
        public static DataTable GetOldestPendingTicket()
        {
            string sql = "SELECT TOP 1 * FROM Ticket WHERE status_ticket = 'porAtender' ORDER BY data_criacao ASC";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Atualiza o status de um ticket.
        /// </summary>
        /// <param name="ticketId">ID do ticket.</param>
        /// <param name="colaboradorIdAtend">ID do colaborador que atende o ticket.</param>
        /// <param name="dataAtendimento">Data de atendimento do ticket.</param>
        /// <returns>True se a atualização for bem-sucedida, false caso contrário.</returns>
        public static bool UpdateTicketStatus(string ticketId, string colaboradorIdAtend, string dataAtendimento)
        {
            string sql = "UPDATE Ticket SET status_ticket = 'emAtendimento', status_atend = 'aberto', Colaborador_ID_Atend = @ColaboradorIdAtend, data_atendimento = @DataAtendimento WHERE ID = @TicketId";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@TicketId", ticketId);
                cmd.Parameters.AddWithValue("@ColaboradorIdAtend", colaboradorIdAtend);
                cmd.Parameters.AddWithValue("@DataAtendimento", dataAtendimento);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Atualiza um ticket com novas informações.
        /// </summary>
        /// <param name="ticketId">ID do ticket.</param>
        /// <param name="statusTicket">Novo status do ticket.</param>
        /// <param name="statusAtend">Novo status de atendimento.</param>
        /// <param name="infoAtend">Novas informações de atendimento.</param>
        /// <param name="dataAtendimento">Nova data de atendimento.</param>
        /// <returns>True se a atualização for bem-sucedida, false caso contrário.</returns
        public static bool UpdateTicket(string ticketId, string statusTicket, string statusAtend, string infoAtend, string dataAtendimento)
        {
            string sql = "UPDATE Ticket SET status_ticket = @StatusTicket, status_atend = @StatusAtend, info_atend = @InfoAtend, data_atendimento = @DataAtendimento WHERE ID = @TicketId";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@StatusTicket", statusTicket);
                cmd.Parameters.AddWithValue("@StatusAtend", statusAtend);
                cmd.Parameters.AddWithValue("@InfoAtend", infoAtend);
                cmd.Parameters.AddWithValue("@DataAtendimento", dataAtendimento);
                cmd.Parameters.AddWithValue("@TicketId", ticketId);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Obtém todos os colaboradores.
        /// </summary>
        /// <returns>DataTable contendo todos os colaboradores.</returns>
        public static DataTable GetAllColaboradores()
        {
            string sql = "SELECT * FROM Colaboradores";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Verifica se um nome de usuário já existe.
        /// </summary>
        /// <param name="username">Nome de usuário a ser verificado.</param>
        /// <returns>True se o nome de usuário já existir, false caso contrário.</returns>
        public static bool UsernameExists(string username)
        {
            string sql = "SELECT COUNT(1) FROM Colaboradores WHERE username = @Username";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Username", username);

                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        /// <summary>
        /// Adiciona um novo colaborador.
        /// </summary>
        /// <param name="nome">Nome do colaborador.</param>
        /// <param name="username">Nome de usuário do colaborador.</param>
        /// <param name="password">Senha do colaborador.</param>
        /// <returns>True se a inserção for bem-sucedida, false caso contrário.</returns>
        public static bool AddColaborador(string nome, string username, string password)
        {
            string sql = "INSERT INTO Colaboradores (admin, nome, username, password) VALUES (0, @Nome, @Username, @Password)";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Obtém os detalhes de um ticket pelo ID.
        /// </summary>
        /// <param name="id">ID do ticket.</param>
        /// <returns>DataTable contendo os detalhes do ticket.</returns>
        public static DataTable GetTicketDetails(int id)
        {
            string sql = "SELECT task_ticket, info_ticket FROM Ticket WHERE ID = @Id";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Exclui um colaborador pelo ID.
        /// </summary>
        /// <param name="id">ID do colaborador.</param>
        /// <returns>True se a exclusão for bem-sucedida, false caso contrário.</returns>
        public static bool DeleteColaborador(int id)
        {
            string sql = "DELETE FROM Colaboradores WHERE ID = @Id";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Obtém a contagem de tickets por status.
        /// </summary>
        /// <returns>Tupla contendo a contagem de tickets "porAtender", "emAtendimento" e "atendido".</returns>
        public static (int porAtender, int emAtendimento, int atendido) GetTicketCounts()
        {
            string query = @"
            SELECT 
                SUM(CASE WHEN status_ticket = 'porAtender' THEN 1 ELSE 0 END) AS PorAtender,
                SUM(CASE WHEN status_ticket = 'emAtendimento' THEN 1 ELSE 0 END) AS EmAtendimento,
                SUM(CASE WHEN status_ticket = 'atendido' THEN 1 ELSE 0 END) AS Atendido
            FROM Ticket";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int porAtender = 0, emAtendimento = 0, atendido = 0;

                if (reader.Read())
                {
                    porAtender = reader.GetInt32(reader.GetOrdinal("PorAtender"));
                    emAtendimento = reader.GetInt32(reader.GetOrdinal("EmAtendimento"));
                    atendido = reader.GetInt32(reader.GetOrdinal("Atendido"));
                }

                return (porAtender, emAtendimento, atendido);
            }
        }

        /// <summary>
        /// Obtém a contagem de tickets resolvidos e não resolvidos.
        /// </summary>
        /// <returns>Tupla contendo a contagem de tickets "resolvido" e "naoResolvido".</returns>
        public static (int resolvido, int naoResolvido) GetResolvedTicketCounts()
        {
            string query = @"
            SELECT 
                SUM(CASE WHEN status_atend = 'resolvido' THEN 1 ELSE 0 END) AS Resolvido,
                SUM(CASE WHEN status_atend = 'naoResolvido' THEN 1 ELSE 0 END) AS NaoResolvido
            FROM Ticket";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int resolvido = 0, naoResolvido = 0;

                if (reader.Read())
                {
                    resolvido = reader.GetInt32(reader.GetOrdinal("Resolvido"));
                    naoResolvido = reader.GetInt32(reader.GetOrdinal("NaoResolvido"));
                }

                return (resolvido, naoResolvido);
            }
        }

    }

    /// <summary>
    /// Interface para a camada de acesso a dados do usuário.
    /// </summary>
    public interface IUserDAL
    {
        int GetUserCount(string username, string password);
    }
}