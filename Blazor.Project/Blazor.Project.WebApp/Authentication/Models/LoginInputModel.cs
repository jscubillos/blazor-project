using System.ComponentModel.DataAnnotations;

namespace Blazor.Project.WebApp.Authentication;

public class LoginInputModel
{
    [Required(ErrorMessage = "Emais is required")]
    [EmailAddress]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}