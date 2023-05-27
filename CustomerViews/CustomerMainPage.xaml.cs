using Maui.CustomerApp.Models;
using System.Collections.ObjectModel;

namespace Maui.CustomerApp.CustomerViews;

public partial class CustomerMainPage : ContentPage
{
    public CustomerMainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadCustomers();
        searchBar.Text = string.Empty;
    }

    private void LoadCustomers()
    {
        var customers = new ObservableCollection<Customer>(CustomerRepository.GetAllCustomers());
        UIContactList.ItemsSource = customers;

    }

    private async void UIContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (UIContactList.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(CustomerEditPage)}?Id={((Customer)UIContactList.SelectedItem).Id}");
        }
    }

    private void UIContactList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        UIContactList.SelectedItem = null;
    }

    private void BtnAddCustomer_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CustomerAddPage));
    }

    private void MenuItemDelete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var customer = menuItem.CommandParameter as Customer;
        CustomerRepository.DeleteCustomer(customer.Id);
        LoadCustomers();

    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            var customers = new ObservableCollection<Customer>(CustomerRepository.SearchCustomer(((SearchBar)sender).Text));
            UIContactList.ItemsSource = customers;
        }
        catch (Exception) { }
    }
}