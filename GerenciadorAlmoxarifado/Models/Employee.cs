using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorAlmoxarifado.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public string Sector { get; set; }
        public string UniformSize { get; set; }
        public int ShoesSize { get; set; }
        public int SleevesSize { get; set; }
    }
}
