using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace VxTel.TalkMore.Data.Tests.Config
{
    public class SeleniumHelper : IDisposable
    {
        public IWebDriver WebDriver;
        public readonly ConfigurationHelper Configuration;
        public WebDriverWait Wait;

        public SeleniumHelper(Browser browser, ConfigurationHelper configuration, bool headless = true)
        {
            Configuration = configuration;
            WebDriver = WebDriverFactory.CreateWebDriver(browser, Configuration.WebDrivers, headless);
            WebDriver.Manage().Window.Maximize();
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
        }

        public string GetUrl()
        {
            return WebDriver.Url;
        }

        public void GoToUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public bool ValidarConteudoUrl(string content)
        {
            return Wait.Until(ExpectedConditions.UrlContains(content));
        }

        public void ClickLinkByText(string linkText)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkText)));
            link.Click();
        }

        public void ClickButomById(string buttomId)
        {
            var botao = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(buttomId)));
            botao.Click();
        }

        public void ClickByXPath(string xPath)
        {
            var elemento = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            elemento.Click();
        }

        public IWebElement GetElementByClass(string classeCss)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(classeCss)));
        }

        public IWebElement GetElementByXPath(string xPath)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }

        public void FillTextBoxById(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            campo.SendKeys(valorCampo);
        }

        public void FillDropDownById(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            var selectElement = new SelectElement(campo);
            selectElement.SelectByValue(valorCampo);
        }

        public string GetTextElementByClassCss(string className)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className))).Text;
        }

        public string GetTextElementById(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Text;
        }

        public string GetValueTextBoxById(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)))
                .GetAttribute("value");
        }

        public IEnumerable<IWebElement> GetListByClass(string className)
        {
            return Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(className)));
        }

        public bool ValidateIfElementExistByIr(string id)
        {
            return ElementoExistente(By.Id(id));
        }

        public void VoltarNavegacao(int vezes = 1)
        {
            for (var i = 0; i < vezes; i++)
            {
                WebDriver.Navigate().Back();
            }
        }

        public void ObterScreenShot(string nome)
        {
            SalvarScreenShot(WebDriver.TakeScreenshot(), string.Format("{0}_" + nome + ".png", DateTime.Now.ToFileTime()));
        }

        private void SalvarScreenShot(Screenshot screenshot, string fileName)
        {
            screenshot.SaveAsFile($"{Configuration.FolderPicture}{fileName}", ScreenshotImageFormat.Png);
        }

        private bool ElementoExistente(By by)
        {
            try
            {
                WebDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Dispose()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }
    }
}

