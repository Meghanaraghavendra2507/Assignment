using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAssignmentUnitTesting.Repositories
{
  
    /// <summary>
    /// Summary description for BookRepository
    /// </summary>
    [TestClass]
    public class BookRepository
    {
        private BookRepository bookRepository;
        public BookRepository()
        {
            //
            // TODO: Add constructor logic here
            //
            bookRepository = new BookRepository();
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetBooks()
        {
            var result = bookRepository.GetBooks() as ViewResultBase;
            var Booksdata = result.ViewData.ToList();
            CollectionAssert.AllItemsareNotNull(Booksdata);
        }
    }
}
