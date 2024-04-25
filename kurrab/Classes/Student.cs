using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace kurrab.Classes
{
    // этот класс объединяет информацию о студенте
    internal class Student
    {
        // поля класса соответствуют полям таблицы БД о студентах
        public string name, surname, patronymic, group, phonenumber, email;

        // конструктор лишь сохраняет значения полей
        public Student(string _name, string _surname, string _patronymic, string _group, string _phonenumber, string _email)
        {
            name = _name;
            surname = _surname; 
            patronymic = _patronymic;   
            group = _group;
            phonenumber = _phonenumber;
            email= _email;
        }
    }
}
