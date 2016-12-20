using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Gibe.DittoProcessors.Processors
{
	public class NextUrlAttribute : TestableDittoProcessorAttribute
	{
		private readonly HttpContextBase _httpContextBase;
		private readonly string _pageAlias;

		public NextUrlAttribute(HttpContextBase httpContextBase, string pageAlias = "page")
		{
			_httpContextBase = httpContextBase;
			_pageAlias = pageAlias;
		}

		public NextUrlAttribute(string pageAlias = "page")
		{
			_httpContextBase = DependencyResolver.Current.GetService<HttpContextBase>();
			_pageAlias = pageAlias;
		}

		public override object ProcessValue()
		{
			var canonicalUrl = _httpContextBase.Request.Url?.Scheme + "://"
			                   + _httpContextBase.Request.Url?.Host
			                   + _httpContextBase.Request.Url?.AbsolutePath;

			var queryParameters = _httpContextBase.Request.Url.ParseQueryString();

			if (queryParameters.AllKeys.Contains(_pageAlias))
			{
				var nextPage = int.Parse(queryParameters[_pageAlias]) + 1;
				queryParameters[_pageAlias] = nextPage.ToString();
				return canonicalUrl + "?" + queryParameters;
			}

			queryParameters[_pageAlias] = 2.ToString();
			return canonicalUrl + "?" + queryParameters;
		}
	}
}