using System;
using System.Linq;
using System.Web.Mvc;
using Gibe.Navigation.Umbraco;
using Umbraco.Web;

namespace Gibe.DittoProcessors.Processors
{
	public class DescendantsAttribute : TestableDittoProcessorAttribute
	{
		private readonly string _docTypeAlias;
		private readonly INodeTypeFactory _nodeTypeFactory;
		private readonly Type _targetNodeType;
		private readonly IUmbracoNodeService _umbracoNodeService;

		public DescendantsAttribute(IUmbracoNodeService umbracoNodeService,
			INodeTypeFactory nodeTypeFactory, Type targetNodeType, string docTypeAlias = null)
		{
			_umbracoNodeService = umbracoNodeService;
			_nodeTypeFactory = nodeTypeFactory;
			_docTypeAlias = docTypeAlias;
			_targetNodeType = targetNodeType;
		}

		public DescendantsAttribute(string docTypeAlias = null)
		{
			_umbracoNodeService = DependencyResolver.Current.GetService<IUmbracoNodeService>();
			_nodeTypeFactory = DependencyResolver.Current.GetService<INodeTypeFactory>();
			_docTypeAlias = docTypeAlias;
			_targetNodeType = null;
		}

		public DescendantsAttribute(Type targetNodeType, string docTypeAlias = null)
		{
			_umbracoNodeService = DependencyResolver.Current.GetService<IUmbracoNodeService>();
			_nodeTypeFactory = DependencyResolver.Current.GetService<INodeTypeFactory>();
			_docTypeAlias = docTypeAlias;
			_targetNodeType = targetNodeType;
		}

		public override object ProcessValue()
		{
			var targetNode = _targetNodeType == null
				? Context.Content
				: _umbracoNodeService.GetNode(_nodeTypeFactory.GetNodeType(_targetNodeType));

			return targetNode
				.Descendants()
				.Where(d => string.IsNullOrEmpty(_docTypeAlias) || _docTypeAlias == d.DocumentTypeAlias)
				.ToList();
		}
	}
}