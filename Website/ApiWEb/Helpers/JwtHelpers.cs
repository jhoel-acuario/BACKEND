using ApiWEb.Models.UserValidatorToken;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiWEb.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            List<Claim> claims = new()
            {
                new Claim("Id", userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm ss tt")),
            };
            if (userAccounts.UserName =="admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }else if (userAccounts.UserName=="User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "user"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }
            return claims;
        }
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }
        public static UserTokens GetTokenKey(UserTokens model, JwtSetting jwtSetting)
        {
            try
            {
                var UserToken = new UserTokens();
                if (model== null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                //Generar la clave secreta
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSetting.UserSingInKey);
                Guid Id;
                //Expira en un dia
                DateTime expiredTime = DateTime.UtcNow.AddDays(1);
                //validar el token
                UserToken.Validity = expiredTime.TimeOfDay;
                //Generar token
                var jwToken = new JwtSecurityToken(
                    issuer: jwtSetting.ValidUser,
                    audience: jwtSetting.ValidAudence,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expiredTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256));
                UserToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                UserToken.UserName = model.UserName;
                UserToken.Id = model.Id;
                UserToken.GuidId = Id;
                return UserToken;

            }
            catch(Exception ex)
            {
                throw new Exception("Error al generar el Token", ex);
            }
        }

    }
}
