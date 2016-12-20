using System.Web.Mvc;
using Gibe.Navigation;
using Gibe.Navigation.Models;

namespace Gibe.DittoProcessors.Processors
{
	public class NavigationAttribute : TestableDittoProcessorAttribute
	{
		private readonly INavigationService<INavigationElement> _navigationService;

		public NavigationAttribute(INavigationService<INavigationElement> navigationService)
		{
			_navigationService = navigationService;
		}

		public NavigationAttribute()
		{
			_navigationService = DependencyResolver.Current.GetService<INavigationService<INavigationElement>>();
		}

		public override object ProcessValue()
			=> _navigationService.GetNavigation(Context.Content.Url);
	}
}