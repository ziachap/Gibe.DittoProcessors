using Newtonsoft.Json;

namespace Gibe.DittoProcessors.Processors
{
	public class JsonAttribute : TestableDittoProcessorAttribute
	{
		public override object ProcessValue() 
			=> string.IsNullOrEmpty(Value?.ToString()) ? null : JsonConvert.SerializeObject(Value);
	}
}
