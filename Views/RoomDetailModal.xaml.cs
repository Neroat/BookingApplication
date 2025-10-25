using Booking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Booking.Views
{
    /// <summary>
    /// RoomDetailModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RoomDetailModal : Window
    {
        public RoomDetailModal(int roomId)
        {
            InitializeComponent();
            DataContext = new ViewModel.RoomDetailViewModel(roomId);
        }

    }
}
