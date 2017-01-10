using Gibe.DittoProcessors.Processors;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	[TestFixture]
	internal class JsonAttributeTests
	{
		private JsonAttribute JsonAttribute(object value) => new JsonAttribute {Value = value};

		private JsonTestType JsonTestObject => new JsonTestType
		{
			IsSomething = true,
			Number = 123,
			Text = "Hello World"
		};

		private class JsonTestType
		{
			public string Text { get; set; }
			public int Number { get; set; }
			public bool IsSomething { get; set; }
		}

		[Test]
		public void Json_Returns_Null_When_Null_Object()
		{
			var json = JsonAttribute(null).ProcessValue();

			Assert.IsNull(json);
		}

		[Test]
		public void Json_Returns_Valid_Json_Of_Object()
		{
			var json = JsonAttribute(JsonTestObject).ProcessValue().ToString();
			var result = JsonConvert.DeserializeObject<JsonTestType>(json);

			Assert.IsTrue(result.Text == JsonTestObject.Text);
			Assert.IsTrue(result.Number == JsonTestObject.Number);
			Assert.IsTrue(result.IsSomething == JsonTestObject.IsSomething);
		}
	}
}