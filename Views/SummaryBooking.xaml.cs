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
    public partial class SummaryBooking : Window
    {
        private SummaryViewModel _viewModel;
        public SummaryBooking()
        {
            _viewModel = new SummaryViewModel();
            InitializeComponent();
            DataContext = _viewModel;
        }
        public void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
