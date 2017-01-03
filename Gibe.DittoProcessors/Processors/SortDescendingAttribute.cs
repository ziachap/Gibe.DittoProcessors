using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Umbraco.Core.Models;

namespace Gibe.DittoProcessors.Processors
{
	public class SortDescendingAttribute : TestableDittoProcessorAttribute
	{
		private readonly string _umbracoPropertyAlias;

		public SortDescendingAttribute(string umbracoPropertyAlias)
		{
			_umbracoPropertyAlias = umbracoPropertyAlias;
		}

		public override object ProcessValue()
			=> ((IEnumerable<IPublishedContent>) Value)?.OrderByDescending(GetPropertyOrDefault);

		public object GetPropertyOrDefault(object value)
			=> TypeDescriptor.GetProperties(value).Find(_umbracoPropertyAlias, true)?.GetValue(value);
	}
}