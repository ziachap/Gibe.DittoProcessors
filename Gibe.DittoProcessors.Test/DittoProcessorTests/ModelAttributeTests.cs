using System;
using System.Collections.Generic;
using System.Linq;
using Gibe.DittoProcessors.Processors;
using Gibe.DittoServices.ModelConverters;
using Moq;
using NUnit.Framework;
using Our.Umbraco.Ditto;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	[TestFixture]
	internal class ModelAttributeTests
	{
		[SetUp]
		public void Init()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_modelConverter = _repository.Create<IModelConverter>();
		}

		private MockRepository _repository;
		private Mock<IModelConverter> _modelConverter;

		private ModelAttribute ModelAttribute(Type type)
			=> new ModelAttribute(_modelConverter.Object, type) {Value = null};

		private ModelAttribute ModelAttribute(Type type, IPublishedContent value)
			=> new ModelAttribute(_modelConverter.Object, type) {Value = value};

		private ModelAttribute ModelAttribute(Type type, IEnumerable<IPublishedContent> value)
			=> new ModelAttribute(_modelConverter.Object, type) {Value = value};

		public class TestModel
		{
			[UmbracoProperty("nodeName")]
			public string Name { get; set; }
		}

		[Test]
		public void Model_Attribute_Returns_Null_When_Converting_Null()
		{
			var resultType = typeof(TestModel);

			var result = (IEnumerable<TestModel>) ModelAttribute(resultType).ProcessValue();

			Assert.AreEqual(result, null);
		}

		[Test]
		public void Model_Attribute_Returns_Valid_Model_When_Converting_An_IPublishedContent()
		{
			var content = DittoProcessorTestHelpers.RootNode;
			var resultType = typeof(TestModel);
			var resultModel = new TestModel
			{
				Name = "Root"
			};

			_modelConverter.Setup(x => x.ToModel(It.IsAny<Type>(), It.IsAny<IPublishedContent>())).Returns(resultModel);
			var result = (TestModel) ModelAttribute(resultType, content).ProcessValue();

			Assert.AreEqual(content.Name, result.Name);
		}

		[Test]
		public void Model_Attribute_Returns_Valid_Model_When_Converting_Multiple_IPublishedContent()
		{
			var content = DittoProcessorTestHelpers.RootNode.Descendants().ToList();
			var resultType = typeof(TestModel);
			var resultModel = content.Select(x => new TestModel
			{
				Name = x.Name
			});

			_modelConverter.Setup(x => x.ToModel(It.IsAny<Type>(), It.IsAny<IEnumerable<IPublishedContent>>()))
				.Returns(resultModel);
			var result = (IEnumerable<TestModel>) ModelAttribute(resultType, content).ProcessValue();

			result.Zip(content, (first, second) => new {Result = first.Name, Content = second.Name})
				.ForEach(x => Assert.AreEqual(x.Content, x.Result));
		}
	}
}