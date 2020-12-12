using IRF_Project;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Test
{
    public class LoginTest
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("manager@footballclub", false),
            TestCase("managerfootballclub.com", false),
            TestCase("manager@footballclub.com", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {

            // Arrange
            var loginController = new LoginController();

            // Act
            var actualResult = loginController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [
            Test,
            TestCase("abcdABCD", false),
            TestCase("ABCD1234", false),
            TestCase("abcd1234", false),
            TestCase("Ab1234", false),
            TestCase("Abcd1234", true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            // Arrange
            var loginController = new LoginController();

            // Act
            var actualResult = loginController.ValidatePassword(password);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
