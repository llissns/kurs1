using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using kurrab.Classes;
using System.Net;

namespace kurrabUnitTests.Classes
{
    [TestClass]
    public class CredentialTest
    {
        [TestMethod]
        public void CredentialSearchTest()
        {
            // класс креденшл будет хранить в себе логин и пароль каждого пользователя
            // при этом будет иметь статический метод поиска bool searchForCredential(List<Credential> creds)
            // нужно написать юнит тест этого метода - передавать в него заранее приготовленный список креденшлов 
            // и провреять результат работы

            // Arrange: creating credential list
            List < Credential >  credlist = new List<Credential >();
            credlist.Add(new Credential("admin", "123123"));
            credlist.Add(new Credential("user", "234234"));


            // Act: searching for specified credential at list
            // false cases
            bool result1 = Credential.searchForCredential(credlist, new Credential("login", "password"));
            bool result2 = Credential.searchForCredential(credlist, new Credential("admin", "wrong_password"));
            bool result3 = Credential.searchForCredential(credlist, new Credential("user", "wrong_password"));

            // true cases:
            bool result4 = Credential.searchForCredential(credlist, new Credential("admin", "123123"));
            bool result5 = Credential.searchForCredential(credlist, new Credential("user", "234234"));

            // Assert: making sure result is true
            // checking false cases results
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);

            // checking true cases results
            Assert.IsTrue(result4);
            Assert.IsTrue(result5);
        }
    }
}
