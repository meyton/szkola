using System;
using System.Collections.Generic;
using App1.Model;
using App1.ViewModel;
using Xamarin.Forms;

namespace App1
{
    public partial class RecipesPage : ContentPage
    {
        private Category _category;

        public RecipesPage(Category category)
        {
            _category = category;
            InitializeComponent();
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            //await Navigation.PushAsync(new AddRecipePage(_category));
            await Utils.NavigationService.Push(new View.RecipeDetailsPage(new RecipeViewModel(_category.Id)));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var recipes = await App.LocalDB.GetRecipesByCategoryId(_category.Id);
            lvRecipes.ItemsSource = recipes;
            lvRecipes.ItemTapped += LvRecipes_ItemTapped;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            lvRecipes.ItemTapped -= LvRecipes_ItemTapped;
        }

        private async void LvRecipes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var recipe = (Recipe) e.Item;
            //await Navigation.PushAsync(new RecipeDetailsPage(recipe));
            await Utils.NavigationService.Push(new View.RecipeDetailsPage(new RecipeViewModel(recipe)));
        }
    }
}
