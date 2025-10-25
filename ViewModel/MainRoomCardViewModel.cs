using Booking.Model;
using Booking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Booking.ViewModel
{
    public class MainRoomCardViewModel
    {
        private BookingManagerService _service;

        // 바인딩할 속성들
        public string CurrentTime { get; set; }
        public MainRoomCard Room1 { get; set; }
        public MainRoomCard Room2 { get; set; }
        public MainRoomCard Room3 { get; set; }
        public MainRoomCard Room4 { get; set; }
        public MainRoomCard Room5 { get; set; }

        public MainRoomCardViewModel()
        {
            _service = new BookingManagerService();

            // 초기 시간 설정
            CurrentTime = DateTime.Now.ToString("yyyy년 MM월 dd일 HH:mm");

            // 각 방 데이터 초기화
            Room1 = new MainRoomCard { RoomId = 1 };
            Room2 = new MainRoomCard { RoomId = 2 };
            Room3 = new MainRoomCard { RoomId = 3 };
            Room4 = new MainRoomCard { RoomId = 4 };
            Room5 = new MainRoomCard { RoomId = 5 };

            // 초기 데이터 로드
            UpdateAllRooms();
        }

        public void UpdateAllRooms()
        {
            UpdateRoom(Room1);
            UpdateRoom(Room2);
            UpdateRoom(Room3);
            UpdateRoom(Room4);
            UpdateRoom(Room5);
        }

        private void UpdateRoom(MainRoomCard room)
        {
            var status = _service.GetRoomStatus(room.RoomId);
            var bookings = _service.GetTodayRoomBookings(room.RoomId);
            var now = DateTime.Now;
            var currentBooking = bookings.FirstOrDefault(b => b.StartDate <= now && b.EndDate >= now);
            var nextBooking = bookings.FirstOrDefault(b => b.StartDate > now);

            if (status == RoomStatus.Using && currentBooking != null)
            {
                room.CustomerName = currentBooking.CustomerName;
                room.TimeRange = $"{currentBooking.StartDate:HH:mm} - {currentBooking.EndDate:HH:mm}";
                room.StatusText = "사용 중";
                room.StatusColor = (SolidColorBrush)new BrushConverter().ConvertFrom("#F44336");
            }
            else if (status == RoomStatus.Booking && nextBooking != null)
            {
                room.CustomerName = nextBooking.CustomerName;
                room.TimeRange = $"{nextBooking.StartDate:HH:mm} - {nextBooking.EndDate:HH:mm}";
                room.StatusText = "예약됨";
                room.StatusColor = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF9800");
            }
            else
            {
                room.CustomerName = "빈 방";
                room.TimeRange = "";
                room.StatusText = "예약 없음";
                room.StatusColor = (SolidColorBrush)new BrushConverter().ConvertFrom("#4CAF50");
            }
        }
    }
}