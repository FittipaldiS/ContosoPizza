using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ContosoPizzaUser class
public class ContosoPizzaUser : IdentityUser
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
}

