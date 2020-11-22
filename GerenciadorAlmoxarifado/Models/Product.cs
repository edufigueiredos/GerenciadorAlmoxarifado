using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorAlmoxarifado.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
        public int StructuredCode { get; set; }
        public int AlternativeCode { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Group { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
