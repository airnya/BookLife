using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookTime.Views.DetailsViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewBookAdded : ContentPage
    {
        public NewBookAdded()
        {
            InitializeComponent();
        }

        public string BookTitle
        {
            set
            {
                book_title.Text = value;
            }
            get { return book_title.Text; }
        }

        async void AddNew(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewBookMain());
        }

        async void GoBack(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}