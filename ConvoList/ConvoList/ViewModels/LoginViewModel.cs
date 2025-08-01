using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace ConvoList.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string loginButtonText = "Login";

        [RelayCommand]
        private async Task LoginAsync()
        {
            // Clear previous error
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter username and password!";
                return;
            }

            // Show loading state
            IsLoading = true;
            LoginButtonText = "Logging in...";

            try
            {
                bool isValid = await AuthenticateUser(Username, Password);

                if (isValid)
                {
                    // Update shell authentication state
                    if (Shell.Current is AppShell appShell)
                    {
                        appShell.IsAuthenticated = true;
                    }
                }
                else
                {
                    ErrorMessage = "Invalid credentials";
                }
            }
            finally
            {
                IsLoading = false;
                LoginButtonText = "Login";
            }
        }

        private async Task<bool> AuthenticateUser(string username, string password)
        {
            await Task.Delay(1000); // Simulate network call
            return username == "admin" && password == "password";
        }
    }
}