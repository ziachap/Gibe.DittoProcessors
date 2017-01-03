using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Gibe.DittoServices.ModelConverters;
using Umbraco.Core.Models;

namespace Gibe.DittoProcessors.Processors
{
	public class ModelAttribute : TestableDittoProcessorAttribute
	{
		private readonly IModelConverter _modelConverter;
		private readonly Type _modelType;

		public ModelAttribute(IModelConverter modelConverter, Type modelType)
		{
			_modelConverter = modelConverter;
			_modelType = modelType;
		}

		public ModelAttribute(Type modelType)
		{
			_modelConverter = DependencyResolver.Current.GetService<IModelConverter>();
			_modelType = modelType;
		}

		public override object ProcessValue()
		{
			if (Value is IEnumerable<IPublishedContent>)
			{
				return _modelConverter.ToModel(_modelType, (IEnumerable<IPublishedContent>)Value);
			}
			return Value is IPublishedContent
				? _modelConverter.ToModel(_modelType, (IPublishedContent)Value)
				: null;
		}
	}
}
