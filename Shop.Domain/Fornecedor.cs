using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
