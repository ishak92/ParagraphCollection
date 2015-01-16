using ParagraphProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WordParagraphCollectorTests
{
    
    
    /// <summary>
    ///This is a test class for WordParagraphExtracterTest and is intended
    ///to contain all WordParagraphExtracterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WordParagraphExtracterTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for getAllParagraphs
        ///</summary>
        [TestMethod()]
        public void getAllParagraphsTestNumberTest()
        {
            var wordParagraphCollector = new WordParagraphExtracter();
            wordParagraphCollector.AddParagraphsFromFile(@"C:\Users\Vasya\Documents\Visual Studio 2010\Projects\ParagraphCollection\ParagraphCollection\data\TestFile1.docx");
            var pars = wordParagraphCollector.getAllParagraphs();

            Assert.AreEqual(7, pars.getNumberOfParagpaphs());
        }


        [TestMethod()]
        public void findParagraphTest()
        {
            var wordParagraphCollector = new WordParagraphExtracter();
            wordParagraphCollector.AddParagraphsFromFile(@"C:\Users\Vasya\Documents\Visual Studio 2010\Projects\ParagraphCollection\ParagraphCollection\data\TestFile1.docx");
            var parsWitsWord = wordParagraphCollector.getAllParagraphs().getParagraphsWithSubWord("домен");

            Assert.AreEqual(1, parsWitsWord.getNumberOfParagpaphs());
        }

        [TestMethod()]
        public void canNotFindParagraphTest()
        {
            var wordParagraphCollector = new WordParagraphExtracter();
            wordParagraphCollector.AddParagraphsFromFile(@"C:\Users\Vasya\Documents\Visual Studio 2010\Projects\ParagraphCollection\ParagraphCollection\data\TestFile1.docx");
            var parsWitsWord = wordParagraphCollector.getAllParagraphs().getParagraphsWithSubWord("трололо");

            Assert.AreEqual(0, parsWitsWord.getNumberOfParagpaphs());
        }
    }
}
