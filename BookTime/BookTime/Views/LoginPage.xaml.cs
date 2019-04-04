using BookTime.Views.Menu;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookTime.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            /*         User user = new User(Entry_Username.Text, Entry_Password.Text);
                       if (user.CheckInFormation())
                       {
                           await DisplayAlert("Login", "Login Success", "Oke");
                           //var result await App.RestService.Login(user);
                           var result = new Token();
                           if (this.Entry_Username != null && this.Entry_Password != null) 

                           {
                               //App.UserDatabase.SaveUser(user);
                               //App.TokenDatabase.SaveToken(result);
                               Application.Current.MainPage = new MasterDetail();
                           }
                       }
                       else
                       {
                           await DisplayAlert("Login", "Login Not Correct, empty username or password!", "Oke");
                       }
                       */
            {
                //App.UserDatabase.SaveUser(user);
                //App.TokenDatabase.SaveToken(result);
                Application.Current.MainPage = new MasterDetail();
            }
        }

    }
}