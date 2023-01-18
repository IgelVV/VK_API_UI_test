namespace L2Veshkin5.Tests
{
    public class VkAPITests: BaseTest
    {
        [Test(Description = "TestMyPageFunctionality")]
        public void TestMyPageFunctionality()
        {
            WelcomePage.ClearAndTypeLogin();
            WelcomePage.ClickSignInButton();
            EnterPasswordForm.ClickContinueButton();
        }
    }
}