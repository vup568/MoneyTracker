using Microsoft.AspNetCore.Identity;

namespace PersonalLifeOS.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string DisplayName { get; set; } = string.Empty;
}
