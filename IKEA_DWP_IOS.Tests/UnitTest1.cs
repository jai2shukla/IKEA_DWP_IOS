using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKEA_DWP_IOS.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            About about = new About();
            String firstName = "Shatrunjay"; 
            string lastName = "Shukla";
            string fullName = firstName + " " + lastName;
            string expected = "Shatrunjay Shukla";
            string actual;
            actual = about.GetName(firstName, lastName);
            //Assert  
            Assert.AreEqual(expected, fullName);

        }
    }
}
