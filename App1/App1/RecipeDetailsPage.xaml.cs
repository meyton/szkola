using System;
using System.Collections.Generic;
using App1.Model;
using Xamarin.Forms;

namespace App1
{
    public partial class RecipeDetailsPage : ContentPage
    {
        private Recipe _recipe;
        private Entry entryTitle;
        private Label entryIngredients;
        private Editor editorDescription;

        public RecipeDetailsPage(Recipe recipe)
        {
            _recipe = recipe;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var stackLayout = new StackLayout()
            {
                Margin = 10,
                Spacing = 20,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            entryTitle = new Entry()
            {
                Text = _recipe.Title,
                FontSize = 20.0
            };

            stackLayout.Children.Add(entryTitle);

            entryIngredients = new Label()
            {
                Text = _recipe.Ingredients
            };

            stackLayout.Children.Add(entryIngredients);

            editorDescription = new Editor()
            {
                Text = _recipe.Description,
                BackgroundColor = Color.LightGray
            };
            stackLayout.Children.Add(editorDescription);

            var anotherStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };
            anotherStack.Children.Add(new Label()
            {
                Text = "Data dodania: "
            });
            anotherStack.Children.Add(new Label()
            {
                Text = _recipe.DateCreated.ToShortDateString(),
                FontAttributes = FontAttributes.Bold
            });

            stackLayout.Children.Add(anotherStack);

            var btn = new Button()
            {
                Text = "Zapisz zmiany"
            };
            btn.Clicked += BtnSave_Clicked;

            stackLayout.Children.Add(btn);

            var btn2 = new Button()
            {
                Text = "Usuń przepis"
            };
            btn2.Clicked += BtnDelete_Clicked;

            stackLayout.Children.Add(btn2);
            Content = stackLayout;
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            _recipe.Title = entryTitle.Text;
            _recipe.Description = editorDescription.Text;
            _recipe.Ingredients = entryIngredients.Text;

            await App.LocalDB.SaveItemAsync(_recipe);
            await DisplayAlert("Sukces", "Dane zostały zapisane", "OK");
            await Navigation.PopAsync();
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("UWAGA", "Czy na pewno chcesz usunąć przepis?", "TAK", "NIE"))
            {
                await App.LocalDB.DeleteItemAsync(_recipe);
                await DisplayAlert("Sukces", "Usunięto", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("OK", "Nie usuwam", "OK");
            }
        }
    }
}
