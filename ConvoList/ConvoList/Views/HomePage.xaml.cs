using ConvoList.Interfaces;
using ConvoList.ViewModels;
using ConvoList.Services;
using System.Collections.ObjectModel;
using ConvoList.ContentViews;

namespace ConvoList.Views;

public partial class HomePage : ContentPage
{   

    public HomePage(TodoService todoService)
	{
		InitializeComponent();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Load data or perform actions when the page appears
        if (BindingContext is HomePageViewModel modelView)
        {
            modelView.LoadDataCommand.Execute(null);
        }
    }

    private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
    {
        if(sender is TodoItemView todoItemView && todoItemView.TodoItem is not null)
        {

        }
    }
}