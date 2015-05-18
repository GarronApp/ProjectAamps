using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AAMPS.Test.Authentication
{
    [TestClass]
    public class TestUserAutehntication
    {
        [TestMethod]
        public void ValidateUser()
        {

            var username = "test";
            var password = "test";

            AAMPS.Clients.Security.AuthProvider _authenticationProvider = new Clients.Security.AuthProvider();

            var user = _authenticationProvider.ValidateUser(username, password);

            Assert.IsNotNull(user);
            Assert.IsTrue(user);

        }
    }
}
