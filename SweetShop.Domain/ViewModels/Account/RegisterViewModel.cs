using System.ComponentModel.DataAnnotations;

namespace SweetShop.Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Введите имя пользователя")]
        [MaxLength(20, ErrorMessage = "Имя должно иметь длину меньше 20 символом")]
        [MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]
        public string Name { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(8, ErrorMessage = "Пароль должен иметь длину больше 8 символов")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
