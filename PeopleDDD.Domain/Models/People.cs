using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleDDD.Domain.Models
{
    public class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public string Phone { get; set; }
    }
}
