using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterMindLogic;

namespace mastermind1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VorgabenAusBeispielAufgabe1()
        {
            var mm = new Basic(3);
            Assert.AreEqual( (1,0), mm.EvaluateNumber("042","682"));
            Assert.AreEqual( (0,1), mm.EvaluateNumber("042","614"));
            Assert.AreEqual( (0,2), mm.EvaluateNumber("042","206"));
            Assert.AreEqual( (0,0), mm.EvaluateNumber("042","738"));
            Assert.AreEqual( (0,1), mm.EvaluateNumber("042","870"));
        }

        [TestMethod]
        public void Doppelte5()
        {
            var mm = new Basic(5);
            Assert.AreEqual( (4,0), mm.EvaluateNumber("69098","67098"));
            Assert.AreEqual( (3,1), mm.EvaluateNumber("66098","67096"));
            Assert.AreEqual( (2,2), mm.EvaluateNumber("66766","67696"));
            Assert.AreEqual( (3,1), mm.EvaluateNumber("66766","66696"));
            Assert.AreEqual( (2,1), mm.EvaluateNumber("66766","68696"));
        }
    }
}
