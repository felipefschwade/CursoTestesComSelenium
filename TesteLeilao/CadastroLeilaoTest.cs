using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TesteLeilao.Paginas;

namespace TesteLeilao
{
    [TestClass]
    public class CadastroLeilaoTest
    {
        public IWebDriver Driver { get; set; }
        public LeiloesPage LeiloesPage { get; set; }
        public CadastroLeilaoTest()
        {
            Driver = new ChromeDriver(@"G:\Documentos\Alura\TestesAutomatizadosComSelenium");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var page = new UsuariosPage(Driver);
            page.Visita();
            if (!page.ExisteNaPagina("Paulo Henrique", "ph@ph.com"))
            {
                page.NovoUsuario().Cadastra("Paulo Henrique", "ph@ph.com");
                LeiloesPage = new LeiloesPage(Driver);
            }
        }

        [TestMethod]
        public void DeveCadastrarUmLeilao()
        {
            LeiloesPage.Visita();
            LeiloesPage.Novo().Cadastra("Geladeira", 123, "Paulo Henrique", true);
            Assert.IsTrue(LeiloesPage.TemLeilaoDe("Geladeira", 123, "Paulo Henrique", true));
        }

    }
}
