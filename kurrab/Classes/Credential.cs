using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurrab.Classes
{
    internal class Credential
    {
        public string login;
        public string password;

        Credential(string _login, string _password)
        {
            login       = _login;
            password    = _password;
        }
        public static bool searchForCredential(List<Credential> credential, Credential cred)
        {
         // TODO: надо описать код поиска здесь
            return false;
        }
    }
}
