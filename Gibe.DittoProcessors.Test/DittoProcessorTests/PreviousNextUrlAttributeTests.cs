using System;
using System.Web;
using Gibe.DittoProcessors.Processors;
using Moq;
using NUnit.Framework;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	internal class PreviousNextUrlAttributeTests
	{
		[SetUp]
		public void Init()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_httpContextBase = _repository.Create<HttpContextBase>();
		}

		private MockRepository _repository;
		private Mock<HttpContextBase> _httpContextBase;

		private PreviousUrlAttribute PreviousUrlAttribute() => new PreviousUrlAttribute(_httpContextBase.Object);
		private PreviousUrlAttribute PreviousUrlAttribute(string alias) => new PreviousUrlAttribute(_httpContextBase.Object, alias);
		private NextUrlAttribute NextUrlAttribute() => new NextUrlAttribute(_httpContextBase.Object);

		[Test]
		public void Previous_Url_Returns_Empty_String_When_Page_Equals_1()
		{
			var uri = new Uri("http://www.whatareyouonabout.com/subcategory?jeff=345&page=1&orange=true");
			_httpContextBase.Setup(x => x.Request.Url).Returns(uri);
			var result = PreviousUrlAttribute().ProcessValue().ToString();

			Assert.AreEqual(string.Empty, result);
		}

		[Test]
		public void Previous_Url_Returns_Page_Parameter_Minus_1_When_Page_Is_More_Than_1()
		{
			var uri = new Uri("http://www.whatareyouonabout.com/subcategory?steve=345&page=4&orange=true");
			_httpContextBase.Setup(x => x.Request.Url).Returns(uri);
			var result = PreviousUrlAttribute().ProcessValue().ToString();

			Assert.AreEqual("http://www.whatareyouonabout.com/subcategory?steve=345&page=3&orange=true", result);
		}

		[Test]
		public void Previous_Url_Returns_Empty_String_When_Page_Is_Undefined()
		{
			var uri = new Uri("http://www.whatareyouonabout.com/subcategory?steve=345&orange=true");
			_httpContextBase.Setup(x => x.Request.Url).Returns(uri);
			var result = PreviousUrlAttribute().ProcessValue().ToString();

			Assert.AreEqual(string.Empty, result);
		}

		[Test]
		public void Next_Url_Returns_Page_Parameter_Plus_1_When_Page_Is_Defined()
		{
			var uri = new Uri("http://www.whatareyouonabout.com/subcategory?steve=345&page=4&orange=true");
			_httpContextBase.Setup(x => x.Request.Url).Returns(uri);
			var result = NextUrlAttribute().ProcessValue().ToString();

			Assert.AreEqual("http://www.whatareyouonabout.com/subcategory?steve=345&page=5&orange=true", result);
		}

		[Test]
		public void Next_Url_Returns_Page_Parameter_Equals_2_When_Page_Is_Undefined()
		{
			var uri = new Uri("http://www.whatareyouonabout.com/subcategory?steve=345&orange=true");
			_httpContextBase.Setup(x => x.Request.Url).Returns(uri);
			var result = NextUrlAttribute().ProcessValue().ToString();

			Assert.IsTrue(result.Contains("page=2"));
		}

		[Test]
		public void Previous_Url_Returns_Page_Parameter_Minus_1_When_Page_Is_More_Than_1_And_Using_Page_Alias()
		{
			var uri = new Uri("http://www.whatareyouonabout.com/subcategory?steve=345&slide=7&orange=true");
			_httpContextBase.Setup(x => x.Request.Url).Returns(uri);
			var result = PreviousUrlAttribute("slide").ProcessValue().ToString();

			Assert.IsTrue(result.Contains("slide=6"));
		}
	}
}
