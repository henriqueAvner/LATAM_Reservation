﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTesting.access
{ 

     class AutomationWeb
    {
        public IWebDriver driver;
        public string OriginTrip { get; set; }
        public string DestinyTrip { get; set; }

        public DateTime Ida { get; set; }
        public DateTime Chegada { get; set; }

        public AutomationWeb(string originTrip, string destinyTrip)
        {
            driver = new ChromeDriver();
            OriginTrip = originTrip;
            DestinyTrip = destinyTrip;
            //Ida = ida;
            //Chegada = chegada;
        }

        public void LatamTest()
        {
            //Navegação ao google
            driver.Navigate().GoToUrl("https://www.google.com.br");
            driver.Manage().Window.Maximize();
            //Pesquisa sobre a LATAM
            driver.FindElement(By.Name("q")).SendKeys("LATAM");
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[4]/center/input[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"tads\"]/div/div/div/div/div[1]/a/div[1]/span")).Click();
            //aceitando os cookies
            driver.FindElement(By.XPath("//*[@id=\"cookies-politics-button\"]/span")).Click();
            //Ida:
            driver.FindElement(By.XPath("//*[@id=\"txtInputOrigin_field\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"txtInputOrigin_field\"]")).SendKeys(OriginTrip);
            driver.FindElement(By.Id("btnItemAutoComplete_0")).Click();
            //Volta:
            driver.FindElement(By.XPath("//*[@id=\"txtInputDestination_field\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"txtInputDestination_field\"]")).SendKeys(DestinyTrip);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnItemAutoComplete_0")).Click();
            //data de Ida calendário:
            driver.FindElement(By.XPath("//*[@id=\"inputSection\"]/form/div/div[3]/div/div[1]")).Click();
            Console.ReadLine();
            //Botao de pesquisar:
            driver.FindElement(By.XPath("//*[@id=\"btnSearchCTA\"]")).Click();

            Thread.Sleep(7000);

            string newTab = driver.WindowHandles.Last();
            driver.SwitchTo().Window(newTab);

            


            List<IWebElement> tripCards = driver.FindElements(By.ClassName("kKMdJR")).ToList();
  
            
            for (int i = 0; i < tripCards.Count; i++)
            {
                IWebElement cardInfo = tripCards[i].FindElement(By.Id($"FlightInfoComponent{i}"));
                string goingDate = cardInfo.FindElement(By.ClassName($"flight-information"))
                    .FindElement(By.ClassName("kvztEO")).Text;
                string goingDuration = cardInfo.FindElement(By.ClassName("flight-duration")).FindElement(By.TagName("span")).Text;
                string arriveDate = cardInfo.FindElement(By.ClassName("flight-information"))
                    .FindElement(By.ClassName("kvztEO")).Text;

                
                List<IWebElement> divValueTrip =[.. cardInfo.FindElements(By.XPath($"//*[@id=\"WrapperCardFlight{i}\"]/div/div[2]/div[2]"))];
                //erro nessa linha abaixo:
                string valueTrip = divValueTrip[1].Text;
            }
            

        }
    }
}
