using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Model
{
    public class MainPreview
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RoomStatus Status { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        
    }
}
