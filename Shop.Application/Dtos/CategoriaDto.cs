using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
         StringLength(25, MinimumLength = 3, ErrorMessage = "Insira de 3 a 25 caracteres.")]
        public string Nome { get; set; }

    }
}
