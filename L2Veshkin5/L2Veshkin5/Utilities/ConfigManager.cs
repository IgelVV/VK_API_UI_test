using Aquality.Selenium.Core.Utilities;

namespace L2Veshkin5.Utilities
{
    public static class ConfigManager
    {
        private static readonly JsonSettingsFile s_configData = new(@"config_data.json");
        private static readonly JsonSettingsFile s_loginUser = new(@"login_user.json");

        public static string StartUrl => s_configData.GetValue<string>("startUrl");
        public static string APIUrlMethod => s_configData.GetValue<string>("apiUrlMethod");
        public static string APIVersion => s_configData.GetValue<string>("apiVersion");
        public static string TestPhotoPath => s_configData.GetValue<string>("testPhotoPath");

        public static string Login => s_loginUser.GetValue<string>("login");
        public static string Password => s_loginUser.GetValue<string>("password");
        public static string Token => s_loginUser.GetValue<string>("token");
        public static int UserId => s_loginUser.GetValue<int>("userId");
    }
}