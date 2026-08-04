namespace PersonalLifeOS.Domain.Users;

public class UserPreference
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public LanguagePreference Language { get; set; } = LanguagePreference.Auto;

    public ThemePreference Theme { get; set; } = ThemePreference.System;

    public string Currency { get; set; } = "VND";

    public string TimeZone { get; set; } = "Asia/Ho_Chi_Minh";
}
