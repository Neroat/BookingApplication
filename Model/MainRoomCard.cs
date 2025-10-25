using System.ComponentModel;
using System.Windows.Media;

namespace Booking.Model
{
    public class MainRoomCard : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public int RoomId { get; set; }

        private string _customerName = "빈 방";
        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerName)));
            }
        }

        private string _timeRange = "";
        public string TimeRange
        {
            get => _timeRange;
            set
            {
                _timeRange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeRange)));
            }
        }

        private string _statusText = "예약 없음";
        public string StatusText
        {
            get => _statusText;
            set
            {
                _statusText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatusText)));
            }
        }

        private Brush _statusColor = Brushes.Green;
        public Brush StatusColor
        {
            get => _statusColor;
            set
            {
                _statusColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatusColor)));
            }
        }


    }
}