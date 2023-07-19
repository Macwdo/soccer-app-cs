using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Services;

public class LoginService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<UserEntity> _userManager;
    private readonly UserEntity _user;

    public LoginService(
        IConfiguration configuration,
        UserManager<UserEntity> userManager,
        UserEntity user
        )
    {
        _userManager = userManager;
        _configuration = configuration;
        _user = user;
    }
    
    public async Task<string> CreateTokenAsync() 
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
    
    private SigningCredentials GetSigningCredentials()
    {
        var jwtConfig = _configuration.GetSection("jwtConfig");
        var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
    
    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim("Player", "View"),
            new Claim(ClaimTypes.Role , "Client")
        };
        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;
    }
    
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JWT_CONFIG");
        var tokenOptions = new JwtSecurityToken
        (
            issuer: jwtSettings["VALID_ISSUER"],
            audience: jwtSettings["VALID_AUDIENCE"],
            claims: claims,
            expires: DateTime.Now.AddHours(Convert.ToDouble(jwtSettings["EXPIRE_IN_HOUR"])),
            signingCredentials: signingCredentials
        );
        return tokenOptions;
    }
    
}