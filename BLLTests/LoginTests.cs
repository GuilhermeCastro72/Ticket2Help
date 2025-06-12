using Moq;
using Ticket2Help;
using Xunit;
namespace BLLTests
{
    /// <summary>
    /// Classe de testes para validar o login utilizando mocks da interface IUserDAL.
    /// </summary>
    public class LoginTests
    {
        /// <summary>
        /// Mock da interface IUserDAL.
        /// </summary>
        private readonly Mock<IUserDAL> _mockDal;

        /// <summary>
        /// Servi�o de usu�rio a ser testado.
        /// </summary>
        private readonly UserService _userService;

        /// <summary>
        /// Construtor da classe LoginTests.
        /// Inicializa o mock da interface IUserDAL e o servi�o do utilizador.
        /// </summary>
        public LoginTests()
        {
            _mockDal = new Mock<IUserDAL>();
            _userService = new UserService(_mockDal.Object);
        }

        /// <summary>
        /// Testa o m�todo ValidateLogin com credenciais v�lidas.
        /// </summary>
        [Fact]
        public void ValidateLogin_ValidCredentials_ReturnsTrue()
        {
            string username = "validUser";
            string password = "validPassword";

            _mockDal.Setup(dal => dal.GetUserCount(username, password)).Returns(1);

            bool result = _userService.ValidateLogin(username, password);

            Assert.True(result);
            _mockDal.Verify(dal => dal.GetUserCount(username, password), Times.Once);
        }

        /// <summary>
        /// Testa o m�todo ValidateLogin com credenciais inv�lidas.
        /// </summary>
        [Fact]
        public void ValidateLogin_InvalidCredentials_ReturnsFalse()
        {
            string username = "invalidUser";
            string password = "invalidPassword";

            _mockDal.Setup(dal => dal.GetUserCount(username, password)).Returns(0);

            bool result = _userService.ValidateLogin(username, password);

            Assert.False(result);
            _mockDal.Verify(dal => dal.GetUserCount(username, password), Times.Once);
        }
    }

}