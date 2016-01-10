using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private MenuItem _addItem; 
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;
            this.OnPropertyChanged("MenuItems");

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                         
            };
            this.OnPropertyChanged("CurrentlySelectedMenuItems");
        }
        public List<MenuItem> MenuItems
        {
            get;
            set;
        }
        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get;
            set; 
        }
        public OrderViewModel(MenuItem addItem)
            {
            _addItem = addItem;
            AddMenuItemCommand = new DelegateCommand(AddMenuItem);
            SubmitOrderCommand = new DelegateCommand(SaveOrder);
            }

        private void AddMenuItem(object parameter)
        {       
            CurrentlySelectedMenuItems.Add((MenuItem)parameter);
            this.OnPropertyChanged("CurrentlySelectedMenuItems");
        }
        private void SaveOrder(object parameter)
        {
            Order curOrder = new Order();
            curOrder.Complete = false;
            curOrder.Expedite = false;
            curOrder.SpecialRequests = string.Empty;
            curOrder.Table = base.Repository.Tables[0];
            List<MenuItem> orderList = new List<MenuItem>();
            foreach (var  mItem in this.CurrentlySelectedMenuItems)
                {
                orderList.Add((MenuItem)mItem);
                }
            curOrder.Items = orderList;
            base.Repository.Orders.Add(curOrder);
        }
        public ICommand AddMenuItemCommand { get; private set; }
        public ICommand SubmitOrderCommand { get; private set; }
    }
}
