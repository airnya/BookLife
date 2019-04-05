using BookTime.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookTime.Views.DetailsViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryPage : ContentPage
    {
        App app = (App)Application.Current;
        ObservableCollection<Category> CategoryList;

        public CategoryPage()
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
            CategoryList = new ObservableCollection<Category>(app.Database.GetCategories().ToList());
            CategoryListHome.ItemsSource = CategoryList;
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
        public void RemoveBook(Category name)
        {
            CategoryList.Remove(name);
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewBookMain()));
            await Navigation.PushAsync(new AddCategory());
        }

        async void SearchItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewBookMain()));
            await Navigation.PushAsync(new SearchBookPage());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddCategory()
                {
                    BindingContext = e.SelectedItem as Category
                });
                Debug.WriteLine("Navigating to book details page");
            }

        }

        private void OnDeleteClickedAsync(object sender, EventArgs e)
        {
            //var itemsender = (ImageButton)sender;
            //var item = (Category)itemsender?.CommandParameter;
            //// it would be much cleaner to keep a ref to your VM in your page
            //// rather than continually casting it from BindingContext
            //app.Database.DeleteCategory(item.Id);
        }
    }
}
