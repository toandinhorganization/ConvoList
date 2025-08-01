using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConvoList.Models;
using ConvoList.Models.Ultilities;
using ConvoList.Services;
using System.Collections.ObjectModel;

namespace ConvoList.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoadDataCommand))]
        private bool _isLoading;

        [ObservableProperty]
        private string _dataLoadedText = "No data loaded yet.";
        [ObservableProperty]

        private ObservableRangeCollection<TodoItem> todoItems  = new ObservableRangeCollection<TodoItem>();
        private readonly TodoService _todoService;
        public HomePageViewModel(TodoService todoService)
        {
            _todoService = todoService;
        }
        [RelayCommand(CanExecute = nameof(CanLoadData))]
        private async Task LoadData()
        {
            IsLoading = true;
            await Task.Delay(3000);
            var todos = await _todoService.GetTodosAsync();
            TodoItems.Clear();
            TodoItems.AddRange(todos);
            IsLoading = false;
        }

        private bool CanLoadData() => !IsLoading;
    }
}

