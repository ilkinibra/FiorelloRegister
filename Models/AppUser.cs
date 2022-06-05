using Microsoft.AspNetCore.Identity;

namespace fiorello.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}
