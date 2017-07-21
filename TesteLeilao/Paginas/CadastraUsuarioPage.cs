using System;
using OpenQA.Selenium;

namespace TesteLeilao.Paginas
{
    public class CadastraUsuarioPage : PageBase
    {
        public CadastraUsuarioPage(IWebDriver driver) : base(driver)
        {
        }

        public void Cadastra(string nome, string email)
        {
            var campoEmail = WebDriver.FindElement(By.Name("usuario.email"));
            var campoNome = WebDriver.FindElement(By.Name("usuario.nome"));
            var botaoSubmit = WebDriver.FindElement(By.Id("btnSalvar"));

            campoNome.SendKeys(nome);
            campoEmail.SendKeys(email);
            botaoSubmit.Click();
        }

        public bool TemErroDeNome()
        {
            return WebDriver.PageSource.Contains("Nome obrigatorio!");
        }

        public bool TemErroDeEmail()
        {
            return WebDriver.PageSource.Contains("E-mail obrigatorio!");
        }

        public override void Visita()
        {
            throw new NotImplementedException();
        }
    }
}