using PontsBet.Utils;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodNormal()
        {
            string[] items = { "apple", "banana", "cherry" };
            string separator = ",";
            string expected = "apple,banana,cherry";
            string result = StringFormatter.ToCommaSepatatedList(items, separator);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethodContainNull()
        {
            string[] items = { "apple", null, "cherry" };
            string separator = ",";
            string expected = "apple,,cherry";
            string result = StringFormatter.ToCommaSepatatedList(items, separator);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethodOnlyOne()
        {
            string[] items = { "apple" };
            string separator = ",";
            string expected = "apple";
            string result = StringFormatter.ToCommaSepatatedList(items, separator);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethodItemsEmputy()
        {
            string[] items = Array.Empty<string>();
            string separator = "- ";
            string expected = "";
            string result = StringFormatter.ToCommaSepatatedList(items, separator);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethodItemsNull()
        {
            string[] items = null;
            string separator = "- ";
            string expected = "";
            string result = StringFormatter.ToCommaSepatatedList(items, separator);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethodSeparatorNull()
        {
            string[] items = { "apple", "banana" };
            string separator = null;
            var ex = Assert.ThrowsException<ArgumentException>(() => StringFormatter.ToCommaSepatatedList(items, separator));
            Assert.IsNotNull(ex);
        }
        [TestMethod]
        public void TestMethodLongArray()
        {
            List<string> items=new List<string>();
            for (int i = 0; i < 10000; i++)
            {
                items.Add(  "apple"+i );
            }
            string separator = "-";
            string expected = string.Join(separator, items);
            string result = StringFormatter.ToCommaSepatatedList(items.ToArray(), separator);
            Assert.IsTrue(result.Length>0);
            Assert.AreEqual(expected, result);
        }
    }
}