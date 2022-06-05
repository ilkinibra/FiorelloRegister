using System.ComponentModel.DataAnnotations;

namespace fiorello.ViewModels
{
    public class RegisterVM
    {
        [Required,StringLength(100)]
        public string Fullname { get; set; }
        [Required, StringLength(100)]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password),Compare(nameof(Password))]
        public string CheckPassword { get; set; }
    }
}
