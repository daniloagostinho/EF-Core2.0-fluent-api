using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi.Models
{
    public class Planeta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Tamanho { get; set; }

        public Galaxia Galaxia { get; set; }
    }
}
