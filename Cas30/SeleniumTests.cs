using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Cas30
{
    class SeleniumTests
    {
        IWebDriver Driver;
        WebDriverWait Wait;
        Random Rnd = new Random();

        [Test]
        [Category("Create"), Category("Site: test.qa.rs")]
        public void TestCreateNewUser()
        {
            GoTo("http://test.qa.rs/");

            IWebElement LinkCreate = Wait.Until(
                EC.ElementIsVisible(
                    By.LinkText("Kreiraj novog korisnika")
                )
            );
            if (LinkCreate.Displayed && LinkCreate.Enabled)
            {
                LinkCreate.Click();
            }

            IWebElement InputName = Wait.Until(
                EC.ElementIsVisible(
                    By.Name("ime")
                )
            );
            if (InputName.Displayed && InputName.Enabled)
            {
                InputName.SendKeys(
                    Functions.RandomAlpha(
                        Rnd.Next(10, 20)
                    )
                );
            }

            IWebElement InputLastName = FindElement(By.Name("prezime"));
            if (InputLastName != null)
            {
                InputLastName.SendKeys(
                    Functions.RandomAlpha(
                        Rnd.Next(10, 20)
                    )
                );
            }

            IWebElement InputUserName = FindElement(By.Name("korisnicko"));
            InputUserName?.SendKeys(
                    Functions.RandomAlphaNumeric(
                        Rnd.Next(10, 20)
                    )
                );

            IWebElement InputEmail = FindElement(By.Name("email"));
            InputEmail?.SendKeys(Functions.RandomEmail());

            IWebElement InputPhone = FindElement(By.Name("telefon"));
            InputPhone?.SendKeys(Functions.RandomTelephone());

            IWebElement InputCountry = FindElement(By.Name("zemlja"));
            if (InputCountry != null)
            {
                SelectElement SelectCountry = new SelectElement(InputCountry);
                SelectCountry.SelectByText("Sweden");
            }

            IWebElement InputCity = Wait.Until(
                EC.ElementIsVisible(
                    By.Name("grad")
                )
            );
            if (InputCity.Displayed && InputCity.Enabled)
            {
                SelectElement SelectCity = new SelectElement(InputCity);
                int NumberOfOptions = SelectCity.Options.Count;
                SelectCity.SelectByIndex(Rnd.Next(1, NumberOfOptions - 1));
            }

            IWebElement InputStreet = FindElement(
                By.XPath("//div[@id='address']//input")
            );
            InputStreet?.SendKeys(
                    Functions.RandomAlpha(
                        Rnd.Next(10, 20)
                    ) +
                    " " +
                    Rnd.Next(1, 100)
                );

            IWebElement InputGender = FindElement(By.Id("pol_m"));
            InputGender?.Click();

            IWebElement ButtonRegister = FindElement(By.Name("register"));
            ButtonRegister?.Click();

            System.Threading.Thread.Sleep(5000);

        }

        public IWebElement FindElement(By Selector)
        {
            IWebElement ReturnElement = null;
            try
            {
                ReturnElement = Driver.FindElement(Selector);
            }
            catch (NoSuchElementException)
            {
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return ReturnElement;
        }

        public void GoTo(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
