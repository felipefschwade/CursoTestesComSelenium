using System;
using OpenQA.Selenium;

namespace TesteLeilao.Paginas
{
    public class LeiloesPage : PageBase
    {
        public LeiloesPage(IWebDriver driver) : base(driver)
        {
        }

        public LeilaoCadastroPage Novo()
        {
            WebDriver.FindElement(By.LinkText("Novo Leilão")).Click();
            return new LeilaoCadastroPage(WebDriver);
        }

        public override void Visita()
        {
            WebDriver.Navigate().GoToUrl("http://localhost:8080/leiloes");
        }

        public bool TemLeilaoDe(string nomeItem, double preco, string usuarioNome, bool usado)
        {
            return WebDriver.PageSource.Contains(nomeItem) &&
                   WebDriver.PageSource.Contains(Convert.ToString(preco)) &&
                   WebDriver.PageSource.Contains(usuarioNome) &&
                   WebDriver.PageSource.Contains(usado ? "Sim" : "Não");
        }
    }
}