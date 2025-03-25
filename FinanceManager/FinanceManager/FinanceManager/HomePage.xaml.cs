using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceManager
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{

		


        public HomePage ()
		{
			InitializeComponent ();
			


        }

		public void addNewEntry(int value, string date, string value_label)
		{
			
		}

        protected override void OnAppearing()
        {
			base.OnAppearing();
			
			{
				new ChartEntry(20000) { Label = "23.03.25", ValueLabel = "20000", Color = SKColor.Parse("#0EF316") },
				new ChartEntry(15000) { Label = "10.03.25", ValueLabel = "15000", Color = SKColor.Parse("#0EF316") },
            };
            linechart_income.Chart = new LineChart { 
				Entries = entries,
                LineMode = LineMode.Spline,
                LabelOrientation = Orientation.Horizontal,
				ValueLabelOrientation = Orientation.Horizontal,
                LineSize = 10,
                PointMode = PointMode.Circle,
                PointSize = 25,
                LabelTextSize = 50,
				BackgroundColor = SKColor.Parse("#4968FF"),
                LabelColor = SKColor.Parse("#FFFFFF")

            };
        }
    }
}