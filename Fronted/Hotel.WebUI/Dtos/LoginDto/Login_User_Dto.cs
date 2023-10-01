using System.ComponentModel.DataAnnotations;

namespace Hotel.WebUI.Dtos.LoginDto
{
    public class Login_User_Dto
    {
        [Required(ErrorMessage ="Lütfen email giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi giriniz")]
        public string Password { get; set; }
    }
}
