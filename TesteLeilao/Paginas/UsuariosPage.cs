using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TesteLeilao.Paginas
{
    public class UsuariosPage : PageBase
    {
        public UsuariosPage(IWebDriver driver) : base(driver) { }

        public CadastraUsuarioPage NovoUsuario()
        {
            WebDriver.FindElement(By.LinkText("Novo Usuário")).Click();
            return new CadastraUsuarioPage(WebDriver);
        }

        public bool ExisteNaPagina(string nome, string email)
        {
            bool achouNome = WebDriver.PageSource.Contains(nome);
            bool achouEmail = WebDriver.PageSource.Contains(email);
            return achouEmail && achouNome;
        }

        public override void Visita()
        {
            WebDriver.Navigate().GoToUrl("http://localhost:8080/");
            WebDriver.FindElement(By.LinkText("Usuários")).Click();
        }
    }
}
