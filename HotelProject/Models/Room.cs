namespace HotelApp.Models
{
    public class Room
    {
        public string RoomNumber { get; init; }
        public string RoomType { get; set; }
        public double DailyRate { get; set; } 
        public bool IsOccupied { get; set; }
        public bool NeedsCleaning { get; set; }

        public Room(string roomNo, string type, double rate)
        {
            RoomNumber = roomNo;
            RoomType = type;
            DailyRate = rate;
            IsOccupied = false;
            NeedsCleaning = false;
        }
    }
}