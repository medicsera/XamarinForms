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
        private List<ChartEntry> income = new List<ChartEntry>();
        private List<ChartEntry> expenses = new List<ChartEntry>();

        public HomePage ()
		{
			InitializeComponent ();
        }

		public void addNewEntry(int value, string date, string value_label)
		{
            income.Add( new ChartEntry(value) { Label = date, ValueLabel = value_label, Color = SKColor.Parse("#0EF316"),ValueLabelColor = SKColor.Parse("#FFFFFF")  });

            updateEntry();
		}

        public void addNewExepenses(int value, string date, string value_label)
        {
            expenses.Add(new ChartEntry(value) { Label = date, ValueLabel = value_label, Color = SKColor.Parse("#0EF316"), ValueLabelColor = SKColor.Parse("#FFFFFF") });

            updateExpenses();
        }

        private void updateEntry()
        {
            linechart_income.Chart = new LineChart
            {
                Entries = income,
                LineMode = LineMode.Spline,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
                LineSize = 20,
                PointMode = PointMode.Circle,
                PointSize = 40,
                LabelTextSize = 55,
                BackgroundColor = SKColor.Parse("#4968FF"),
                LabelColor = SKColor.Parse("#FFFFFF"),
                LineAreaAlpha = 0,
                Margin = 30
            };
        }

        private void updateExpenses()
        {
            linechart_expenses.Chart = new LineChart
            {
                Entries = expenses,
                LineMode = LineMode.Spline,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
                LineSize = 20,
                PointMode = PointMode.Circle,
                PointSize = 40,
                LabelTextSize = 55,
                BackgroundColor = SKColor.Parse("#4968FF"),
                LabelColor = SKColor.Parse("#FFFFFF"),
                LineAreaAlpha = 0,
                Margin = 30
            };
        }

        protected override void OnAppearing()
        {
			base.OnAppearing();
            income = new List<ChartEntry>
            {
				new ChartEntry(20000) { Label = "23.03.25", ValueLabel = "20000", Color = SKColor.Parse("#0EF316"), ValueLabelColor = SKColor.Parse("#FFFFFF") },
				new ChartEntry(15000) { Label = "10.03.25", ValueLabel = "15000", Color = SKColor.Parse("#0EF316"), ValueLabelColor = SKColor.Parse("#FFFFFF")},
            };
            addNewEntry(5000, "25.02.25", "5000");

            expenses = new List<ChartEntry>
            {
                new ChartEntry(1000) { Label = "23.03.25", ValueLabel = "1000", Color = SKColor.Parse("#0EF316"), ValueLabelColor = SKColor.Parse("#FFFFFF") },
                new ChartEntry(2000) { Label = "10.03.25", ValueLabel = "2000", Color = SKColor.Parse("#0EF316"), ValueLabelColor = SKColor.Parse("#FFFFFF")},
            };
            addNewExepenses(500, "18.03.25", "500");
        }


    }
}