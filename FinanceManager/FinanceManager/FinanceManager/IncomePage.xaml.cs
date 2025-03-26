using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceManager
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncomePage : ContentPage
	{
		public IncomePage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
			ShowIncomeCategory();
        }

		public void ShowIncomeCategory()
		{
            incomeCategoryCollection.ItemsSource = App.IncomeCategory.GetIncomeCategory();
        }

        public async void OnAddIncomeClicked(object sender, EventArgs e)
        {
			var frame = (Frame)sender;
			await frame.ScaleTo(0.95, 100);
			await frame.ScaleTo(1,100);

			var popup = new AddCateforyIncomePopup();
			await Navigation.PushModalAsync(new NavigationPage(popup)
			{
				BarBackgroundColor = Color.Transparent,
				BarTextColor = Color.Transparent,
			});
        }
    };

	
}