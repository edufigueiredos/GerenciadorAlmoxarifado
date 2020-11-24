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
        public string Lastname { get; set; }
        public string UniformSize { get; set; }
        public int ShoesSize { get; set; }
        public int SleevesSize { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
