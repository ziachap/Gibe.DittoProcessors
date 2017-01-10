using System.Collections.Generic;
using System.Linq;
using Examine;
using Examine.LuceneEngine.Providers;
using Examine.Providers;
using Examine.SearchCriteria;
using Gibe.DittoProcessors.Processors;
using Gibe.UmbracoWrappers;
using Moq;
using NUnit.Framework;
using Umbraco.Core.Models;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	[TestFixture]
	internal class NodesAttributeTests
	{
		[SetUp]
		public void Init()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_umbracoWrapper = _repository.Create<IUmbracoWrapper>();
			_examineSearchWrapper = _repository.Create<IExamineSearchWrapper>();
		}

		private MockRepository _repository;
		private Mock<IUmbracoWrapper> _umbracoWrapper;
		private Mock<IExamineSearchWrapper> _examineSearchWrapper;

		private NodesAttribute NodesAttribute(string key, string value)
			=> new NodesAttribute(_umbracoWrapper.Object, _examineSearchWrapper.Object, key, value);

		[Test]
		public void Nodes_Returns_Enumerable_Of_Matching_Nodes_Where_DocTypeAlias_Matches_Query()
		{
			var key = "docTypeAlias";
			var value = "page";

			var node = new FakePublishedContent
			{
				Id = 123,
				DocumentTypeAlias = value
			};

			var searchResults = new[]
			{
				new SearchResult {Id = 123}
			};

			_examineSearchWrapper.Setup(x => x.ExternalSearcher()).Returns(new LuceneSearcher());
			_examineSearchWrapper.Setup(x => x.CreateSearchCriteria(It.IsAny<BaseSearchProvider>()))
				.Returns(new FakeSearchCriteria());
			_examineSearchWrapper.Setup(x => x.Compile(It.IsAny<IBooleanOperation>())).Returns(new FakeSearchCriteria());
			_examineSearchWrapper.Setup(x => x.Field(It.IsAny<ISearchCriteria>(), It.IsAny<string>(), It.IsAny<string>()))
				.Returns(new FakeBooleanOperation());
			_examineSearchWrapper.Setup(x => x.Search(It.IsAny<BaseSearchProvider>(), It.IsAny<ISearchCriteria>()))
				.Returns(new FakeSearchResults(searchResults));
			_umbracoWrapper.Setup(x => x.TypedContent(It.IsAny<int>())).Returns(node);

			var result = (NodesAttribute(key, value).ProcessValue() as IEnumerable<IPublishedContent>)?.ToList();

			Assert.IsTrue(result.Any());
			result.ForEach(x => Assert.AreEqual(value, x.DocumentTypeAlias));
		}
	}
}