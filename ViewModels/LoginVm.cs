using System.ComponentModel.DataAnnotations;

namespace fiorello.ViewModels
{
    public class LoginVm
    {
        [Required,DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
