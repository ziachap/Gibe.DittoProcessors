using System.Collections.Generic;
using System.Linq;
using Gibe.DittoProcessors.Processors;
using NUnit.Framework;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	[TestFixture]
	internal class SkipTakeAttributeTests
	{
		private SkipAttribute SkipAttribute(uint skip, IEnumerable<IPublishedContent> value)
			=> new SkipAttribute(skip) {Value = value};

		private TakeAttribute TakeAttribute(uint take, IEnumerable<IPublishedContent> value)
			=> new TakeAttribute(take) {Value = value};

		[Test]
		public void Skip_First_Two_Nodes_When_Skip_Equals_2()
		{
			var skip = (uint) 2;
			var contentSet = DittoProcessorTestHelpers.RootNode.Descendants().ToList();
			var result = (IEnumerable<IPublishedContent>) SkipAttribute(skip, contentSet).ProcessValue();
			Assert.IsTrue(result.First().Id == contentSet.Skip((int) skip).First().Id);
		}

		[Test]
		public void Skip_Returns_Null_When_Content_Set_Is_Null()
		{
			var skip = (uint) 2;
			var result = (IEnumerable<IPublishedContent>) SkipAttribute(skip, null).ProcessValue();
			Assert.AreEqual(null, result);
		}

		[Test]
		public void Take_First_Two_Nodes_When_Take_Equals_2()
		{
			var take = (uint) 2;
			var contentSet = DittoProcessorTestHelpers.RootNode.Descendants().ToList();
			var result = (IEnumerable<IPublishedContent>) TakeAttribute(take, contentSet).ProcessValue();
			Assert.IsTrue(result.Last().Id == contentSet.Take((int) take).Last().Id);
		}

		[Test]
		public void Take_Returns_Null_When_Content_Set_Is_Null()
		{
			var take = (uint) 2;
			var result = (IEnumerable<IPublishedContent>) TakeAttribute(take, null).ProcessValue();
			Assert.AreEqual(null, result);
		}
	}
}