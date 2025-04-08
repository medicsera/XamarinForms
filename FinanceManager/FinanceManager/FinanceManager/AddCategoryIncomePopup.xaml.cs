using System;
using Xamarin.Forms;

namespace FinanceManager.Views.Popups
{
    public partial class AddCategoryIncomePopup : ContentPage
    {
        private readonly Action<string> _onCategoryAdded;

        public AddCategoryIncomePopup(Action<string> onCategoryAdded)
        {
            InitializeComponent(); // Добавьте это для XAML-страницы
            _onCategoryAdded = onCategoryAdded;
        }

        // Обработчик кнопки "Добавить" (будет связан через XAML)
        private void OnAddClicked(object sender, EventArgs e)
        {
            string categoryName = CategoryNameEntry.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                _onCategoryAdded?.Invoke(categoryName);
                Navigation.PopModalAsync();
            }
        }

        // Обработчик кнопки "Отмена"
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}