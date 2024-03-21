using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace rurrabTests.Classes
{
    [TestClass]
    public class Credential
    {
        [TestMethod]
        public void CredentialSearchTest()
        {
            // класс креденшл будет хранить в себе логин и пароль каждого пользователя
            // при этом будет иметь статический метод поиска bool searchForCredential(List<Credential> creds)
            // нужно написать юнит тест этого метода - передавать в него заранее приготовленный список креденшлов 
            // и провреять результат работы

            // Arrange
            Dictionary<string, string> credentials = new Dictionary<string, string>();
            credentials.Add("admin", "hash");
            credentials.Add("user", "hash");


            // Act
            bool result = Credential.searchForCredentials(credentials);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
