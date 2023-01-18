﻿using Aquality.Selenium.Core.Utilities;

namespace L2Veshkin5.Utilities
{
    public static class ConfigManager
    {
        private static readonly JsonSettingsFile s_configData = new(@"TestData\config_data.json");
        private static readonly JsonSettingsFile s_testData = new(@"TestData\test_data.json");
        private static readonly JsonSettingsFile s_loginUser = new(@"TestData\login_user.json");

        public static string StartUrl => s_configData.GetValue<string>("startUrl");

        public static string Login => s_loginUser.GetValue<string>("login");
        public static string Password => s_loginUser.GetValue<string>("password");
    }
}