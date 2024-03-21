using System.Collections.Generic;

namespace kurrab.Classes
{
    public class Credential
    {
        string login;
        string password;

        public Credential(string _login, string _password)
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
