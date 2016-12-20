using System;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Gibe.DittoProcessors.Processors
{
	public class PreviousUrlAttribute : TestableDittoProcessorAttribute
	{
		private readonly HttpContextBase _httpContextBase;
		private readonly string _pageAlias;

		public PreviousUrlAttribute(HttpContextBase httpContextBase, string pageAlias = "page")
		{
			_httpContextBase = httpContextBase;
			_pageAlias = pageAlias;
		}

		public PreviousUrlAttribute(string pageAlias = "page")
		{
			_httpContextBase = DependencyResolver.Current.GetService<HttpContextBase>();
			_pageAlias = pageAlias;
		}

		public override object ProcessValue()
		{
			var url = _httpContextBase.Request.Url?.GetLeftPart(UriPartial.Path);

			var queryParameters = _httpContextBase.Request.Url.ParseQueryString();

			if (queryParameters.AllKeys.Contains(_pageAlias))
			{
				var nextPage = int.Parse(queryParameters[_pageAlias]) - 1;
				if (nextPage <= 0) return string.Empty;
				queryParameters[_pageAlias] = nextPage.ToString();
				return url + "?" + queryParameters;
			}

			return string.Empty;
		}
	}
}