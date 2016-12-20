using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Gibe.Navigation.Umbraco;
using Umbraco.Web;

namespace Gibe.DittoProcessors.Processors
{
	public class WithinDateRangeAttribute : TestableDittoProcessorAttribute
	{
		private readonly DateTime _end;
		private readonly IUmbracoNodeService _nodeService;
		private readonly INodeTypeFactory _nodeTypeFactory;
		private readonly Type _rootNodeType;
		private readonly DateTime _start;
		private readonly string _umbracoPropertyAlias;

		public WithinDateRangeAttribute(IUmbracoNodeService nodeService, INodeTypeFactory nodeTypeFactory,
			Type rootNodeType, string umbracoPropertyAlias, string startDate, string endDate)
		{
			_umbracoPropertyAlias = umbracoPropertyAlias;
			_nodeService = nodeService;
			_nodeTypeFactory = nodeTypeFactory;
			_rootNodeType = rootNodeType;
			_start = DateTime.Parse(startDate);
			_end = DateTime.Parse(endDate);
		}

		/// <summary>
		///     Returns all published content where the specified Umbraco property is  a valid date time between
		///     the specified start and end dates
		/// </summary>
		/// <param name="rootNodeType">INodeType of the root node of the Umbraco site</param>
		/// <param name="umbracoPropertyAlias">Alias of the Umbraco property to use as a date</param>
		/// <param name="startDate">dd/MM/yyyy</param>
		/// <param name="endDate">dd/MM/yyyy</param>
		public WithinDateRangeAttribute(Type rootNodeType, string umbracoPropertyAlias, string startDate, string endDate)
		{
			_umbracoPropertyAlias = umbracoPropertyAlias;
			_nodeService = DependencyResolver.Current.GetService<IUmbracoNodeService>();
			_nodeTypeFactory = DependencyResolver.Current.GetService<INodeTypeFactory>();
			_rootNodeType = rootNodeType;
			_start = DateTime.Parse(startDate);
			_end = DateTime.Parse(endDate);
		}

		public override object ProcessValue()
			=> _nodeService.GetNode(_nodeTypeFactory.GetNodeType(_rootNodeType))
				.Descendants()
				.Where(x => IsWithinRange(GetPropertyOrDefault<DateTime?>(x)));

		public T GetPropertyOrDefault<T>(object value) where T : new()
			=> (T) (TypeDescriptor.GetProperties(value).Find(_umbracoPropertyAlias, true)?.GetValue(value) ?? default(T));

		private bool IsWithinRange(DateTime? date) => _start < date && date < _end;
	}
}