using CodeCampDemoFramework.Generators;
using NUnit.Framework;

namespace CodeCampDemoFramework
{
    [TestFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        public static void Initialize()
        {
            Browser.Initialize();
            UserGenerator.Initialize();
        }        

        [OneTimeTearDown]
        public static void TestFixtureTearDown()
        {
            Browser.Close();
        }

        [TearDown]
        public static void TearDown()
        {
            if(Pages.TopNavigation.IsLoggedIn())
                Pages.TopNavigation.LogOut();

            if(UserGenerator.LastGeneratedUser != null)
                Browser.Goto("Account/DeleteUsers.cshtml");
        }
    }
}
