using System.Collections.Generic;
using System.Linq;
using Gibe.Navigation.Umbraco.NodeTypes;
using Umbraco.Core.Models;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	internal class FakeRootNodeType : INodeType
	{
		public IPublishedContent FindNode(IEnumerable<IPublishedContent> rootNodes)
		{
			return rootNodes.First(x => x.DocumentTypeAlias == "superpage");
		}
	}
}