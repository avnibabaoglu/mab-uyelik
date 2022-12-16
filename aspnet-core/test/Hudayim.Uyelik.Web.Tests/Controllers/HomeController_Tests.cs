using System.Threading.Tasks;
using Hudayim.Uyelik.Models.TokenAuth;
using Hudayim.Uyelik.Web.Controllers;
using Shouldly;
using Xunit;

namespace Hudayim.Uyelik.Web.Tests.Controllers
{
    public class HomeController_Tests: UyelikWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}