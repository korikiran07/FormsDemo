using System;
using System.Collections.Generic;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using Xamarin.Forms;

namespace FormsDemo.Pages
{
    public partial class RegistrationPage : ContentPage
    {

		string strDOB="";
		string strGender="";


        public RegistrationPage()
        {
            InitializeComponent();
			FnInitialization();
			FnClickEvents();
        }

        protected override bool OnBackButtonPressed()
        {
           // return base.OnBackButtonPressed();
            FnMoveToLoginPage();
            return true;
        }


		void FnInitialization()
		{
			FnAddValuesToPickerGender();
		
		}
		void FnClickEvents()
		{
			datePickerDOB.DateSelected += delegate 
			{
				try
				{
					strDOB = datePickerDOB.Date.ToString("ddMMyyyy");
				}
				catch (Exception ex)
				{

				}
			};

			pickerGender.SelectedIndexChanged += (sender, e) =>
			{ 
				strGender = pickerGender.Items[pickerGender.SelectedIndex];
			};
			var tap = new TapGestureRecognizer();
			tap.Tapped += (s,e) =>
	        {
                FnMoveToLoginPage();
	        };
			lblLoginHere.GestureRecognizers.Add(tap);

			btnRegister.Clicked += delegate 
			{
				//if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmailId.Text) || string.IsNullOrEmpty(txtMobileNumber.Text) || string.IsNullOrEmpty(txtPassword.Text)
				//|| string.IsNullOrEmpty(txtConfirmPassword.Text) || string.IsNullOrEmpty(strDOB) || string.IsNullOrEmpty(strGender))
				//{
				//	DisplayAlert("Demo", "Please Fill All Fields", "Ok");
				//}
				//else
				//{
				//	FnRegister();
				//}
                FnRegister();
			};
		
		}

		void FnAddValuesToPickerGender()
		{
			

			List<string> listGender = new List<string>() { "Male","Female","Other"};
			//pickerGender.Title = "Select";

			foreach (var item in listGender)
			{
				pickerGender.Items.Add(item);
			}
		
		}

		void FnMoveToLoginPage()
		{
			Application.Current.MainPage = new LoginPage();
			Navigation.PushModalAsync(new LoginPage());
		}

		async void FnRegister()
		{
			RegisterCLass objRegisterCLass = new RegisterCLass();
			objRegisterCLass.Name = txtName.Text;
			objRegisterCLass.EmailId = txtEmailId.Text;
			objRegisterCLass.MobileNumber = txtMobileNumber.Text;
			objRegisterCLass.Password = txtPassword.Text;
			objRegisterCLass.ConfirmPassword = txtConfirmPassword.Text;
			objRegisterCLass.DOB = strDOB;
			objRegisterCLass.Gender = strGender;

			try
			{
				var firebase = new FirebaseClient("https://formsdemo-36909.firebaseio.com/");
				var item = await firebase
					.Child(string.Format("USER_TABLE/{0}/", 1))
					.WithAuth("d7d94592-1ba9-470f-810b-dbb44c6ce4a3")
					.PostAsync(objRegisterCLass, false);
			}
			catch (Exception ex)
			{

			}


			//var firebase = new FirebaseClient("https://yourdatabase.firebaseio.com/");

			//// add new item to list of data 
			//var item = await firebase
			//  .Child("india")
			//  //.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
			//  .PostAsync(objRegisterCLass);

		}

	}
}
