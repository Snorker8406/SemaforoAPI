﻿namespace SemaforoWeb.Email
{
    public class EmailSenderSettings
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }

    }
}