using L2Veshkin5.VkAPI;

namespace L2Veshkin5.Tests
{
    public class VkAPITests: BaseTest
    {
        // ��� ������� �������� ��������� ������ ����� ������ ����� (�������� ������, ����� �����)
        // ��� �������� � �������? ������� ����� ��� �����, ������, ������������ ��������
        // ��� ��������� ��� �������� �� ��

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