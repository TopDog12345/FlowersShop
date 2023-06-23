using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slobodianiuk.University.Example.Models.Frontend
{
    public class CreateFlowerRequest
    {
        [Required(ErrorMessage = "Це поле є обов'язковим.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Це поле є обов'язковим.")]
        public int? price { get; set; }
    }
}
