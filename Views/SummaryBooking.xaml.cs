using Booking.ViewModel;
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
    /// RoomInfoModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SummaryBooking : Window
    {
        private SummaryViewModel _viewModel;
        public SummaryBooking()
        {
            InitializeComponent();
            _viewModel = new SummaryViewModel();
            DataContext = _viewModel;
            int[] sum_num = _viewModel.SummaryList();
            TotalBookingsText.Text = sum_num[0] + "건";
            UsingText.Text = sum_num[1] + "건";
            BookingText.Text = sum_num[2] + "건";
            
        }
        public void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
