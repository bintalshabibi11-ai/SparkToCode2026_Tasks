using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagementSystem;

// Represents a hotel room and stores its details and availability.
class Room
{
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public double PricePerNight { get; set; }
    public bool IsAvailable { get; set; }

    public Room(
        int roomNumber,
        string roomType,
        double pricePerNight,
        bool isAvailable)
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
        Console.WriteLine($"Price Per Night: OMR {PricePerNight:F2}");

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

// Represents a hotel guest and stores their booking information.
class Guest
{
    public string GuestId { get; set; }
    public string GuestName { get; set; }
    public string RoomNumber { get; set; }
    public string CheckInDate { get; set; }
    public int TotalNights { get; set; }
    public double PricePerNight { get; set; }

    public Guest(
        string guestId,
        string guestName,
        string roomNumber,
        string checkInDate,
        int totalNights)
    {
        GuestId = guestId;
        GuestName = guestName;
        RoomNumber = roomNumber;
        CheckInDate = checkInDate;
        TotalNights = totalNights;
        PricePerNight = 0;
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
        // Creates the room and guest lists.
        List<Room> rooms = new List<Room>();
        List<Guest> guests = new List<Guest>();

        // Adds the six starting rooms required by the task.
        rooms.Add(new Room(101, "Single", 25.00, true));
        rooms.Add(new Room(102, "Single", 30.00, true));
        rooms.Add(new Room(201, "Double", 45.00, true));
        rooms.Add(new Room(202, "Double", 50.00, true));
        rooms.Add(new Room(301, "Suite", 80.00, true));
        rooms.Add(new Room(302, "Suite", 95.00, true));

        // Keeps guest IDs unique while the program is running.
        int nextGuestNumber = 1;

        // Displays the menu until the user chooses Exit.
        bool exitApp = false;

        while (!exitApp)
        {
            Console.WriteLine();
            Console.WriteLine("================================================");
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
            Console.WriteLine("================================================");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                {
                    // Adds a new room after validating its details.
                    Console.Write("Enter room number: ");

                    if (!int.TryParse(Console.ReadLine(), out int newRoomNumber) ||
                        newRoomNumber <= 0)
                    {
                        Console.WriteLine(
                            "Room number must be a positive number."
                        );
                        break;
                    }

                    bool roomExists = rooms.Any(
                        r => r.RoomNumber == newRoomNumber
                    );

                    if (roomExists)
                    {
                        Console.WriteLine(
                            "A room with this number already exists."
                        );
                        break;
                    }

                    Console.Write(
                        "Enter room type (Single / Double / Suite): "
                    );

                    string? roomTypeInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(roomTypeInput))
                    {
                        Console.WriteLine("Room type cannot be empty.");
                        break;
                    }

                    string newRoomType = roomTypeInput.Trim();

                    if (!newRoomType.Equals(
                            "Single",
                            StringComparison.OrdinalIgnoreCase) &&
                        !newRoomType.Equals(
                            "Double",
                            StringComparison.OrdinalIgnoreCase) &&
                        !newRoomType.Equals(
                            "Suite",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Invalid room type.");
                        break;
                    }

                    if (newRoomType.Equals(
                            "Single",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        newRoomType = "Single";
                    }
                    else if (newRoomType.Equals(
                                 "Double",
                                 StringComparison.OrdinalIgnoreCase))
                    {
                        newRoomType = "Double";
                    }
                    else
                    {
                        newRoomType = "Suite";
                    }

                    Console.Write("Enter price per night: ");

                    if (!double.TryParse(
                            Console.ReadLine(),
                            out double newRoomPrice) ||
                        newRoomPrice <= 0)
                    {
                        Console.WriteLine(
                            "Price must be a positive number."
                        );
                        break;
                    }

                    Room newRoom = new Room(
                        newRoomNumber,
                        newRoomType,
                        newRoomPrice,
                        true
                    );

                    rooms.Add(newRoom);

                    Console.WriteLine();
                    Console.WriteLine("Room added successfully.");
                    Console.WriteLine(
                        $"Room Number: {newRoom.RoomNumber}"
                    );
                    Console.WriteLine(
                        $"Room Type: {newRoom.RoomType}"
                    );
                    Console.WriteLine(
                        $"Price Per Night: OMR " +
                        $"{newRoom.PricePerNight:F2}"
                    );
                    Console.WriteLine("Status: Available");
                    Console.WriteLine(
                        $"Total Rooms: {rooms.Count()}"
                    );

                    break;
                }

                case 2:
                {
                    // Registers a new guest with an automatic guest ID.
                    Console.Write("Enter guest name: ");
                    string? guestNameInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(guestNameInput))
                    {
                        Console.WriteLine(
                            "Guest name cannot be empty."
                        );
                        break;
                    }

                    string guestName = guestNameInput.Trim();

                    Console.Write("Enter check-in date: ");
                    string? checkInDateInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(checkInDateInput))
                    {
                        Console.WriteLine(
                            "Check-in date cannot be empty."
                        );
                        break;
                    }

                    string checkInDate = checkInDateInput.Trim();

                    Console.Write("Enter number of nights: ");

                    if (!int.TryParse(
                            Console.ReadLine(),
                            out int totalNights) ||
                        totalNights <= 0)
                    {
                        Console.WriteLine(
                            "Number of nights must be a positive integer."
                        );
                        break;
                    }

                    string guestId =
                        "G" + nextGuestNumber.ToString("D3");

                    nextGuestNumber++;

                    Guest newGuest = new Guest(
                        guestId,
                        guestName,
                        "Not Assigned",
                        checkInDate,
                        totalNights
                    );

                    guests.Add(newGuest);

                    Console.WriteLine();
                    Console.WriteLine(
                        "Guest registered successfully."
                    );
                    Console.WriteLine(
                        $"Guest ID: {newGuest.GuestId}"
                    );
                    Console.WriteLine(
                        $"Guest Name: {newGuest.GuestName}"
                    );
                    Console.WriteLine(
                        $"Room Number: {newGuest.RoomNumber}"
                    );
                    Console.WriteLine(
                        $"Check-In Date: {newGuest.CheckInDate}"
                    );
                    Console.WriteLine(
                        $"Total Nights: {newGuest.TotalNights}"
                    );

                    break;
                }

                case 3:
                {
                    // Books an available room for a registered guest.
                    Console.Write("Enter guest ID: ");
                    string? guestIdInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(guestIdInput))
                    {
                        Console.WriteLine(
                            "Guest ID cannot be empty."
                        );
                        break;
                    }

                    string bookingGuestId =
                        guestIdInput.Trim().ToUpper();

                    Guest? bookingGuest = guests.FirstOrDefault(
                        g => g.GuestId == bookingGuestId
                    );

                    if (bookingGuest == null)
                    {
                        Console.WriteLine("Guest not found.");
                        break;
                    }

                    if (bookingGuest.RoomNumber != "Not Assigned")
                    {
                        Console.WriteLine(
                            "This guest already has an active booking."
                        );
                        break;
                    }

                    Console.Write("Enter desired room number: ");

                    if (!int.TryParse(
                            Console.ReadLine(),
                            out int bookingRoomNumber) ||
                        bookingRoomNumber <= 0)
                    {
                        Console.WriteLine("Invalid room number.");
                        break;
                    }

                    Room? bookingRoom = rooms.FirstOrDefault(
                        r => r.RoomNumber == bookingRoomNumber
                    );

                    if (bookingRoom == null)
                    {
                        Console.WriteLine("Room not found.");
                        break;
                    }

                    if (!bookingRoom.IsAvailable)
                    {
                        Console.WriteLine(
                            "Room is already booked."
                        );
                        break;
                    }

                    bookingGuest.RoomNumber =
                        bookingRoom.RoomNumber.ToString();

                    bookingGuest.PricePerNight =
                        bookingRoom.PricePerNight;

                    bookingRoom.IsAvailable = false;

                    Console.WriteLine();
                    Console.WriteLine(
                        "Booking completed successfully."
                    );
                    Console.WriteLine(
                        $"Guest Name: {bookingGuest.GuestName}"
                    );
                    Console.WriteLine(
                        $"Room Number: {bookingRoom.RoomNumber}"
                    );
                    Console.WriteLine(
                        $"Room Type: {bookingRoom.RoomType}"
                    );
                    Console.WriteLine(
                        $"Price Per Night: OMR " +
                        $"{bookingRoom.PricePerNight:F2}"
                    );
                    Console.WriteLine(
                        $"Total Nights: {bookingGuest.TotalNights}"
                    );
                    Console.WriteLine(
                        $"Total Cost: OMR " +
                        $"{bookingGuest.CalculateTotalCost():F2}"
                    );

                    break;
                }

                case 4:
                {
                    // Displays all rooms sorted by room number.
                    if (rooms.Count() == 0)
                    {
                        Console.WriteLine(
                            "No rooms have been added yet."
                        );
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        $"Total Rooms: {rooms.Count()}"
                    );

                    List<Room> sortedRooms = rooms
                        .OrderBy(r => r.RoomNumber)
                        .ToList();

                    foreach (Room room in sortedRooms)
                    {
                        Console.WriteLine();
                        Console.WriteLine(
                            "----------------------------"
                        );
                        room.DisplayRoom();
                    }

                    break;
                }

                case 5:
                {
                    // Displays all guests sorted by guest name.
                    if (guests.Count() == 0)
                    {
                        Console.WriteLine(
                            "No guests have been registered yet."
                        );
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        $"Total Guests: {guests.Count()}"
                    );

                    List<Guest> sortedGuests = guests
                        .OrderBy(g => g.GuestName)
                        .ToList();

                    foreach (Guest guest in sortedGuests)
                    {
                        Console.WriteLine();
                        Console.WriteLine(
                            "----------------------------"
                        );
                        guest.DisplayGuest();
                    }

                    break;
                }

                case 6:
                {
                    // Filters and analyses rooms using LINQ.
                    Console.WriteLine();
                    Console.WriteLine(
                        "--- Search and Filter Rooms ---"
                    );
                    Console.WriteLine(
                        "1. Show all available rooms"
                    );
                    Console.WriteLine(
                        "2. Filter by room type"
                    );
                    Console.WriteLine(
                        "3. Filter by maximum price"
                    );
                    Console.WriteLine(
                        "4. Room price statistics"
                    );
                    Console.WriteLine("0. Back");
                    Console.Write("Enter your choice: ");

                    if (!int.TryParse(
                            Console.ReadLine(),
                            out int filterChoice))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    switch (filterChoice)
                    {
                        case 1:
                        {
                            List<Room> availableRooms = rooms
                                .Where(r => r.IsAvailable)
                                .OrderBy(r => r.PricePerNight)
                                .ToList();

                            if (!availableRooms.Any())
                            {
                                Console.WriteLine(
                                    "No rooms found for the " +
                                    "selected criteria."
                                );
                                break;
                            }

                            Console.WriteLine(
                                $"Available Rooms: " +
                                $"{availableRooms.Count()}"
                            );

                            foreach (Room room in availableRooms)
                            {
                                Console.WriteLine(
                                    $"Room {room.RoomNumber} | " +
                                    $"{room.RoomType} | " +
                                    $"OMR {room.PricePerNight:F2}"
                                );
                            }

                            break;
                        }

                        case 2:
                        {
                            Console.Write(
                                "Enter room type " +
                                "(Single / Double / Suite): "
                            );

                            string? typeInput = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(typeInput))
                            {
                                Console.WriteLine(
                                    "Room type cannot be empty."
                                );
                                break;
                            }

                            string searchRoomType = typeInput.Trim();

                            List<Room> roomsByType = rooms
                                .Where(r => r.RoomType.Equals(
                                    searchRoomType,
                                    StringComparison.OrdinalIgnoreCase))
                                .OrderBy(r => r.RoomNumber)
                                .ToList();

                            if (!roomsByType.Any())
                            {
                                Console.WriteLine(
                                    "No rooms found for the " +
                                    "selected criteria."
                                );
                                break;
                            }

                            Console.WriteLine(
                                $"Rooms Found: {roomsByType.Count()}"
                            );

                            foreach (Room room in roomsByType)
                            {
                                Console.WriteLine();
                                room.DisplayRoom();
                                Console.WriteLine(
                                    "----------------------------"
                                );
                            }

                            break;
                        }

                        case 3:
                        {
                            Console.Write(
                                "Enter maximum price: "
                            );

                            if (!double.TryParse(
                                    Console.ReadLine(),
                                    out double maximumPrice) ||
                                maximumPrice <= 0)
                            {
                                Console.WriteLine(
                                    "Maximum price must be " +
                                    "a positive number."
                                );
                                break;
                            }

                            List<Room> roomsByPrice = rooms
                                .Where(r =>
                                    r.IsAvailable &&
                                    r.PricePerNight <= maximumPrice)
                                .OrderBy(r => r.PricePerNight)
                                .ToList();

                            if (!roomsByPrice.Any())
                            {
                                Console.WriteLine(
                                    "No rooms found for the " +
                                    "selected criteria."
                                );
                                break;
                            }

                            Console.WriteLine(
                                $"Rooms Found: " +
                                $"{roomsByPrice.Count()}"
                            );

                            foreach (Room room in roomsByPrice)
                            {
                                Console.WriteLine(
                                    $"Room {room.RoomNumber} | " +
                                    $"{room.RoomType} | " +
                                    $"OMR {room.PricePerNight:F2}"
                                );
                            }

                            break;
                        }

                        case 4:
                        {
                            if (!rooms.Any())
                            {
                                Console.WriteLine(
                                    "No rooms have been added yet."
                                );
                                break;
                            }

                            int totalRoomCount = rooms.Count();

                            int availableRoomCount = rooms.Count(
                                r => r.IsAvailable
                            );

                            double averageRoomPrice = rooms.Average(
                                r => r.PricePerNight
                            );

                            double cheapestRoomPrice = rooms.Min(
                                r => r.PricePerNight
                            );

                            double highestRoomPrice = rooms.Max(
                                r => r.PricePerNight
                            );

                            Console.WriteLine(
                                $"Total Rooms: {totalRoomCount}"
                            );
                            Console.WriteLine(
                                $"Available Rooms: " +
                                $"{availableRoomCount}"
                            );
                            Console.WriteLine(
                                $"Average Price: OMR " +
                                $"{averageRoomPrice:F2}"
                            );
                            Console.WriteLine(
                                $"Cheapest Price: OMR " +
                                $"{cheapestRoomPrice:F2}"
                            );
                            Console.WriteLine(
                                $"Most Expensive Price: OMR " +
                                $"{highestRoomPrice:F2}"
                            );

                            break;
                        }

                        case 0:
                        {
                            Console.WriteLine(
                                "Returning to the main menu."
                            );
                            break;
                        }

                        default:
                        {
                            Console.WriteLine("Invalid option.");
                            break;
                        }
                    }

                    break;
                }

                case 7:
                {
                    // Displays occupancy and revenue statistics.
                    int totalGuests = guests.Count();

                    int bookedGuestsCount = guests.Count(
                        g => g.RoomNumber != "Not Assigned"
                    );

                    int totalRoomsCount = rooms.Count();

                    int bookedRoomsCount = rooms.Count(
                        r => !r.IsAvailable
                    );

                    Console.WriteLine();
                    Console.WriteLine(
                        "--- Guest and Booking Statistics ---"
                    );
                    Console.WriteLine(
                        $"Total Registered Guests: {totalGuests}"
                    );
                    Console.WriteLine(
                        $"Guests With Active Bookings: " +
                        $"{bookedGuestsCount}"
                    );
                    Console.WriteLine(
                        $"Total Rooms: {totalRoomsCount}"
                    );
                    Console.WriteLine(
                        $"Booked Rooms: {bookedRoomsCount}"
                    );

                    List<Guest> bookedGuests = guests
                        .Where(
                            g => g.RoomNumber != "Not Assigned"
                        )
                        .ToList();

                    if (!bookedGuests.Any())
                    {
                        Console.WriteLine(
                            "No active bookings recorded."
                        );
                        break;
                    }

                    double averageNights = bookedGuests.Average(
                        g => g.TotalNights
                    );

                    Console.WriteLine(
                        $"Average Number of Nights: " +
                        $"{averageNights:F2}"
                    );

                    List<Guest> topGuests = bookedGuests
                        .OrderByDescending(
                            g => g.CalculateTotalCost()
                        )
                        .Take(3)
                        .ToList();

                    Console.WriteLine();
                    Console.WriteLine(
                        "Top 3 Highest-Spending Guests:"
                    );

                    foreach (Guest guest in topGuests)
                    {
                        Console.WriteLine(
                            $"{guest.GuestName} | " +
                            $"Room {guest.RoomNumber} | " +
                            $"OMR " +
                            $"{guest.CalculateTotalCost():F2}"
                        );
                    }

                    List<string> bookingSummaries =
                        bookedGuests
                            .Select(g =>
                                $"{g.GuestName} - " +
                                $"Room {g.RoomNumber} - " +
                                $"{g.TotalNights} nights - " +
                                $"OMR " +
                                $"{g.CalculateTotalCost():F2}")
                            .ToList();

                    Console.WriteLine();
                    Console.WriteLine(
                        "Active Booking Summary:"
                    );

                    foreach (string summary in bookingSummaries)
                    {
                        Console.WriteLine(summary);
                    }

                    break;
                }

                case 8:
                {
                    // Updates the selected room's nightly price.
                    Console.Write("Enter room number: ");

                    if (!int.TryParse(
                            Console.ReadLine(),
                            out int updateRoomNumber) ||
                        updateRoomNumber <= 0)
                    {
                        Console.WriteLine(
                            "Invalid room number."
                        );
                        break;
                    }

                    Room? roomToUpdate = rooms.FirstOrDefault(
                        r => r.RoomNumber == updateRoomNumber
                    );

                    if (roomToUpdate == null)
                    {
                        Console.WriteLine("Room not found.");
                        break;
                    }

                    Console.Write(
                        "Enter new price per night: "
                    );

                    if (!double.TryParse(
                            Console.ReadLine(),
                            out double newPrice) ||
                        newPrice <= 0)
                    {
                        Console.WriteLine(
                            "Price must be a positive number."
                        );
                        break;
                    }

                    double oldPrice =
                        roomToUpdate.PricePerNight;

                    roomToUpdate.PricePerNight = newPrice;

                    // Updates the booked guest's saved room price.
                    Guest? guestInRoom = guests.FirstOrDefault(
                        g => g.RoomNumber ==
                             roomToUpdate.RoomNumber.ToString()
                    );

                    if (guestInRoom != null)
                    {
                        guestInRoom.PricePerNight = newPrice;
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        "Room price updated successfully."
                    );
                    Console.WriteLine(
                        $"Room Number: " +
                        $"{roomToUpdate.RoomNumber}"
                    );
                    Console.WriteLine(
                        $"Old Price: OMR {oldPrice:F2}"
                    );
                    Console.WriteLine(
                        $"New Price: OMR " +
                        $"{roomToUpdate.PricePerNight:F2}"
                    );

                    break;
                }

                case 9:
                {
                    // Searches by full or partial guest name.
                    Console.Write(
                        "Enter guest name or part of the name: "
                    );

                    string? nameInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nameInput))
                    {
                        Console.WriteLine(
                            "Search text cannot be empty."
                        );
                        break;
                    }

                    string searchName = nameInput.Trim();

                    List<Guest> matchedGuests = guests
                        .Where(g => g.GuestName.Contains(
                            searchName,
                            StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (!matchedGuests.Any())
                    {
                        Console.WriteLine(
                            "No guests matched that search."
                        );
                        break;
                    }

                    Console.WriteLine(
                        $"Guests Found: {matchedGuests.Count()}"
                    );

                    foreach (Guest guest in matchedGuests)
                    {
                        Console.WriteLine(
                            $"Guest ID: {guest.GuestId} | " +
                            $"Name: {guest.GuestName} | " +
                            $"Room: {guest.RoomNumber}"
                        );
                    }

                    break;
                }

                case 10:
                {
                    // Displays counts and average prices by room type.
                    if (!rooms.Any())
                    {
                        Console.WriteLine(
                            "No rooms have been added yet."
                        );
                        break;
                    }

                    string[] roomTypes =
                    {
                        "Single",
                        "Double",
                        "Suite"
                    };

                    Console.WriteLine();
                    Console.WriteLine(
                        "--- Room Type Breakdown Report ---"
                    );

                    foreach (string roomType in roomTypes)
                    {
                        int typeCount = rooms.Count(
                            r => r.RoomType == roomType
                        );

                        Console.WriteLine();
                        Console.WriteLine(
                            $"Room Type: {roomType}"
                        );
                        Console.WriteLine(
                            $"Total Rooms: {typeCount}"
                        );

                        if (typeCount == 0)
                        {
                            Console.WriteLine(
                                "Average Price: N/A"
                            );
                        }
                        else
                        {
                            double typeAveragePrice = rooms
                                .Where(
                                    r => r.RoomType == roomType
                                )
                                .Average(
                                    r => r.PricePerNight
                                );

                            Console.WriteLine(
                                $"Average Price: OMR " +
                                $"{typeAveragePrice:F2}"
                            );
                        }
                    }

                    double overallAveragePrice = rooms.Average(
                        r => r.PricePerNight
                    );

                    Console.WriteLine();
                    Console.WriteLine(
                        $"Overall Average Price: OMR " +
                        $"{overallAveragePrice:F2}"
                    );

                    break;
                }

                case 11:
                {
                    // Checks out a guest and frees their room.
                    Console.Write(
                        "Enter guest ID to check out: "
                    );

                    string? checkoutIdInput =
                        Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(
                            checkoutIdInput))
                    {
                        Console.WriteLine(
                            "Guest ID cannot be empty."
                        );
                        break;
                    }

                    string checkoutGuestId =
                        checkoutIdInput.Trim().ToUpper();

                    Guest? checkoutGuest =
                        guests.FirstOrDefault(
                            g => g.GuestId ==
                                 checkoutGuestId
                        );

                    if (checkoutGuest == null)
                    {
                        Console.WriteLine("Guest not found.");
                        break;
                    }

                    if (checkoutGuest.RoomNumber ==
                        "Not Assigned")
                    {
                        Console.WriteLine(
                            "This guest has no active booking."
                        );
                        break;
                    }

                    Room? checkoutRoom = rooms.FirstOrDefault(
                        r => r.RoomNumber.ToString() ==
                             checkoutGuest.RoomNumber
                    );

                    if (checkoutRoom == null)
                    {
                        Console.WriteLine(
                            "The guest's room could not be found."
                        );
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("--- Final Bill ---");
                    Console.WriteLine(
                        $"Guest Name: " +
                        $"{checkoutGuest.GuestName}"
                    );
                    Console.WriteLine(
                        $"Room Number: " +
                        $"{checkoutRoom.RoomNumber}"
                    );
                    Console.WriteLine(
                        $"Room Type: {checkoutRoom.RoomType}"
                    );
                    Console.WriteLine(
                        $"Check-In Date: " +
                        $"{checkoutGuest.CheckInDate}"
                    );
                    Console.WriteLine(
                        $"Total Nights: " +
                        $"{checkoutGuest.TotalNights}"
                    );
                    Console.WriteLine(
                        $"Price Per Night: OMR " +
                        $"{checkoutGuest.PricePerNight:F2}"
                    );
                    Console.WriteLine(
                        $"Total Cost: OMR " +
                        $"{checkoutGuest.CalculateTotalCost():F2}"
                    );

                    Console.Write(
                        "Confirm checkout (Y/N): "
                    );

                    string? confirmationInput =
                        Console.ReadLine();

                    string checkoutConfirmation = "";

                    if (confirmationInput != null)
                    {
                        checkoutConfirmation =
                            confirmationInput.Trim().ToUpper();
                    }

                    if (checkoutConfirmation != "Y")
                    {
                        Console.WriteLine(
                            "Checkout cancelled. " +
                            "No changes were made."
                        );
                        break;
                    }

                    checkoutRoom.IsAvailable = true;
                    guests.Remove(checkoutGuest);

                    bool roomIsAvailable = rooms.Any(
                        r => r.RoomNumber ==
                             checkoutRoom.RoomNumber &&
                             r.IsAvailable
                    );

                    Console.WriteLine();
                    Console.WriteLine(
                        "Checkout completed successfully."
                    );
                    Console.WriteLine(
                        $"Guest: {checkoutGuest.GuestName}"
                    );
                    Console.WriteLine(
                        $"Room {checkoutRoom.RoomNumber} " +
                        $"is now available: " +
                        $"{roomIsAvailable}"
                    );
                    Console.WriteLine(
                        $"Updated Guest Count: " +
                        $"{guests.Count()}"
                    );
                    Console.WriteLine(
                        $"Updated Room Count: " +
                        $"{rooms.Count()}"
                    );

                    break;
                }

                case 12:
                {
                    // Removes unavailable rooms with no guest booking.
                    List<Room> removableRooms = rooms
                        .Where(r =>
                            !r.IsAvailable &&
                            !guests.Any(g =>
                                g.RoomNumber ==
                                r.RoomNumber.ToString()))
                        .OrderBy(r => r.RoomNumber)
                        .ToList();

                    if (!removableRooms.Any())
                    {
                        Console.WriteLine(
                            "All unavailable rooms are " +
                            "currently occupied. No rooms " +
                            "can be decommissioned."
                        );
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        "--- Rooms Safe to Remove ---"
                    );

                    foreach (Room room in removableRooms)
                    {
                        Console.WriteLine(
                            $"Room {room.RoomNumber} | " +
                            $"{room.RoomType} | " +
                            $"OMR {room.PricePerNight:F2}"
                        );
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        $"Removable Rooms: " +
                        $"{removableRooms.Count()}"
                    );

                    Console.Write(
                        "Confirm removal (Y/N): "
                    );

                    string? removalInput =
                        Console.ReadLine();

                    string removalConfirmation = "";

                    if (removalInput != null)
                    {
                        removalConfirmation =
                            removalInput.Trim().ToUpper();
                    }

                    if (removalConfirmation != "Y")
                    {
                        Console.WriteLine(
                            "Removal cancelled. " +
                            "No rooms were removed."
                        );
                        break;
                    }

                    int removedRoomsCount =
                        rooms.RemoveAll(r =>
                            !r.IsAvailable &&
                            !guests.Any(g =>
                                g.RoomNumber ==
                                r.RoomNumber.ToString())
                        );

                    Console.WriteLine();
                    Console.WriteLine(
                        $"{removedRoomsCount} room(s) " +
                        "removed successfully."
                    );

                    Console.WriteLine(
                        $"Updated Total Rooms: " +
                        $"{rooms.Count()}"
                    );

                    List<string> remainingRooms = rooms
                        .OrderBy(r => r.RoomNumber)
                        .Select(r =>
                            $"Room {r.RoomNumber} | " +
                            $"{r.RoomType}")
                        .ToList();

                    Console.WriteLine();
                    Console.WriteLine(
                        "--- Remaining Rooms ---"
                    );

                    foreach (string roomDetails
                             in remainingRooms)
                    {
                        Console.WriteLine(roomDetails);
                    }

                    break;
                }

                case 13:
                {
                    // Extends a guest's active booking.
                    Console.Write("Enter guest ID: ");

                    string? extendIdInput =
                        Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(
                            extendIdInput))
                    {
                        Console.WriteLine(
                            "Guest ID cannot be empty."
                        );
                        break;
                    }

                    string extendGuestId =
                        extendIdInput.Trim().ToUpper();

                    Guest? guestToExtend =
                        guests.FirstOrDefault(
                            g => g.GuestId ==
                                 extendGuestId
                        );

                    if (guestToExtend == null)
                    {
                        Console.WriteLine("Guest not found.");
                        break;
                    }

                    if (guestToExtend.RoomNumber ==
                        "Not Assigned")
                    {
                        Console.WriteLine(
                            "This guest has no active " +
                            "booking to extend."
                        );
                        break;
                    }

                    Console.Write(
                        "Enter number of additional nights: "
                    );

                    if (!int.TryParse(
                            Console.ReadLine(),
                            out int additionalNights) ||
                        additionalNights <= 0)
                    {
                        Console.WriteLine(
                            "Additional nights must be " +
                            "a positive integer."
                        );
                        break;
                    }

                    guestToExtend.TotalNights +=
                        additionalNights;

                    Console.WriteLine();
                    Console.WriteLine(
                        "Guest stay extended successfully."
                    );
                    Console.WriteLine(
                        $"Guest Name: " +
                        $"{guestToExtend.GuestName}"
                    );
                    Console.WriteLine(
                        $"Room Number: " +
                        $"{guestToExtend.RoomNumber}"
                    );
                    Console.WriteLine(
                        $"Additional Nights: " +
                        $"{additionalNights}"
                    );
                    Console.WriteLine(
                        $"Updated Total Nights: " +
                        $"{guestToExtend.TotalNights}"
                    );
                    Console.WriteLine(
                        $"New Total Cost: OMR " +
                        $"{guestToExtend.CalculateTotalCost():F2}"
                    );

                    break;
                }

                case 14:
                {
                    // Displays the active booking with the highest cost.
                    List<Guest> highestRevenueBooking =
                        guests
                            .Where(g =>
                                g.RoomNumber !=
                                "Not Assigned")
                            .Select(g => g)
                            .OrderByDescending(
                                g => g.CalculateTotalCost()
                            )
                            .Take(1)
                            .ToList();

                    if (!highestRevenueBooking.Any())
                    {
                        Console.WriteLine(
                            "No active bookings recorded."
                        );
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        "--- Highest Revenue Booking ---"
                    );

                    foreach (Guest booking
                             in highestRevenueBooking)
                    {
                        Console.WriteLine(
                            $"Guest Name: " +
                            $"{booking.GuestName}"
                        );
                        Console.WriteLine(
                            $"Room Number: " +
                            $"{booking.RoomNumber}"
                        );
                        Console.WriteLine(
                            $"Total Nights: " +
                            $"{booking.TotalNights}"
                        );
                        Console.WriteLine(
                            $"Price Per Night: OMR " +
                            $"{booking.PricePerNight:F2}"
                        );
                        Console.WriteLine(
                            $"Total Cost: OMR " +
                            $"{booking.CalculateTotalCost():F2}"
                        );
                    }

                    break;
                }

                case 15:
                {
                    // Displays guests three at a time.
                    if (!guests.Any())
                    {
                        Console.WriteLine(
                            "No guests have been registered yet."
                        );
                        break;
                    }

                    int pageSize = 3;

                    int totalGuestPages =
                        (int)Math.Ceiling(
                            guests.Count() /
                            (double)pageSize
                        );

                    Console.Write(
                        $"Enter page number " +
                        $"(1 to {totalGuestPages}): "
                    );

                    if (!int.TryParse(
                            Console.ReadLine(),
                            out int pageNumber) ||
                        pageNumber < 1 ||
                        pageNumber > totalGuestPages)
                    {
                        Console.WriteLine(
                            "That page does not exist."
                        );
                        break;
                    }

                    List<Guest> guestsOnPage = guests
                        .OrderBy(g => g.GuestName)
                        .Skip(
                            (pageNumber - 1) * pageSize
                        )
                        .Take(pageSize)
                        .ToList();

                    Console.WriteLine();
                    Console.WriteLine(
                        $"--- Guest Page {pageNumber} " +
                        $"of {totalGuestPages} ---"
                    );

                    foreach (Guest guest in guestsOnPage)
                    {
                        Console.WriteLine();
                        Console.WriteLine(
                            "----------------------------"
                        );
                        guest.DisplayGuest();
                    }

                    break;
                }

                case 0:
                {
                    exitApp = true;
                    Console.WriteLine(
                        "Thank you. Goodbye!"
                    );
                    break;
                }

                default:
                {
                    Console.WriteLine(
                        "Invalid option. " +
                        "Please choose from 0 to 15."
                    );
                    break;
                }
            }
        }
    }
}