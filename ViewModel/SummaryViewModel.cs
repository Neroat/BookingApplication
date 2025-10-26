using Booking.Model;
using Booking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.ViewModel
{
    public class SummaryViewModel
    {
        private BookingManagerService _service;
        public List<BookingModel> SummaryBookings {  get; set; }
        public string TotalText { get; set; }
        public string DateText { get; set; }
        public string UsingText { get; set; }
        public string BookingText { get; set; }
        public SummaryViewModel()
        {
            _service = new BookingManagerService();
            SummaryBookings = _service.GetUpcomingAllBookings();
            int[] summaries = new int[3];
            int total = SummaryBookings.Count;
            int using_room = 0;
            int booking_room = 0;
            List<BookingModel> bookingModels = new List<BookingModel>();
            for (int i = 1; i <= 5; i++)
            {
                RoomStatus status = _service.GetRoomStatus(i);
                switch (status)
                {
                    case RoomStatus.Booking: booking_room++; break;
                    case RoomStatus.Using: using_room++; break;
                }
                summaries[0] = total;
                summaries[1] = using_room;
                summaries[2] = booking_room;
            }
            DateText = DateTime.Now.ToString("yyyy년 MM월 dd일");
            TotalText = summaries[0] + "건";
            UsingText = summaries[1] + "건";
            BookingText = summaries[2] + "건";
        }
        
    }
}
