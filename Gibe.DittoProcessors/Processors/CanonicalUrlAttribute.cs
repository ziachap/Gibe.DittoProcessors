using Umbraco.Web;

namespace Gibe.DittoProcessors.Processors
{
	public class CanonicalUrlAttribute : TestableDittoProcessorAttribute
	{
		public override object ProcessValue() => Context.Content.UrlAbsolute();
	}
}