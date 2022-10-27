using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TGTG_Portal.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? EmailAddress { get; set; }

        [Required]
        [UIHint("Password")]
        [PasswordPropertyText]
        public string? Password { get; set; }
    }
}
