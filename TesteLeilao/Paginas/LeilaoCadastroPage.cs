using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TesteLeilao.Paginas
{
    public class LeilaoCadastroPage : PageBase
    {
        public LeilaoCadastroPage(IWebDriver driver) : base(driver)
        {

        }

        public override void Visita()
        {
            throw new NotImplementedException();
        }

        public void Cadastra(string nomeItem, double preco, string usuario, bool usado)
        {
            var campoNome = WebDriver.FindElement(By.Name("leilao.nome"));
            var campoPreco = WebDriver.FindElement(By.Name("leilao.valorInicial"));
            var cbUsuario = new SelectElement(WebDriver.FindElement(By.Name("leilao.usuario.id")));
            cbUsuario.SelectByText(usuario);

            campoNome.SendKeys(nomeItem);
            campoPreco.SendKeys(Convert.ToString(preco));

            if (usado)
            {
                WebDriver.FindElement(By.Name("leilao.usado")).Click();
            }
            campoNome.Submit();
        }
    }
}