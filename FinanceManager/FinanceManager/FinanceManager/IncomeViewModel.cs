using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;

namespace FinanceManager.ViewModels
{
    public class IncomeViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseRepository _repository;

        private ObservableCollection<IncomeCategoryDB> _categories;
        public ObservableCollection<IncomeCategoryDB> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCategoryCommand { get; }
        public ICommand LoadCategoriesCommand { get; }
        public ICommand DeleteCategoryCommand { get; }



        

        public IncomeViewModel(string dbPath)
        {
            _repository = new DatabaseRepository(dbPath);
            AddCategoryCommand = new Command<string>(async (categoryName) => await AddNewCategory(categoryName));
            LoadCategoriesCommand = new Command(async () => await LoadCategories());
            DeleteCategoryCommand = new Command<IncomeCategoryDB>(async (category) => await DeleteCategory(category));

            Categories = new ObservableCollection<IncomeCategoryDB>();
        }

        public async Task LoadCategories()
        {
            var categories = await _repository.GetIncomeCategoriesAsync();
            Categories.Clear();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }

        public async Task AddNewCategory(string categoryName)
        {
            try
            {
                var newCategory = new IncomeCategoryDB
                {
                    income_category = categoryName,
                    CreatedDate = DateTime.Now
                };

                await _repository.AddIncomeCategoryAsync(newCategory);
                Categories.Insert(0, newCategory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении категории: {ex.Message}");
            }
        }

        private async Task DeleteCategory(IncomeCategoryDB category)
        {
            if (category == null) return;

            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Удаление категории",
                $"Вы уверены, что хотите удалить категорию \"{category.income_category}\"?",
                "Удалить",
                "Отмена");

            if (confirm)
            {
                await _repository.DeleteIncomeCategoryAsync(category);
                Categories.Remove(category);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}