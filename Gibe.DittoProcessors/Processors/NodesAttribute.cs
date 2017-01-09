using System.Linq;
using System.Web.Mvc;
using Examine;
using Gibe.UmbracoWrappers;

namespace Gibe.DittoProcessors.Processors
{
	public class NodesAttribute : TestableDittoProcessorAttribute
	{
		private readonly string _key;
		private readonly string _searcherAlias;
		private readonly IExamineSearchWrapper _examineSearchWrapper;
		private readonly IUmbracoWrapper _umbracoWrapper;
		private readonly string _value;

		public NodesAttribute(IUmbracoWrapper umbracoWrapper, IExamineSearchWrapper examineSearchWrapper,
			string key, string value, string searcherAlias = null)
		{
			_umbracoWrapper = umbracoWrapper;
			_key = key;
			_value = value;
			_searcherAlias = searcherAlias;
			_examineSearchWrapper = examineSearchWrapper;
		}

		public NodesAttribute(string key, string value, string searcherAlias = null)
		{
			_key = key;
			_value = value;
			_searcherAlias = searcherAlias;
			_umbracoWrapper = DependencyResolver.Current.GetService<IUmbracoWrapper>();
			_examineSearchWrapper = DependencyResolver.Current.GetService<IExamineSearchWrapper>();
		}

		public override object ProcessValue()
			=> Query(_key, _value).Select(x => _umbracoWrapper.TypedContent(x.Id));

		private ISearchResults Query(string key, string value)
		{
			var searcher = string.IsNullOrEmpty(_searcherAlias)
				? _examineSearchWrapper.ExternalSearcher()
				: _examineSearchWrapper.Searcher(_searcherAlias);

			var searchCriteria = _examineSearchWrapper.CreateSearchCriteria(searcher);
			var operation = _examineSearchWrapper.Field(searchCriteria, key, value);
			var query = _examineSearchWrapper.Compile(operation);
			return _examineSearchWrapper.Search(searcher, query);
		}
	}
}
