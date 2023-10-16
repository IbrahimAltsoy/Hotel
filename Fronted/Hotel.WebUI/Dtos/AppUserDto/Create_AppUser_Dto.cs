using System.ComponentModel.DataAnnotations;

namespace Hotel.WebUI.Dtos.AppUserDto
{
    public class Create_AppUser_Dto
    {
        [Required(ErrorMessage ="Lütfen ad alanını boş geçmeyiniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyad alanını boş geçmeyiniz.")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Lütfen kullanıcı adı alanını boş geçmeyiniz.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen Şehir alanını boş geçmeyiniz.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Lütfen mail alanını boş geçmeyiniz.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifre alanını boş geçmeyiniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen tekrar şifreyi giriniz.")]
        [Compare("Password", ErrorMessage ="Şifreler uyuşmuyor, şifre alanını lütfen kontrol ediniz")]
        public string ConfirmPassword { get; set; }


        public Guid? WorkLocationId { get; set; } = Guid.Parse("7f45fef5-6e8b-48ea-887f-43b9b71d0d88");
    }
}
