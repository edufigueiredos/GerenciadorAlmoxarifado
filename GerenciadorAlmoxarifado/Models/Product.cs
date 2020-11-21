using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorAlmoxarifado.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StructuredCode { get; set; }
        public int AlternativeCode { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
        public string Group { get; set; }
    }
}
