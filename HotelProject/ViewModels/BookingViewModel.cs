using CommunityToolkit.Mvvm.ComponentModel;
using HotelApp.Models;
using System;

namespace HotelApp.ViewModels
{
    public partial class BookingViewModel : ObservableObject
    {
        protected Booking _booking;
        private RoomViewModel _assignedRoomVM;

        [ObservableProperty]                
        private bool _isCompleted;

        [ObservableProperty]
        private DateTime? _checkOutTime;

        [ObservableProperty]
        private double _totalFee;

        public int ReservationId => _booking.ReservationId;
        public string GuestName => _booking.GuestName;
        public string RoomNumber => _booking.AssignedRoomNumber;
        public DateTime CheckInDate => _booking.CheckInDate;

        public BookingViewModel(int id, string guest, RoomViewModel roomVM, DateTime date)
        {
            _booking = new Booking(id, guest, roomVM.RoomNumber, date);
            _assignedRoomVM = roomVM;
            _assignedRoomVM.IsOccupied = true;
            IsCompleted = false;
        }

        public void FinalizeBooking(DateTime checkOutDate)
        {
            if (!IsCompleted)
            {
                CheckOutTime = checkOutDate;

                TimeSpan stayDuration = checkOutDate - CheckInDate;
                int days = stayDuration.Days;
                if (days < 1) days = 1;

                TotalFee = days * _assignedRoomVM.DailyRate;
                _booking.TotalFee = TotalFee;

                _assignedRoomVM.IsOccupied = false;
                _assignedRoomVM.NeedsCleaning = true;

                IsCompleted = true;
            }
        }

        partial void OnIsCompletedChanged(bool value)
        {
            _booking.IsCompleted = value;
        }
    }
}