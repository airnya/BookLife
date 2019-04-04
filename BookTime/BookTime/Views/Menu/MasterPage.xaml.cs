using BookTime.Models;
using BookTime.Views.DetailsViews;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookTime.Views.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> items;

        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("Книги", "icon.png", "", Color.WhiteSmoke, typeof(HomePage)));
            items.Add(new MasterMenuItem("Категории", "category.png", "", Color.WhiteSmoke, typeof(CategoryPage)));
            items.Add(new MasterMenuItem("Добавить книгу", "category.png", "ТЗ вариант", Color.WhiteSmoke, typeof(NewBookMain)));
            ListView.ItemsSource = items;
        }
    }
}