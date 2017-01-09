using Examine.SearchCriteria;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	internal class FakeBooleanOperation : IBooleanOperation
	{
		public IQuery And()
		{
			throw new System.NotImplementedException();
		}

		public IQuery Or()
		{
			throw new System.NotImplementedException();
		}

		public IQuery Not()
		{
			throw new System.NotImplementedException();
		}

		public ISearchCriteria Compile()
		{
			throw new System.NotImplementedException();
		}
	}
}