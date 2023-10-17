using Nameless.Libraries.Rukia.ProjectEuler.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class EvenFibonacciNumbersTest
    {
        [TestMethod]
        public void TestValuesLess100()
        {
            EvenFibonacciNumbers task = new EvenFibonacciNumbers(100);
            Assert.AreEqual(task.Result, 44);
        }

        [TestMethod]
        public void TestValuesLess4M()
        {
            EvenFibonacciNumbers task = new EvenFibonacciNumbers(4000000);
            Assert.AreEqual(task.Result, 4613732);
        }
    }
}
