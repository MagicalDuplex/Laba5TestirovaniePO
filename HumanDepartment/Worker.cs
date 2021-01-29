using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment
{
    public class Worker
    {
        public string name { get; set; }
        public string secondname { get; set; }
        public string age { get; set; }
        public string monthsWorkedOut { get; set; }

        public string position { get; set; }

        public string passport { get; set; }

        public Worker(string _name, string _secondname, string _age,string _monthsWorkedOut,string _position,string _passport)
        {
            name = _name;
            secondname = _secondname;
            age = _age;
            monthsWorkedOut = _monthsWorkedOut;
            position = _position;
            passport = _passport;
        }
    }
}
