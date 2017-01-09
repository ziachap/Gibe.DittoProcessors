using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Examine;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	public class FakeSearchResults : ISearchResults
	{
		private readonly IEnumerable<SearchResult> _results;

		public FakeSearchResults(IEnumerable<SearchResult> results)
		{
			_results = results;
		}

		public IEnumerator<SearchResult> GetEnumerator() => _results.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => _results.GetEnumerator();

		public IEnumerable<SearchResult> Skip(int skip) => _results.Skip(skip);

		public int TotalItemCount => _results.Count();
	}
}