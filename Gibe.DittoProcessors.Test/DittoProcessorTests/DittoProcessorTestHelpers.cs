using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	internal class DittoProcessorTestHelpers
	{
		private static readonly IEnumerable<IPublishedContent> MoreChildren = new[]
		{
			new TestPublishedContent
			{
				Id = 4,
				DocumentTypeAlias = "yellow",
				Name = "Karl",
				CreateDate = new DateTime(2015, 2, 1),
				Children = Enumerable.Empty<IPublishedContent>()
			},
			new TestPublishedContent
			{
				Id = 5,
				DocumentTypeAlias = "blue",
				Name = "Kes",
				CreateDate = new DateTime(2013, 2, 1),
				Children = Enumerable.Empty<IPublishedContent>()
			}
		};

		private static readonly IEnumerable<IPublishedContent> RootChildren = new[]
		{
			new TestPublishedContent
			{
				Id = 1,
				Name = "Zia",
				DocumentTypeAlias = "green",
				CreateDate = new DateTime(2016, 2, 1),
				Children = Enumerable.Empty<IPublishedContent>()
			},
			new TestPublishedContent
			{
				Id = 2,
				Name = "Andrew",
				DocumentTypeAlias = "blue",
				CreateDate = new DateTime(2014, 2, 1),
				Children = Enumerable.Empty<IPublishedContent>()
			},
			new TestPublishedContent
			{
				Id = 3,
				Name = "Steve",
				DocumentTypeAlias = "blue",
				CreateDate = new DateTime(2000, 2, 1),
				Children = MoreChildren
			}
		};

		public static readonly IPublishedContent RootNode = new TestPublishedContent
		{
			Id = 24,
			Name = "Root",
			DocumentTypeAlias = "superpage",
			Children = RootChildren
		};
	}
}
