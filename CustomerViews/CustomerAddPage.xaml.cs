using Maui.CustomerApp.Models;

namespace Maui.CustomerApp.CustomerViews;

public partial class CustomerAddPage : ContentPage
{
    public CustomerAddPage()
    {
        InitializeComponent();
    }

    private void CustomerCtrl_OnSave(object sender, EventArgs e)
    {
        var customer = new Customer()
        {
            Name = CustomerCtrl.Name,
            Email = CustomerCtrl.Email,
            PhoneNumber = CustomerCtrl.PhoneNumber,
            Address = CustomerCtrl.Address
        };
        CustomerRepository.CreateCustomer(customer);
    }
}