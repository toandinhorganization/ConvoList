using ConvoList.Models;

namespace ConvoList.ContentViews;

public partial class TodoItemView : ContentView
{
	public static readonly BindableProperty TodoItemProperty =
		BindableProperty.Create(nameof(TodoItem), typeof(TodoItem), typeof(TodoItemView), propertyChanged: OnTodoItemChanged);

	public TodoItem TodoItem
	{
		get => (TodoItem)GetValue(TodoItemProperty);
		set => SetValue(TodoItemProperty, value);
	}

	public TodoItemView()
	{
		InitializeComponent();
	}

	private static void OnTodoItemChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is TodoItemView view)
		{
			view.BindingContext = newValue as TodoItem;
		}
	}

    private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
    {

    }
}