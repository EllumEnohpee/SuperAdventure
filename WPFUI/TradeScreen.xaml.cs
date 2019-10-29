using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Engine.Models;
using Engine.ViewModels;

namespace WPFUI
{
	/// <summary>
	/// Interaction logic for TradeScreen.xaml
	/// </summary>
	public partial class TradeScreen : Window
	{
		public GameSession Session => DataContext as GameSession;
		public TradeScreen()
		{
			InitializeComponent();
		}

		public void OnClick_Sell(object sender, RoutedEventArgs e)
		{
			GroupedInventoryItem groupedItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;
			if(groupedItem != null)
			{
				Session.CurrentPlayer.RemoveItemFromInventory(groupedItem.Item);
				Session.CurrentPlayer.Gold += groupedItem.Item.Price;
				Session.CurrentTrader.AddItemToInventory(groupedItem.Item);
			}
		}
		public void OnClick_Buy(object sender, RoutedEventArgs e)
		{
			GroupedInventoryItem groupedItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;
			if(Session.CurrentPlayer.Gold < groupedItem.Item.Price)
			{
				MessageBox.Show("You do not have enough gold!");
				return;
			}
			if(groupedItem != null)
			{
				Session.CurrentPlayer.AddItemToInventory(groupedItem.Item);
				Session.CurrentPlayer.Gold -= groupedItem.Item.Price;
				Session.CurrentTrader.RemoveItemFromInventory(groupedItem.Item);
			}
		}
		public void OnClick_CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
