using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSharpCarolinaMiranda
{

    [TestFixture]
    public class TreinamentoBase2
    {
        private ChromeDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void VerificarValoresVerdadeiros()
        {
            string empresa = "Base2";
            Assert.IsTrue(empresa.Equals("Base2"));

            string notebook = "Dell";
            Assert.AreEqual(notebook, "Dell");
        }

        [Test]
        public void VerificarValoresFalsos()
        {
            string smartphone = "Samsung";
            Assert.IsFalse(smartphone.Equals("iPhone"));
        }

        [Test]
        public void InstanciarDriver()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            Assert.AreEqual(driver.Title, "Google");
            Assert.AreEqual(driver.Url, "https://www.google.com/");
        }

        [Test]
        [Obsolete]
        public void EncontrarElementos()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.Name("q")).SendKeys("Base2 Tecnologia");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnK"))).Click();
        }

        [Test]
        [Obsolete]
        public void PreencherTodosOsCampos()
        {
            driver.Navigate().GoToUrl("https://ultimateqa.com/filling-out-forms/");
            driver.FindElement(By.Id("et_pb_contact_name_0")).SendKeys("Carol");
            driver.FindElement(By.Id("et_pb_contact_message_0")).SendKeys("Teste");
            driver.FindElement(By.ClassName("et_contact_bottom_container")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("et-pb-contact-message")));
            IWebElement message = driver.FindElement(By.ClassName("et-pb-contact-message"));
            string successMessage = message.Text;
            string successfully = "Form filled out successfully";
            Assert.IsTrue(successMessage.Equals(successfully));
        }

        [Test]
        [Obsolete]
        public void PreencherUmCampo()
        {
            driver.Navigate().GoToUrl("https://ultimateqa.com/filling-out-forms/");
            driver.FindElement(By.Id("et_pb_contact_message_0")).SendKeys("Teste");
            driver.FindElement(By.ClassName("et_contact_bottom_container")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("et-pb-contact-message")));
            IWebElement message = driver.FindElement(By.ClassName("et-pb-contact-message"));
            string messageFields = message.Text;
            string messageError = "Please, fill in the following fields:\r\nName";
            Assert.AreEqual(messageFields, messageError);
        }

        [Test]
        [Obsolete]
        public void SiteMultiplasAcoes()
        {
            driver.Navigate().GoToUrl("https://www.base2.com.br/");
            string base2 = "https://www.base2.com.br/";
            Assert.IsTrue(base2.Equals(driver.Url));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menu-item-336"))).Click();
            driver.Navigate().Back();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menu-item-2627"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menu-item-2162"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menu-item-334"))).Click();
            driver.Navigate().GoToUrl("http://google.com/");
        }

        [Test]
        public void ComboBox()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            SelectElement combobox = new SelectElement(driver.FindElement(By.Id("dropdown")));
            combobox.SelectByValue("2");
        }

        [Test]
        [Obsolete]
        public void CrowdTest()
        {
            driver.Navigate().GoToUrl("http://blackmirror.crowdtest.me/users/sign_in");
            driver.FindElement(By.Id("user_email")).SendKeys("carolina.miranda@base2.com.br");
            driver.FindElement(By.Id("user_password")).SendKeys("base2tecnologia");
            driver.FindElement(By.Name("commit")).Click();
            driver.FindElement(By.ClassName("column-button")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#wrapper > nav > div.navbar-default.sidebar.paypertest-sidebar > div > ul > a:nth-child(2)"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btn_open_project_595"))).Click();
            driver.FindElement(By.Id("li-test-cases-link")).Click();
            IWebElement test = driver.FindElement(By.ClassName("sorting_1"));
            string testCases = test.Text;
            string validateTextTestCases = "CT09 - Verificar Acesso";
            Assert.AreEqual(testCases, validateTextTestCases);
        }
    }
}