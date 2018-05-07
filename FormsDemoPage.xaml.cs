using Xamarin.Forms;

namespace FormsDemo
{
	public partial class FormsDemoPage : ContentPage
	{
		public FormsDemoPage()
		{
			InitializeComponent();
            FnClickEvents();
		}
        protected override bool OnBackButtonPressed()
        {
            //return base.OnBackButtonPressed();
            return true;
        }

        void FnClickEvents()
        {
            login.Clicked += delegate 
            {
                if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
                {
                    DisplayAlert("Demo", "Please Enter Login Credentials", "Ok");
                }
                else
                {
                    FnLoginClicked();
                }
            };
        }

        void FnLoginClicked()
        {
            Application.Current.MainPage = new Pages.RegistrationPage();
            Navigation.PushModalAsync(new Pages.RegistrationPage());
        }

	}
}
