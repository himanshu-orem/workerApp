﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker_7ERFAcraft.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker_7ERFAcraft.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        public ListView ListView { get { return listView; } }
        public static ListView listView;
        public MenuPage ()
		{
			InitializeComponent ();
            Icon = "hamburger_white.png";
            Title = Resx.AppResources.Home;
            BindingContext = new MenuViewModel(Navigation);
            listView = lstVieMenu;

            var lng = App.Database.GetLng();
            if (lng != null && !string.IsNullOrEmpty(lng.Language))
            {
                if (lng.Language == Models.CultureLanguage.Arabic || lng.Language == Models.CultureLanguage.Urdu)
                {
                    this.FlowDirection = FlowDirection.RightToLeft;
                }
                else
                {
                    this.FlowDirection = FlowDirection.LeftToRight;
                }
            }
            else
            {
                this.FlowDirection = FlowDirection.LeftToRight;
            }

        }

        private void lstVieMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lstVieMenu.SelectedItem = null;
        }
    }
}