using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using L2Veshkin5.Utilities;
using L2Veshkin5.Forms;

namespace L2Veshkin5.Tests
{
    public abstract class BaseTest
    {
        protected static string ScenarioName
            => TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
            ?? TestContext.CurrentContext.Test.Name.Replace("_", string.Empty);

        private static Logger Logger => Logger.Instance;

        private WelcomePage? _welcomePage;
        private EnterPasswordForm? _enterPasswordForm;
        private SideBarForm? _sideBarForm;
        private MyProfileForm? _myProfileForm;

        protected WelcomePage WelcomePage => _welcomePage ??= new();
        protected EnterPasswordForm EnterPasswordForm => _enterPasswordForm ??= new();
        protected SideBarForm SideBarForm=> _sideBarForm ??= new();
        protected MyProfileForm MyProfileForm => _myProfileForm ??= new();

        [SetUp]
        public void Setup()
        {
            Logger.Info($"Start scenario [{ScenarioName}]");
            AqualityServices.Browser.GoTo(ConfigManager.StartUrl);
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            Logger.Info($"Finished scenario [{ScenarioName}]");

            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}