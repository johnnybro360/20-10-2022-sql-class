using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Define Connection Details
        //private string dbName = "JP_traffic_cop";
        //private string dbUser = "JP_traffic_cop";
        //private string dbPassword = "Password1";
        //private int dbPort = 3306;
        //private string dbServer = "localhost";

        //// Connection String and MySQL Connection
        //private string dbConnectionString = "";
        //private MySqlConnection conn;
        MySQLDATAService service = new MySQLDATAService();
        public MainWindow()
        {
            InitializeComponent();
            //dbConnectionString = $"server={dbServer}; user={dbUser}; database={dbName}; port={dbPort}; password={dbPassword};";
            //conn = new MySqlConnection(dbConnectionString);
            //service.UpdatePeople("Matt", 2);
        }

        private void FillButton_Click(object sender, RoutedEventArgs e)
        {
            //string sqlQuery = "SELECT * FROM traffic;";

            //try
            //{

            //    vehicleListbox.Items.Clear();
            //    List<Traffic> trafficlist = new List<Traffic>();             
            //    conn.Open();
            //    MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            //    MySqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        //vehicleListbox.Items.Add($"{rdr[1]} : {rdr[2], 10}kph");
            //        //traffic.Add(new Traffic(int.Parse(rdr[0].ToString()), rdr[1].ToString(), int.Parse(rdr[2].ToString()), int.Parse(rdr[3].ToString())));
            //        int id = Convert.ToInt32(rdr["id"]);
            //        string plate = rdr["number_plate"].ToString();
            //        int speed = Convert.ToInt32(rdr["speed"]);
            //        int limit = Convert.ToInt32(rdr["speed_limit"]);
            //        Traffic traffic = new Traffic(id, plate, speed, limit);
            //        trafficlist.Add(traffic);
            //    }
            //    vehicleListbox.ItemsSource = trafficlist;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

            //conn.Close();
            int id = Convert.ToInt32(searchTextbox.Text);

            //vehicleListbox.ItemsSource = service.GetPeople();
            vehicleListbox.Items.Add(service.GetTraffic(id));
            //vehicleListbox.ItemsSource = service.GetTraffic(id); // service.GetTraffic();
        }


    }
}
