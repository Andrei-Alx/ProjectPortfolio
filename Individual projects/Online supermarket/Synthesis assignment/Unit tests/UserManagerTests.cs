using Data.MockClasses;
using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_tests
{
	[TestClass]
	public class UserManagerTests
	{
		private IDbUserHelper CreateTestRepo()
		{
			return new MockUserHelper();
		}

		[TestMethod]
		public void AddUserSuccess()
		{
			//Arrange
			UserManager userManager = new UserManager(CreateTestRepo());
			//Act
			bool testResult =  userManager.CreateUser("p@mail.com", "0000", UserRoles.Customer);
			//Assert
			Assert.IsTrue(testResult);

			//Act
			//User user = new User("andrei@mail.com", "0000", "Customer");
			//Assert
			//Assert.AreEqual("Adi", user.Name);
			//Assert.AreEqual("1234", user.Password);
			//Assert.IsNotNull(user);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void AddUserUsernameFail()
		{
			//Arrange
			UserManager userManager = new UserManager(CreateTestRepo());
			//Act
			bool testResult = userManager.CreateUser(null, "0000", UserRoles.Customer);
			//Assert
			Assert.IsTrue(testResult);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void AddUserEmailFail()
		{
			//Arrange
			UserManager userManager = new UserManager(CreateTestRepo());
			//Act
			bool testResult = userManager.CreateUser("andrei", "0000", UserRoles.Customer);
			//Assert
			Assert.IsTrue(testResult);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void AddUserPasswordFail()
		{
			//Arrange
			UserManager userManager = new UserManager(CreateTestRepo());
			//Act
			userManager.CreateUser("andrei@mail.com", null, UserRoles.Customer);
		}
	}
}
