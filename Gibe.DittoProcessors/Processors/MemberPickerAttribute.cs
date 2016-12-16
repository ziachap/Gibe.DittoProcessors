using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Gibe.DittoProcessors.Processors.Models;
using Gibe.DittoServices.ModelConverters;
using Gibe.UmbracoWrappers;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Gibe.DittoProcessors.Processors
{
	public class MemberPickerAttribute : TestableDittoProcessorAttribute
	{
		private readonly IModelConverter _modelConverter;

		public MemberPickerAttribute(IModelConverter modelConverter)
		{
			_modelConverter = modelConverter;
		}

		public MemberPickerAttribute()
		{
			_modelConverter = DependencyResolver.Current.GetService<IModelConverter>();
		}

		public override object ProcessValue()
		{
			if (string.IsNullOrEmpty(Value.ToString())) return Enumerable.Empty<IPublishedContent>();
			//TODO: Make TypedMember() in IUmbracoWrapper and use that
			return Value.ToString()
				.Split(',')
				.Select(int.Parse)
				.Select(new Umbraco.Web.Security.MembershipHelper(UmbracoContext.Current).GetById)
				.Select(x => _modelConverter.ToModel<MemberModel>(x))
				.ToList();
		}
	}
}
