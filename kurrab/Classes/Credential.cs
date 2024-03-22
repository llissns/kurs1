using System.Collections.Generic;

namespace kurrab.Classes
{
    /// <summary>
    /// класс отвечает за хранение учетных данных и поиск по ним в общем списке
    /// </summary>
    public class Credential
    {
        string login;
        string password;

        // этот конструктор вызывается в классе DbConnector чтобы быстро создать полный список учетных данных и сохранить его в тип List<Credential>
        public Credential(string _login, string _password)
        {
            login       = _login;
            password    = _password;
        }

        public static bool searchForCredential(List<Credential> credential, Credential cred)
        {
            for(int i = 0; i <credential.Count; i++)
            {
                if (credential[i].login == cred.login && credential[i].password == cred.password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
