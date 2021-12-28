using HtmlAgilityPack;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;

namespace UI_Test
{
    public class Tests
    {
        private HtmlDocument _document;

        [SetUp]
        public void Setup()
        {
            _document = new HtmlWeb() { OverrideEncoding = Encoding.UTF8 }.Load("https://dungeon.su/", "GET");
        }

        [Test]
        public void TestTitle()
        {
            string expected = "Dungeon.su";
            string actual = _document.DocumentNode.SelectSingleNode("//div[@class='title']//h2").InnerText?.Trim();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEditButton()
        {
            string expected = "Справочники";
            string actual = _document.DocumentNode.SelectSingleNode("//li[@data-menu='menu-main-1']//a[@class='parent']").InnerText?.Trim();
            Assert.AreEqual(expected, actual);
        }
    }
}