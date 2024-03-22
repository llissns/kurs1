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
            credlist.Add(new Credential("admin", "pass"));
            credlist.Add(new Credential("user", "pass"));


            // Act: searching for specified credential at list
            bool result = Credential.searchForCredential(credlist, new Credential("login", "password"));

            // Assert: making sure result is true
            Assert.IsTrue(result);
        }
    }
}
