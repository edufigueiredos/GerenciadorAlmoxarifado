﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorAlmoxarifado.Models
{
    public class Branch : IMover
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Branch() { Type = "Branch"; }
        public string Type { get; set; }
    }
}
