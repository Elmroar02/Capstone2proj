using System.ComponentModel.DataAnnotations;

namespace Models{
public class Login
{
    [Required(ErrorMessage = "Username required")]

    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]

    public string Password { get; set; }
}
}


