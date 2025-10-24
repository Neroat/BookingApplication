using System.Configuration;
using System.Data;
using System.Windows;

namespace Booking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ConnectionString = 
            "Server=localhost;" +
            "Database=golf_booking;"+
            "User Id=root;" +
            "Password=1234;" +
            "Charset=utf8;";
    }

}
