using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using RestaurantManager.Models;
using RestaurantManager.ViewModels;
namespace RestaurantManager.UniversalWindows
{
    public sealed partial class OrderPage : Page
    {
        MenuItem toSendItem = new MenuItem();
       
        public OrderPage()
        {
            this.InitializeComponent();
            this.DataContext = new OrderViewModel(toSendItem);

        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnAddToOrder_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (this.lstMenu.SelectedItem != null) 
                {
                var selItem = this.lstMenu.SelectedItem;
                bool selExist = false;
                foreach (var selCur in lstCSelItems.Items)
                {
                    if (selItem.Equals(selCur))
                    {
                        selExist = true;
                        break; }
                }
                if (!selExist)
                {
                    toSendItem = (MenuItem)selItem;
                    var viewModel = (OrderViewModel)DataContext;
                    if ((viewModel != null) && (viewModel.AddMenuItemCommand.CanExecute(null)))
                    {
                        viewModel.AddMenuItemCommand.Execute(toSendItem);
                    }

                }
            }
        }
    }
}
