using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Gibe.DittoProcessors.Test.DittoProcessorTests
{
	internal class TestPublishedContent : IPublishedContent
	{
		public int GetIndex()
		{
			throw new NotImplementedException();
		}

		public IPublishedProperty GetProperty(string alias)
		{
			throw new NotImplementedException();
		}

		public IPublishedProperty GetProperty(string alias, bool recurse)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IPublishedContent> ContentSet { get; }
		public PublishedContentType ContentType { get; }
		public int Id { get; set; }
		public int TemplateId { get; }
		public int SortOrder { get; }
		public string Name { get; set; }
		public string UrlName { get; }
		public string DocumentTypeAlias { get; set; }
		public int DocumentTypeId { get; }
		public string WriterName { get; }
		public string CreatorName { get; }
		public int WriterId { get; }
		public int CreatorId { get; }
		public string Path { get; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; }
		public Guid Version { get; }
		public int Level { get; }
		public string Url { get; }
		public PublishedItemType ItemType { get; }
		public bool IsDraft { get; }
		public IPublishedContent Parent { get; }
		public IEnumerable<IPublishedContent> Children { get; set; }
		public ICollection<IPublishedProperty> Properties { get; }

		public object this[string alias]
		{
			get { throw new NotImplementedException(); }
		}
	}
}