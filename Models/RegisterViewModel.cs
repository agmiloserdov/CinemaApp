using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Это поле обязательно")]
        [Display(Name = "Электронная почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        
        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        public string SecondName { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно")]
        [Display(Name = "Введите пароль повторно")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}