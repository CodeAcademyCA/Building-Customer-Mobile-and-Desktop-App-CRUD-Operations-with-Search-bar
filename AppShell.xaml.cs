namespace Maui.CustomerApp;
using Maui.CustomerApp.CustomerViews;
public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		//Registering Content Pages : Customer Main page, customer Edit page, Customer Add page
		Routing.RegisterRoute(nameof(CustomerMainPage), typeof(CustomerMainPage));
        Routing.RegisterRoute(nameof(CustomerAddPage), typeof(CustomerAddPage));
        Routing.RegisterRoute(nameof(CustomerEditPage), typeof(CustomerEditPage));
    }
}
