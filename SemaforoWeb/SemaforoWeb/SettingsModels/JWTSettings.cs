namespace SemaforoWeb.SettingsModels
{
    public class JWTSettings
    {
        public string ServerSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
