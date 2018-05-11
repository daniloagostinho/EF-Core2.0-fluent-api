using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi.Models
{
    public class BuracoNegro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Tamanho { get; set; }

        public Galaxia Galaxia { get; set; }
    }
}
