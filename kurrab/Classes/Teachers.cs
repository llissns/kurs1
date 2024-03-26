using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurrab.Classes
{
    internal class Teachers
    {
        string name, surname, patronymic, subject;
        public Teachers(string _name, string _surname, string _patronymic, string _subject)
        {
            name = _name;
            surname = _surname;
            patronymic = _patronymic;
            subject = _subject;
        }
    }
}
