using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace kurrab.Classes
{
    internal class Student
    {
        string name, surname, patronymic, group;
        public Student(string _name, string _surname, string _patronymic, string _group)
        {
            name = _name;
            surname = _surname; 
            patronymic = _patronymic;   
            group = _group;
        }
    }
}
