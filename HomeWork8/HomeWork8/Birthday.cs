using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    [Serializable]
    public class Birthday
    {
        public string name;
        public DateTime date;
        public Birthday() { }
        public Birthday(string name,DateTime date)
        {
            this.name = name;
            this.date = date;
        }
    }
}
