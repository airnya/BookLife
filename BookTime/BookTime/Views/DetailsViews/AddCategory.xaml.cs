using BookTime.Models;
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
	public partial class AddCategory : ContentPage
    {
        App app = (App)Application.Current;
        Category category;

        public AddCategory()
        {
            NavigationPage.SetHasBackButton(this, true);
            Title = "Add Category";
            InitializeComponent();
        }

        public Category Category
        {
            set
            {
                category = value;
                BindingContext = value;
            }
            get { return category; }
        }

        async void adddata(object s, EventArgs args)
        {
            var category = new Category();
            category.CategoryName = category_name.Text;
            category.CategoryImagePath = img_url.Text;

            //           book.owner_id = (int)App.Current.Properties["userId"];


            app.Database.AddCategory(category);
            await DisplayAlert("Data Saved!", "New category '" + category_name.Text + "' has been added to your library!", "OK");
            await Navigation.PopAsync();

        }
        async void cancel(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        async void addimage(object sender, EventArgs args)
        {
            await DisplayAlert("Image!", "New image will be added", "OK");
        }

        async public void removecategory(object s, EventArgs args)
        {
            if (await DisplayAlert("Remove category", "Are you sure want to remove this category from the library?", "Yes", "No"))
            {
                var categoryItem = (Category)BindingContext;
                app.Database.DeleteCategory(categoryItem.Id);
                await Navigation.PopAsync();
            }
        }
    }
}
