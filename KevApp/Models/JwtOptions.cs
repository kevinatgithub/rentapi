#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using Microsoft.IdentityModel.Tokens;

namespace KevApp.Api.Models;

public class JwtOptions
{
    public string SecurityKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public SecurityKey SecurityKeyToken { get; set; }
    public string DefaultAuthenticateScheme { get; set; }
    public string DefaultChallengeScheme { get; set; }
    public string DefaultScheme { get; set; }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.