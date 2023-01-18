using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace L2Veshkin5.Forms
{
    public class EnterPasswordForm: Form
    {
        private IButton ContinueButton => 
            ElementFactory.GetButton(By.ClassName("vkuiButton__in"), nameof(ContinueButton));
        private ITextBox PasswordBox =>
            ElementFactory.GetTextBox(By.XPath("//*[contains(@class,'vkc__Password__Wrapper')]//*[contains(@class,'vkc__TextField__input')]"), nameof(PasswordBox));

        public EnterPasswordForm() : base(By.ClassName("vkc__EnterPasswordNoUserInfo__content"), nameof(EnterPasswordForm))
        {
        }

        public void ClickContinueButton() => ContinueButton.Click();
    }
}
