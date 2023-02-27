using ApiWEb.Models.UserValidatorToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ApiWEb
{
    public static class AddJwtTokenServicesExtension
    {
        public static void AddJwtTokenServices( this IServiceCollection Services, IConfiguration Configuration) 
        {
            var bindJwtSetting = new JwtSetting();
            Configuration.Bind("JsonWebTokenKeys", bindJwtSetting);
            Services.AddSingleton(bindJwtSetting);

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata= false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey= bindJwtSetting.ValidateUserSingKey,
                    IssuerSigningKey= new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSetting.UserSingInKey)),
                    ValidateIssuer = bindJwtSetting.ValidateUser,
                    ValidIssuer = bindJwtSetting.ValidUser,
                    ValidateAudience= bindJwtSetting.ValidateAudence,
                    ValidAudience = bindJwtSetting.ValidAudence,
                    RequireExpirationTime= bindJwtSetting.ValidLifeTime,
                    ClockSkew = TimeSpan.FromDays(1)
                };
            });
        
        }

    }
}
