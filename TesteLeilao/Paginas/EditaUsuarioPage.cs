using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TesteLeilao.Paginas
{
    public class EditaUsuarioPage : PageBase
    {
        public EditaUsuarioPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Visita()
        {
            throw new NotImplementedException();
        }

        public void Edita(string nome, string email)
        {
            var campoNome = WebDriver.FindElement(By.Name("usuario.nome"));
            var campoEmail = WebDriver.FindElement(By.Name("usuario.email"));
            var botao = WebDriver.FindElement(By.Id("btnSalvar"));

            campoNome.Clear();
            campoNome.SendKeys(nome);
            campoEmail.Clear();
            campoEmail.SendKeys(email);

            botao.Click();
        }
    }
}
