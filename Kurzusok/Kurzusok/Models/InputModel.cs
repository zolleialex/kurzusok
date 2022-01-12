using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Kurzusok.Models
{
    public class InputModel
    {
        [Required(ErrorMessage = "A felhasználó név megadása kötelező!")]
        [DataType(DataType.Text)]
        [Display(Name = "Felhasználó név")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Az email cím megadása kötelező!")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A jelszó megadása kötelező!")]
        [StringLength(100, ErrorMessage = "A jelszó minimum {2} és maximum {1} karakter hosszú lehet.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Jelszó megerősítése")]
        [Compare("Password", ErrorMessage = "A két jelszó nem egyezik.")]
        public string ConfirmPassword { get; set; }
    }
}
