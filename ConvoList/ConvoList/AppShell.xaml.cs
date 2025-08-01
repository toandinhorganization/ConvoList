using CommunityToolkit.Mvvm.ComponentModel;
using ConvoList.ViewModels;
using ConvoList.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using Microsoft.Maui.Controls;

namespace ConvoList
{
    public partial class AppShell : Shell
    {
        LoginViewModel loginModelView = new LoginViewModel();
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TodoListPage), typeof(TodoListPage));

            // Subscribe to the Navigated event
            this.Navigated += OnShellNavigated;
        }

        private void OnShellNavigated(object sender, ShellNavigatedEventArgs e)
        {
            // Check if the navigation source is a FlyoutItem
            if (e.Source == ShellNavigationSource.ShellContentChanged)
            {
                // Log or handle the content change
                Console.WriteLine($"Navigated to: {e.Current.Location}");
            }
        }

        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set
            {
                if (_isAuthenticated != value)
                {
                    _isAuthenticated = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsNotAuthenticated));

                    // Navigate to appropriate section
                    if (value)
                    {
                        GoToAsync("//home"); // Navigate to home after login
                    }
                    else
                    {
                        GoToAsync("//login"); // Navigate to login
                    }
                }
            }
        }

        public bool IsNotAuthenticated => !IsAuthenticated;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void AuthenticateUser()
        {

        }

        //Switching between Login and Main Content
        private void AppContentSwitch()
        {

        }

    }
}
