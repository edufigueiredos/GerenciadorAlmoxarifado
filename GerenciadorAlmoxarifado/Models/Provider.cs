using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorAlmoxarifado.Models
{
    public class Provider : IMover
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Provider() { Type = "Provider"; }
        public string Type { get; set; }
    }
}
