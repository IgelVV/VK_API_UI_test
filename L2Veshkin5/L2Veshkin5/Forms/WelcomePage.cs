using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using L2Veshkin5.Utilities;
using OpenQA.Selenium;

namespace L2Veshkin5.Forms
{
    public class WelcomePage: Form
    {
        private IButton SignInButton => 
            ElementFactory.GetButton(By.XPath("//*[contains(@class,'VkIdForm__signInButton')]//*[contains(@class,'FlatButton__in')]"), nameof(SignInButton));

        private ITextBox LoginBox =>
            ElementFactory.GetTextBox(By.ClassName("VkIdForm__input"), nameof(LoginBox));

        public WelcomePage() : base(By.ClassName("VkIdForm__header"), nameof(WelcomePage))
        {
        }

        public void ClearAndTypeLogin()
        {
            LoginBox.ClearAndType(ConfigManager.Login);
        }

        public void ClickSignInButton() => SignInButton.Click();
    }
}
