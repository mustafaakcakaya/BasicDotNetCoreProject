using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp2.Models
{
    public class UserViewModel:IValidatableObject
    {
        [Display(Name = "Sıra No: ")]
        public int Id { get; set; }


        [Display(Name = "Adı: "),Required(ErrorMessage ="İsim alanı zorunludur."),StringLength(25,ErrorMessage ="Maksimum 25 karakter girilebilir.")]
        public string Name { get; set; }


        [Display(Name = "Soyadı: ")]
        public string Surname { get; set; }


        [Display(Name = "Github Hesabı: "), Required(ErrorMessage = "Github alanı zorunludur."),DataType(DataType.Url,ErrorMessage ="Url formatı hatalıdır.")]
        public string GithubAccountUrl { get; set; }


        [Display(Name = "Email Adresi: ")]
        [Required(ErrorMessage = "Email adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçersiz E-mail adresi.")]
        public string Email { get; set; }


        [Display(Name = "Doğum Tarihi: "),Required(ErrorMessage ="Bu alanı boş bırakamazsınız.")]
        public DateTime BirthDate { get; set; }


        [Display(Name = "Cinsiyet"), Required(ErrorMessage ="Cinsiyet bilgisi seçiniz.")]
        public string Gender { get; set; }

        public IEnumerable<SelectListItem> GenderSelectList { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //gender bilgisinin kontrolü ("Female", "Male")
            if (Gender !="Female" && Gender != "Male")
            {
                yield return new ValidationResult("Cinsiyet Tercihi Yapınız.", new[] {Gender});
            }

            //18 yaşından küçükleri kullanıcı olarak eklememe
            if (BirthDate>DateTime.Now.AddYears(-18))
            {
                yield return new ValidationResult("Yaşınız 18'den büyük olmalıdır.", new[] { nameof(BirthDate) });
            }
        }
    }
}
