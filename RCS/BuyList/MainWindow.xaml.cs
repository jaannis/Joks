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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BuyList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> BuyItemsList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            BuyListItemName.Text = "Lūdzu ievadiet pirkumu";

            //pasakam BuyItemsControl, ka ir jāizmanto mūsu saraksts,
            //kā rādāmo lietu avots (jāskatās no saraksta, ko rādīt)
            this.BuyItemListControl.ItemsSource = this.BuyItemsList;
            
        }

        private void AddListItemButton_Click(object sender, RoutedEventArgs e)
        {
            //izvelkam vērtību no teksta lauka
           string enteredItemToBuy =  this.BuyListItemName.Text;

            //nodzēšam vertību teksta laukā
           this.BuyListItemName.Text = "";

            //ierakstam iegūto vētību teksta blokā
            this.BuyItemsList.Add(enteredItemToBuy);
        }
    }
}
