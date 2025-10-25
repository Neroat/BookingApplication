using Booking.Services;
using Booking.ViewModel;
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
        private MainRoomCardViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainRoomCardViewModel();
            DataContext = _viewModel;

            _service = new BookingManagerService();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();

        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            CurrentTimeText.Text = DateTime.Now.ToString("yyyy년 MM월 dd일 HH:mm");
            _viewModel.UpdateAllRooms();
        }
        public void RoomCard_Click(object sender, RoutedEventArgs e)
        {
           int roomId = int.Parse(((Border)sender).Tag.ToString() ?? "0");
           // MessageBox.Show($"Room {roomId} card clicked.");
            RoomDetailModal roomDetailModal = new RoomDetailModal(roomId);
            roomDetailModal.Owner = this;
            roomDetailModal.ShowDialog();
        }
        public void Summary_Click(object sender, RoutedEventArgs e)
        { 
        }

    }
}