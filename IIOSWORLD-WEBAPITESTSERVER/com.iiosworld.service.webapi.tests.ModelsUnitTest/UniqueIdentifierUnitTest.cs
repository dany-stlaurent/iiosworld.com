using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.iiosworld.service.webapi.models;
using System;

namespace com.iiosworld.service.webapi.tests.ModelsUnitTest
{
    [TestClass]
    public class UniqueIdentifierUnitTest
    {
        [TestMethod]
        public void TestConstructorWithoutParms()
        {
            UniqueIdentifier uid = new UniqueIdentifier();

            Assert.IsNotNull(uid);
            Assert.IsNotNull(uid.IdValue);
            Assert.IsNotNull(Guid.Parse(uid.IdValue));
        }
        [TestMethod]
        public void TestConstructorWithParms()
        {
            Guid guid = Guid.NewGuid();

            UniqueIdentifier uid = new UniqueIdentifier(guid.ToString());
            Guid guidCheck = Guid.Parse(uid.IdValue);

            Assert.AreEqual(guid, guidCheck);
        }
    }
}
