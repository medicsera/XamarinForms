using System;
using FinanceManager.ViewModels;
using FinanceManager.Views.Popups;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomePage : ContentPage
    {
        private IncomeViewModel _viewModel;

        public IncomePage()
        {
            InitializeComponent();

            var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("finance.db3");
            _viewModel = new IncomeViewModel(dbPath);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadCategories();
        }

        private async void OnAddIncomeClicked(object sender, EventArgs e)
        {
            var frame = (Frame)sender;
            await frame.ScaleTo(0.95, 100);
            await frame.ScaleTo(1, 100);

            var popup = new AddCategoryIncomePopup(async (categoryName) =>
            {
                if (!string.IsNullOrWhiteSpace(categoryName))
                {
                    await _viewModel.AddNewCategory(categoryName);
                }
            });

            // Используем навигацию через Application.Current.MainPage
            await Application.Current.MainPage.Navigation.PushModalAsync(popup);
        }

      
    }
}