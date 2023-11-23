using Nameless.Libraries.Rukia.ProjectEuler.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class NamesScoresTest
    {
        [TestMethod]
        public void TestNameScores()
        {
            NamesScores action = new NamesScores();
            Assert.AreEqual(871198282, action.Result);
        }
    }
}
