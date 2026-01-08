using CommunityToolkit.Mvvm.ComponentModel;
using HotelApp.Models;

namespace HotelApp.ViewModels
{
    public partial class RoomViewModel : ObservableObject
    {
        private Room _room;

        [ObservableProperty]
        private bool _isOccupied;

        [ObservableProperty]
        private bool _needsCleaning;

        public string RoomNumber => _room.RoomNumber;
        public string RoomType => _room.RoomType;
        public double DailyRate => _room.DailyRate;
        public bool CanBeReserved => !IsOccupied && !NeedsCleaning;

        public RoomViewModel(Room room)
        {
            _room = room;
            IsOccupied = room.IsOccupied;
            NeedsCleaning = room.NeedsCleaning;
        }

        partial void OnIsOccupiedChanged(bool value)
        {
            _room.IsOccupied = value;
        }

        partial void OnNeedsCleaningChanged(bool value)
        {
            _room.NeedsCleaning = value;
            OnPropertyChanged(nameof(CanBeReserved));
        }
    }
}