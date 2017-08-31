using Microsoft.VisualStudio.TestTools.UnitTesting;
using GRM.Interface; 
using GRM.Entity.Partner;
using System.Linq; 
using GRM.Factory;

namespace GRM.TEST.FakePartner
{
    [TestClass]
    public class PartnerFactoryTest
    {
        private readonly IPartnerFactory factory;

        public PartnerFactoryTest()
        {
             factory = new PartnerFactory();
        }

        [TestMethod]
        public void ProvideYouTubeTest()
        {
            var partnerName = "Youtube";
            var usage = "streaming"; 
            var actualResult = factory.ProvidePartner(partnerName, usage);
            var expectedResult = new YouTube(usage);

            Assert.IsInstanceOfType(actualResult, typeof(YouTube));
            Assert.AreEqual(expectedResult.Name, actualResult.Name);
            Assert.AreEqual(expectedResult.Usage.FirstOrDefault(), actualResult.Usage.FirstOrDefault());
        }

        [TestMethod]
        public void ProvideITunesTest()
        {
            var partnerName = "Itunes";
            var usage = "digital download";
            var actualResult = factory.ProvidePartner(partnerName, usage);
            var expectedResult = new ITunes(usage);

            Assert.IsInstanceOfType(actualResult, typeof(ITunes));
            Assert.AreEqual(expectedResult.Name, actualResult.Name);
            Assert.AreEqual(expectedResult.Usage.FirstOrDefault(), actualResult.Usage.FirstOrDefault());
        }

    }
}
