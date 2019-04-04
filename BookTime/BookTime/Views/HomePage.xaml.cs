using BookTime.Models;
using BookTime.Views.DetailsViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookTime.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
    {
        App app = (App)Application.Current;
        ObservableCollection<Book> BookList;

        public HomePage()
        {
            Title = "БИБЛИОТЕКА";
            //NavigationPage.SetHasNavigationBar(this, false);
            //NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            //BookListHome.ItemsSource = new ObservableCollection<Book>(app.Database.GetBooks().ToList());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            BookList = new ObservableCollection<Book>(app.Database.GetBooks().ToList());
            BookListHome.ItemsSource = BookList;
        }

        async void OnToolbarItemClicked(object sender, EventArgs args)
        {
            ToolbarItem toolbarItem = (ToolbarItem)sender;

            if (toolbarItem.Text.Equals("My Books"))
            {
                //               await Navigation.PushAsync(new BookListPage(null, "BookDetailsPage"));
            }
            else if (toolbarItem.Text.Equals("Add a Book"))
            {
                await Navigation.PushAsync(new NewBookMain());
            }

            if (toolbarItem.Text.Equals("search"))
            {
                await Navigation.PushAsync(new SearchBookPage());
            }
        }
        public void RemoveBook(Book book)
        {
            BookList.Remove(book);
        }

        async void OnViewListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new BookDetailsPage()
                {
                    BindingContext = e.SelectedItem as Book
                });
                Debug.WriteLine("Navigating to book details page");
            }

        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewBookMain()));
            await Navigation.PushAsync(new NewBookSearch());
        }

        async void SearchItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewBookMain()));
            await Navigation.PushAsync(new SearchBookPage());
        }

        async void ScanItem_ClickedAsync(object sender, EventArgs e)
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)
            {
                Debug.WriteLine("Scanned Barcode: " + result.Text);
                var book = app.Database.GetBookByBarcode(result.Text);
                if (book != null)
                {
                    await Task.Delay(300);
                    await Navigation.PushAsync(new BookDetailsPage()
                    {
                        Book = book
                    });
                }
                else
                {
                    if (await DisplayAlert("Not Found!", "Книга с ISBN " + result.Text + " не найдена. Добавить эту книгу в библиотеку?", "Yes", "No"))
                    {
                        await Navigation.PushAsync(new NewBookEdit()
                        {
                            ISBN = result.Text
                        });
                    }
                }
            }
        }
    }
}
