using CodeCampDemoFramework;
using NUnit.Framework;

namespace CodeCampDemoTests
{
    [TestFixture]
    public class SmokeTests : TestBase
    {
        [Test]
        public void GoToAboutPage()
        {
            Pages.About.Goto();
            Assert.IsTrue(Pages.About.IsAt());
        }

        [Test]
        public void GoToHomePage()
        {
            Pages.Home.Goto();
            Assert.IsTrue(Pages.Home.IsAt());
        }

        [Test]
        public void GoToContactPage()
        {
            Pages.Contact.Goto();
            Assert.IsTrue(Pages.Contact.IsAt());
        }

        [Test]
        public void RegisterNewAccount()
        {
            Pages.Register.Goto();
            Pages.Register.RegisterNewUser();
            
            Assert.IsTrue(Pages.TopNavigation.LoggedInAsLastRegisteredUser(), "User not registered successfully");

        }

        [Test]
        public void Login()
        {
            Pages.Register.Goto();
            Pages.Register.RegisterNewUser();
            Pages.TopNavigation.LogOut();

            Pages.Login.Goto();
            Pages.Login.LogInAsLastRegisteredUser();
            Assert.IsTrue(Pages.TopNavigation.LoggedInAsLastRegisteredUser());
        }

        [Test]
        public void Logout()
        {
            // Create a new user
            Pages.Register.Goto();
            Pages.Register.RegisterNewUser();

            // Verify can log out
            Pages.TopNavigation.LogOut();
            Assert.IsFalse(Pages.TopNavigation.IsLoggedIn());
        }

        [Test]
        public void ChangePassword()
        {
            // Create a new user
            Pages.Register.Goto();
            Pages.Register.RegisterNewUser();

            // Change the password
            Pages.ManageAccount.Goto();
            Pages.ManageAccount.ChangePassword();
            Pages.TopNavigation.LogOut();

            // Try to log in with old password
            Pages.Login.Goto();
            Pages.Login.LogInAsLastRegisteredUser();
            Assert.IsFalse(Pages.TopNavigation.IsLoggedIn());

            // Log in with new password
            Pages.Login.Goto();
            Pages.Login.LogInAsLastRegisteredUser(LoginPage.LoginOptions.UseLastGeneratedPassword);
            Assert.IsTrue(Pages.TopNavigation.IsLoggedIn());
        }
    }


}