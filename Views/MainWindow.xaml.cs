using Booking.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Booking.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private BookingManagerService _service;
        public MainWindow()
        {
            InitializeComponent();
            _service = new BookingManagerService();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            CurrentTimeText.Text = DateTime.Now.ToString("yyyy년 MM월 dd일 HH:mm");
            UpdateRoomCard(1);
            UpdateRoomCard(2);
            UpdateRoomCard(3);
            UpdateRoomCard(4);
            UpdateRoomCard(5);
        }
        public void UpdateRoomCard(int roomId)
        {
            try
            {
                var status = _service.GetRoomStatus(roomId);
                var bookings = _service.GetTodayRoomBookings(roomId);
                var now = DateTime.Now;
                var currentBooking = bookings.FirstOrDefault(b => b.StartDate <= now && b.EndDate >= now);
                var nextBooking = bookings.FirstOrDefault(b => b.StartDate > now);

                //CN = Customer Name (예약자 이름), CT = Customer Time (예약 시간)
                var lineName = (TextBlock)this.FindName($"Room{roomId}CN");
                var lineTime = (TextBlock)this.FindName($"Room{roomId}CT");
                var statusBorder = (Border)this.FindName($"Room{roomId}StatusBorder");
                var statusText = (TextBlock)this.FindName($"Room{roomId}StatusText");

                if (lineName == null || lineTime == null || statusBorder == null || statusText == null)
                    return;

                if(status == Model.RoomStatus.Using && currentBooking != null)
                {
                    lineName.Text = currentBooking.CustomerName;
                    lineTime.Text = $"{currentBooking.StartDate:HH:mm} - {currentBooking.EndDate:HH:mm}";
                    statusBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#F44336");
                    statusText.Text = "사용 중";
                }
                else if(status == Model.RoomStatus.Booking && nextBooking != null)
                {
                    lineName.Text = nextBooking.CustomerName;
                    lineTime.Text = $"{nextBooking.StartDate:HH:mm} - {nextBooking.EndDate:HH:mm}";
                    statusBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF9800");
                    statusText.Text = "예약됨";
                }
                else
                {
                    lineName.Text = "빈 방";
                    lineTime.Text = "";
                    statusBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#4CAF50");
                    statusText.Text = "예약 없음";
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error updating room {roomId} card: {e.Message}", "error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void RoomCard_Click(object sender, RoutedEventArgs e)
        {
        }
        public void MenuButton_Click(object sender, RoutedEventArgs e)
        { 
        }

    }
}