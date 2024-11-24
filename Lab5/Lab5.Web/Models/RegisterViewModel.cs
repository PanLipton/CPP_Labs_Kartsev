using System.ComponentModel.DataAnnotations;

namespace Lab5.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ім'я користувача обов'язкове")]
        [StringLength(50, ErrorMessage = "Ім'я користувача має бути не більше 50 символів")]
        [Display(Name = "Ім'я користувача")]
        public string Username { get; set; }

        [Required(ErrorMessage = "ПІБ обов'язкове")]
        [StringLength(500, ErrorMessage = "ПІБ має бути не більше 500 символів")]
        [Display(Name = "ПІБ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Пароль обов'язковий")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Пароль має бути від 8 до 16 символів")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,16}$",
            ErrorMessage = "Пароль повинен містити мінімум 1 цифру, 1 спеціальний знак, 1 велику літеру")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження паролю")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Номер телефону обов'язковий")]
        [RegularExpression(@"^\+380\d{9}$", 
            ErrorMessage = "Телефон повинен бути у форматі +380XXXXXXXXX")]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email обов'язковий")]
        [EmailAddress(ErrorMessage = "Неправильний формат email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}