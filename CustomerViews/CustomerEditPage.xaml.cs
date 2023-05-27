using Maui.CustomerApp.Models;

namespace Maui.CustomerApp.CustomerViews;

[QueryProperty(nameof(CustomerId), "Id")]
public partial class CustomerEditPage : ContentPage
{
	private Customer customer;
	public CustomerEditPage()
	{
		InitializeComponent();
	}

    public string CustomerId 
	{
		set
		{
			customer = CustomerRepository.GetCustomerById(int.Parse(value));
			CustomerCtrl.Name = customer.Name;
			CustomerCtrl.Email = customer.Email;
			CustomerCtrl.PhoneNumber = customer.PhoneNumber;
			CustomerCtrl.Address = customer.Address;
		}
	}

    private void CustomerCtrl_OnSave(object sender, EventArgs e)
    {
        customer.Name = CustomerCtrl.Name;
        customer.Email = CustomerCtrl.Email;
        customer.PhoneNumber = CustomerCtrl.PhoneNumber;
        customer.Address = CustomerCtrl.Address;
		CustomerRepository.UpdateCustomer(customer);
    }
}