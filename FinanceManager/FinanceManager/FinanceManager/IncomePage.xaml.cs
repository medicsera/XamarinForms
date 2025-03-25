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

        public void OnAddIncomeClicked(object sender, EventArgs e)
        {
            DisplayAlert("Добавление", "Открыта форма добавления дохода", "OK");
        }
    };

	
}