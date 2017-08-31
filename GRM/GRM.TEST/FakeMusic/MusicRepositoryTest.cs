using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GRM.Interface;
using Moq;
using GRM.TEST.FakeRepository;
using System.Collections.Generic;
using GRM.Entity.Music;
using System;

namespace GRM.TEST.FakeMusic
{
    [TestClass]
    public class MusicRepositoryTest
    {
        private static Mock<IMusicRepository> mock;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            mock = new Mock<IMusicRepository>();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            mock = null;
        }

        [TestMethod]
        public void GetAllMusicTest()
        {
            mock.Setup(x => x.GetAll()).Returns(new FakeMusicRepository().GetAll()); 

            var actualResult = mock.Object.GetAll().ToList();
            var expectedResult = new FakeMusicRepository().GetAll();

            CollectionAssert.AllItemsAreInstancesOfType(actualResult, typeof(Music));
            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
        }

        [TestMethod]
        public void GetMusicListByUsageStreamingTest()
        {
            var startDate = new DateTime(2012, 7, 12);
            var usage = "streaming";
            mock.Setup(x => x.Get(usage, startDate))
                .Returns(new FakeMusicRepository().Get(usage, startDate));

            var actualResult = mock.Object.Get(usage, startDate).ToList();
            var expectedResult = new FakeMusicRepository().Get(usage, startDate);
             
            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
        }

        [TestMethod]
        public void GetMusicListByUsageDigitalDownloadTest()
        {
            var startDate = new DateTime(2012, 9, 22);
            var usage = "digital download";
            mock.Setup(x => x.Get(usage, startDate))
                .Returns(new FakeMusicRepository().Get(usage, startDate));

            var actualResult = mock.Object.Get(usage, startDate).ToList();
            var expectedResult = new FakeMusicRepository().Get(usage, startDate);

            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
        }


        [TestMethod]
        public void GetMusicListByPastDateTest()
        {
            var startDate = new DateTime(2009, 9, 22);
            var usage = "digital download";
            mock.Setup(x => x.Get(usage, startDate))
                .Returns(new FakeMusicRepository().Get(usage, startDate));

            var actualResult = mock.Object.Get(usage, startDate).ToList();
            var expectedResult = new FakeMusicRepository().Get(usage, startDate);

            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
        }
    }
}
