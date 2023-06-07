using System;

namespace Shop.Domain
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public int Categoria_id { get; set; }

        public int Fornecedor_id { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public Categoria Categoria { get; set; }
    }
}
