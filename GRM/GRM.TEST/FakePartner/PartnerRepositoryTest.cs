using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GRM.Interface; 
using System.Collections.Generic;
using GRM.Entity.Partner;
using System.Linq;
using GRM.TEST.FakeRepository;

namespace GRM.TEST.FakePartner
{
    [TestClass]
    public class PartnerRepositoryTest
    {
        private static Mock<IPartnerRepository> mock;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            mock = new Mock<IPartnerRepository>();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            mock = null;
        }

        [TestMethod]
        public void GetAllPartnerTest()
        {
            mock.Setup(x => x.GetAll()).Returns(new FakePartnerRepository().GetAll());

            var actualResult = mock.Object.GetAll().ToList();
            var expectedResult = new List<IPartner> { new YouTube("streaming"), new ITunes("digital download") };

            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
        }

        [TestMethod]
        public void GetYouTubeTest()
        {
            var partnerName = "YouTube";
            mock.Setup(x => x.Get(partnerName)).Returns(new FakePartnerRepository().Get(partnerName));

            var actualResult = mock.Object.Get(partnerName);
            var expectedResult = new YouTube("streaming");

            Assert.AreEqual(expectedResult.Usage.Count(), actualResult.Usage.Count());
            Assert.AreEqual(expectedResult.Name, actualResult.Name);
            Assert.AreEqual(expectedResult.Usage.FirstOrDefault(), actualResult.Usage.FirstOrDefault());
        }

        [TestMethod]
        public void GetITunesTest()
        {
            var partnerName = "ITunes";
            mock.Setup(x => x.Get(partnerName)).Returns(new FakePartnerRepository().Get(partnerName));

            var actualResult = mock.Object.Get(partnerName);
            var expectedResult = new ITunes("digital download");

            Assert.AreEqual(expectedResult.Usage.Count(), actualResult.Usage.Count());
            Assert.AreEqual(expectedResult.Name, actualResult.Name);
            Assert.AreEqual(expectedResult.Usage.FirstOrDefault(), actualResult.Usage.FirstOrDefault());
        }
    }
}
