using System.ComponentModel.DataAnnotations;

namespace RTD.Web.Models;

public class AccountModel
{
    [Required, MinLength(4, ErrorMessage = "Username must be at least 4 characters long")]
    public string Username { get; set; }

    [Required, MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string Password { get; set; }

    public string? Error { get; set; }

    public bool HasError()
    {
        return !string.IsNullOrEmpty(Error);
    }
}