namespace HotelManagementSystem;


    class Room
    {
        // Represents a hotel room and stores its number, type, price, and availability.

        public int RoomNumber { get; set; }
        public string RoomType { get; set; } = "";
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        public Room(int roomNumber, string roomType, double pricePerNight, bool isAvailable)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
        }

        public void DisplayRoom()
        {
            Console.WriteLine($"Room Number: {RoomNumber}");
            Console.WriteLine($"Room Type: {RoomType}");
            Console.WriteLine($"Price Per Night: {PricePerNight:F2}");

            if (IsAvailable)
            {
                Console.WriteLine("Status: Available");
            }
            else
            {
                Console.WriteLine("Status: Booked");
            }
        }
    }

    class Guest
    { 
        // Represents a hotel guest and stores booking details and total stay cost.

        public string GuestId { get; set; } = "";
        public string GuestName { get; set; } = "";
        public string RoomNumber { get; set; } = "Not Assigned";
        public string CheckInDate { get; set; } = "";
        public int TotalNights { get; set; }
        public double PricePerNight { get; set; }

        public Guest(
            string guestId,
            string guestName,
            string roomNumber,
            string checkInDate,
            int totalNights
        )
        {
            GuestId = guestId;
            GuestName = guestName;
            RoomNumber = roomNumber;
            CheckInDate = checkInDate;
            TotalNights = totalNights;
        }

        public void DisplayGuest()
        {
            Console.WriteLine($"Guest ID: {GuestId}");
            Console.WriteLine($"Guest Name: {GuestName}");
            Console.WriteLine($"Room Number: {RoomNumber}");
            Console.WriteLine($"Check-In Date: {CheckInDate}");
            Console.WriteLine($"Total Nights: {TotalNights}");
        }

        public double CalculateTotalCost()
        {
            return PricePerNight * TotalNights;
        }
    }

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
