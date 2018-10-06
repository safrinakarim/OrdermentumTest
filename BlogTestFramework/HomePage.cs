using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogTestFramework
{
    public class HomePage
    { 
        public static bool AsIt(string v)
        {

            // Verifying title of the page after login
           var x = Driver.Instance.FindElement(By.XPath("//p[@class='site-title']"));
            if (x.Text == v)
                return true;
            else
                return false;
        }

        public static void ReachToArticle()
        {
            //Clicking Module from main menu
            IWebElement link_mod = Driver.Instance.FindElement(By.XPath("//span[@class='nav-item-text']  [contains(text(),'Modules')]"));
            link_mod.Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);

            //Clicking submenu blog under module
            IWebElement link_blog = Driver.Instance.FindElement(By.XPath("//a[@href='/private/en/blog/index'] [contains(text(),'Blog')]"));
            link_blog.Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);
        
        }
        public static void InputFormValueToCreateArticle(string art_title)
        {
            //Clicking button to add article 
            IWebElement btn_article = Driver.Instance.FindElement(By.XPath("//a[@class='btn btn-default']"));
            btn_article.Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);

            //Input values in the form
            //Input title
            IWebElement article_input_title = Driver.Instance.FindElement(By.XPath("//input[@id='title']"));
            article_input_title.SendKeys(art_title);
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);

            //Finding frame to switch to input main Content
            IWebElement frameContent = Driver.Instance.FindElement(By.XPath("//div[@id='cke_1_contents']//iframe[@class='cke_wysiwyg_frame cke_reset']"));
            Driver.Instance.SwitchTo().Frame(frameContent);

            //Input Main content
            IWebElement contentText = Driver.Instance.FindElement(By.CssSelector("body"));
            contentText.Click();
            contentText.SendKeys("Test article Content");

            //Switch to main content from the iframe
            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);

            //uploading image
            IWebElement attachment = Driver.Instance.FindElement(By.XPath("//input[@id='image']"));
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path + "\\test.png";
            attachment.SendKeys(path);
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);

            //Finding frame to switch to input summary
            IWebElement frameSummary = Driver.Instance.FindElement(By.XPath("//div[@id='cke_2_contents']//iframe[@class='cke_wysiwyg_frame cke_reset']"));
            Driver.Instance.SwitchTo().Frame(frameSummary);

            //Input summary
            IWebElement summaryText = Driver.Instance.FindElement(By.CssSelector("body"));
            summaryText.Click();
            summaryText.SendKeys("Test article Summary");

            //Return to the main content from iframe
            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);

        }
        public static bool PublishedArticleTitleAsIt()
        {
            //Verifying newly created article published on blog site
            Driver.Instance.Url = "https://demo.fork-cms.com/en/modules/blog";

            IWebElement articleTable = Driver.Instance.FindElement(By.XPath(" //div[@class='block-body']//article[@class='article']"));

            List<IWebElement> lstElem = new List<IWebElement>(articleTable.FindElements(By.TagName("h2")));

            foreach (IWebElement article in lstElem)
            {

                IWebElement name = article.FindElement(By.TagName("a"));
                if (name.Text == "Test Published Article")
                {
                    return true;
                }

            }
            return false;

        }
        public static bool DraftArticleTitleAsIt()
        {
            //Verifying newly created draft exist on the draft article list
            Driver.Instance.Url = "https://demo.fork-cms.com/private/en/blog/index";
            IWebElement elemTable = Driver.Instance.FindElement(By.XPath("//div[@class='content-block content-block-pb']//h2[contains(text(),'Drafts')]/../..//tbody"));
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));

            foreach (IWebElement elemTr in lstTrElem)
            {

                IWebElement title = elemTr.FindElement(By.ClassName("title"));
                if (title.Text == "Test Draft Article")
                {
                    return true;
                }

            }
            return false;
        }
        public static void SaveDraftArticle()
        {
            ReachToArticle();
            InputFormValueToCreateArticle("Test Draft Article");
            
            //saving article as Draft
            IWebElement save_draft = Driver.Instance.FindElement(By.XPath("//button[@title='Save draft']"));
            save_draft.Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);

            
        }

        public static void PublishArticle()
        {
            ReachToArticle();
            InputFormValueToCreateArticle("Test Published Article");
            //saving article as Published
            IWebElement publish = Driver.Instance.FindElement(By.XPath("//button[@title='Publish']"));
            publish.Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);
       
        }



    }
}
