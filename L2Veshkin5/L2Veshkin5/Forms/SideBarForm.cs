using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Browsers;
using OpenQA.Selenium;
using L2Veshkin5.Extetions;

namespace L2Veshkin5.Forms
{
    public class SideBarForm : Form
    {
        private IButton MyProfileButton =>
            ElementFactory.GetButton(By.XPath("//*[@id='l_pr']/a"), nameof(MyProfileButton));

        public SideBarForm() : base(By.Id("side_bar"), nameof(SideBarForm))
        {
        }

        public void ClickMyProfileButton()
        {
            MyProfileButton.State.WaitForClickable();
            var href = MyProfileButton.GetHref();
            AqualityServices.Browser.GoTo(href);
        }
    }
}
