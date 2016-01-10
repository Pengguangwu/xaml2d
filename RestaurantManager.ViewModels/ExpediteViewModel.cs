using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            
         this.OrderItems = base.Repository.Orders;
            this.OnPropertyChanged("OrderItems");
        }

        public List<Order> OrderItems
        {
            get;
            set;
        }
        
    }
}
