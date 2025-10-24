using Booking.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class BookingManagerService
    {
        private readonly string _dbConnection;
        public BookingManagerService()
        {
                       _dbConnection = App.ConnectionString;
        }
        public List<RoomModel> GetAllRooms()
        {
            var rooms = new List<RoomModel>();
           using(var db = new MySqlConnection(_dbConnection))
            {
                db.Open();
                string query = "SELECT Id, RoomNumber FROM rooms ORDER BY RoomNumber";
                using (var command = new MySqlCommand(query, db))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new RoomModel
                        {
                            Id = reader.GetInt32("Id"),
                            RoomNumber = reader.GetInt32("RoomNumber")
                        });
                    }
                }
            }
            return rooms;
        }
        public List<BookingModel> GetTodayRoomBookings(int roomNumber)
        {
            var bookings = new List<BookingModel>();
            using (var db = new MySqlConnection(_dbConnection))
            {
                db.Open();
                string query = "SELECT Id, RoomNumber, CustomerName, CustomerPhone, StartDate, EndDate, BookingDate " +
                    "FROM Bookings " +
                    "WHERE DATE(StartDate) = @Today " +
                    //"WHERE @Today BETWEEN StartDate AND EndDate " +
                    "AND RoomNumber = @RoomNumber ";
                using (var command = new MySqlCommand(query, db))
                {
                    command.Parameters.AddWithValue("@Today", DateTime.Today);
                    command.Parameters.AddWithValue("@RoomNumber", roomNumber);

                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            bookings.Add(new BookingModel
                            {
                                Id = reader.GetInt32("Id"),
                                RoomNumber = reader.GetInt32("RoomNumber"),
                                CustomerName = reader.GetString("CustomerName"),
                                CustomerPhone = reader.GetString("CustomerPhone"),
                                StartDate = reader.GetDateTime("StartDate"),
                                EndDate = reader.GetDateTime("EndDate"),
                                BookingDate = reader.GetDateTime("BookingDate")
                            });
                        }
                    }
                }
            }
            return bookings;
        }
        public List<BookingModel> GetRoomAllBookings(int roomNumber)
        {
            var bookings = new List<BookingModel>();
            using (var db = new MySqlConnection(_dbConnection))
            {
                db.Open();
                string query = "SELECT Id, RoomNumber, CustomerName, CustomerPhone, StartDate, EndDate, BookingDate " +
                    "FROM Bookings  " +
                    "WHERE RoomNumber = @RoomNumber ";
                using (var command = new MySqlCommand(query, db))
                {
                    command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookings.Add(new BookingModel
                            {
                                Id = reader.GetInt32("Id"),
                                RoomNumber = reader.GetInt32("RoomNumber"),
                                CustomerName = reader.GetString("CustomerName"),
                                CustomerPhone = reader.GetString("CustomerPhone"),
                                StartDate = reader.GetDateTime("StartDate"),
                                EndDate = reader.GetDateTime("EndDate"),
                                BookingDate = reader.GetDateTime("BookingDate")
                            });
                        }
                    }
                }
            }
            return bookings;
        }

        public RoomStatus GetRoomStatus(int roomNumber)
        {
            var now = DateTime.Now;
            var bookings = GetTodayRoomBookings(roomNumber);
            if (bookings.Any(b => b.StartDate <= now && b.EndDate >= now))
            {
                return RoomStatus.Using;
            }
            else if (bookings.Any(b => b.StartDate > now))
            {
                return RoomStatus.Booking;
            }
            else
            {
                return RoomStatus.Emptying;
            }
        }

        }
}
