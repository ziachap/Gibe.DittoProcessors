using System.Linq;

namespace Gibe.DittoProcessors.Processors
{
	public class DropdownMultipleListAttribute : TestableDittoProcessorAttribute
	{
		public override object ProcessValue()
		{
			if (string.IsNullOrEmpty(Value.ToString())) return Enumerable.Empty<string>();
			return Value.ToString().Split(',');
		}
	}
}
