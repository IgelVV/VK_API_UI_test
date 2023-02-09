using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace L2Veshkin5.Forms
{
    public class MyProfileForm : Form
    {
        public MyProfileForm() : base(By.ClassName("ProfileHeader__wrapper"), nameof(MyProfileForm))
        {
        }

        public PostForm GetPostById(int postId) => new(postId);
    }
}
