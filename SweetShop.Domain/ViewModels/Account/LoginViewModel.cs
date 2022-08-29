using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Domain.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        //[MaxLength(20, ErrorMessage = "Имя должно иметь длину меньше 20 символов")]
        //[MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; } = null!;
        public string ReturnUrl { get; set; } = "https://localhost:7254/Account/";
    }
}
