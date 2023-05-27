namespace Maui.CustomerApp.CustomerViews.CustomerControls;

public partial class CustomerControl : ContentView
{
    public event EventHandler<EventArgs> OnSave;
	public CustomerControl()
	{
		InitializeComponent();
	}

	public string Name
	{
		get { return Entry_Name.Text; }
		set { Entry_Name.Text = value; }
	}

    public string Email
    {
        get { return Entry_Email.Text; }
        set { Entry_Email.Text = value; }
    }

    public string Address
    {
        get { return Entry_Address.Text; }
        set { Entry_Address.Text = value; }
    }

    public int PhoneNumber
    {
        get { return int.Parse(Entry_PhoneNumber.Text); }
        set { Entry_PhoneNumber.Text = value.ToString(); }
    }

    private void BtnSaveContact_Clicked(object sender, EventArgs e)
    {
        OnSave?.Invoke(sender, e);
    }
}