using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gibe.DittoProcessors.Processors;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	[TestFixture]
	internal class JsonAttributeTests
	{
		private JsonAttribute JsonAttribute(object value) => new JsonAttribute { Value = value };

		private JsonTestType JsonTestObject => new JsonTestType
		{
			IsSomething = true,
			Number = 123,
			Text = "Hello World"
		};

		[Test]
		public void Json_Returns_Valid_Json_Of_Object()
		{
			var json = JsonAttribute(JsonTestObject).ProcessValue().ToString();
			var result = JsonConvert.DeserializeObject<JsonTestType>(json);

			Assert.IsTrue(result.Text == JsonTestObject.Text);
			Assert.IsTrue(result.Number == JsonTestObject.Number);
			Assert.IsTrue(result.IsSomething == JsonTestObject.IsSomething);
		}

		[Test]
		public void Json_Returns_Null_When_Null_Object()
		{
			var json = JsonAttribute(null).ProcessValue();

			Assert.IsNull(json);
		}

		private class JsonTestType
		{
			public string Text { get; set; }
			public int Number { get; set; }
			public bool IsSomething { get; set; }
		}
	}

	
}
