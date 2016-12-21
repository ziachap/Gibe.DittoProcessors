using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Umbraco.Core.Models;

namespace Gibe.DittoProcessors.Processors
{
	public class SortAttribute : TestableDittoProcessorAttribute
	{
		private readonly string _umbracoPropertyAlias;

		public SortAttribute(string umbracoPropertyAlias)
		{
			_umbracoPropertyAlias = umbracoPropertyAlias;
		}

		public override object ProcessValue()
			=> ((IEnumerable<IPublishedContent>) Value)?.OrderBy(GetPropertyOrDefault);

		public object GetPropertyOrDefault(object value)
			=> TypeDescriptor.GetProperties(value).Find(_umbracoPropertyAlias, true)?.GetValue(value);
	}
}