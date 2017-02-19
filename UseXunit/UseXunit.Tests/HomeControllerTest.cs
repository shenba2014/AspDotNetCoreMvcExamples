using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UseXunit.Controllers;
using Xunit;

namespace UseXunit.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void ShouldGetIndexResult()
        {
            var homeController = new HomeController();
            var contentResult = homeController.Index() as ContentResult;
            Assert.NotNull(contentResult);
            Assert.Equal("Hello test", contentResult.Content);
        }
    }
}
