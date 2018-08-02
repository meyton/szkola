using System;
using System.Collections.Generic;
using App1.ViewModel;
using Xamarin.Forms;

namespace App1.View
{
    public partial class RecipeDetailsPage : ContentPage
    {
        public RecipeDetailsPage(RecipeViewModel recipeViewModel)
        {
            InitializeComponent();
            BindingContext = recipeViewModel;
        }
    }
}
