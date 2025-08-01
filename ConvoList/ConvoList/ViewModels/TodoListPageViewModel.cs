using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConvoList.Models;
using ConvoList.Services;

namespace ConvoList.ViewModels
{
    public partial class TodoListPageViewModel : ObservableObject
    {
        private readonly TodoService _todoService;
        private ObservableCollection<TodoItem> _todos;
        [ObservableProperty]
        private string newTodoName;
        [ObservableProperty]
        private string newTodoDescription;
        public TodoListPageViewModel(TodoService todoService)
        {
            _todoService = todoService;
            Todos = new ObservableCollection<TodoItem>();
            Task.Run(async () => await LoadTodos());
        }
        public ObservableCollection<TodoItem> Todos
        {
            get => _todos;
            set
            {
                _todos = value;
                OnPropertyChanged();
            }
        }


        private async Task LoadTodos()
        {
            try
            {
                var todos = await _todoService.GetTodosAsync();
                Todos = new ObservableCollection<TodoItem>(todos);
            }
            catch (Exception ex)
            {
                // Log or handle the error
            }
        }
        [RelayCommand]
        private async Task AddTodo()
        {
            if (string.IsNullOrWhiteSpace(NewTodoName))
                return;

            var newTodo = new TodoItem { Name = NewTodoName, Description = NewTodoDescription, IsDone = false };
            await _todoService.SaveTodoAsync(newTodo);
            Todos.Add(newTodo);
            NewTodoName = string.Empty;
            NewTodoDescription = string.Empty;
        }
        [RelayCommand]
        private async Task DeleteAllAsync()
        {
            if (Todos.Count == 0)
                return;
            foreach (var todo in Todos.ToList())
            {
                await _todoService.DeleteTodoAsync(todo);
                Todos.Remove(todo);
            }
        }

    }
}
