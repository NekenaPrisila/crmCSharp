// Models/LoginModel.cs
using System.ComponentModel.DataAnnotations;

namespace CRMSharp.Models
{
    public class LoginModel
    {
        public LoginInputModel Input { get; set; } = new LoginInputModel();

        public class LoginInputModel
        {
            [Required(ErrorMessage = "L'email est obligatoire")]
            [EmailAddress(ErrorMessage = "Format d'email invalide")]
            public string Email { get; set; }

            [DataType(DataType.Password)]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }
    }
}