using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TesteLeilao.Paginas;

namespace TesteLeilao
{
    [TestClass]
    public class CadastroUsuarioTest
    {
        public IWebDriver Driver { get; set; }
        public CadastroUsuarioTest()
        {
            Driver = new ChromeDriver(@"G:\Documentos\Alura\TestesAutomatizadosComSelenium");
        }
        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
        [TestMethod]
        public void DeveCadastrarOUsuario()
        {
            var emailCadastro = "axavier@empresa.com.br";
            var nomeCadastro = "Adriano Xavier";
            var page = new UsuariosPage(Driver);
            page.Visita();
            page.NovoUsuario().Cadastra(nomeCadastro, emailCadastro);
            Assert.IsTrue(page.ExisteNaPagina(nomeCadastro, emailCadastro));
        }

        [TestMethod]
        public void NaoDeveCadastrarSemNome()
        {
            var nome = String.Empty;
            var email = "email@email.com";
            var page = new UsuariosPage(Driver);
            page.Visita();
            var pageCadastro = page.NovoUsuario();
            pageCadastro.Cadastra(nome, email);

            Assert.IsTrue(pageCadastro.TemErroDeNome());
        }

        [TestMethod]
        public void NaoDeveCadastrarSemNomeESemEmail()
        {
            var nome = String.Empty;
            var email = String.Empty;
            var usuariosPage = new UsuariosPage(Driver);
            usuariosPage.Visita();
            var pageCadastro = usuariosPage.NovoUsuario();
            pageCadastro.Cadastra(nome, email);

            Assert.IsTrue(pageCadastro.TemErroDeEmail());
            Assert.IsTrue(pageCadastro.TemErroDeNome());
        }
    }
}
