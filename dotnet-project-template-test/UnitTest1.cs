using Dotnet_project_template;
using System;
using Xunit;

namespace dotnet_project_template_test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var class1= new Class1();
            Assert.NotNull(class1);
        }
    }
}
