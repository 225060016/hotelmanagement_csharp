using System;

namespace HotelApp.Models
{
    public class Booking
    {
        public int ReservationId { get; init; }
        public string GuestName { get; set; }
        public string AssignedRoomNumber { get; set; }
        public DateTime CheckInDate { get; set; }
        public bool IsCompleted { get; set; }
        public double TotalFee { get; set; }

        public Booking(int id, string guest, string roomNo, DateTime date)
        {
            ReservationId = id;
            GuestName = guest;
            AssignedRoomNumber = roomNo;
            CheckInDate = date;
            IsCompleted = false;
            TotalFee = 0;
        }
    }
}   