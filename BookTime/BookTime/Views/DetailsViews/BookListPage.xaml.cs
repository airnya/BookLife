using BookTime.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookTime.Views.DetailsViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookListPage : ContentPage
    {
        App app = (App)Application.Current;
        ObservableCollection<Book> BookList;
        String nextPage;

        public BookListPage(List<Book> books, String nextPage)
        {
            this.nextPage = nextPage;
            Title = "Book List";
            InitializeComponent();

            if (books == null)
            {
                BookList = new ObservableCollection<Book>(app.Database.GetBooks().ToList());
            }
            else
            {
                BookList = new ObservableCollection<Book>(books);
            }
            BookListView.ItemsSource = BookList;
        }

        public void RemoveBook(Book book)
        {
            BookList.Remove(book);
        }

        async void OnViewListItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Book book = args.SelectedItem as Book;
            if (book != null)
            {
                BookListView.SelectedItem = null;
                if (nextPage.Equals("BookDetailsPage"))
                {
                    await Navigation.PushAsync(new BookDetailsPage()
                    {
                        Book = book
                    });
                }
                else if (nextPage.Equals("SendSomePage"))
                {
                    await Navigation.PushAsync(new BookDetailsPage()
                    {
                        Book = book
                    });
                }

                Debug.WriteLine("Navigating to book details page");
            }

        }
    }
}
