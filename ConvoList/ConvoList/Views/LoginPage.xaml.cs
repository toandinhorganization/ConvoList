using ConvoList.ViewModels;

namespace ConvoList.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginModelView)
	{
		InitializeComponent();
		BindingContext = loginModelView;
	}
}
