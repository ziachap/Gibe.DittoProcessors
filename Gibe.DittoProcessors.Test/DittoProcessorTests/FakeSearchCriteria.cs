using System;
using System.Collections.Generic;
using Examine.SearchCriteria;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	internal class FakeSearchCriteria : ISearchCriteria
	{
		public IBooleanOperation Id(int id)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation NodeName(string nodeName)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation NodeName(IExamineValue nodeName)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation NodeTypeAlias(string nodeTypeAlias)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation NodeTypeAlias(IExamineValue nodeTypeAlias)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation ParentId(int id)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Field(string fieldName, string fieldValue)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Field(string fieldName, IExamineValue fieldValue)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, DateTime lower, DateTime upper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, DateTime lower, DateTime upper, bool includeLower, bool includeUpper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, DateTime lower, DateTime upper, bool includeLower, bool includeUpper,
			DateResolution resolution)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, int lower, int upper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, int lower, int upper, bool includeLower, bool includeUpper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, double lower, double upper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, double lower, double upper, bool includeLower, bool includeUpper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, float lower, float upper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, float lower, float upper, bool includeLower, bool includeUpper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, long lower, long upper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, long lower, long upper, bool includeLower, bool includeUpper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, string lower, string upper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation Range(string fieldName, string lower, string upper, bool includeLower, bool includeUpper)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation GroupedAnd(IEnumerable<string> fields, params string[] query)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation GroupedAnd(IEnumerable<string> fields, params IExamineValue[] query)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation GroupedOr(IEnumerable<string> fields, params string[] query)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation GroupedOr(IEnumerable<string> fields, params IExamineValue[] query)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation GroupedNot(IEnumerable<string> fields, params string[] query)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation GroupedNot(IEnumerable<string> fields, params IExamineValue[] query)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation GroupedFlexible(IEnumerable<string> fields, IEnumerable<BooleanOperation> operations,
			params string[] query)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation GroupedFlexible(IEnumerable<string> fields, IEnumerable<BooleanOperation> operations,
			params IExamineValue[] query)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation OrderBy(params string[] fieldNames)
		{
			throw new NotImplementedException();
		}

		public IBooleanOperation OrderByDescending(params string[] fieldNames)
		{
			throw new NotImplementedException();
		}

		public BooleanOperation BooleanOperation { get; }

		public ISearchCriteria RawQuery(string query)
		{
			throw new NotImplementedException();
		}

		public string SearchIndexType { get; }
	}
}