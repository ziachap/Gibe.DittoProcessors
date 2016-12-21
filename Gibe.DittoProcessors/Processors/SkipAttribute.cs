using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;

namespace Gibe.DittoProcessors.Processors
{
	public class SkipAttribute : TestableDittoProcessorAttribute
	{
		private readonly uint _skip;

		public SkipAttribute(uint skip)
		{
			_skip = skip;
		}

		public override object ProcessValue() => ((IEnumerable<IPublishedContent>) Value)?.Skip((int) _skip);
	}
}