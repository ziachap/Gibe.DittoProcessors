using System.Collections.Generic;
using System.Linq;
using Gibe.DittoProcessors.Processors;
using NUnit.Framework;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	[TestFixture]
	internal class SortAttributeTests
	{
		private SortAttribute SortAttribute(string propertyAlias, object value)
			=> new SortAttribute(propertyAlias) {Value = value};

		[Test]
		public void Sort_Attribute_Does_Nothing_When_Content_Set_Is_Empty()
		{
			var propertyAlias = string.Empty;
			var contentSet = DittoProcessorTestHelpers.RootNode.Descendants();
			var result = (IEnumerable<IPublishedContent>) SortAttribute(propertyAlias, contentSet).ProcessValue();
			Assert.AreEqual(contentSet, result);
		}

		[Test]
		public void Sort_Attribute_Does_Nothing_When_Property_Alias_Equals_Empty_String()
		{
			var propertyAlias = string.Empty;
			var contentSet = DittoProcessorTestHelpers.RootNode.Descendants();
			var result = (IEnumerable<IPublishedContent>) SortAttribute(propertyAlias, contentSet).ProcessValue();
			Assert.AreEqual(contentSet, result);
		}

		[Test]
		public void Sort_Attribute_Returns_Null_When_Content_Set_Is_Null()
		{
			var propertyAlias = string.Empty;
			var result = (IEnumerable<IPublishedContent>)SortAttribute(propertyAlias, null).ProcessValue();
			Assert.AreEqual(null, result);
		}

		[Test]
		public void Sort_Attribute_Sorts_Content_By_Name_When_Property_Alias_Equals_Name()
		{
			var propertyAlias = "name";
			var contentSet = DittoProcessorTestHelpers.RootNode.Descendants();
			var result = (IEnumerable<IPublishedContent>) SortAttribute(propertyAlias, contentSet).ProcessValue();

			Assert.AreEqual("Andrew", result.First().Name);
			Assert.AreEqual("Zia", result.Last().Name);
			Assert.AreEqual(contentSet.OrderBy(x => x.Name), result);
		}
	}
}