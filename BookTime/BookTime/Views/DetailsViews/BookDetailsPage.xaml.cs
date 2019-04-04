using BookTime.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookTime.Views.DetailsViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookDetailsPage : ContentPage
    {
        App app = (App)Application.Current;
        Book book;

        public BookDetailsPage()
        {
            Title = "Book Details";
            InitializeComponent();
        }

        public Book Book
        {
            set
            {
                book = value;
                BindingContext = value;
            }
            get { return book; }
        }

        async public void savebook(object s, EventArgs args)
        {
            if (await DisplayAlert("Remove Book", "Are you sure want to remove this book from the library?", "Yes", "No"))
            {
                var bookItem = (Book)BindingContext;
                app.Database.SaveBook(bookItem);
                await Navigation.PopAsync();
            }
        }

        async public void removebook(object s, EventArgs args)
        {
            if (await DisplayAlert("Remove Book", "Are you sure want to remove this book from the library?", "Yes", "No"))
            {
                var bookItem = (Book)BindingContext;
                app.Database.DeleteBook(bookItem.Id);
                await Navigation.PopAsync();
            }
        }
    }
}