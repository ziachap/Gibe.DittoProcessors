using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;

namespace Gibe.DittoProcessors.Processors
{
	public class TakeAttribute : TestableDittoProcessorAttribute
	{
		private readonly uint _take;

		public TakeAttribute(uint take)
		{
			_take = take;
		}

		public override object ProcessValue() => ((IEnumerable<IPublishedContent>) Value)?.Take((int) _take);
	}
}