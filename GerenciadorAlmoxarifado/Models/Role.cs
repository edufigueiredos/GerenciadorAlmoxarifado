using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorAlmoxarifado.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}
