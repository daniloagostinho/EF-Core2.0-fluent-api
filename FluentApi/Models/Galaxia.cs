using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi.Models
{
    public class Galaxia
    {

        public Galaxia()
        {
            BuracoNegros = new List<BuracoNegro>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Tamanho { get; set; }

        public Planeta Planeta { get; set; }
        public List<BuracoNegro> BuracoNegros { get; set; }


    }
}
