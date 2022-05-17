using Microsoft.VisualStudio.TestTools.UnitTesting;
using praktika2022;
using System;
using System.Data.SqlClient;

namespace UnitTestProject1
{
    [TestClass]
    public class praktika2022test
    {
        [TestMethod]
        public void TestMethod1()
        {
            praktika2022.Class1 test = new praktika2022.Class1();
            var win = new MainWindow();

            bool expected = true;
            bool actual = win.Auth("Drago112", "Grag118@");
            Assert.AreEqual(expected, actual);
            
            
        }
    }
}
