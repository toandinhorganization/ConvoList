using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvoList.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<T>() where T : Page;
        Task NavigateToAsync(Page page);
        Page GetPreviousPage();
        string GetPreviousPageName();
    }

    public class NavigationService : INavigationService
    {
        private readonly Stack<string> _navigationHistory = new();
        private Page _currentPage;

        public async Task NavigateToAsync<T>() where T : Page
        {
            var page = Activator.CreateInstance<T>();
            await NavigateToAsync(page);
        }

        public async Task NavigateToAsync(Page page)
        {
            // Store current page before navigation
            if (_currentPage != null)
            {
                _navigationHistory.Push(_currentPage.GetType().Name);
            }

            _currentPage = page;
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public Page GetPreviousPage()
        {
            if (Application.Current.MainPage.Navigation.NavigationStack.Count >= 2)
            {
                return Application.Current.MainPage.Navigation.NavigationStack[^2];
            }
            return null;
        }

        public string GetPreviousPageName()
        {
            return _navigationHistory.TryPeek(out var previousPageName)
                ? previousPageName
                : "Unknown";
        }
    }
}
