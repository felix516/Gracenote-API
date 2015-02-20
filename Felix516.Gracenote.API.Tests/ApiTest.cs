using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Felix516.Gracenote.API.Tests
{
    [TestClass]
    public class ApiTest
    {
        private const string CLIENT_ID = "Insert Your Client ID Here";
        private const string USER_ID = "Insert Your User ID Here";

        private const string O_BROTHER_GN_ID = "15145216-E6E0EB71C036B10B0C1158CE602C5FAC";
        private const string O_BROTHER_TOC = "150 20512 30837 50912 64107 78357 90537 110742 126817 144657 153490 160700 175270 186830 201800 218010 237282 244062 262600 272929";
        private const string MULTI_RESULT_TOC = "150 15832 40427 66507 86977 112825 150285 177882 194987 208700 224312 238707 257440 294680";

        private GracenoteClient gc;
        private Auth au;

        [TestInitialize]
        public void Initialize()
        {
            this.au = new Auth(CLIENT_ID, USER_ID);
            this.gc = new GracenoteClient(au, GracenoteClient.Language.ENGLISH, GracenoteClient.Country.US);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.au = null;
            this.gc = null;
        }

        [TestMethod]
        public void TestAlbum_Fetch()
        {
            Response r = this.gc.Album_Fetch(O_BROTHER_GN_ID);

            Assert.AreEqual("O Brother, Where Art Thou?", r.Albums[0].Title);
        }

        [TestMethod]
        public void TestAlbum_TOC_None()
        {
            Response r = this.gc.Album_ToC(Query_Toc.Modes.NONE, MULTI_RESULT_TOC);

            Assert.AreNotEqual(1, r.Albums.Count);
        }

        [TestMethod]
        public void TestAlbum_Toc_Single_Best()
        {
            Response r = this.gc.Album_ToC(Query_Toc.Modes.SINGLE_BEST, MULTI_RESULT_TOC);

            Assert.AreEqual(1, r.Albums.Count);
        }

        [TestMethod]
        public void TestAlbum_Toc_Single_Best_Cover()
        {
            Response r = this.gc.Album_ToC(Query_Toc.Modes.SINGLE_BEST_COVER, MULTI_RESULT_TOC);

            Assert.IsNotNull(r.Albums[0].CoverartUrl);
        }
    }
}
