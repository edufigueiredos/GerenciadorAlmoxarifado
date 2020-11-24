using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorAlmoxarifado.Models
{
    public class Movement
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public bool Input { get; set; }
        public bool Output { get; set; }
        public DateTime Date { get; set; }
        public int MoverTypeId { get; set; }
        public MoverType MoverType { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
