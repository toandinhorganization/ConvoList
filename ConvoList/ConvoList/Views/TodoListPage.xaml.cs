using ConvoList.ContentViews;
using ConvoList.Models;
using ConvoList.ViewModels;

namespace ConvoList.Views;

public partial class TodoListPage : ContentPage
{
	public TodoItem todoItem;
	public TodoListPage(TodoListPageViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

    }

    private void OnDragStarting(object sender, DragStartingEventArgs e)
    {
        if (sender is TodoItemView todoItemView && todoItemView.TodoItem != null)
        {
            e.Data.Properties.Add("DraggedItem", todoItemView.TodoItem);
        }
    }


}