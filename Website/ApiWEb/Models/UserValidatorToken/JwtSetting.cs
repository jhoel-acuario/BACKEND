namespace ApiWEb.Models.UserValidatorToken
{
    public class JwtSetting
    {
        public bool ValidateUserSingKey { get; set; }
        public string UserSingInKey { get; set; }= string.Empty;
        public bool ValidateUser { get; set; }
        public string? ValidUser { get; set; }
        public bool ValidateAudence { get; set; } = true;
        public string? ValidAudence { get; set; }
        public bool RequiredExperitionTime { get; set; }
        public bool ValidLifeTime { get; set; }
    }
}
