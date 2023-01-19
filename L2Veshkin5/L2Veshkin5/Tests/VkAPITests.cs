using L2Veshkin5.VkAPI;

namespace L2Veshkin5.Tests
{
    public class VkAPITests: BaseTest
    {
        // как принято скрывать приватные данные Логин пароль токен (запушить пустой, потом игнор)
        // как работать с постами? создать форму для поста, модель, динамические локаторы
        // как проверить что картинка та же

        [Test(Description = "TestMyPageFunctionality")]
        public void TestMyPageFunctionality()
        {
            var vkApiRequest = new VkAPI.VkAPI();

            WelcomePage.ClearAndTypeLogin();
            WelcomePage.ClickSignInButton();
            EnterPasswordForm.ClearAndTypePassword();
            EnterPasswordForm.ClickContinueButton();
            SideBarForm.ClickMyProfileButton();

            var resp = vkApiRequest.PostToCreateWallPost();
        }
    }
}