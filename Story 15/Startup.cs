using System.ComponentModel.DataAnnotations;

public class Swimmer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number format.")]
    public string PhoneNumber { get; set; }
}

