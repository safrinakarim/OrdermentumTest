using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogTestFramework;

namespace BlogTest
{
    [TestClass]
    public class AllTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialise();

        }

        [TestMethod]
        public void LogInAsAdmin()
        {
            LoginPage.Goto();
            LoginPage.LoginAs("demo@fork-cms.com").withPassword("demo").Login();
            //Verifying login test
            Assert.IsTrue(HomePage.AsIt("My website Visit website"), "Fail to Login");


        }
        [TestMethod]
        public void CreateDraftArticle()
        {
            LogInAsAdmin();
            //Creating draft article
            HomePage.SaveDraftArticle();
           // Verifying creation of draft article
            Assert.IsTrue(HomePage.DraftArticleTitleAsIt(), "Draft Article not found");
        }

        [TestMethod]
        public void PublishArticle()
        {
            LogInAsAdmin();
             //publish article 
            HomePage.PublishArticle();
            //Seeing it in blog
            Assert.IsTrue(HomePage.PublishedArticleTitleAsIt(), "Article not found");
        }

        [TestCleanup]
        public void close()
        {
            Driver.Close();

        }

    }
}


