namespace SemaforoWeb.DTO
{
    public class UserLoginSocialDTO
    {
        public string Provider { get; set; }
        public UserLoginSocialDataDTO Data { get; set; }
    }

    public class UserLoginSocialDataDTO
    {
        public string short_name { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string userID { get; set; }
        public string picture_url { get; set; }
        public string birthday { get; set; }

    }
}
