﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoCSVclientes.Models
{
    internal class Cliente
    {
        public string CpfCliente { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string? Telefone { get; set; }

    }
}
