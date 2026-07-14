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
                        // Adds a new room after validating the details and checking that the room number is unique.

                        Console.Write("Enter room number: ");

                        if (!int.TryParse(Console.ReadLine(), out int newRoomNumber) || newRoomNumber <= 0)
                        {
                            Console.WriteLine("Room number must be a positive number.");
                            break;
                        }

                        bool roomExists = rooms.Any(r => r.RoomNumber == newRoomNumber);

                        if (roomExists)
                        {
                            Console.WriteLine("A room with this number already exists.");
                            break;
                        }

                        Console.Write("Enter room type (Single / Double / Suite): ");
                        string newRoomType = Console.ReadLine();

                        if (newRoomType != "Single" &&
                            newRoomType != "Double" &&
                            newRoomType != "Suite")
                        {
                            Console.WriteLine("Invalid room type.");
                            break;
                        }

                        Console.Write("Enter price per night: ");

                        if (!double.TryParse(Console.ReadLine(), out double newRoomPrice) ||
                            newRoomPrice <= 0)
                        {
                            Console.WriteLine("Price must be a positive number.");
                            break;
                        }

                        Room newRoom = new Room(
                            newRoomNumber,
                            newRoomType,
                            newRoomPrice,
                            true
                        );

                        rooms.Add(newRoom);

                        Console.WriteLine("\nRoom added successfully.");
                        Console.WriteLine($"Room Number: {newRoom.RoomNumber}");
                        Console.WriteLine($"Room Type: {newRoom.RoomType}");
                        Console.WriteLine($"Price Per Night: {newRoom.PricePerNight:F2}");
                        Console.WriteLine("Status: Available");
                        Console.WriteLine($"Total Rooms: {rooms.Count()}");

                        break;

                    case 2:
                        // Registers a new guest, generates a unique guest ID, and leaves the room unassigned.

                        Console.Write("Enter guest name: ");
                        string guestName = Console.ReadLine();

                        if (guestName == null || guestName == "")
                        {
                            Console.WriteLine("Guest name cannot be empty.");
                            break;
                        }

                        Console.Write("Enter check-in date: ");
                        string checkInDate = Console.ReadLine();

                        if (checkInDate == null || checkInDate == "")
                        {
                            Console.WriteLine("Check-in date cannot be empty.");
                            break;
                        }

                        Console.Write("Enter number of nights: ");

                        if (!int.TryParse(Console.ReadLine(), out int totalNights) || totalNights <= 0)
                        {
                            Console.WriteLine("Number of nights must be a positive integer.");
                            break;
                        }

                        string guestId = "G" + (guests.Count() + 1).ToString("D3");

                        Guest newGuest = new Guest(
                            guestId,
                            guestName,
                            "Not Assigned",
                            checkInDate,
                            totalNights
                        );

                        guests.Add(newGuest);

                        Console.WriteLine("\nGuest registered successfully.");
                        Console.WriteLine($"Guest ID: {newGuest.GuestId}");
                        Console.WriteLine($"Guest Name: {newGuest.GuestName}");
                        Console.WriteLine($"Room Number: {newGuest.RoomNumber}");
                        Console.WriteLine($"Check-In Date: {newGuest.CheckInDate}");
                        Console.WriteLine($"Total Nights: {newGuest.TotalNights}");

                        break;

                    case 3:
                        // Books an available room for a registered guest using LINQ FirstOrDefault.

                        Console.Write("Enter guest ID: ");
                        string bookingGuestId = Console.ReadLine();

                        Guest? bookingGuest = guests.FirstOrDefault(g => g.GuestId == bookingGuestId);

                        if (bookingGuest == null)
                        {
                            Console.WriteLine("Guest not found.");
                            break;
                        }

                        Console.Write("Enter desired room number: ");

                        if (!int.TryParse(Console.ReadLine(), out int bookingRoomNumber))
                        {
                            Console.WriteLine("Invalid room number.");
                            break;
                        }

                        Room? bookingRoom = rooms.FirstOrDefault(r => r.RoomNumber == bookingRoomNumber);

                        if (bookingRoom == null)
                        {
                            Console.WriteLine("Room not found.");
                            break;
                        }

                        if (!bookingRoom.IsAvailable)
                        {
                            Console.WriteLine("Room is already booked.");
                            break;
                        }

                        bookingGuest.RoomNumber = bookingRoom.RoomNumber.ToString();
                        bookingGuest.PricePerNight = bookingRoom.PricePerNight;
                        bookingRoom.IsAvailable = false;

                        double bookingTotalCost = bookingGuest.CalculateTotalCost();

                        Console.WriteLine("\nBooking completed successfully.");
                        Console.WriteLine($"Guest Name: {bookingGuest.GuestName}");
                        Console.WriteLine($"Room Number: {bookingRoom.RoomNumber}");
                        Console.WriteLine($"Room Type: {bookingRoom.RoomType}");
                        Console.WriteLine($"Price Per Night: {bookingRoom.PricePerNight:F2}");
                        Console.WriteLine($"Total Nights: {bookingGuest.TotalNights}");
                        Console.WriteLine($"Total Cost: {bookingTotalCost:F2}");

                        break;

                    case 4:
                        // Displays all rooms sorted by room number without changing the original list.

                        if (rooms.Count() == 0)
                        {
                            Console.WriteLine("No rooms have been added yet.");
                            break;
                        }

                        Console.WriteLine($"\nTotal Rooms: {rooms.Count()}");

                        var sortedRooms = rooms
                            .OrderBy(r => r.RoomNumber)
                            .ToList();

                        foreach (Room room in sortedRooms)
                        {
                            Console.WriteLine("\n----------------------------");
                            room.DisplayRoom();
                        }

                        break;

                    case 5:
                        // Displays all registered guests sorted alphabetically by guest name.

                        if (guests.Count() == 0)
                        {
                            Console.WriteLine("No guests have been registered yet.");
                            break;
                        }

                        Console.WriteLine($"\nTotal Guests: {guests.Count()}");

                        var sortedGuests = guests
                            .OrderBy(g => g.GuestName)
                            .ToList();

                        foreach (Guest guest in sortedGuests)
                        {
                            Console.WriteLine("\n----------------------------");
                            guest.DisplayGuest();
                        }

                        break;

                    case 6:
                        // Displays a room search sub-menu and filters rooms using LINQ.
                        Console.WriteLine("\n--- Search and Filter Rooms ---");
                        Console.WriteLine("1. Show all available rooms");
                        Console.WriteLine("2. Filter by room type");
                        Console.WriteLine("3. Filter by maximum price");
                        Console.WriteLine("4. Room price statistics");
                        Console.WriteLine("0. Back");
                        Console.Write("Enter your choice: ");
                        
                        if (!int.TryParse(Console.ReadLine(), out int filterChoice))
                        {
                            Console.WriteLine("Invalid input.");
                            break;
                        }
                        
                        switch (filterChoice)
                        {
                            case 1:
                                var availableRooms = rooms
                                    .Where(r => r.IsAvailable)
                                    .OrderBy(r => r.PricePerNight)
                                    .ToList();

                                if (availableRooms.Count() == 0)
                                {
                                    Console.WriteLine("No rooms found for the selected criteria.");
                                    break;
                                }

                                Console.WriteLine($"Available Rooms: {availableRooms.Count()}");

                                foreach (Room room in availableRooms)
                                {
                                    Console.WriteLine(
                                        $"Room {room.RoomNumber} | " +
                                        $"{room.RoomType} | " +
                                        $"OMR {room.PricePerNight:F2}"
                                    );
                                }

                                break;
                            case 2:
                                Console.Write("Enter room type (Single / Double / Suite): ");
                                string searchRoomType = Console.ReadLine();

                                var roomsByType = rooms
                                    .Where(r => r.RoomType.ToLower() == searchRoomType.ToLower())
                                    .ToList();

                                if (roomsByType.Count() == 0)
                                {
                                    Console.WriteLine("No rooms found for the selected criteria.");
                                    break;
                                }

                                Console.WriteLine($"Rooms Found: {roomsByType.Count()}");

                                foreach (Room room in roomsByType)
                                {
                                    room.DisplayRoom();
                                    Console.WriteLine("----------------------------");
                                }

                                break;
                                case 3:
                                Console.Write("Enter maximum price: ");

                                if (!double.TryParse(Console.ReadLine(), out double maximumPrice) ||
                                    maximumPrice <= 0)
                                {
                                    Console.WriteLine("Maximum price must be a positive number.");
                                    break;
                                }
                                var roomsByPrice = rooms
                                    .Where(r => r.IsAvailable &&
                                                r.PricePerNight <= maximumPrice)
                                    .OrderBy(r => r.PricePerNight)
                                    .ToList();

                                if (roomsByPrice.Count() == 0)
                                {
                                    Console.WriteLine("No rooms found for the selected criteria.");
                                    break;
                                }

                                Console.WriteLine($"Rooms Found: {roomsByPrice.Count()}");

                                foreach (Room room in roomsByPrice)
                                {
                                    Console.WriteLine(
                                        $"Room {room.RoomNumber} | " +
                                        $"{room.RoomType} | " +
                                        $"OMR {room.PricePerNight:F2}"
                                    );
                                }
                                break;
                            case 4:
                                if (rooms.Count() == 0)
                                {
                                    Console.WriteLine("No rooms have been added yet.");
                                    break;
                                }

                                int totalRoomCount = rooms.Count();
                                int availableRoomCount = rooms.Count(r => r.IsAvailable);
                                double averageRoomPrice = rooms.Average(r => r.PricePerNight);
                                double cheapestRoomPrice = rooms.Min(r => r.PricePerNight);
                                double highestRoomPrice = rooms.Max(r => r.PricePerNight);

                                Console.WriteLine($"Total Rooms: {totalRoomCount}");
                                Console.WriteLine($"Available Rooms: {availableRoomCount}");
                                Console.WriteLine($"Average Price: OMR {averageRoomPrice:F2}");
                                Console.WriteLine($"Cheapest Price: OMR {cheapestRoomPrice:F2}");
                                Console.WriteLine($"Most Expensive Price: OMR {highestRoomPrice:F2}");

                                break;
                            case 0:
                                Console.WriteLine("Returning to the main menu.");
                                break;

                            default:
                                Console.WriteLine("Invalid option.");
                                break;
                        }

                        break;
                    
                    case 7:
                        // Displays booking, occupancy, and revenue statistics using LINQ.

                        int totalGuests = guests.Count();

                        int bookedGuestsCount = guests.Count(
                            g => g.RoomNumber != "Not Assigned"
                        );

                        int totalRoomsCount = rooms.Count();

                        int bookedRoomsCount = rooms.Count(
                            r => !r.IsAvailable
                        );

                        Console.WriteLine("\n--- Guest and Booking Statistics ---");
                        Console.WriteLine($"Total Registered Guests: {totalGuests}");
                        Console.WriteLine($"Guests With Active Bookings: {bookedGuestsCount}");
                        Console.WriteLine($"Total Rooms: {totalRoomsCount}");
                        Console.WriteLine($"Booked Rooms: {bookedRoomsCount}");

                        var bookedGuests = guests
                            .Where(g => g.RoomNumber != "Not Assigned")
                            .ToList();

                        if (!bookedGuests.Any())
                        {
                            Console.WriteLine("No active bookings recorded.");
                            break;
                        }

                        double averageNights = bookedGuests
                            .Average(g => g.TotalNights);

                        Console.WriteLine($"Average Number of Nights: {averageNights:F2}");

                        var topGuests = bookedGuests
                            .OrderByDescending(g => g.CalculateTotalCost())
                            .Take(3)
                            .ToList();

                        Console.WriteLine("\nTop 3 Highest-Spending Guests:");

                        foreach (Guest guest in topGuests)
                        {
                            Console.WriteLine(
                                $"{guest.GuestName} | " +
                                $"Room {guest.RoomNumber} | " +
                                $"OMR {guest.CalculateTotalCost():F2}"
                            );
                        }

                        var bookingSummaries = bookedGuests
                            .Select(g =>
                                $"{g.GuestName} — Room {g.RoomNumber} — " +
                                $"{g.TotalNights} nights — " +
                                $"OMR {g.CalculateTotalCost():F2}")
                            .ToList();

                        Console.WriteLine("\nActive Booking Summary:");

                        foreach (string summary in bookingSummaries)
                        {
                            Console.WriteLine(summary);
                        }

                        break;

                    case 8:
                        // Updates a room price after finding the room with FirstOrDefault.

                        Console.Write("Enter room number: ");

                        if (!int.TryParse(Console.ReadLine(), out int updateRoomNumber))
                        {
                            Console.WriteLine("Invalid room number.");
                            break;
                        }

                        Room? roomToUpdate = rooms.FirstOrDefault(r => r.RoomNumber == updateRoomNumber);

                        if (roomToUpdate == null)
                        {
                            Console.WriteLine("Room not found.");
                            break;
                        }

                        Console.Write("Enter new price per night: ");

                        if (!double.TryParse(Console.ReadLine(), out double newPrice) ||
                            newPrice <= 0)
                        {
                            Console.WriteLine("Price must be a positive number.");
                            break;
                        }

                        double oldPrice = roomToUpdate.PricePerNight;

                        roomToUpdate.PricePerNight = newPrice;

                        Console.WriteLine("\nRoom price updated successfully.");
                        Console.WriteLine($"Room Number: {roomToUpdate.RoomNumber}");
                        Console.WriteLine($"Old Price: OMR {oldPrice:F2}");
                        Console.WriteLine($"New Price: OMR {roomToUpdate.PricePerNight:F2}");

                        break;

                    case 9:
                        // Searches for guests by full or partial name using LINQ Where.

                        Console.Write("Enter guest name or part of the name: ");
                        string searchName = Console.ReadLine();

                        if (searchName == null || searchName == "")
                        {
                            Console.WriteLine("Search text cannot be empty.");
                            break;
                        }

                        var matchedGuests = guests
                            .Where(g => g.GuestName.ToLower().Contains(searchName.ToLower()))
                            .ToList();

                        if (matchedGuests.Count() == 0)
                        {
                            Console.WriteLine("No guests matched that search.");
                            break;
                        }

                        Console.WriteLine($"Guests Found: {matchedGuests.Count()}");

                        foreach (Guest guest in matchedGuests)
                        {
                            Console.WriteLine(
                                $"Guest ID: {guest.GuestId} | " +
                                $"Name: {guest.GuestName} | " +
                                $"Room: {guest.RoomNumber}"
                            );
                        }

                        break;

                    case 10:
                        // Displays room counts and average prices for each room type using LINQ.

                        if (rooms.Count() == 0)
                        {
                            Console.WriteLine("No rooms have been added yet.");
                            break;
                        }

                        string[] roomTypes = { "Single", "Double", "Suite" };

                        Console.WriteLine("\n--- Room Type Breakdown Report ---");

                        foreach (string roomType in roomTypes)
                        {
                            int typeCount = rooms.Count(
                                r => r.RoomType == roomType
                            );

                            Console.WriteLine($"\nRoom Type: {roomType}");
                            Console.WriteLine($"Total Rooms: {typeCount}");

                            if (typeCount == 0)
                            {
                                Console.WriteLine("Average Price: N/A");
                            }
                            else
                            {
                                double typeAveragePrice = rooms
                                    .Where(r => r.RoomType == roomType)
                                    .Average(r => r.PricePerNight);

                                Console.WriteLine($"Average Price: OMR {typeAveragePrice:F2}");
                            }
                        }

                        double overallAveragePrice = rooms
                            .Average(r => r.PricePerNight);

                        Console.WriteLine($"\nOverall Average Price: OMR {overallAveragePrice:F2}");

                        break;
                    
                   case 11:
                        // Checks out a guest, frees the room, removes the guest, and displays the final bill.

                        Console.Write("Enter guest ID to check out: ");
                        string checkoutGuestId = Console.ReadLine();

                        Guest checkoutGuest = guests.FirstOrDefault(
                            g => g.GuestId == checkoutGuestId
                        );

                        if (checkoutGuest == null)
                        {
                            Console.WriteLine("Guest not found.");
                            break;
                        }
                        if (checkoutGuest.RoomNumber == "Not Assigned")
                        {
                            Console.WriteLine("This guest has no active booking.");
                            break;
                        }
                        Room? checkoutRoom = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == checkoutGuest.RoomNumber);





                        if (checkoutRoom == null) 
                        { 
                            Console.WriteLine("The guest's room could not be found."); 
                            break; 
                        }
                        
                        Console.WriteLine("\n--- Final Bill ---"); 
                        Console.WriteLine($"Guest Name: {checkoutGuest.GuestName}"); 
                        Console.WriteLine($"Room Number: {checkoutRoom.RoomNumber}"); 
                        Console.WriteLine($"Room Type: {checkoutRoom.RoomType}"); 
                        Console.WriteLine($"Check-In Date: {checkoutGuest.CheckInDate}"); 
                        Console.WriteLine($"Total Nights: {checkoutGuest.TotalNights}"); 
                        Console.WriteLine($"Price Per Night: OMR {checkoutRoom.PricePerNight:F2}"); 
                        Console.WriteLine($"Total Cost: OMR {checkoutGuest.CalculateTotalCost():F2}");
                        Console.Write("Confirm checkout (Y/N): "); 
                        string checkoutConfirmation = Console.ReadLine();
                        if (checkoutConfirmation.ToUpper() != "Y") 
                        {
                            Console.WriteLine("Checkout cancelled. No changes were made.");
       
                            break; 
                        }
                        
                        checkoutRoom.IsAvailable = true; 
                        guests.Remove(checkoutGuest);

    
                        bool roomIsAvailable = rooms.Any(r => r.RoomNumber == checkoutRoom.RoomNumber && r.IsAvailable);

   
                        Console.WriteLine("\nCheckout completed successfully.");
                        Console.WriteLine($"Guest: {checkoutGuest.GuestName}"); 
                        Console.WriteLine($"Room {checkoutRoom.RoomNumber} is now available: {roomIsAvailable}"); 
                        Console.WriteLine($"Updated Guest Count: {guests.Count()}"); 
                        Console.WriteLine($"Updated Room Count: {rooms.Count()}");
                        
                        break;

                    case 12:
                        // Removes unavailable rooms only when no guest currently holds that room number.

                        var removableRooms = rooms
                            .Where(r =>
                                !r.IsAvailable &&
                                !guests.Any(g => g.RoomNumber == r.RoomNumber.ToString())
                            )
                            .OrderBy(r => r.RoomNumber)
                            .ToList();

                        if (!removableRooms.Any())
                        {
                            Console.WriteLine(
                                "All unavailable rooms are currently occupied. " +
                                "No rooms can be decommissioned."
                            );
                            break;
                        }

                        Console.WriteLine("\n--- Rooms Safe to Remove ---");

                        foreach (Room room in removableRooms)
                        {
                            Console.WriteLine(
                                $"Room {room.RoomNumber} | " +
                                $"{room.RoomType} | " +
                                $"OMR {room.PricePerNight:F2}"
                            );
                        }

                        Console.WriteLine($"\nRemovable Rooms: {removableRooms.Count()}");
                        Console.Write("Confirm removal (Y/N): ");

                        string removalConfirmation = Console.ReadLine();

                        if (removalConfirmation == null ||
                            removalConfirmation.ToUpper() != "Y")
                        {
                            Console.WriteLine("Removal cancelled. No rooms were removed.");
                            break;
                        }

                        int removedRoomsCount = rooms.RemoveAll(r =>
                            !r.IsAvailable &&
                            !guests.Any(g => g.RoomNumber == r.RoomNumber.ToString())
                        );

                        Console.WriteLine(
                            $"\n{removedRoomsCount} room(s) removed successfully."
                        );

                        Console.WriteLine($"Updated Total Rooms: {rooms.Count()}");

                        var remainingRooms = rooms
                            .OrderBy(r => r.RoomNumber)
                            .Select(r => $"Room {r.RoomNumber} | {r.RoomType}")
                            .ToList();

                        Console.WriteLine("\n--- Remaining Rooms ---");

                        foreach (string roomDetails in remainingRooms)
                        {
                            Console.WriteLine(roomDetails);
                        }

                        break;

                    case 13:
                        // Extends an active guest booking and recalculates the total cost.

                        Console.Write("Enter guest ID: ");
                        string extendGuestId = Console.ReadLine();

                        Guest guestToExtend = guests.FirstOrDefault(g => g.GuestId == extendGuestId);

                        if (guestToExtend == null)
                        {
                            Console.WriteLine("Guest not found.");
                            break;
                        }

                        if (guestToExtend.RoomNumber == "Not Assigned")
                        {
                            Console.WriteLine("This guest has no active booking to extend.");
                            break;
                        }

                        Console.Write("Enter number of additional nights: ");

                        if (!int.TryParse(Console.ReadLine(), out int additionalNights) ||
                            additionalNights <= 0)
                        {
                            Console.WriteLine("Additional nights must be a positive integer.");
                            break;
                        }

                        guestToExtend.TotalNights += additionalNights;

                        Console.WriteLine("\nGuest stay extended successfully.");
                        Console.WriteLine($"Guest Name: {guestToExtend.GuestName}");
                        Console.WriteLine($"Room Number: {guestToExtend.RoomNumber}");
                        Console.WriteLine($"Additional Nights: {additionalNights}");
                        Console.WriteLine($"Updated Total Nights: {guestToExtend.TotalNights}");
                        Console.WriteLine(
                            $"New Total Cost: OMR {guestToExtend.CalculateTotalCost():F2}"
                        );

                        break;

                    case 14:
                        // Finds and displays the active booking with the highest total revenue.

                        var activeBookings = guests
                            .Where(g => g.RoomNumber != "Not Assigned")
                            .ToList();

                        if (!activeBookings.Any())
                        {
                            Console.WriteLine("No active bookings recorded.");
                            break;
                        }

                        var highestRevenueBooking = activeBookings
                            .Select(g => new
                            {
                                GuestName = g.GuestName,
                                RoomNumber = g.RoomNumber,
                                TotalCost = g.CalculateTotalCost()
                            })
                            .OrderByDescending(g => g.TotalCost)
                            .Take(1)
                            .ToList();

                        Console.WriteLine("\n--- Highest Revenue Booking ---");

                        foreach (var booking in highestRevenueBooking)
                        {
                            Console.WriteLine($"Guest Name: {booking.GuestName}");
                            Console.WriteLine($"Room Number: {booking.RoomNumber}");
                            Console.WriteLine($"Total Cost: OMR {booking.TotalCost:F2}");
                        }

                        break;
                    
                    case 15:
                        // Displays registered guests three at a time using LINQ Skip and Take.

                        if (guests.Count() == 0)
                        {
                            Console.WriteLine("No guests have been registered yet.");
                            break;
                        }

                        int pageSize = 3;
                        int totalGuestPages = (int)Math.Ceiling(
                            guests.Count() / (double)pageSize
                        );

                        Console.Write($"Enter page number (1 to {totalGuestPages}): ");

                        if (!int.TryParse(Console.ReadLine(), out int pageNumber) ||
                            pageNumber < 1 ||
                            pageNumber > totalGuestPages)
                        {
                            Console.WriteLine("That page does not exist.");
                            break;
                        }

                        var guestsOnPage = guests
                            .OrderBy(g => g.GuestName)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        Console.WriteLine(
                            $"\n--- Guest Page {pageNumber} of {totalGuestPages} ---"
                        );

                        foreach (Guest guest in guestsOnPage)
                        {
                            Console.WriteLine("\n----------------------------");
                            guest.DisplayGuest();
                        }

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
   

   

        
 
