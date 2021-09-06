using System;
using System.Collections.Generic;
using System.Globalization;

namespace HotelManagementSytem
{
    class Program
    {
        public static List<Booking> AvailableRoomBookingList;
        public static List<Room> AvailableRoomList;
        static void Main(string[] args)
        {


            //Service instances
            UserService userService = new UserService();
            GuestService guestService = new GuestService();
            RoomService roomService = new RoomService();
            BookingService bookingService = new BookingService();
            //User Creation Inputs
            string name;
            string surname;
            string username_input;
            string password_input;
            int id;
            //User Object
            User user;
            User newUser;
            //Loop Choice
            byte choice;
            //Guest Creation Inputs
            string identification;
            string guestName;
            string guestSurname;
            string email;
            string phone;
            string newIdentification;
            string newGuestName;
            string newGuestSurname;
            string newGuestEmail;
            string newGuestPhone;

            //Guest object
            Guest guest;
            Guest newGuest;
            Guest guestUpt;
            //Room inputs
            int roomNumber;
            int number;
            int bedCount;
            int price;
            string type;
            int number_input;
            int bedCount_input;
            int price_input;
            string type_input;
            //Room object
            Room roomCrud;
            Room newRoom;
            //Available room 
            bool dublicate=false;
            Booking bookingUpt;
            Booking booking1;
            //*********
            //DateTime objects for Check-In Check-Out
            DateTime checkin_input;
            DateTime checkout_input;
            string checkin_str;
            string checkout_str;
             CultureInfo cultInfo = CultureInfo.InvariantCulture;
        //Error Handling
        bool success;
            //*************
            byte loginAttempt = 0;
            User logedinUser;

            Console.WriteLine("                          Welcome to The Grand Budapest Hotel!");
            Console.WriteLine("                       ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine();

            do
            {
                
                Console.WriteLine("Enter username: ");
                string username = Console.ReadLine();

                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();

                logedinUser = userService.GetAll().Find(u => u.Username == username && u.Password == password);
                if (logedinUser == null)

                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect password or username!");
                    Console.WriteLine();
                    Console.WriteLine("Try again!");
                    Console.WriteLine("---------------------------------");
                    loginAttempt++;
                }
                else
                {
                    break;
                }
            } while (loginAttempt<3);

            if (logedinUser!=null)
            {
                
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Booking");
                    Console.WriteLine("2. Users");
                    Console.WriteLine("3. Room information");
                    Console.WriteLine("4. Guest information");
                    Console.WriteLine("5. Booking reports");
                    Console.WriteLine("0. Exit");
                    choice = Convert.ToByte(Console.ReadLine());


                    switch (choice)
                    {
                           
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Booking Menu: ");

                            do
                            {
                                Console.WriteLine("1. Available room list");
                                Console.WriteLine("2. Check-in");
                                Console.WriteLine("3. Check-out");
                                Console.WriteLine("0. Exit");
                                choice = Convert.ToByte(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        Console.WriteLine("Avialable room list");
                                        Console.WriteLine("\n\n");
                                        Console.Write("Enter Check-IN Date(dd.MM.yyyy):");
                                        checkin_str = Console.ReadLine();
                                        success = DateTime.TryParseExact(checkin_str, "dd.MM.yyyy", cultInfo, System.Globalization.DateTimeStyles.None, out checkin_input);
                                        while (!success)
                                        {
                                            Console.Write("Reenter Check-IN Date:");
                                            checkin_str = Console.ReadLine();
                                            success = DateTime.TryParseExact(checkin_str, "dd.MM.yyyy", cultInfo, DateTimeStyles.None, out checkin_input);
                                        }

                                        Console.Write("Enter Check-OUT Date(dd.MM.yyyy):");

                                        checkout_str = Console.ReadLine();
                                        success = DateTime.TryParseExact(checkout_str, "dd.MM.yyyy", cultInfo, DateTimeStyles.None, out checkout_input);
                                        while (!success)
                                        {
                                            Console.Write("Reenter Check-OUT Date:");
                                            checkout_str = Console.ReadLine();
                                            success = DateTime.TryParseExact(checkout_str, "dd.MM.yyyy", cultInfo, DateTimeStyles.None, out checkout_input);
                                        }

                                        AvailableRoomBookingList = bookingService.GetAll().FindAll(room => (room.CheckInDate > checkin_input && room.CheckInDate > checkout_input) || (room.CheckOutDate < checkout_input && room.CheckInDate < room.CheckOutDate));

                                        for (int i = 0; i < AvailableRoomBookingList.Count; i++)
                                        {
                                            for (int j = 0; j < AvailableRoomBookingList.Count-1; j++)
                                            {
                                                if (AvailableRoomBookingList[i].RoomNumber==AvailableRoomBookingList[j+1].RoomNumber)
                                                {
                                                    dublicate = true;
                                                }
                                            }
                                            if (dublicate)
                                            {
                                                AvailableRoomBookingList.Remove(AvailableRoomBookingList[i]);
                                            }
                                            dublicate = false;
                                        }

                                        AvailableRoomList = roomService.GetAll().FindAll(room => bookingService.GetAll().Exists(booking => booking.RoomNumber != room.Number));
                                        if (AvailableRoomBookingList.Count>0 || AvailableRoomList.Count>0)
                                        {
                                            foreach (Booking booking in AvailableRoomBookingList)
                                            {
                                                Console.WriteLine($"Room number: {booking.RoomNumber} | Price: {roomService.Get(booking.RoomNumber).Price}");
                                                Console.WriteLine();
                                            }
                                            foreach (Room rooms in AvailableRoomList)
                                            {
                                                Console.WriteLine($"Room number: {rooms.Number} | Price: {rooms.Price}");
                                                Console.WriteLine();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No room available");
                                            Console.WriteLine("Press any key to exit");
                                            Console.ReadKey(true);
                                        }

                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Enter Identification: ");
                                        identification = Console.ReadLine();

                                        Console.WriteLine("Enter name: ");
                                        guestName = Console.ReadLine();

                                        Console.WriteLine("Enter surname: ");
                                        guestSurname = Console.ReadLine();

                                        Console.WriteLine("Enter email: ");
                                        email = Console.ReadLine();

                                        Console.WriteLine("Enter phone number: ");
                                        phone = Console.ReadLine();
                                      

                                        guest = new Guest()
                                        {
                                            Id = guestService.GetAll().Count + 1,
                                            Identification = identification,
                                            Name = guestName,
                                            Surname = guestSurname,
                                            Phone = phone,
                                            Email = email,
                                            CreatedDate = DateTime.Now
                                        };
                                        guestService.Create(guest);

                                        Console.WriteLine("Enter room number: ");
                                        roomNumber = Convert.ToInt32(Console.ReadLine());
                                        Room roomRsrv = roomService.GetAll().Find(r => r.Number == roomNumber);

                                        Console.WriteLine("Enter booking id: ");
                                        id = Convert.ToInt32(Console.ReadLine());

                                        Console.WriteLine("Enter Identification: ");
                                        identification = Console.ReadLine();

                                        Console.WriteLine("Enter check-out date(dd.mm.yyyy): ");
                                        DateTime checkOut = Convert.ToDateTime(Console.ReadLine());

                                        roomService.Create(roomRsrv);
                                        booking1 = new Booking(id, identification, roomNumber, DateTime.Now, checkOut);
                                        bookingService.Create(booking1);

                                        Console.WriteLine("Press any key to exit");
                                        Console.ReadKey(true);
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("Enter Booking Id: ");
                                        id = Convert.ToInt32(Console.ReadLine());
                                        Booking bookingCheck = bookingService.Get(id);
                                        if (bookingCheck!=null)
                                        {
                                            bookingUpt = bookingCheck;
                                            bookingUpt.CheckOutDate = DateTime.Now;
                                            bookingService.Update(bookingCheck, bookingUpt);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Booking not found.");
                                        }
                                        
                                        break;
                                    case 0:
                                        Console.ReadKey(true);
                                        break;
                                    default:
                                        break;
                                }
                            } while (choice != 0);
                            
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("User Menu");
                            Console.WriteLine("");

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("1: Show list");
                                Console.WriteLine("2: Create");
                                Console.WriteLine("3: Find");
                                Console.WriteLine("4: Delete");
                                Console.WriteLine("5: Update");
                                Console.WriteLine("0: Exit");
                                choice = Convert.ToByte(Console.ReadLine());

                                switch(choice)
                                {
                                    case 1:
                                        foreach (User item in userService.GetAll())
                                        {
                                            Console.WriteLine($"ID: {item.Id} | Username: {item.Username} | Created Date: {item.CreatedDate.ToString("dd.MM.yyyy")}");
                                        }
                                        Console.WriteLine("Press any key to exit");
                                      
                                        Console.ReadKey(true);
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("~~~Creation~~~");
                                        Console.WriteLine("\n\n");
                                        Console.Write("Enter ID: ");
                                        id = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter Name: ");
                                        name = Console.ReadLine();
                                        Console.Write("Enter Surname: ");
                                        surname = Console.ReadLine();
                                        Console.Write("Enter username: ");
                                        username_input = Console.ReadLine();
                                        Console.Write("Enter password: ");
                                        password_input = Console.ReadLine();

                                         user = new User(id, username_input, password_input, name, surname);
                                        userService.Create(user);

                                        Console.WriteLine("Press any key to exit");

                                        Console.ReadKey(true);

                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.Write("Enter Id: ");
                                        id = Convert.ToInt32(Console.ReadLine());
                                        user = userService.Get(id);
                                        if(user!=null)
                                        {
                                            Console.WriteLine($"ID: {user.Id} | Username: {user.Username} | Created Date: {user.CreatedDate.ToString("dd.MM.yyyy")}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("No User Found");
                                        }
                                        Console.WriteLine("Press any key to exit");
                                        Console.ReadKey(true);
                                        break;
                                    case 4:
                                        Console.Clear();
                                        Console.Write("Enter Id: ");
                                        id = Convert.ToInt32(Console.ReadLine());
                                        user = userService.Get(id);
                                        if (user != null)
                                        {
                                            userService.Delete(user);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No user found");
                                        }
                                        Console.WriteLine("Press any key to exit");
                                        Console.ReadKey(true);
                                        break;
                                    case 5:
                                        Console.Clear();
                                        Console.Write("Enter Id: ");
                                        id = Convert.ToInt32(Console.ReadLine());
                                        user = userService.Get(id);
                                        if (user != null)
                                        {
                                            newUser = user;
                                            Console.Write("Enter new username: ");
                                            username_input = Console.ReadLine();
                                            Console.Write("Enter new password: ");
                                            password_input = Console.ReadLine();

                                            newUser.Username = username_input;
                                            newUser.Password = password_input;
                                            userService.Update(user, newUser);
                                            Console.WriteLine("User has been updated!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("No User Found");
                                        }
                                        Console.WriteLine("Press any key to exit");
                                        Console.ReadKey(true);

                                        break;
                                    case 0:
                                        Console.ReadKey(true);
                                        break;
                                    default:
                                        break;

                                }
                            } while (choice != 0);
                            Console.WriteLine("Press any key to exit");
                            choice = 1;
                            Console.ReadKey(true);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Room menu:");
                            Console.WriteLine();
                            do
                            {
                                Console.WriteLine("1.Room list");
                                Console.WriteLine("2.Create room");
                                Console.WriteLine("3.Update room");
                                Console.WriteLine("4.Delete room");
                                Console.WriteLine("0.Exit");
                                choice = Convert.ToByte(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        foreach (Room item in roomService.GetAll())
                                        {
                                            Console.WriteLine($"Number: {item.Number} | Type: {item.Type} | Bed count: {item.BedCount} | Price: {item.Price} ");
                                        }
                                        Console.WriteLine("Press any key to exit");
                                        Console.ReadKey(true);
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("~~~Creation~~~");
                                        Console.WriteLine("\n\n");
                                        Console.Write("Enter Number: ");
                                        number = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter type: ");
                                        type = Console.ReadLine();
                                        Console.Write("Enter bed count: ");
                                        bedCount = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter price: ");
                                        price = Convert.ToInt32(Console.ReadLine());
                                        
                                        roomCrud = new Room(number, type, bedCount, price);
                                        roomService.Create(roomCrud);

                                        Console.WriteLine("Press any key to exit");

                                        Console.ReadKey(true);
                                        break;
                                    case 3:
                                        
                                        Console.Clear();
                                        Console.Write("Enter number: ");
                                        number = Convert.ToInt32(Console.ReadLine());
                                        roomCrud = roomService.Get(number);
                                        if (roomCrud != null)
                                        {
                                            newRoom = roomCrud;
                                            Console.Write("Enter new room number: ");
                                            number_input = Convert.ToInt32(Console.ReadLine());

                                            Console.Write("Enter new type: ");
                                            type_input = Console.ReadLine();

                                            Console.Write("Enter new bed count: ");
                                            bedCount_input = Convert.ToInt32(Console.ReadLine());

                                            Console.Write("Enter new price: ");
                                            price_input = Convert.ToInt32(Console.ReadLine());

                                            newRoom.Number = number_input;
                                            newRoom.Type = type_input;
                                            newRoom.BedCount = bedCount_input;
                                            newRoom.Price = price_input;
                                            roomService.Update(roomCrud, newRoom);
                                            Console.WriteLine("Room has been updated!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Room Found");
                                        }
                                        Console.WriteLine("Press any key to exit");
                                        Console.ReadKey(true);
                                        break;
                                    case 4:
                                        Console.Clear();
                                        Console.Write("Enter Number: ");
                                        number = Convert.ToInt32(Console.ReadLine());
                                        roomCrud = roomService.Get(number);
                                        if (roomCrud != null)
                                        {
                                            roomService.Delete(roomCrud);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No room found");
                                        }
                                        Console.WriteLine("Press any key to exit");
                                        Console.ReadKey(true);
                                        break;
                                    case 0:
                                        
                                        Console.ReadKey(true);
                                        break;

                                    default:
                                        break;
                                }

                            } while (choice!=0);

                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Guest menu");

                            do
                            {
                                Console.WriteLine("1.Guests list");
                                Console.WriteLine("2.Add new guest");
                                Console.WriteLine("3.Update guest");
                                Console.WriteLine("4.Delete guest");
                                Console.WriteLine("0.Exit");
                                choice = Convert.ToByte(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        foreach (Guest item in guestService.GetAll())
                                        {
                                            Console.WriteLine($"Identification: {item.Identification} | Name: {item.Name} | Surname: {item.Surname} | Email: {item.Email} | Phone number: {item.Phone}");
                                        }
                                        Console.WriteLine("Press any key to exit");

                                        Console.ReadKey(true);
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("~~~Creation~~~");
                                        Console.WriteLine("\n\n");
                                        Console.Write("Enter Identification: ");
                                        identification = Console.ReadLine();
                                        Console.Write("Enter Name: ");
                                        guestName = Console.ReadLine();
                                        Console.Write("Enter Surname: ");
                                        guestSurname = Console.ReadLine();
                                        Console.Write("Enter email: ");
                                        email = Console.ReadLine();
                                        Console.Write("Enter phone number");
                                        phone = Console.ReadLine();
                                        newGuest = new Guest()
                                        {
                                            Id = guestService.GetAll().Count + 1,
                                            Identification = identification,
                                            Name = guestName,
                                            Surname = guestSurname,
                                            Phone = phone,
                                            Email = email,
                                            CreatedDate = DateTime.Now
                                        };
                                        guestService.Create(newGuest);
                                      

                                        Console.WriteLine("Press any key to exit");

                                        Console.ReadKey(true);
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.Write("Enter Id: ");
                                        id = Convert.ToInt32(Console.ReadLine());
                                        guest = guestService.Get(id);
                                        if (guest != null)
                                        {
                                            guestUpt = guest;
                                            Console.Write("Enter new identification: ");
                                            newIdentification = Console.ReadLine();

                                            Console.Write("Enter new name: ");
                                            newGuestName = Console.ReadLine();

                                            Console.Write("Enter new surname: ");
                                            newGuestSurname = Console.ReadLine();

                                            Console.Write("Enter new email: ");
                                            newGuestEmail = Console.ReadLine();

                                            Console.Write("Enter new phone number: ");
                                            newGuestPhone = Console.ReadLine();

                                            guestUpt.Identification = newIdentification;
                                            guestUpt.Name = newGuestName;
                                            guestUpt.Surname = newGuestSurname;
                                            guestUpt.Email = newGuestEmail;
                                            guestUpt.Phone = newGuestPhone;
                                            guestService.Update(guest, guestUpt);
                                            Console.WriteLine("Guest has been updated!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Guest Found");
                                        }
                                        Console.WriteLine("Press any key to exit");
                                        Console.ReadKey(true);
                                        break;
                                    case 4:
                                        Console.Clear();
                                        Console.Write("Enter Id: ");
                                        id = Convert.ToInt32(Console.ReadLine());
                                        guest = guestService.Get(id);
                                        if (guest != null)
                                        {
                                            guestService.Delete(guest);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No guest found");
                                        }
                                        Console.WriteLine("Press any key to exit");
                                        Console.ReadKey(true);
                                        break;
                                    case 0:
                                        Console.ReadKey(true);
                                        break;
                                    default:
                                        break;
                                }
                            } while (choice!=0);
                            break;
                        case 5:
                            Console.Clear();
                            foreach (var item in bookingService.GetAll())
                            {
                                Console.WriteLine($"Guest {item.GuestId} | Room: {item.RoomNumber} |  Check-in date: {item.CheckInDate.ToString("dd.MM.yyyy")} |  Check-out date: + {item.CheckOutDate.ToString("dd.MM.yyyy")}");
                            }

                            if (bookingService.GetAll().Count == 0)
                            {
                                Console.WriteLine("List is empty!");
                            }
                            Console.WriteLine();

                            Console.WriteLine("Press any key to exit");
                            Console.ReadKey(true);
                            break;
                        case 0:
                            Console.WriteLine("Bye");
                            Console.ReadKey(true);
                            break;
                        default:
                            break;

                            
                    }
                    
                    
                } while (choice!=0);
            }

        }
    }
}
