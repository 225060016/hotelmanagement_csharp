using System.Windows;
using HotelApp.ViewModels;
using HotelApp.Views;

namespace HotelApp
{
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel => (MainViewModel)this.DataContext;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void BtnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            AddRoomWindow addWindow = new AddRoomWindow();
            addWindow.Owner = this;
            if (addWindow.ShowDialog() == true)
            {
                ViewModel.AddNewRoom(addWindow.NewRoom);
            }
        }

        private void BtnReserve_Click(object sender, RoutedEventArgs e)
        {
            var selectedRoom = RoomGrid.SelectedItem as RoomViewModel;
            if (selectedRoom == null || !selectedRoom.CanBeReserved)
            {
                MessageBox.Show("Please select a valid and clean room.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtGuestName.Text))
            {
                MessageBox.Show("Please enter guest name.");
                return;
            }
            ViewModel.CreateNewBooking(TxtGuestName.Text, selectedRoom);
            TxtGuestName.Clear();
        }

        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            var selectedBooking = BookingGrid.SelectedItem as BookingViewModel;
            if (selectedBooking == null || selectedBooking.IsCompleted) return;
            ViewModel.CompleteBooking(selectedBooking);
            MessageBox.Show($"Checkout completed. Total Fee: {selectedBooking.TotalFee} $");
        }

        private void BtnClean_Click(object sender, RoutedEventArgs e)
        {
            var selectedRoom = RoomGrid.SelectedItem as RoomViewModel;
            if (selectedRoom != null && selectedRoom.NeedsCleaning)
            {
                ViewModel.CleanRoom(selectedRoom);
            }
        }
    }
}