using System.ComponentModel.DataAnnotations;

namespace Models{
    public class Forgot{
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Meal is required")]
        public string Meal { get; set; }
    }
}