using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TesteLeilao.Paginas;

namespace TesteLeilao
{
    [TestClass]
    public class LeilaoTest
    {
        public IWebDriver Driver { get; set; }
        public LeiloesPage LeiloesPage { get; set; }
        public LeilaoTest()
        {
            Driver = new ChromeDriver(@"G:\Documentos\Alura\TestesAutomatizadosComSelenium");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Navigate().GoToUrl("http://localhost:8080/apenas-teste/limpa");
            Driver.Close();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var page = new UsuariosPage(Driver);
            page.Visita();
            page.NovoUsuario().Cadastra("Paulo Henrique", "ph@ph.com");
            LeiloesPage = new LeiloesPage(Driver);
        }

        [TestMethod]
        public void DeveCadastrarUmLeilao()
        {
            LeiloesPage.Visita();
            LeiloesPage.Novo().Cadastra("Geladeira", 123, "Paulo Henrique", true);
            Assert.IsTrue(LeiloesPage.TemLeilaoDe("Geladeira", 123, "Paulo Henrique", true));
        }

        [TestMethod]
        public void DeveExibirMensagemDeErroSeCadastradoSemValor()
        {
            LeiloesPage.Visita();
            var leilaoCadastroPage = LeiloesPage.Novo();
            leilaoCadastroPage.Cadastra("Geladeira", 0, "Paulo Henrique", true);
            Assert.IsTrue(leilaoCadastroPage.ChecaMensagem("Valor inicial deve ser maior que zero!"));
        }
    }
}
