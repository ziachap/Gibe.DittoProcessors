using System;
using System.Collections.Generic;
using Gibe.DittoProcessors.Processors;
using Gibe.Navigation.Umbraco;
using Gibe.Navigation.Umbraco.NodeTypes;
using Moq;
using NUnit.Framework;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	[TestFixture]
	internal class DescendantsAttributeTests
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

		private DescendantsAttribute DescendantsAttribute(Type targetNodeType, string docType = null)
			=> new DescendantsAttribute(_umbracoNodeService.Object, _nodeTypeFactory.Object, targetNodeType, docType);

		[Test]
		public void Descendants_Returns_All_Descendants_Of_The_Given_Node_Type_And_DocType()
		{
			var nodeType = typeof(TestRootNodeType);
			var docType = "blue";

			_umbracoNodeService.Setup(x => x.GetNode(It.IsAny<INodeType>())).Returns(DittoProcessorTestHelpers.RootNode);
			_nodeTypeFactory.Setup(x => x.GetNodeType(It.IsAny<Type>())).Returns(new TestRootNodeType());
			var result = (IEnumerable<IPublishedContent>) DescendantsAttribute(nodeType, docType).ProcessValue();

			Assert.AreEqual(DittoProcessorTestHelpers.RootNode.Descendants(docType), result);
		}

		[Test]
		public void Descendants_Returns_All_Descendants_Of_The_Given_Root_Node_Type()
		{
			var nodeType = typeof(TestRootNodeType);

			_umbracoNodeService.Setup(x => x.GetNode(It.IsAny<INodeType>())).Returns(DittoProcessorTestHelpers.RootNode);
			_nodeTypeFactory.Setup(x => x.GetNodeType(It.IsAny<Type>())).Returns(new TestRootNodeType());
			var result = (IEnumerable<IPublishedContent>) DescendantsAttribute(nodeType).ProcessValue();

			Assert.AreEqual(DittoProcessorTestHelpers.RootNode.Descendants(), result);
		}
	}
}