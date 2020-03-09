using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Hello
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Login:{Login}, Password:{Password}";
        }
    }
}
