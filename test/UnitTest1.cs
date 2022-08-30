using NUnit.Framework;
using Moq;
using membership_management.Interface;
using System;

namespace test
{
    [TestFixture]
    public class test1
    {
        Mock<Iclass1> _class1Mock = new Mock<Iclass1>();

        public test1()
        {
            _class1Mock = new Mock<Iclass1>();
        }

        [Test]
        public void register_testMethod()
        {
            _class1Mock.Setup(x => x.getOrgId(It.IsAny<string>())).ToString();
            int result = Convert.ToInt32(_class1Mock.Object.getOrgId("apu@gmail.com"));
            Assert.IsNotNull(result);
        }
        [Test]
        public void add_member_testMethod()
        {
            var result = _class1Mock.Setup(t => t.add_member(It.IsIn<string>("abc"), It.IsIn<string>("1234567890"), It.IsAny<DateTime>(), It.IsIn<bool>(true), It.IsIn<int>(1)));
            Assert.IsNotNull(result);

        }

    }
}


