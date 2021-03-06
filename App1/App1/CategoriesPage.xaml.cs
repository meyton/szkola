﻿using System;
using System.Collections.Generic;
using App1.Model;
using Xamarin.Forms;

namespace App1
{
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();
        }

        private async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var category = (Category) e.Item;
            await Navigation.PushAsync(new RecipesPage(category));
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddClassPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lvCategories.ItemsSource = await App.LocalDB.GetItems<Category>();
        }
    }
}