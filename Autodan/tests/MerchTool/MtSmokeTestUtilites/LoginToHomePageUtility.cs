using Autodan.core;
using Autodan.pages.MerchTool.MtCommonSitePages;

namespace Autodan.tests.MerchTool.MtSmokeTestUtilites
{
    public interface ILoginToHomePageUtility
    {
        MtHomePageObject GetHomePage();
    }

    public class LoginToHomePageUtility : BaseTest, ILoginToHomePageUtility
    {
        private MtLoginPageObject _loginPage;

        public MtHomePageObject GetHomePage()
        {
            Setup("chrome", "merchtool");
            _loginPage = new MtLoginPageObject();
            var homePage = _loginPage.Login();
            return homePage;
        }
    }
}
