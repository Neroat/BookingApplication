using Booking.Model;
using Booking.Services;
using System;
using System.Collections.Generic;

namespace Booking.ViewModel
{
    public class RoomDetailViewModel
    {
        private BookingManagerService _service;

        public string TitleText { get; set; }
        public string DateText { get; set; }
        public List<BookingModel> TodayBookings { get; set; }
        public List<BookingModel> HistoryBookings { get; set; }

        public RoomDetailViewModel(int roomId)
        {
            _service = new BookingManagerService();

            TitleText = $"{roomId}번 방 상세 정보";
            DateText = DateTime.Now.ToString("yyyy년 MM월 dd일");
            TodayBookings = _service.GetTodayRoomBookings(roomId);
            HistoryBookings = _service.GetRoomAllBookings(roomId);
            
        }
    }
}