using System;
using System.Collections.Generic;
using App1.Model;
using Xamarin.Forms;

namespace App1
{
    public partial class AddRecipePage : ContentPage
    {
        private Category _category;

        public AddRecipePage(Category category)
        {
            _category = category;
            InitializeComponent();
            lblCategory.Text = $"W kategorii: {_category.Name}";
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var recipe = new Recipe()
            {
                Title = entryName.Text,
                Ingredients = entryIngredients.Text,
                Description = editorDescription.Text,
                DateCreated = DateTime.Now,
                CategoryId = _category.Id
            };

            await App.LocalDB.SaveItemAsync(recipe);

            await DisplayAlert("Sukces", "Dane zapisane", "OK");

            await Navigation.PopAsync();
        }
    }
}
