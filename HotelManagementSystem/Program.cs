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
            // Creates the room and guest lists and adds the six starting rooms required by the task.

            List<Room> rooms = new List<Room>();
            List<Guest> guests = new List<Guest>();

            rooms.Add(new Room(101, "Single", 25.00, true));
            rooms.Add(new Room(102, "Single", 30.00, true));
            rooms.Add(new Room(201, "Double", 45.00, true));
            rooms.Add(new Room(202, "Double", 50.00, true));
            rooms.Add(new Room(301, "Suite", 80.00, true));
            rooms.Add(new Room(302, "Suite", 95.00, true));

            // Displays the main menu repeatedly until the user chooses Exit.

            bool exitApp = false;

            while (!exitApp)
            {
                Console.WriteLine("\n================================================");
                Console.WriteLine("GRAND VISTA HOTEL - MANAGEMENT SYSTEM");
                Console.WriteLine("================================================");
                Console.WriteLine("1. Add New Room");
                Console.WriteLine("2. Register New Guest");
                Console.WriteLine("3. Book a Room for a Guest");
                Console.WriteLine("4. View All Rooms");
                Console.WriteLine("5. View All Guests");
                Console.WriteLine("6. Search and Filter Rooms");
                Console.WriteLine("7. Guest and Booking Statistics");
                Console.WriteLine("8. Update Room Price");
                Console.WriteLine("9. Guest Lookup by Name");
                Console.WriteLine("10. Room Type Breakdown Report");
                Console.WriteLine("11. Check Out a Guest");
                Console.WriteLine("12. Remove Unavailable Rooms");
                Console.WriteLine("13. Extend Guest Stay");
                Console.WriteLine("14. Highest Revenue Booking");
                Console.WriteLine("15. Guest Pagination Viewer");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");


                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        break;

                    case 10:
                        break;

                    case 11:
                        break;

                    case 12:
                        break;

                    case 13:
                        break;

                    case 14:
                        break;

                    case 15:
                        break;

                    case 0:
                        exitApp = true;
                        Console.WriteLine("Thank you. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose from 0 to 15.");
                        break;
                }
            }
        }
    }
   

   

        
 
