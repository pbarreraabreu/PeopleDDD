using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDDD.Domain.Commands
{
    public class PeopleCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public string Phone { get; set; }
    }
}
