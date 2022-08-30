using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace mm_lib.Services.Tests
{
    [TestClass()]
    public class MembersServicesTests
    {
        [TestMethod()]
        public void GetMembersByMemberId()
        {
            // Arrange
            var membersData = new List<Members>
            {
                new Members {  MemberId = 1, OrgId = 10, Name = "apu", PhoneNo = "78999721066", Gender = true},
                new Members {  MemberId = 2, OrgId = 10, Name = "abc", PhoneNo = "78999721123", Gender = false},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Members>>();
            mockSet.As<IQueryable<Members>>().Setup(m => m.Provider).Returns(membersData.Provider);
            mockSet.As<IQueryable<Members>>().Setup(m => m.Expression).Returns(membersData.Expression);
            var mockContext = new Mock<members_managementContext>();
            mockContext.Setup(c => c.Members).Returns(mockSet.Object);
            MembersServices ms = new MembersServices(mockContext.Object);

            // Act
            var getMembersById = ms.GetMembersByMemberId(1);

            // Assert
            foreach (var m in getMembersById)
            {
                Assert.AreEqual(1, m.MemberId);
                Assert.AreEqual("apu", m.Name);
                Assert.IsNotNull(m.PhoneNo);
                Assert.IsNotNull(m.Name);
            }
            
        }

        [TestMethod()]
        public void GetMembersByOrgId()
        {
            // Arrange
            var membersData = new List<Members>
            {
                new Members {  MemberId = 1, OrgId = 100, Name = "apu", PhoneNo = "78999721066", Gender = true},
                new Members {  MemberId = 2, OrgId = 200, Name = "abc", PhoneNo = "78999721123", Gender = false},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Members>>();
            mockSet.As<IQueryable<Members>>().Setup(m => m.Provider).Returns(membersData.Provider);
            mockSet.As<IQueryable<Members>>().Setup(m => m.Expression).Returns(membersData.Expression);
            var mockContext = new Mock<members_managementContext>();
            mockContext.Setup(c => c.Members).Returns(mockSet.Object);
            MembersServices ms = new MembersServices(mockContext.Object);

            // Act
            var getMembers = ms.GetMembersByOrgId(100);

            // Arrange
            foreach (var m in getMembers)
            {
                Assert.AreEqual(1, m.MemberId);
                Assert.AreEqual("apu", m.Name);
                Assert.IsNotNull(m.PhoneNo);
                Assert.IsNotNull(m.Name);
            }

        }
    }
}