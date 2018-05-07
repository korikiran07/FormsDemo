using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsDemo.Pages
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			FnInitialization();
			FnClickEvents();
		}

		void FnInitialization()
		{
			
		}
		void FnClickEvents()
		{
			btnLogin.Clicked += (sender, e) => FnLoginClicked();
			var register_tap = new TapGestureRecognizer();
			register_tap.Tapped += (s,e) =>
	        {
				FnMoveToRegisterPage();
	        };
			lblRegister.GestureRecognizers.Add(register_tap);
			
		}

		void FnLoginClicked()
		{
			if (string.IsNullOrEmpty(txtEmailOrMobile.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
				DisplayAlert("Demo", "Please Enter Login Credentials", "Ok");
            }
            else
            {
                FnMoveToRegisterPage();
            }
		}
		void FnMoveToRegisterPage()
		{ 
			Application.Current.MainPage = new RegistrationPage();
			Navigation.PushModalAsync(new RegistrationPage());
		}
    }
}
