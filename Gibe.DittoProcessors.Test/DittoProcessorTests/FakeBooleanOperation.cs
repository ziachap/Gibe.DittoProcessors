using System;
using Examine.SearchCriteria;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	internal class FakeBooleanOperation : IBooleanOperation
	{
		public IQuery And()
		{
			throw new NotImplementedException();
		}

		public IQuery Or()
		{
			throw new NotImplementedException();
		}

		public IQuery Not()
		{
			throw new NotImplementedException();
		}

		public ISearchCriteria Compile()
		{
			throw new NotImplementedException();
		}
	}
}