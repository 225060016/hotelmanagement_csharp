using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using HotelApp.Models;
using System;
using System.Linq;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;

namespace HotelApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<RoomViewModel> Rooms { get; set; }
        public ObservableCollection<BookingViewModel> Bookings { get; set; }
        public List<string> RoomTypes { get; } = new List<string> { "All", "Standard", "Suite", "King" };

        public ICollectionView RoomsView { get; }

        [ObservableProperty]
        private bool _showOnlyAvailable;

        [ObservableProperty]
        private string _selectedTypeFilter = "All";

        public MainViewModel()
        {
            Rooms = new ObservableCollection<RoomViewModel>();
            Bookings = new ObservableCollection<BookingViewModel>();

            RoomsView = CollectionViewSource.GetDefaultView(Rooms);
            RoomsView.Filter = FilterRooms;

            LoadSampleData();
        }

        private void LoadSampleData()
        {
            Rooms.Add(new RoomViewModel(new Room("101", "Standard", 50)));
            Rooms.Add(new RoomViewModel(new Room("102", "Suite", 100)));
            Rooms.Add(new RoomViewModel(new Room("103", "Standard", 50)));
            Rooms.Add(new RoomViewModel(new Room("201", "King", 200)));
        }

        private bool FilterRooms(object item)
        {
            if (item is RoomViewModel room)
            {
                bool matchesAvailable = !ShowOnlyAvailable || room.CanBeReserved;
                bool matchesType = SelectedTypeFilter == "All" || room.RoomType == SelectedTypeFilter;
                return matchesAvailable && matchesType;
            }
            return false;
        }

        partial void OnShowOnlyAvailableChanged(bool value) => RoomsView.Refresh();
        partial void OnSelectedTypeFilterChanged(string value) => RoomsView.Refresh();

        public void AddNewRoom(Room room)
        {
            Rooms.Add(new RoomViewModel(room));
            RoomsView.Refresh();
        }

        public void CreateNewBooking(string guestName, RoomViewModel selectedRoom)
        {
            if (selectedRoom != null && selectedRoom.CanBeReserved)
            {
                int newId = Bookings.Count + 1;
                var newBooking = new BookingViewModel(newId, guestName, selectedRoom, DateTime.Now);
                Bookings.Add(newBooking);
                RoomsView.Refresh();
            }
        }

        public void CleanRoom(RoomViewModel room)
        {
            if (room != null)
            {
                room.NeedsCleaning = false;
                RoomsView.Refresh();
            }
        }

        public void CompleteBooking(BookingViewModel booking)
        {
            if (booking != null && !booking.IsCompleted)
            {
                booking.FinalizeBooking(DateTime.Now);
                RoomsView.Refresh();
            }
        }
    }
}