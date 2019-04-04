using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookTime.Views.DetailsViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewBookSearch : ContentPage
    {
        public NewBookSearch()
        {
            InitializeComponent();
        }

        async void SeachBook(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewBookEdit()
            {
                BookId = book_id.Text
            });
        }
    }
}
