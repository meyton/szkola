using System;
using System.Threading.Tasks;
using App1.Model;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class RecipeViewModel : BaseViewModel
    {
        public Recipe Recipe 
        { 
            get => _recipe; 
            set
            {
                if (_recipe != value)
                {
                    _recipe = value;
                    RaisePropertyChanged(nameof(Recipe));
                    RaisePropertyChanged(nameof(PageTitle));
                }
            }
        }

        public Command SaveCommand { get; private set; }
        public Command DeleteCommand { get; private set; }

        public string PageTitle 
        { 
            get => Recipe.Id == 0
                        ? $"Dodajesz przepis: {Recipe.Title}"
                             : $"Edytujesz przepis z dnia {Recipe.DateCreated}"; 
        }

        public bool IsDeleteVisible { get => Recipe.Id != 0; }
        private Recipe _recipe;

        public RecipeViewModel(int categoryId)
        {
            Recipe = new Recipe
            {
                CategoryId = categoryId
            };

            SaveCommand = new Command(async () => await HandleAction());
        }

        public RecipeViewModel(Recipe recipe)
        {
            Recipe = recipe;
            SaveCommand = new Command(async () => await HandleAction(false));
            DeleteCommand = new Command(async () => await DeleteAction());
        }

        private async Task HandleAction(bool shouldSetDate = true)
        {
            if (shouldSetDate)
                Recipe.DateCreated = DateTime.Now;
            
            await App.LocalDB.SaveItemAsync(Recipe);
        }

        private async Task DeleteAction()
        {
            if (await Utils.UINotificationService.DisplayQuestion("Czy na pewno?", "Czy chcesz usunąć przepis?"))
            {
                await App.LocalDB.DeleteItemAsync(Recipe);
                await Utils.NavigationService.Pop();
            }
        }
    }
}
