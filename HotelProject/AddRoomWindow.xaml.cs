using System.Windows;
using System.Windows.Controls;
using HotelApp.Models;

namespace HotelApp.Views
{
    public partial class AddRoomWindow : Window
    {
        public Room NewRoom { get; private set; }

        public AddRoomWindow()
        {
            InitializeComponent();
        }

        private void CmbRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbRoomType.SelectedItem is ComboBoxItem selectedItem)
            {
                string type = selectedItem.Content.ToString();
                switch (type)
                {
                    case "Standard":
                        TxtDailyRate.Text = "50";
                        break;
                    case "Suite":
                        TxtDailyRate.Text = "100";
                        break;
                    case "King":
                        TxtDailyRate.Text = "200";
                        break;
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtRoomNumber.Text) || CmbRoomType.SelectedItem == null)
            {
                MessageBox.Show("Please enter a room number and select a type.");
                return;
            }

            string selectedType = (CmbRoomType.SelectedItem as ComboBoxItem).Content.ToString();
            double rate = double.Parse(TxtDailyRate.Text);

            NewRoom = new Room(TxtRoomNumber.Text, selectedType, rate);
            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}