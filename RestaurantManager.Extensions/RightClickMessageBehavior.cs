﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;



namespace RestaurantManager.Extensions
{
    public class RightClickMessageBehavior : DependencyObject, IBehavior
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject is Page)
            {
                this.AssociatedObject = associatedObject;
                (this.AssociatedObject as Page).RightTapped += Page_RightTapped;
            }
        }

        public void Detach()
        {
            if (this.AssociatedObject != null && this.AssociatedObject is Page)
            {
                this.AssociatedObject = null;
                (this.AssociatedObject as Page).RightTapped -= Page_RightTapped;
            }
        }

        private async void Page_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
           await new MessageDialog(this.Message, Title).ShowAsync();
        }

    }
}
