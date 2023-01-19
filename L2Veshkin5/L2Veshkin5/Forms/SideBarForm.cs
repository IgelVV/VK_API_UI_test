using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace L2Veshkin5.Forms
{
    public class SideBarForm : Form
    {
        private IButton MyProfileButton =>
            ElementFactory.GetButton(By.Id("l_pr"), nameof(MyProfileButton));

        public SideBarForm() : base(By.Id("side_bar"), nameof(SideBarForm))
        {
        }

        public void ClickMyProfileButton()
        {
            MyProfileButton.State.WaitForClickable();
            MyProfileButton.Click();
        }
    }
}
