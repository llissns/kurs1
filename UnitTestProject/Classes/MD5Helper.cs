using kurrab.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace kurrabUnitTests.Classes
{
    [TestClass]
    public class MD5Helper
    {
        [TestMethod]
        public void TestGetMD5Hash()
        {
            // Arrange: creating credential list
            string password1 = "admin12345";
            string password2 = "asdf1234";
            string password3 = "asdfAA123__%%";

            // Act: searching for specified credential at list

            // Assert: making sure result is true
            string hash1 = kurrab.Classes.MD5Helper.GetMd5Hash(password1);
            string hash2 = kurrab.Classes.MD5Helper.GetMd5Hash(password2);
            string hash3 = kurrab.Classes.MD5Helper.GetMd5Hash(password3);
            
            // checking true cases results
            Assert.IsTrue(hash1 == "7488e331b8b64e5794da3fa4eb10ad5d");
            Assert.IsTrue(hash2 == "1adbb3178591fd5bb0c248518f39bf6d");
            Assert.IsTrue(hash3 == "7bf63f8ef06dbc66a38f237770a60f99");
        }
    }
}
