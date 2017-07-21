using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace TesteLeilao.Paginas
{
    public abstract class PageBase : IPage
    {
        public IWebDriver WebDriver { get; private set; }
        public PageBase(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public abstract void Visita();
    }
}