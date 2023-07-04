using Azure.Identity;

namespace NewCard
{
    public static class Configuracao
    {
        public static string JWTkey = "zdeFRHF14851845JGYvbhvfchguyBGHJBU";
        public static string ApiKeyName = "api_Key";
        public static string ApiKey = "curso_api_IlTevUM/z0ey3NwCV/unWg==";

        public static SmtpConfiguracao Smtp = new SmtpConfiguracao();
    }

    public class SmtpConfiguracao
    {
        public string Host { get; set; }
        public int Port { get; set; } = 25;
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
