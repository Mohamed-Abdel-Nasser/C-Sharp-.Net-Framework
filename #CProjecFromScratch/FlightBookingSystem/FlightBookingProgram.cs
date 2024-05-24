using System;
using System.Collections.Generic;
namespace FlightBookingSystem
{
    class FlightBookingProgram
    {
        static void Main(string[] args)
        {
            Flight flight1 = new Flight("FL123", "New York", 100, 20, 5);
            BookingSystem bookingSystem = new BookingSystem();
            BookingAgent agent = new BookingAgent(flight1, bookingSystem);

            while (true)
            {
                Console.WriteLine("\n===== Flight Booking System Menu =====");
                Console.WriteLine("1. Book Economy Class");
                Console.WriteLine("2. Book Business Class");
                Console.WriteLine("3. Book First Class");
                Console.WriteLine("4. Display Available Seats");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            BookSeat(agent, SeatClass.Economy);
                            break;
                        case 2:
                            BookSeat(agent, SeatClass.Business);
                            break;
                        case 3:
                            BookSeat(agent, SeatClass.FirstClass);
                            break;
                        case 4:
                            DisplayAvailableSeats(flight1);
                            break;
                        case 5:
                            Console.WriteLine("Exiting Flight Booking System. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                catch (BookingException ex)
                {
                    Console.WriteLine($"Booking Error: {ex.Message}");
                }
            }
        }
        static void BookSeat(BookingAgent agent, SeatClass seatClass)
        {
            Console.Write("Enter passenger name: ");
            string passengerName = Console.ReadLine();
            agent.BookSeat(passengerName, seatClass);
        }

        static void DisplayAvailableSeats(Flight flight)
        {
            Console.WriteLine($"\nAvailable Seats for Flight {flight.FlightNumber} to {flight.Destination}:");
            Console.WriteLine($"Economy Class: {flight.EconomySeats}");
            Console.WriteLine($"Business Class: {flight.BusinessSeats}");
            Console.WriteLine($"First Class: {flight.FirstClassSeats}");
        }
    }

    public enum SeatClass
    {
        Economy,
        Business,
        FirstClass
    }

    public class BookingException : Exception
    {
        public BookingException(string message) : base(message) { }
    }

    public class BookingSystem
    {
        public event EventHandler<string> BookingConfirmed;

        public void ConfirmBooking(string passengerName, SeatClass seatClass)
        {
            string confirmationMessage = $"Booking confirmed for {passengerName} in {seatClass} class.";
            BookingConfirmed?.Invoke(this, confirmationMessage);
        }
    }

    public class Flight
    {
        public string FlightNumber { get; }
        public string Destination { get; }
        public int EconomySeats { get; set; }
        public int BusinessSeats { get; set; }
        public int FirstClassSeats { get; set; }

        public Flight(string flightNumber, string destination, int economySeats, int businessSeats, int firstClassSeats)
        {
            FlightNumber = flightNumber;
            Destination = destination;
            EconomySeats = economySeats;
            BusinessSeats = businessSeats;
            FirstClassSeats = firstClassSeats;
        }

        public static Flight operator +(Flight flight, int numSeats)
        {
            flight.EconomySeats += numSeats;
            return flight;
        }
    }

    public class Passenger
    {
        public string Name { get; }
        public int Age { get; }

        public Passenger(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class BusinessClassPassenger : Passenger
    {
        public string Company { get; }

        public BusinessClassPassenger(string name, int age, string company) : base(name, age)
        {
            Company = company;
        }
    }

    public interface IFlightBooking
    {
        void BookSeat(string passengerName, SeatClass seatClass);
    }

    public class BookingAgent : IFlightBooking
    {
        private Flight _flight;
        private BookingSystem _bookingSystem;

        public BookingAgent(Flight flight, BookingSystem bookingSystem)
        {
            _flight = flight;
            _bookingSystem = bookingSystem;
            _bookingSystem.BookingConfirmed += HandleBookingConfirmation;
        }

        public void BookSeat(string passengerName, SeatClass seatClass)
        {
            switch (seatClass)
            {
                case SeatClass.Economy:
                    if (_flight.EconomySeats > 0)
                    {
                        _flight.EconomySeats--;
                        _bookingSystem.ConfirmBooking(passengerName, SeatClass.Economy);
                    }
                    else
                    {
                        throw new BookingException("No available seats in Economy class.");
                    }
                    break;

                case SeatClass.Business:
                    if (_flight.BusinessSeats > 0)
                    {
                        _flight.BusinessSeats--;
                        _bookingSystem.ConfirmBooking(passengerName, SeatClass.Business);
                    }
                    else
                    {
                        throw new BookingException("No available seats in Business class.");
                    }
                    break;

                case SeatClass.FirstClass:
                    if (_flight.FirstClassSeats > 0)
                    {
                        _flight.FirstClassSeats--;
                        _bookingSystem.ConfirmBooking(passengerName, SeatClass.FirstClass);
                    }
                    else
                    {
                        throw new BookingException("No available seats in First Class.");
                    }
                    break;

                default:
                    throw new BookingException("Invalid seat class.");
            }
        }

        private void HandleBookingConfirmation(object sender, string confirmationMessage)
        {
            Console.WriteLine($"Booking Agent received confirmation: {confirmationMessage}");
        }
    }

}
