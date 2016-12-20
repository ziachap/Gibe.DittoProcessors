using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gibe.DittoProcessors.Processors;
using Gibe.Navigation.Umbraco;
using Gibe.Navigation.Umbraco.NodeTypes;
using Moq;
using NUnit.Framework;
using Umbraco.Core.Models;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	[TestFixture]
	class WithinDateRangeAttributeTests
	{
		[SetUp]
		public void Init()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_umbracoNodeService = _repository.Create<IUmbracoNodeService>();
			_nodeTypeFactory = _repository.Create<INodeTypeFactory>();
		}

		private MockRepository _repository;
		private Mock<IUmbracoNodeService> _umbracoNodeService;
		private Mock<INodeTypeFactory> _nodeTypeFactory;

		private WithinDateRangeAttribute WithinDateRangeAttribute(string propertyAlias, string startDate, string endDate)
			=> new WithinDateRangeAttribute(_umbracoNodeService.Object, _nodeTypeFactory.Object, typeof(TestRootNodeType),
				propertyAlias, startDate, endDate);

		[Test]
		public void
			Within_Date_Range_Attribute_Returns_All_Nodes_With_Property_In_Date_Range_When_Property_Alias_Is_Defined()
		{
			var start = new DateTime(2005, 1, 1);
			var end = new DateTime(2017, 1, 1);

			_umbracoNodeService.Setup(x => x.GetNode(It.IsAny<INodeType>())).Returns(DittoProcessorTestHelpers.RootNode);
			_nodeTypeFactory.Setup(x => x.GetNodeType(It.IsAny<Type>())).Returns(new TestRootNodeType());
			var result =
				(IEnumerable<IPublishedContent>)WithinDateRangeAttribute("createDate", "01/01/2005", "01/01/2017").ProcessValue();

			Assert.IsTrue(result.All(x => x.CreateDate > start));
			Assert.IsTrue(result.All(x => x.CreateDate < end));
		}

		[Test]
		public void Within_Date_Range_Attribute_Returns_Empty_Enumerable_When_Property_Alias_Does_Not_Exist()
		{
			_umbracoNodeService.Setup(x => x.GetNode(It.IsAny<INodeType>())).Returns(DittoProcessorTestHelpers.RootNode);
			_nodeTypeFactory.Setup(x => x.GetNodeType(It.IsAny<Type>())).Returns(new TestRootNodeType());
			var result =
				(IEnumerable<IPublishedContent>)
					WithinDateRangeAttribute("ImNotActuallyAProperty", "01/01/2005", "01/01/2017").ProcessValue();

			Assert.AreEqual(Enumerable.Empty<IPublishedContent>(), result);
		}
	}
}
