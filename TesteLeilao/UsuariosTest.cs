using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TesteLeilao.Paginas;

namespace TesteLeilao
{
    [TestClass]
    public class UsuariosTest
    {
        public IWebDriver Driver { get; set; }
        public UsuariosPage Page { get; set; }
        public UsuariosTest()
        {
            Driver = new ChromeDriver(@"G:\Documentos\Alura\TestesAutomatizadosComSelenium");
        }
        [TestInitialize]
        public void Inititaliza()
        {
            Page = new UsuariosPage(Driver);
        }
        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }

        [TestMethod]
        public void T1DeveCadastrarOUsuario()
        {
            var emailCadastro = "axavier@empresa.com.br";
            var nomeCadastro = "Adriano Xavier";
            
            Page.Visita();
            Page.NovoUsuario().Cadastra(nomeCadastro, emailCadastro);
            Assert.IsTrue(Page.ExisteNaPagina(nomeCadastro, emailCadastro));
        }

        [TestMethod]
        public void T2NaoDeveCadastrarSemNome()
        {
            var nome = String.Empty;
            var email = "email@email.com";
            var page = new UsuariosPage(Driver);
            Page.Visita();
            var pageCadastro = Page.NovoUsuario();
            pageCadastro.Cadastra(nome, email);

            Assert.IsTrue(pageCadastro.TemErroDeNome());
        }

        [TestMethod]
        public void T3NaoDeveCadastrarSemNomeESemEmail()
        {
            var nome = String.Empty;
            var email = String.Empty;
            Page.Visita();
            var pageCadastro = Page.NovoUsuario();
            pageCadastro.Cadastra(nome, email);

            Assert.IsTrue(pageCadastro.TemErroDeEmail());
            Assert.IsTrue(pageCadastro.TemErroDeNome());
        }

        [TestMethod]
        public void T4DeveAlterarOUsuário()
        {
            var nome = "Bernardo";
            var email = "Ber@Ber.com";
            Page.Visita();
            Page.EditaUsuarioDaPosicao(1).Edita(nome, email);
            Assert.IsTrue(Page.ExisteNaPagina(nome, email));
            Assert.IsFalse(Page.ExisteNaPagina("Adriano Xavier", "axavier@empresa.com.br"));
        }

        [TestMethod]
        public void T5DeveExcluirOUsuário()
        {
            Page.Visita();

            Page.ExcluiUsuarioDaPosicao(1);

            Assert.IsFalse(Driver.PageSource.Contains("Bernardo"));
        }

    }
}
