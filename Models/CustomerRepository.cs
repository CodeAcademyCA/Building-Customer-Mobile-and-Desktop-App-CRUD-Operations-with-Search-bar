using Maui.CustomerApp.CustomerViews;

namespace Maui.CustomerApp.Models
{
    public class CustomerRepository
    {
        public static List<Customer> CustomerList = new List<Customer>()
        {
            new Customer() { Id = 1, Name = "Frederick Hughes", Address = "Str. 112", Email = "Fred@gmail.com", PhoneNumber = 01470258803},
            new Customer() { Id = 2, Name = "Moses Adams", Address = "Str. 114", Email = "Fred@gmail.com", PhoneNumber = 78966555},
            new Customer() { Id = 3, Name = "James Klean", Address = "Str. 117", Email = "Moses@gmail.com", PhoneNumber = 45877522},
            new Customer() { Id = 4, Name = "Joseph Klick", Address = "Str. 142", Email = "Joseph@gmail.com", PhoneNumber = 01225477},
            new Customer() { Id = 5, Name = "Hurbert Fricks", Address = "Str. 8112", Email = "Hurbert@gmail.com", PhoneNumber = 6355897},
            new Customer() { Id = 6, Name = "Ransford Blue", Address = "Str. 1192", Email = "Ransford@gmail.com", PhoneNumber = 45336987},
            new Customer() { Id = 7, Name = "Justice Hurns", Address = "Str. 1125", Email = "Justice@gmail.com", PhoneNumber = 1245789},
            new Customer() { Id = 8, Name = "Freedom Gads", Address = "Str. 1120", Email = "Freedom@gmail.com", PhoneNumber = 369852},
            new Customer() { Id = 9, Name = "Richard Sees", Address = "Str. 987", Email = "Richard@gmail.com", PhoneNumber = 147852},
            new Customer() { Id = 10, Name = "Rack Kiss", Address = "Str. 325", Email = "Rack@gmail.com", PhoneNumber = 258741},
            new Customer() { Id = 11, Name = "Rockson Judge", Address = "Str. 785", Email = "Rockson@gmail.com", PhoneNumber = 14569887},
            new Customer() { Id = 12, Name = "Mabel Yankson", Address = "Str. 417", Email = "Mabel@gmail.com", PhoneNumber = 36542178},
            new Customer() { Id = 13, Name = "Rosemond Tuckson", Address = "Str. 963", Email = "Rosemond@gmail.com", PhoneNumber = 98200145},
            new Customer() { Id = 14, Name = "Millicent Kurts", Address = "Str. 785", Email = "Millicent@gmail.com", PhoneNumber = 6325587},
            new Customer() { Id = 15, Name = "Mirinda Roberts", Address = "Str. 245", Email = "Mirinda@gmail.com", PhoneNumber = 45277411},
            new Customer() { Id = 16, Name = "Grace Hanson", Address = "Str. 365856", Email = "Grace@gmail.com", PhoneNumber = 21001455},
            new Customer() { Id = 17, Name = "Nancy Oduro", Address = "Str. 963", Email = "Nancy@gmail.com", PhoneNumber = 022100452},
            new Customer() { Id = 18, Name = "Franklina Wright", Address = "Str. 748", Email = "Franklina@gmail.com", PhoneNumber = 022545887},
        };

        // CRUD Operation : Create, Read, Update & Delete

        //Create
        public static void CreateCustomer(Customer customer)
        {
            if (customer != null)
            {
                //get and set customer Id
                int maxId = CustomerList.Max(x => x.Id);
                customer.Id = maxId + 1;

                var checkEmailandPhone = CustomerList.Where(x => x.Email.ToLower().Equals(customer.Email.ToLower()) || x.PhoneNumber == customer.PhoneNumber).FirstOrDefault();
                if (checkEmailandPhone != null)
                {
                    Shell.Current.DisplayAlert("Error", "Email or Phone Number cannot be used", "Ok");
                    return;
                }
                CustomerList.Add(customer);
                Shell.Current.DisplayAlert("Success", "Customer Created Done", "Ok");
                Shell.Current.GoToAsync("..");
            }
        }


        //Read All
        public static List<Customer> GetAllCustomers() => CustomerList;

        //Read Individual
        public static Customer GetCustomerById(int id)
        {
            var customer = CustomerList.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        //Update
        public static void UpdateCustomer(Customer customer)
        {
            var result = CustomerList.FirstOrDefault(x => x.Id == customer.Id);
            if (result != null)
            {
                result.Name = customer.Name;
                result.Email = customer.Email;
                result.Address = customer.Address;
                result.PhoneNumber = customer.PhoneNumber;
                Shell.Current.DisplayAlert("Success", "Customer Updated", "Ok");
                Shell.Current.GoToAsync($"//{nameof(CustomerMainPage)}");
            }
        }

        //Delete
        public static void DeleteCustomer(int id)
        {
            var result = CustomerList.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                CustomerList.Remove(result);
                Shell.Current.DisplayAlert("Success", "Customer Deleted", "Ok");
                Shell.Current.GoToAsync($"//{nameof(CustomerMainPage)}");
            }
        }


        //Search
        public static List<Customer> SearchCustomer(string filter)
        {
            var customers = CustomerList.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

            if (customers == null || customers.Count <= 0)
            {
                customers = CustomerList.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else return customers;

            if (customers == null || customers.Count <= 0)
            {
                customers = CustomerList.Where(x => x.PhoneNumber == int.Parse(filter)).ToList();
            }
            else return customers;

            return customers;
        }
    }
}
