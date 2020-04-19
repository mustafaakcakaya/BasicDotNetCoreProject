using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp2.Models
{
    public class BookViewModel
    {
        [Range(0,int.MaxValue)]
        public int Id { get; set; }


        [Required(ErrorMessage ="Kitap adı alanı gereklidir.")]
        [StringLength(25, ErrorMessage ="En fazla 100 karakter girebilirsiniz.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Yazar gereklidir.")]
        public string Author { get; set; }



        [Required(ErrorMessage = "Yayın evi gereklidir.")]
        public string Publisher { get; set; }

    }
}
