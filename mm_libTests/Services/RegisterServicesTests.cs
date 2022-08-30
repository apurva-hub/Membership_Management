using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace mm_lib.Services.Tests
{
    [TestClass()]
    public class RegisterServicesTests
    {
        [TestMethod()]
        public void SuccessfullLoginTest()
        {
            // Arrange
            var data = new List<Register>
            {
                new Register {  OrgId = 1,OrgName = "abc", Email = "a@gmail.com", Password = "a" },
                new Register {  OrgId = 2,OrgName = "def", Email = "b@gmail.com", Password = "b" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Register>>();
            mockSet.As<IQueryable<Register>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Register>>().Setup(m => m.Expression).Returns(data.Expression);     
            var mockContext = new Mock<members_managementContext>();
            mockContext.Setup(c => c.Register).Returns(mockSet.Object);
            RegisterServices rs = new RegisterServices(mockContext.Object);

            // Act
            var login = rs.Login("a@gmail.com", "a");

            // Assert
            Assert.IsTrue(login);
        }
        [TestMethod()]
        public void UnSuccessfullLoginTest()
        {
            // Arrange
            var data = new List<Register>
            {
                new Register {  OrgId = 1,OrgName = "abc", Email = "a@gmail.com", Password = "a" },
                new Register {  OrgId = 2,OrgName = "def", Email = "b@gmail.com", Password = "b" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Register>>();
            mockSet.As<IQueryable<Register>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Register>>().Setup(m => m.Expression).Returns(data.Expression);
            var mockContext = new Mock<members_managementContext>();
            mockContext.Setup(c => c.Register).Returns(mockSet.Object);
            RegisterServices rs = new RegisterServices(mockContext.Object);

            // Act
            var login = rs.Login("ap@gmail.com", "a");

            // Assert
            Assert.IsFalse(login);
        }
        [TestMethod()]
        public void GetOrgIdTest()
        {
            // Arrange
            var registerData = new List<Register>
            {
                new Register {  OrgId = 1,OrgName = "abc", Email = "a@gmail.com", Password = "a" },
                new Register {  OrgId = 2,OrgName = "def", Email = "b@gmail.com", Password = "b" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Register>>();
            mockSet.As<IQueryable<Register>>().Setup(m => m.Provider).Returns(registerData.Provider);
            mockSet.As<IQueryable<Register>>().Setup(m => m.Expression).Returns(registerData.Expression);
            var mockContext = new Mock<members_managementContext>();
            mockContext.Setup(c => c.Register).Returns(mockSet.Object);
            RegisterServices rs = new RegisterServices(mockContext.Object);

            // Act
            var getOrgId = rs.GetOrgId("a@gmail.com");

            //Assert
            Assert.AreEqual(1, getOrgId);  
        }
        [TestMethod()]
        public void OrgIdDoesnotExist()
        {
            // Arrange
            var registerData = new List<Register>
            {
                new Register {  OrgId = 1,OrgName = "abc", Email = "a@gmail.com", Password = "a" },
                new Register {  OrgId = 2,OrgName = "def", Email = "b@gmail.com", Password = "b" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Register>>();
            mockSet.As<IQueryable<Register>>().Setup(m => m.Provider).Returns(registerData.Provider);
            mockSet.As<IQueryable<Register>>().Setup(m => m.Expression).Returns(registerData.Expression);
            var mockContext = new Mock<members_managementContext>();
            mockContext.Setup(c => c.Register).Returns(mockSet.Object);
            RegisterServices rs = new RegisterServices(mockContext.Object);

            // Act
            var getOrgId = rs.GetOrgId("abcd@gmail.com");

            // Assert
            Assert.AreEqual(0, getOrgId);
        }
    }
}