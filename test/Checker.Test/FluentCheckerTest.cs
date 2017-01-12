using System;

namespace Checking.FluentApi.Test
{
    public class FluentCheckerTest
    {
        public void Checking_FluentApi_Test()
        {
            var user = new User
            {
                Username = "rigofunc",
                Password = "p@ssword",
                Age = 31,
            };

            var checker = new UserChecker();

            var result = checker.Check(user);

            //Assert.IsTrue(result.Succeed);
        }
    }
}
