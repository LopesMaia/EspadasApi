using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EspadasApi.Models
{
    public class Espada
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(80)]
        public string Nome { get; set; }


        [Required]
        [StringLength(80)]
        public string Familia { get; set; }


        [Required]
        public int Forca { get; set; }


        [Required]
        public double Durabilidade { get; set; }

    }
}