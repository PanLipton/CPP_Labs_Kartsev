using System.ComponentModel.DataAnnotations;

namespace Lab5.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введіть ім'я користувача")]
        [Display(Name = "Ім'я користувача")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}