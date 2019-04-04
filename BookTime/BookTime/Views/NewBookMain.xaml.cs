using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookTime.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewBookMain : TabbedPage
    {
        public NewBookMain()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }
    }
}