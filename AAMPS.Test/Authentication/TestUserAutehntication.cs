using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AAMPS.Clients.Security;

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

            //AAMPS.Clients.Security.AuthProvider _authenticationProvider = new Clients.Security.AuthProvider();

            var _currentUser = new AuthProvider().ValidateUser(username, password);

            Assert.IsNotNull(_currentUser);

        }
    }
}
