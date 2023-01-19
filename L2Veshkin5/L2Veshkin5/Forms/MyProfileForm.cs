using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Net.Mail;

namespace L2Veshkin5.Forms
{
    public class MyProfileForm : Form
    {
        private IList<IElement> WallPost =>
            ElementFactory.FindElements<IElement>(By.XPath("//*[@id='page_wall_posts']//*[contains(@class,'_post') and contains(@class,'page_block')]"));


        public MyProfileForm() : base(By.ClassName("ProfileHeader__wrapper"), nameof(MyProfileForm))
        {
        }

    }
}
