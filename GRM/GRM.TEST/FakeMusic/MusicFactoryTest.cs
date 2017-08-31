using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GRM.Interface;
using GRM.Factory;
using System.Linq;
using GRM.Entity.Music;

namespace GRM.TEST.FakeMusic
{
    [TestClass]
    public class MusicFactoryTest
    {
        private readonly IMusicFactory factory;
        public MusicFactoryTest()
        {
            factory = new MusicFactory();
        }
         
        [TestMethod]
        public void ProvideMusicTest()
        {
            string artist = "Youtube",
                    title = "streaming",
                    usages = "digital download, streaming",
                    startdate = "01/12/2012",
                    endDate = "01/12/2014";

            var actualResult = factory.GetMusicInstance(artist, title, usages, startdate, endDate);
            var expectedResult = new Music();
            expectedResult.Artist = artist;
            expectedResult.Title = title; 
            expectedResult.Usage.AddRange(usages.Split(new string[] { ", " }, StringSplitOptions.None));
            expectedResult.StartDate = DateTime.Parse(startdate);
            expectedResult.EndDate = DateTime.Parse(endDate);

            Assert.IsInstanceOfType(actualResult, typeof(Music));
            Assert.AreEqual(expectedResult.Artist, actualResult.Artist);
            Assert.AreEqual(expectedResult.Usage.Count(), actualResult.Usage.Count());
            Assert.AreEqual(expectedResult.Usage.FirstOrDefault(), actualResult.Usage.FirstOrDefault());
        } 
    }
}
