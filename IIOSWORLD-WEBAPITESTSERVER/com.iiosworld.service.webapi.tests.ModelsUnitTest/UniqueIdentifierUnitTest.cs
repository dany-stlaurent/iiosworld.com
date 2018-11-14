using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.iiosworld.service.webapi.models;
using System;
using System.Threading;
using System.Globalization;

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
        [TestMethod]
        public void TestConstructorWithBadParms()
        {
            CultureInfo cultureInfo = new CultureInfo(@"fr");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            try
            {
                UniqueIdentifier uid = new UniqueIdentifier(@"This is definitely not a guid.");
            }
            catch(Exception frEx)
            {
                Assert.IsTrue(string.Equals(frEx.Message, @"Une erreure a été rencontrée en essayant de traiter le paramètre 'pUniqueIdentifier' pour le constructeur, vérifiez l'exception interne pour les détails."));
            }
                        
        }
        [TestMethod]
        public void TestConstructorWithBadParmsNeutral()
        {
            CultureInfo cultureInfo = new CultureInfo(@"en");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            try
            {
                UniqueIdentifier uid = new UniqueIdentifier(@"This is definitely not a guid.");
            }
            catch (Exception enEx)
            {

                Assert.IsTrue(string.Equals(enEx.Message, @"Error encountered trying to parse the parameter 'pUniqueIdentifier' for constructor, check inner the Exception for details."));
            }
        }

    }
}
