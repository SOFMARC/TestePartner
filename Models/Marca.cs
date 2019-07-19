using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApiPartner.Models
{
    public class Marca
    {
        [Required]  
        public int MarcaId { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
