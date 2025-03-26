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
	public partial class AddCateforyIncomePopup : ContentPage
	{
		public AddCateforyIncomePopup ()
		{
			InitializeComponent ();
		}

        private async void OnAddClicked(object sender, EventArgs e)
        {
			string category = income_category_name.Text.Trim();

			if (category.Length < 3)
			{
				await DisplayAlert("Error", "Длина минимум 3 символа", "Ok");
				return;
			}

			IncomeCategoryDB incomeCategory = new IncomeCategoryDB
			{
				income_category = category
			};

			App.IncomeCategory.SaveIncomeCategory(incomeCategory);
			

            income_category_name.Text = " ";
        }

		private async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
    }
}