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
    using System.Collections.ObjectModel;
    using System.IO;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> BuyItemsList = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();

            this.BuyListItemName.Text = "";

            //Ielādē staffu atveroties
            var AllItemsFromFile = System.IO.File.ReadAllLines(@"C:\mans_fails\hehehe.txt");

            //sadala staffu no viena veseluma pa vienam
            BuyItemListControl.ItemsSource = BuyItemsList;
            foreach (var ItemFromFile in AllItemsFromFile)
            {
                this.BuyItemsList.Add(ItemFromFile);
            }




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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveAllTodos();
        }

        public void SaveAllTodos()
        {
            File.WriteAllLines(@"C:\mans_fails\hehehe.txt", this.BuyItemsList);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var todosFromFile = File.ReadAllLines(@"C:\mans_fails\hehehe.txt");

            for (int i = 0; i < todosFromFile.Length; i++)
            {
                string currentTodo = todosFromFile[i];
                this.BuyItemsList.Add(currentTodo);
            }

            MessageBox.Show("All items have been loaded");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedItems = this.BuyItemListControl.SelectedItems;

            for (int i = 0; i < selectedItems.Count; i++)
            {
                var selectedItem = selectedItems[i] as string;
                this.BuyItemsList.Remove(selectedItem);
            }
        }

        private void MainWindow_OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.SaveAllTodos();
        }

        private void BuyListItemName_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.BuyItemsList.Add(this.BuyListItemName.Text);

                //Nodzēš veco tekstu
                this.BuyListItemName.Text = "";
            }
        }
    }
    
}
